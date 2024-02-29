using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (UserInfoComponentClient))]
    [EntitySystemOf(typeof (Scroll_Item_RolePropertyTeShuItem))]
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

        public static void Refresh(this Scroll_Item_RolePropertyTeShuItem self, ShowPropertyList showPropertyList)
        {
            NumericComponentClient numericComponentClient = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentClient>();
            UserInfoComponentClient userInfoComponentClient = self.Root().GetComponent<UserInfoComponentClient>();

            self.E_PropertyTypeText.text = showPropertyList.Name;

            //整数
            if (showPropertyList.Type == 1)
            {
                self.E_ProTypeValueText.text = numericComponentClient.GetAsLong(showPropertyList.NumericType).ToString();
            }

            //浮点数
            if (showPropertyList.Type == 2)
            {
                float value = numericComponentClient.GetAsFloat(showPropertyList.NumericType) * 100.0f;

                if (showPropertyList.NumericType == NumericType.Now_Cri)
                {
                    value += ComHelp.LvProChange(numericComponentClient.GetAsLong(NumericType.Now_CriLv), userInfoComponentClient.UserInfo.Lv) * 100f;
                }

                if (showPropertyList.NumericType == NumericType.Now_Res)
                {
                    value += ComHelp.LvProChange(numericComponentClient.GetAsLong(NumericType.Now_ResLv), userInfoComponentClient.UserInfo.Lv) * 100f;
                    value += ComHelp.LvProChange(numericComponentClient.GetAsLong(NumericType.PointNaiLi) * 4, userInfoComponentClient.UserInfo.Lv) *
                            100f;
                }

                if (showPropertyList.NumericType == NumericType.Now_Hit)
                {
                    value += ComHelp.LvProChange(numericComponentClient.GetAsLong(NumericType.Now_HitLv), userInfoComponentClient.UserInfo.Lv) * 100f;
                }

                if (showPropertyList.NumericType == NumericType.Now_Dodge)
                {
                    value += ComHelp.LvProChange(numericComponentClient.GetAsLong(NumericType.Now_DodgeLv), userInfoComponentClient.UserInfo.Lv) *
                            100f;
                    value += ComHelp.LvProChange(numericComponentClient.GetAsLong(NumericType.PointTiZhi) * 2, userInfoComponentClient.UserInfo.Lv) *
                            100f;
                }

                if (showPropertyList.NumericType == NumericType.Now_ZhongJiPro)
                {
                    value += ComHelp.LvProChange(numericComponentClient.GetAsLong(NumericType.Now_ZhongJiLv), userInfoComponentClient.UserInfo.Lv) *
                            100f;
                }

                if (showPropertyList.NumericType == NumericType.Now_MageDamgeAddPro)
                {
                    value += ComHelp.LvProChange(numericComponentClient.GetAsLong(NumericType.PointZhiLi) * 5, userInfoComponentClient.UserInfo.Lv) *
                            100f;
                }

                if (showPropertyList.NumericType == NumericType.Now_ActSpeedPro)
                {
                    value += ComHelp.LvProChange(
                        numericComponentClient.GetAsLong(NumericType.PointMinJie) * 2 +
                        numericComponentClient.GetAsLong(NumericType.PointLiLiang) * 2,
                        userInfoComponentClient.UserInfo.Lv) * 100f;
                }

                //冷却时间显示
                if (showPropertyList.NumericType == NumericType.Now_SkillCDTimeCostPro)
                {
                    //value += ComHelp.LvProChange(numericComponent.GetAsLong(NumericType.Now_SkillCDTimeCostPro), self.UserInfoComponent.UserInfo.Lv) * 100f;
                }

                if (value.ToString().Contains("."))
                {
                    self.E_ProTypeValueText.text = value.ToString("F2") + "%";
                }
                else
                {
                    self.E_ProTypeValueText.text = value.ToString() + "%";
                }
            }
        }
    }
}