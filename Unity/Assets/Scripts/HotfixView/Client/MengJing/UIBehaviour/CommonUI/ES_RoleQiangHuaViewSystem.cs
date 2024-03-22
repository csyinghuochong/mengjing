using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_RoleQiangHuaItem))]
    [FriendOf(typeof (BagComponentClient))]
    [EntitySystemOf(typeof (ES_RoleQiangHua))]
    [FriendOfAttribute(typeof (ES_RoleQiangHua))]
    public static partial class ES_RoleQiangHuaSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleQiangHua self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_QiangHuaButton.AddListenerAsync(self.OnButtonQiangHua);

            self.ES_RoleQiangHuaItem_1.OnInitUI(1);
            self.ES_RoleQiangHuaItem_1.SetClickHandler(self.OnBtn_EquipHandler);
            self.QiangHuaItemList.Add(self.ES_RoleQiangHuaItem_1);
            self.ES_RoleQiangHuaItem_2.OnInitUI(2);
            self.ES_RoleQiangHuaItem_2.SetClickHandler(self.OnBtn_EquipHandler);
            self.QiangHuaItemList.Add(self.ES_RoleQiangHuaItem_2);
            self.ES_RoleQiangHuaItem_3.OnInitUI(3);
            self.ES_RoleQiangHuaItem_3.SetClickHandler(self.OnBtn_EquipHandler);
            self.QiangHuaItemList.Add(self.ES_RoleQiangHuaItem_3);
            self.ES_RoleQiangHuaItem_4.OnInitUI(4);
            self.ES_RoleQiangHuaItem_4.SetClickHandler(self.OnBtn_EquipHandler);
            self.QiangHuaItemList.Add(self.ES_RoleQiangHuaItem_4);
            self.ES_RoleQiangHuaItem_5.OnInitUI(5);
            self.ES_RoleQiangHuaItem_5.SetClickHandler(self.OnBtn_EquipHandler);
            self.QiangHuaItemList.Add(self.ES_RoleQiangHuaItem_5);
            self.ES_RoleQiangHuaItem_6.OnInitUI(6);
            self.ES_RoleQiangHuaItem_6.SetClickHandler(self.OnBtn_EquipHandler);
            self.QiangHuaItemList.Add(self.ES_RoleQiangHuaItem_6);
            self.ES_RoleQiangHuaItem_7.OnInitUI(7);
            self.ES_RoleQiangHuaItem_7.SetClickHandler(self.OnBtn_EquipHandler);
            self.QiangHuaItemList.Add(self.ES_RoleQiangHuaItem_7);
            self.ES_RoleQiangHuaItem_8.OnInitUI(8);
            self.ES_RoleQiangHuaItem_8.SetClickHandler(self.OnBtn_EquipHandler);
            self.QiangHuaItemList.Add(self.ES_RoleQiangHuaItem_8);
            self.ES_RoleQiangHuaItem_9.OnInitUI(9);
            self.ES_RoleQiangHuaItem_9.SetClickHandler(self.OnBtn_EquipHandler);
            self.QiangHuaItemList.Add(self.ES_RoleQiangHuaItem_9);
            self.ES_RoleQiangHuaItem_10.OnInitUI(10);
            self.ES_RoleQiangHuaItem_10.SetClickHandler(self.OnBtn_EquipHandler);
            self.QiangHuaItemList.Add(self.ES_RoleQiangHuaItem_10);
            self.ES_RoleQiangHuaItem_11.OnInitUI(11);
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
            BagComponentClient bagComponent = self.Root().GetComponent<BagComponentClient>();
            for (int i = 0; i < self.QiangHuaItemList.Count; i++)
            {
                self.QiangHuaItemList[i].OnUpateUI(bagComponent.QiangHuaLevel[i + 1]);
            }

            self.QiangHuaItemList[0].OnBtn_Equip();
        }

        public static void OnBtn_EquipHandler(this ES_RoleQiangHua self, int index)
        {
            self.ItemSubType = index;
            self.OnUpdateQiangHuaUI(index);
        }

        public static void OnUpdateQiangHuaUI(this ES_RoleQiangHua self, int subType)
        {
            self.ES_EquipSetItem.InitUI(subType);

            BagComponentClient bagComponent = self.Root().GetComponent<BagComponentClient>();
            int qianghuaLevel = bagComponent.QiangHuaLevel[subType];
            int maxLevel = QiangHuaHelper.GetQiangHuaMaxLevel(subType);

            self.EG_MaxNodeRectTransform.gameObject.SetActive(qianghuaLevel >= maxLevel - 1);
            self.EG_NextNodeRectTransform.gameObject.SetActive(!self.EG_MaxNodeRectTransform.gameObject.activeSelf);

            UICommonHelper.SetParent(self.E_ImageSelectImage.gameObject, self.QiangHuaItemList[subType - 1].uiTransform.gameObject);
            self.E_ImageSelectImage.transform.localPosition = new Vector3(1f, -2f, 0f);
            string qianghuaName = ItemViewData.EquipWeiZhiToName[subType].Name;
            self.E_QiangHuaNameText.text = $"{qianghuaName}强化 +{qianghuaLevel}";
            EquipQiangHuaConfig equipQiangHuaConfig = QiangHuaHelper.GetQiangHuaConfig(subType, qianghuaLevel);

            float fvalue = float.Parse(equipQiangHuaConfig.EquipPropreAdd) * 100f;
            //string svalue = string.Format("{0:F}", fvalue);
            string svalue = fvalue.ToString("0.#####");
            self.E_Attribute1Text.text = $"对应部位提升 {svalue}%属性";

            self.ES_EquipSetItem.E_QiangHuaLvText.text = $"+{qianghuaLevel}";
            self.E_QiangHuaNameText.text = ItemViewData.EquipWeiZhiToName[subType].Name;
            self.QiangHuaItemList[subType - 1].OnUpateUI(qianghuaLevel);

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
            ; /// string.Format("{0:P}", fvalue);
            self.E_Attribute2Text.text = $"对应部位提升 {svalue}%属性";

            string costItems = equipQiangHuaConfig.CostItem;
            costItems += $"@1;{equipQiangHuaConfig.CostGold}";
            self.ES_CostList.Refresh(costItems);
            
            self.E_SuccessRateText.text = $"强化成功率: {(int)(equipQiangHuaConfig.SuccessPro * 100)}%";
            double addPro = QiangHuaHelper.GetQiangHuaConfig(subType, qianghuaLevel).AdditionPro * bagComponent.QiangHuaFails[subType];
            self.E_SuccessAdditionText.text = $"附加成功率 {(int)(addPro * 100)}%";
        }

        public static async ETTask OnButtonQiangHua(this ES_RoleQiangHua self)
        {
            BagComponentClient bagComponent = self.Root().GetComponent<BagComponentClient>();
            int qianghuaLevel = bagComponent.QiangHuaLevel[self.ItemSubType];
            int maxLevel = QiangHuaHelper.GetQiangHuaMaxLevel(self.ItemSubType);
            if (qianghuaLevel >= maxLevel - 1)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("已经强化到最大等级！");
                return;
            }

            EquipQiangHuaConfig equipQiangHuaConfig = QiangHuaHelper.GetQiangHuaConfig(self.ItemSubType, qianghuaLevel);
            string costItems = equipQiangHuaConfig.CostItem;
            costItems += $"@1;{equipQiangHuaConfig.CostGold}";
            if (!bagComponent.CheckNeedItem(costItems))
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("道具不足！");
                return;
            }

            (int, int) respons = await BagClientNetHelper.RequestItemQiangHua(self.Root(), self.ItemSubType);
            if (respons.Item1 != ErrorCode.ERR_Success)
            {
                return;
            }

            if (bagComponent.QiangHuaLevel[self.ItemSubType] == respons.Item2)
            {
                bagComponent.QiangHuaFails[self.ItemSubType]++;
                FlyTipComponent.Instance.SpawnFlyTipDi("强化失败！");
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
