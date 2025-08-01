using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(ES_UnionXiuLianItem))]
    [EntitySystemOf(typeof(ES_UnionRoleXiuLian))]
    [FriendOfAttribute(typeof(ES_UnionRoleXiuLian))]
    public static partial class ES_UnionRoleXiuLianSystem
    {
        [EntitySystem]
        private static void Awake(this ES_UnionRoleXiuLian self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Button_DonationButton.AddListenerAsync(self.OnButton_DonationButton);

            self.ES_UnionXiuLianItem_0.Position = 0;
            self.ES_UnionXiuLianItem_0.ClickHandler = self.OnClickHandler;
            self.UIUnionXiuLianItemList.Add(self.ES_UnionXiuLianItem_0);

            self.ES_UnionXiuLianItem_1.Position = 1;
            self.ES_UnionXiuLianItem_1.ClickHandler = self.OnClickHandler;
            self.UIUnionXiuLianItemList.Add(self.ES_UnionXiuLianItem_1);

            self.ES_UnionXiuLianItem_2.Position = 2;
            self.ES_UnionXiuLianItem_2.ClickHandler = self.OnClickHandler;
            self.UIUnionXiuLianItemList.Add(self.ES_UnionXiuLianItem_2);

            self.ES_UnionXiuLianItem_3.Position = 3;
            self.ES_UnionXiuLianItem_3.ClickHandler = self.OnClickHandler;
            self.UIUnionXiuLianItemList.Add(self.ES_UnionXiuLianItem_3);

            ES_UnionXiuLianItem esUnionXiuLianItem = self.UIUnionXiuLianItemList[0];
            esUnionXiuLianItem.ClickHandler?.Invoke(0);
        }

        [EntitySystem]
        private static void Destroy(this ES_UnionRoleXiuLian self)
        {
            self.DestroyWidget();
        }

        public static void OnClickHandler(this ES_UnionRoleXiuLian self, int position)
        {
            self.Position = position;
            for (int i = 0; i < self.UIUnionXiuLianItemList.Count; i++)
            {
                ES_UnionXiuLianItem esUnionXiuLianItem = self.UIUnionXiuLianItemList[i];
                esUnionXiuLianItem.E_ImageSelectImage.gameObject.SetActive(position == i);
            }

            for (int i = 0; i < self.EG_XiuLianImageIconRectTransform.childCount; i++)
            {
                self.EG_XiuLianImageIconRectTransform.GetChild(i).gameObject.SetActive(position == i);
            }

            self.OnUpdateUI();
        }

        public static void OnUpdateUI(this ES_UnionRoleXiuLian self)
        {
            for (int i = 0; i < self.UIUnionXiuLianItemList.Count; i++)
            {
                ES_UnionXiuLianItem esUnionXiuLianItem = self.UIUnionXiuLianItemList[i];
                esUnionXiuLianItem.OnUpdateUI(i, 0);
            }

            int numerType = ET.UnionHelper.GetXiuLianId(self.Position, 0);

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            int xiulianid = numericComponent.GetAsInt(numerType);
            UnionQiangHuaConfig unionQiangHuaConfig = UnionQiangHuaConfigCategory.Instance.Get(xiulianid);
            self.E_XiuLianNameText.text = unionQiangHuaConfig.EquipSpaceName;

            self.EG_Pro_0RectTransform.Find("Text_Tip_Pro_0").GetComponent<Text>().text =
                    ItemViewHelp.GetAttributeDesc(unionQiangHuaConfig.EquipPropreAdd);

            if (unionQiangHuaConfig.NextID == 0)
            {
                self.EG_Pro_1RectTransform.gameObject.SetActive(false);
                return;
            }

            self.EG_Pro_1RectTransform.gameObject.SetActive(true);
            int nextxiulianid = numericComponent.GetAsInt(numerType) + 1;
            UnionQiangHuaConfig nextunionQiangHuaConfig = UnionQiangHuaConfigCategory.Instance.Get(nextxiulianid);
            self.EG_Pro_1RectTransform.Find("Text_Tip_Pro_0").GetComponent<Text>().text =
                    ItemViewHelp.GetAttributeDesc(nextunionQiangHuaConfig.EquipPropreAdd);
            using (zstring.Block())
            {
                self.EG_Pro_1RectTransform.parent.transform.Find("Text_Tip_Pro_1").GetComponent<Text>().text =
                        zstring.Format("消耗:{0}点公会贡献", unionQiangHuaConfig.CostGold);
            }

            if (!CommonHelp.IfNull(unionQiangHuaConfig.CostItem))
            {
                self.ES_CostList.Refresh(unionQiangHuaConfig.CostItem);
            }
        }

        public static async ETTask OnButton_DonationButton(this ES_UnionRoleXiuLian self)
        {
            //公会等级
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            U2C_UnionMyInfoResponse respose = await UnionNetHelper.UnionMyInfo(self.Root());
            if (respose.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            int unitonlevel = respose.UnionMyInfo.Level;
            UnionConfig unionConfig = UnionConfigCategory.Instance.Get(unitonlevel);
            int numerType = ET.UnionHelper.GetXiuLianId(self.Position, 0);
            int xiulianid = unit.GetComponent<NumericComponentC>().GetAsInt(numerType);
            UnionQiangHuaConfig unionQiangHuaConfig = UnionQiangHuaConfigCategory.Instance.Get(xiulianid);
            if (unionQiangHuaConfig.QiangHuaLv >= unionConfig.XiuLianLevel)
            {
                FlyTipComponent.Instance.ShowFlyTip("请先提升公会等级！");
                return;
            }

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (!bagComponent.CheckNeedItem(unionQiangHuaConfig.CostItem))
            {
                FlyTipComponent.Instance.ShowFlyTip("道具不足！");
                return;
            }

            await UnionNetHelper.UnionXiuLianRequest(self.Root(), self.Position, 0);

            self.OnUpdateUI();
        }
    }
}
