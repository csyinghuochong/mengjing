using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_RoleQiangHuaItem))]
    [FriendOf(typeof(BagComponentC))]
    [EntitySystemOf(typeof(ES_RoleQiangHua))]
    [FriendOfAttribute(typeof(ES_RoleQiangHua))]
    public static partial class ES_RoleQiangHuaSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleQiangHua self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_QiangHuaButton.AddListenerAsync(self.OnQiangHuaButton);

            self.AddQiangHuaItem(self.EG_RoleQiangHuaItem_1RectTransform, 10);
            self.AddQiangHuaItem(self.EG_RoleQiangHuaItem_2RectTransform, 2);
            self.AddQiangHuaItem(self.EG_RoleQiangHuaItem_3RectTransform, 1);
            self.AddQiangHuaItem(self.EG_RoleQiangHuaItem_4RectTransform, 7);
            self.AddQiangHuaItem(self.EG_RoleQiangHuaItem_5RectTransform, 6);
            self.AddQiangHuaItem(self.EG_RoleQiangHuaItem_6RectTransform, 11);
            self.AddQiangHuaItem(self.EG_RoleQiangHuaItem_7RectTransform, 9);
            self.AddQiangHuaItem(self.EG_RoleQiangHuaItem_8RectTransform, 4);
            self.AddQiangHuaItem(self.EG_RoleQiangHuaItem_9RectTransform, 8);
            self.AddQiangHuaItem(self.EG_RoleQiangHuaItem_10RectTransform, 3);
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleQiangHua self)
        {
            self.QiangHuaItemList.Clear();
            self.DestroyWidget();
        }

        private static void AddQiangHuaItem(this ES_RoleQiangHua self, Transform transform, int subType)
        {
            ES_RoleQiangHuaItem item = self.AddChild<ES_RoleQiangHuaItem, Transform>(transform);
            item.ItemSubType = subType;
            item.SetClickHandler(self.OnBtn_EquipHandler);
            self.QiangHuaItemList.Add(item);
        }

        public static void OnUpdateUI(this ES_RoleQiangHua self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            foreach (ES_RoleQiangHuaItem item in self.QiangHuaItemList)
            {
                item.OnUpdateUI(bagComponent.QiangHuaLevel[item.ItemSubType]);
            }

            ES_RoleQiangHuaItem firstItem = self.QiangHuaItemList[0];
            firstItem.OnEquipButton();
        }

        public static void OnBtn_EquipHandler(this ES_RoleQiangHua self, int index)
        {
            self.ItemSubType = index;
            self.OnUpdateQiangHuaUI(index);
        }

        public static void OnUpdateQiangHuaUI(this ES_RoleQiangHua self, int subType)
        {
            ES_RoleQiangHuaItem selectedItem = null;
            foreach (ES_RoleQiangHuaItem item in self.QiangHuaItemList)
            {
                bool isSelected = item.ItemSubType == subType;
                item.Image_SelectImage.gameObject.SetActive(isSelected);
                if (isSelected)
                {
                    selectedItem = item;
                }
            }
            if (selectedItem == null)
            {
                return;
            }

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            int qianghuaLevel = bagComponent.QiangHuaLevel[subType];
            int maxLevel = QiangHuaHelper.GetQiangHuaMaxLevel(subType);
            self.EG_MaxNodeRectTransform.gameObject.SetActive(qianghuaLevel >= maxLevel - 1);
            self.EG_NextNodeRectTransform.gameObject.SetActive(!self.EG_MaxNodeRectTransform.gameObject.activeSelf);

            self.E_EquipIconImage.sprite = selectedItem.Image_EquipIconImage.sprite;
            self.E_QiangHuaNameText.text = ItemViewData.ItemSubType3Name[subType];
            self.E_QiangHuaLvText.text = $"+{qianghuaLevel}";
            self.E_QiangHuaLevelText.text = string.Format("{0}级", qianghuaLevel);
            selectedItem.OnUpdateUI(qianghuaLevel);

            EquipQiangHuaConfig equipQiangHuaConfig = QiangHuaHelper.GetQiangHuaConfig(subType, qianghuaLevel);

            float fvalue = float.Parse(equipQiangHuaConfig.EquipPropreAdd) * 100f;
            string svalue = fvalue.ToString("0.#####");
            self.E_Attribute1Text.text = string.Format("对应部位提升 {0}%属性", svalue);

            for (int i = 0; i < self.EG_QiangHuaLevelListRectTransform.transform.childCount; i++)
            {
                self.EG_QiangHuaLevelListRectTransform.transform.GetChild(i).gameObject.SetActive(i < qianghuaLevel);
            }

            if (qianghuaLevel >= maxLevel - 1)
            {
                return;
            }

            EquipQiangHuaConfig next_equipQiangHuaConfig = QiangHuaHelper.GetQiangHuaConfig(subType, qianghuaLevel + 1);
            fvalue = float.Parse(next_equipQiangHuaConfig.EquipPropreAdd) * 100f;
            svalue = fvalue.ToString("0.#####");
            self.E_Attribute2Text.text = string.Format("对应部位提升 {0}%属性", svalue);

            string costItems = equipQiangHuaConfig.CostItem;
            costItems += string.Format("@{0};1", ConfigData.QiangHuaLuckyCostId);
            self.ES_CostList.Refresh(costItems);

            self.E_SuccessRateText.text = string.Format("共鸣成功率: {0}%", (int)(equipQiangHuaConfig.SuccessPro * 100));
            double addPro = QiangHuaHelper.GetQiangHuaConfig(subType, qianghuaLevel).AdditionPro * bagComponent.QiangHuaFails[subType];
            self.E_SuccessAdditionText.text = string.Format("附加成功率 {0}%", (int)(addPro * 100));

            self.E_Img_LodingValueImage.fillAmount = (qianghuaLevel * 1f / maxLevel);
            self.E_QiangHuaProgressText.text = $"{qianghuaLevel}/{maxLevel}";
            self.E_TextGoldText.text = equipQiangHuaConfig.CostGold.ToString();

            // if (bagComponent.GetItemNumber(1) < equipQiangHuaConfig.CostGold)
            // {
            //     self.E_TextGold.color =  Color.red;
            // }
            // else
            // {
            //     self.E_TextGold.color = Color.white;
            // }
        }

        public static async ETTask OnQiangHuaButton(this ES_RoleQiangHua self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            int qianghuaLevel = bagComponent.QiangHuaLevel[self.ItemSubType];
            int maxLevel = QiangHuaHelper.GetQiangHuaMaxLevel(self.ItemSubType);
            if (qianghuaLevel >= maxLevel - 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("已经强化到最大等级！");
                return;
            }

            EquipQiangHuaConfig equipQiangHuaConfig = QiangHuaHelper.GetQiangHuaConfig(self.ItemSubType, qianghuaLevel);
            string costItems = equipQiangHuaConfig.CostItem;
            costItems += string.Format("@1;{0}", equipQiangHuaConfig.CostGold);

            if (self.E_ToggleLuckyToggle.isOn)
            {
                costItems += string.Format("@{0};1", ConfigData.QiangHuaLuckyCostId);
            }

            if (!bagComponent.CheckNeedItem(costItems))
            {
                FlyTipComponent.Instance.ShowFlyTip("道具不足！");
                return;
            }

            (int, int) respons = await BagClientNetHelper.RequestItemQiangHua(self.Root(), self.ItemSubType, self.E_ToggleLuckyToggle.isOn);
            if (respons.Item1 != ErrorCode.ERR_Success)
            {
                return;
            }

            if (bagComponent.QiangHuaLevel[self.ItemSubType] == respons.Item2)
            {
                bagComponent.QiangHuaFails[self.ItemSubType]++;
                FlyTipComponent.Instance.ShowFlyTip("强化失败！");
            }
            else
            {
                bagComponent.QiangHuaLevel[self.ItemSubType] = respons.Item2;
                bagComponent.QiangHuaFails[self.ItemSubType] = 0;
            }

            self.OnUpdateQiangHuaUI(self.ItemSubType);
        }
    }
}
