using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_UnionBloodStone))]
    [FriendOfAttribute(typeof(ES_UnionBloodStone))]
    public static partial class ES_UnionBloodStoneSystem
    {
        [EntitySystem]
        private static void Awake(this ES_UnionBloodStone self, Transform transform)
        {
            self.uiTransform = transform;
            
            self.E_UpBtnButton.AddListenerAsync(self.OnUpBtn);
            self.UpdateInfo();
        }

        [EntitySystem]
        private static void Destroy(this ES_UnionBloodStone self)
        {
            self.DestroyWidget();
        }

        public static void UpdateInfo(this ES_UnionBloodStone self)
        {
            NumericComponentC numericComponent = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>();
            PublicQiangHuaConfig publicQiangHuaConfig = PublicQiangHuaConfigCategory.Instance.Get(numericComponent.GetAsInt(NumericType.Bloodstone));

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, publicQiangHuaConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            CommonViewHelper.SetImageGray(self.Root(), self.E_IconLImgImage.gameObject, publicQiangHuaConfig.QiangHuaLv == 0);
            CommonViewHelper.SetImageGray(self.Root(), self.E_IconRImgImage.gameObject, publicQiangHuaConfig.QiangHuaLv == 0);

            self.E_IconLImgImage.sprite = sp;
            self.E_IconRImgImage.sprite = sp;

            self.E_NameLTextText.text = publicQiangHuaConfig.EquipSpaceName;
            self.E_NameRTextText.text = publicQiangHuaConfig.EquipSpaceName;
            if (publicQiangHuaConfig.QiangHuaLv != 0)
            {
                self.E_PropertyTextText.text = ItemViewHelp.GetAttributeDesc(publicQiangHuaConfig.EquipPropreAdd);
            }
            else
            {
                self.E_PropertyTextText.text = "下一级:\n" +
                        ItemViewHelp.GetAttributeDesc(PublicQiangHuaConfigCategory.Instance.Get(publicQiangHuaConfig.NextID).EquipPropreAdd);
            }

            self.ES_CostList.Refresh($"1;{publicQiangHuaConfig.CostGold}@" + publicQiangHuaConfig.CostItem);
        }

        public static async ETTask OnUpBtn(this ES_UnionBloodStone self)
        {
            NumericComponentC numericComponent = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>();
            PublicQiangHuaConfig publicQiangHuaConfig = PublicQiangHuaConfigCategory.Instance.Get(numericComponent.GetAsInt(NumericType.Bloodstone));

            if (publicQiangHuaConfig.NextID == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("已经达到最高级");
                return;
            }

            if (self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv < publicQiangHuaConfig.UpLvLimit)
            {
                FlyTipComponent.Instance.ShowFlyTip($"玩家等级不足，{publicQiangHuaConfig.UpLvLimit}开启");
                return;
            }

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (!bagComponent.CheckNeedItem("1;" + publicQiangHuaConfig.CostGold + "@" + publicQiangHuaConfig.CostItem))
            {
                FlyTipComponent.Instance.ShowFlyTip("道具不足！");
                return;
            }

            M2C_BloodstoneQiangHuaResponse response = await UnionNetHelper.BloodstoneQiangHuaRequest(self.Root());

            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            if (response.Level == publicQiangHuaConfig.Id)
            {
                FlyTipComponent.Instance.ShowFlyTip("升级失败");
            }

            self.UpdateInfo();
        }
    }
}