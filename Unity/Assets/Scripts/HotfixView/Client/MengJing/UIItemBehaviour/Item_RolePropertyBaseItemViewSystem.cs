using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(UserInfoComponentC))]
    [EntitySystemOf(typeof(Scroll_Item_RolePropertyBaseItem))]
    public static partial class Scroll_Item_RolePropertyBaseItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_RolePropertyBaseItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_RolePropertyBaseItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_RolePropertyBaseItem self, ShowPropertyList showPropertyList)
        {
            self.E_ProTypeValueText.gameObject.SetActive(true);
            self.E_ProTypeValueRightText.gameObject.SetActive(false);
            
            NumericComponentC numericComponentC = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>();
            UserInfoComponentC userInfoComponentC = self.Root().GetComponent<UserInfoComponentC>();

            //获取强化技能属性,用于显示
            long Power_value_add = 0;
            long Intellect_value_add = 0;
            long Agility_value_add = 0;
            long Stamina_value_add = 0;
            long Constitution_value_add = 0;

            // SkillSetComponent skillSetComponent = self.ZoneScene().GetComponent<SkillSetComponent>();
            // List<PropertyValue> skillProList_8 = skillSetComponent.GetSkillRoleProLists_8();
            // for (int i = 0; i < skillProList_8.Count; i++)
            // {
            //     switch (skillProList_8[i].HideID)
            //     {
            //         case NumericType.Base_Power_Add:
            //             Power_value_add += skillProList_8[i].HideValue;
            //             break;
            //         case NumericType.Base_Intellect_Add:
            //             Intellect_value_add += skillProList_8[i].HideValue;
            //             break;
            //         case NumericType.Base_Agility_Add:
            //             Agility_value_add += skillProList_8[i].HideValue;
            //             break;
            //         case NumericType.Base_Stamina_Add:
            //             Stamina_value_add += skillProList_8[i].HideValue;
            //             break;
            //         case NumericType.Base_Constitution_Add:
            //             Constitution_value_add += skillProList_8[i].HideValue;
            //             break;
            //         default:
            //             break;
            //     }
            // }

            self.E_PropertyTypeText.text = showPropertyList.Name;
            if (showPropertyList.NumericType == NumericType.Now_Speed)
            {
                self.E_ProTypeValueText.text = numericComponentC.GetAsFloat(showPropertyList.NumericType).ToString();
            }
            else
            {
                if (showPropertyList.NumericType == NumericType.Now_MaxAct)
                {
                    using (zstring.Block())
                    {
                        self.E_ProTypeValueText.text = zstring.Format("{0}-{1}", numericComponentC.GetAsLong(NumericType.Now_MinAct),
                            numericComponentC.GetAsLong(NumericType.Now_MaxAct));
                    }
                }
                else if (showPropertyList.NumericType == NumericType.Now_MaxDef)
                {
                    using (zstring.Block())
                    {
                        self.E_ProTypeValueText.text = zstring.Format("{0}-{1}", numericComponentC.GetAsLong(NumericType.Now_MinDef),
                            numericComponentC.GetAsLong(NumericType.Now_MaxDef));
                    }
                }
                else if (showPropertyList.NumericType == NumericType.Now_MaxAdf)
                {
                    using (zstring.Block())
                    {
                        self.E_ProTypeValueText.text = zstring.Format("{0}-{1}", numericComponentC.GetAsLong(NumericType.Now_MinAdf),
                            numericComponentC.GetAsLong(NumericType.Now_MaxAdf));
                    }
                }
                else if (showPropertyList.NumericType == NumericType.Now_Mage)
                {
                    self.E_ProTypeValueText.gameObject.SetActive(false);
                    self.E_ProTypeValueRightText.text = numericComponentC.GetAsLong(showPropertyList.NumericType).ToString();
                    self.E_ProTypeValueRightText.gameObject.SetActive(true);
                }
                else if (showPropertyList.NumericType == NumericType.Now_Power)
                {
                    self.E_ProTypeValueText.text = (numericComponentC.GetAsLong(showPropertyList.NumericType) +
                                numericComponentC.GetAsLong(NumericType.PointLiLiang) + Power_value_add +
                                userInfoComponentC.UserInfo.Lv * 2)
                            .ToString();
                }
                else if (showPropertyList.NumericType == NumericType.Now_Agility)
                {
                    self.E_ProTypeValueText.text = (numericComponentC.GetAsLong(showPropertyList.NumericType) +
                                numericComponentC.GetAsLong(NumericType.PointMinJie) + Agility_value_add +
                                userInfoComponentC.UserInfo.Lv * 2)
                            .ToString();
                }
                else if (showPropertyList.NumericType == NumericType.Now_Intellect)
                {
                    self.E_ProTypeValueText.text = (numericComponentC.GetAsLong(showPropertyList.NumericType) +
                                numericComponentC.GetAsLong(NumericType.PointZhiLi) + Intellect_value_add +
                                userInfoComponentC.UserInfo.Lv * 2)
                            .ToString();
                }
                else if (showPropertyList.NumericType == NumericType.Now_Stamina)
                {
                    self.E_ProTypeValueText.text = (numericComponentC.GetAsLong(showPropertyList.NumericType) +
                                numericComponentC.GetAsLong(NumericType.PointNaiLi) + Stamina_value_add +
                                userInfoComponentC.UserInfo.Lv * 2)
                            .ToString();
                }
                else if (showPropertyList.NumericType == NumericType.Now_Constitution)
                {
                    self.E_ProTypeValueText.text = (numericComponentC.GetAsLong(showPropertyList.NumericType) +
                                numericComponentC.GetAsLong(NumericType.PointTiZhi) + Constitution_value_add +
                                userInfoComponentC.UserInfo.Lv * 2)
                            .ToString();
                }
                else
                {
                    self.E_ProTypeValueText.text = numericComponentC.GetAsLong(showPropertyList.NumericType).ToString();
                }
            }

            //显示图标
            if (!string.IsNullOrEmpty(showPropertyList.IconID))
            {
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PropertyIcon, showPropertyList.IconID);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                self.E_IconImage.sprite = sp;
            }
        }
    }
}