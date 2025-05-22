using System;
using System.Collections.Generic;
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
            
            self.ES_RoleQiangHuaItem_1.SetClickHandler(self.OnBtn_EquipHandler);
            self.QiangHuaItemList.Add(self.ES_RoleQiangHuaItem_1);
            self.ES_RoleQiangHuaItem_2.SetClickHandler(self.OnBtn_EquipHandler);
            self.QiangHuaItemList.Add(self.ES_RoleQiangHuaItem_2);
            self.ES_RoleQiangHuaItem_3.SetClickHandler(self.OnBtn_EquipHandler);
            self.QiangHuaItemList.Add(self.ES_RoleQiangHuaItem_3);
            self.ES_RoleQiangHuaItem_4.SetClickHandler(self.OnBtn_EquipHandler);
            self.QiangHuaItemList.Add(self.ES_RoleQiangHuaItem_4);
            self.ES_RoleQiangHuaItem_5.SetClickHandler(self.OnBtn_EquipHandler);
            self.QiangHuaItemList.Add(self.ES_RoleQiangHuaItem_5);
            self.ES_RoleQiangHuaItem_6.SetClickHandler(self.OnBtn_EquipHandler);
            self.QiangHuaItemList.Add(self.ES_RoleQiangHuaItem_6);
            self.ES_RoleQiangHuaItem_7.SetClickHandler(self.OnBtn_EquipHandler);
            self.QiangHuaItemList.Add(self.ES_RoleQiangHuaItem_7);
            self.ES_RoleQiangHuaItem_8.SetClickHandler(self.OnBtn_EquipHandler);
            self.QiangHuaItemList.Add(self.ES_RoleQiangHuaItem_8);
            self.ES_RoleQiangHuaItem_9.SetClickHandler(self.OnBtn_EquipHandler);
            self.QiangHuaItemList.Add(self.ES_RoleQiangHuaItem_9);
            self.ES_RoleQiangHuaItem_10.SetClickHandler(self.OnBtn_EquipHandler);
            self.QiangHuaItemList.Add(self.ES_RoleQiangHuaItem_10);
            self.ES_RoleQiangHuaItem_11.SetClickHandler(self.OnBtn_EquipHandler);
            self.QiangHuaItemList.Add(self.ES_RoleQiangHuaItem_11);
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleQiangHua self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this ES_RoleQiangHua self)
        {
            self.ES_RoleQiangHuaItem_1.OnInitUI(1);
            self.ES_RoleQiangHuaItem_2.OnInitUI(2);
            self.ES_RoleQiangHuaItem_3.OnInitUI(3);
            self.ES_RoleQiangHuaItem_4.OnInitUI(4);
            self.ES_RoleQiangHuaItem_5.OnInitUI(5);
            self.ES_RoleQiangHuaItem_6.OnInitUI(6);
            self.ES_RoleQiangHuaItem_7.OnInitUI(7);
            self.ES_RoleQiangHuaItem_8.OnInitUI(8);
            self.ES_RoleQiangHuaItem_9.OnInitUI(9);
            self.ES_RoleQiangHuaItem_10.OnInitUI(10);
            self.ES_RoleQiangHuaItem_11.OnInitUI(11);
            
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            for (int i = 0; i < self.QiangHuaItemList.Count; i++)
            {
                ES_RoleQiangHuaItem esRoleQiangHuaItem = self.QiangHuaItemList[i];
                esRoleQiangHuaItem.OnUpateUI(bagComponent.QiangHuaLevel[i + 1]);
            }

            ES_RoleQiangHuaItem item = self.QiangHuaItemList[0];
            item.OnEquipButton();
        }

        public static void OnBtn_EquipHandler(this ES_RoleQiangHua self, int index)
        {
            self.ItemSubType = index;
            self.OnUpdateQiangHuaUI(index);
        }

        public static void OnUpdateQiangHuaUI(this ES_RoleQiangHua self, int subType)
        {
            self.ES_EquipSetItem.InitUI(subType);

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            int qianghuaLevel = bagComponent.QiangHuaLevel[subType];
            int maxLevel = QiangHuaHelper.GetQiangHuaMaxLevel(subType);
            ItemInfo bagInfo = bagComponent.GetEquipBySubType(ItemLocType.ItemLocEquip, subType);
            self.ES_EquipSetItem.UpdateData(bagInfo, 0, ItemOperateEnum.None, new List<ItemInfo>());
            self.E_QiangItemNameText.text = bagInfo != null ? ItemConfigCategory.Instance.Get(bagInfo.ItemID).ItemName : String.Empty;
            self.EG_MaxNodeRectTransform.gameObject.SetActive(qianghuaLevel >= maxLevel - 1);
            self.EG_NextNodeRectTransform.gameObject.SetActive(!self.EG_MaxNodeRectTransform.gameObject.activeSelf);

            ES_RoleQiangHuaItem esRoleQiangHuaItem = self.QiangHuaItemList[subType - 1];
            CommonViewHelper.SetParent(self.E_ImageSelectImage.gameObject, esRoleQiangHuaItem.uiTransform.gameObject);
            self.E_ImageSelectImage.transform.localPosition = new Vector3(1f, -2f, 0f);
            string qianghuaName = ItemViewData.EquipWeiZhiToName[subType].Name;
            using (zstring.Block())
            {
                self.E_QiangHuaNameText.text = zstring.Format("{0}共鸣 +{1}", qianghuaName, qianghuaLevel);
                self.E_QiangHuaLevelText.text = zstring.Format("{0}级", qianghuaLevel);
            }

            EquipQiangHuaConfig equipQiangHuaConfig = QiangHuaHelper.GetQiangHuaConfig(subType, qianghuaLevel);

            float fvalue = float.Parse(equipQiangHuaConfig.EquipPropreAdd) * 100f;
            string svalue = fvalue.ToString("0.#####");
            using (zstring.Block())
            {
                self.E_Attribute1Text.text = zstring.Format("对应部位提升 {0}%属性", svalue);
                self.ES_EquipSetItem.E_QiangHuaLvText.text = zstring.Format("+{0}", qianghuaLevel);
            }

            self.E_QiangHuaNameText.text = ItemViewData.EquipWeiZhiToName[subType].Name;
            esRoleQiangHuaItem.OnUpateUI(qianghuaLevel);

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
            using (zstring.Block())
            {
                self.E_Attribute2Text.text = zstring.Format("对应部位提升 {0}%属性", svalue);

                string costItems = equipQiangHuaConfig.CostItem;
                costItems += zstring.Format("@{0};1", ConfigData.QiangHuaLuckyCostId);
                self.ES_CostList.Refresh(costItems);

                self.E_SuccessRateText.text = zstring.Format("共鸣成功率: {0}%", (int)(equipQiangHuaConfig.SuccessPro * 100));
                double addPro = QiangHuaHelper.GetQiangHuaConfig(subType, qianghuaLevel).AdditionPro * bagComponent.QiangHuaFails[subType];
                self.E_SuccessAdditionText.text = zstring.Format("附加成功率 {0}%", (int)(addPro * 100));
            }

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
            using (zstring.Block())
            {
                costItems += zstring.Format("@1;{0}", equipQiangHuaConfig.CostGold);

                if (self.E_ToggleLuckyToggle.isOn)
                {
                    costItems += zstring.Format("@{0};1", ConfigData.QiangHuaLuckyCostId);
                }
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
