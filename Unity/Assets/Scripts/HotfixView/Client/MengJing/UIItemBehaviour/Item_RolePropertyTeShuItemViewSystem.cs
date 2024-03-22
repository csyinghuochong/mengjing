using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (UserInfoComponent_C))]
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
            NumericComponent_C numericComponentC = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponent_C>();
            UserInfoComponent_C userInfoComponentC = self.Root().GetComponent<UserInfoComponent_C>();

            self.E_PropertyTypeText.text = showPropertyList.Name;

            //整数
            if (showPropertyList.Type == 1)
            {
                self.E_ProTypeValueText.text = numericComponentC.GetAsLong(showPropertyList.NumericType).ToString();
            }

            //浮点数
            if (showPropertyList.Type == 2)
            {
                float value = numericComponentC.GetAsFloat(showPropertyList.NumericType) * 100.0f;

                if (showPropertyList.NumericType == NumericType.Now_Cri)
                {
                    value += ComHelp.LvProChange(numericComponentC.GetAsLong(NumericType.Now_CriLv), userInfoComponentC.UserInfo.Lv) * 100f;
                }

                if (showPropertyList.NumericType == NumericType.Now_Res)
                {
                    value += ComHelp.LvProChange(numericComponentC.GetAsLong(NumericType.Now_ResLv), userInfoComponentC.UserInfo.Lv) * 100f;
                    value += ComHelp.LvProChange(numericComponentC.GetAsLong(NumericType.PointNaiLi) * 4, userInfoComponentC.UserInfo.Lv) *
                            100f;
                }

                if (showPropertyList.NumericType == NumericType.Now_Hit)
                {
                    value += ComHelp.LvProChange(numericComponentC.GetAsLong(NumericType.Now_HitLv), userInfoComponentC.UserInfo.Lv) * 100f;
                }

                if (showPropertyList.NumericType == NumericType.Now_Dodge)
                {
                    value += ComHelp.LvProChange(numericComponentC.GetAsLong(NumericType.Now_DodgeLv), userInfoComponentC.UserInfo.Lv) *
                            100f;
                    value += ComHelp.LvProChange(numericComponentC.GetAsLong(NumericType.PointTiZhi) * 2, userInfoComponentC.UserInfo.Lv) *
                            100f;
                }

                if (showPropertyList.NumericType == NumericType.Now_ZhongJiPro)
                {
                    value += ComHelp.LvProChange(numericComponentC.GetAsLong(NumericType.Now_ZhongJiLv), userInfoComponentC.UserInfo.Lv) *
                            100f;
                }

                if (showPropertyList.NumericType == NumericType.Now_MageDamgeAddPro)
                {
                    value += ComHelp.LvProChange(numericComponentC.GetAsLong(NumericType.PointZhiLi) * 5, userInfoComponentC.UserInfo.Lv) *
                            100f;
                }

                if (showPropertyList.NumericType == NumericType.Now_ActSpeedPro)
                {
                    value += ComHelp.LvProChange(
                        numericComponentC.GetAsLong(NumericType.PointMinJie) * 2 +
                        numericComponentC.GetAsLong(NumericType.PointLiLiang) * 2,
                        userInfoComponentC.UserInfo.Lv) * 100f;
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