using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(UserInfoComponentC))]
    [EntitySystemOf(typeof(Scroll_Item_RolePropertyTeShuItem))]
    public static partial class Scroll_Item_RolePropertyTeShuItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_RolePropertyTeShuItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_RolePropertyTeShuItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_RolePropertyTeShuItem self, ShowPropertyList showPropertyList, int index)
        {
            NumericComponentC numericComponentC = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>();
            UserInfoComponentC userInfoComponentC = self.Root().GetComponent<UserInfoComponentC>();

            self.E_PropertyTypeText.text = showPropertyList.Name;

            if (!string.IsNullOrEmpty(showPropertyList.IconID))
            {
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PropertyIcon, showPropertyList.IconID);
                self.E_IconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                self.E_IconImage.gameObject.SetActive(true);
            }
            else
            {
                self.E_IconImage.gameObject.SetActive(false);
            }

            //整数
            if (showPropertyList.Type == 1)
            {
                self.E_ProTypeValueText.text = numericComponentC.GetAsLong(showPropertyList.NumericType).ToString();
            }

            self.E_Image_di.gameObject.SetActive(index % 4 ==0);

            //浮点数
            if (showPropertyList.Type == 2)
            {
                float value = numericComponentC.GetAsFloat(showPropertyList.NumericType) * 100.0f;

                if (showPropertyList.NumericType == NumericType.Now_Cri)
                {
                    value += CommonHelp.LvProChange(numericComponentC.GetAsLong(NumericType.Now_CriLv), userInfoComponentC.UserInfo.Lv) * 100f;
                }

                if (showPropertyList.NumericType == NumericType.Now_Res)
                {
                    value += CommonHelp.LvProChange(numericComponentC.GetAsLong(NumericType.Now_ResLv), userInfoComponentC.UserInfo.Lv) * 100f;
                    value += CommonHelp.LvProChange(numericComponentC.GetAsLong(NumericType.PointNaiLi) * 4, userInfoComponentC.UserInfo.Lv) *
                            100f;
                }

                if (showPropertyList.NumericType == NumericType.Now_Hit)
                {
                    value += CommonHelp.LvProChange(numericComponentC.GetAsLong(NumericType.Now_HitLv), userInfoComponentC.UserInfo.Lv) * 100f;
                }

                if (showPropertyList.NumericType == NumericType.Now_Dodge)
                {
                    value += CommonHelp.LvProChange(numericComponentC.GetAsLong(NumericType.Now_DodgeLv), userInfoComponentC.UserInfo.Lv) *
                            100f;
                    value += CommonHelp.LvProChange(numericComponentC.GetAsLong(NumericType.PointTiZhi) * 2, userInfoComponentC.UserInfo.Lv) *
                            100f;
                }

                if (showPropertyList.NumericType == NumericType.Now_ZhongJiPro)
                {
                    value += CommonHelp.LvProChange(numericComponentC.GetAsLong(NumericType.Now_ZhongJiLv), userInfoComponentC.UserInfo.Lv) *
                            100f;
                }

                if (showPropertyList.NumericType == NumericType.Now_MageDamgeAddPro)
                {
                    value += CommonHelp.LvProChange(numericComponentC.GetAsLong(NumericType.PointZhiLi) * 5, userInfoComponentC.UserInfo.Lv) *
                            100f;
                }

                if (showPropertyList.NumericType == NumericType.Now_ActSpeedPro)
                {
                    value += CommonHelp.LvProChange(numericComponentC.GetAsLong(NumericType.PointMinJie) * 2 +
                        numericComponentC.GetAsLong(NumericType.PointLiLiang) * 2,
                        userInfoComponentC.UserInfo.Lv) * 100f;
                }

                //冷却时间显示
                if (showPropertyList.NumericType == NumericType.Now_SkillCDTimeCostPro)
                {
                    //value += ComHelp.LvProChange(numericComponent.GetAsLong(NumericType.Now_SkillCDTimeCostPro), self.UserInfoComponent.UserInfo.Lv) * 100f;
                }

                using (zstring.Block())
                {
                    if (value.ToString().Contains("."))
                    {
                        self.E_ProTypeValueText.text = zstring.Format("{0}%", value.ToString("F2"));
                    }
                    else
                    {
                        self.E_ProTypeValueText.text = zstring.Format("{0}%", value.ToString());
                    }
                }
            }
        }
    }
}