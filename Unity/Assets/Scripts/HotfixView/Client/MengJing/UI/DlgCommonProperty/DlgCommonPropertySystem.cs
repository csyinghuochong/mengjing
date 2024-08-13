using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgCommonProperty))]
    public static class DlgCommonPropertySystem
    {
        public static void RegisterUIEvent(this DlgCommonProperty self)
        {
            self.View.E_ImageButtonButton.AddListener(self.OnImageButtonButton);
        }

        public static void ShowWindow(this DlgCommonProperty self, Entity contextData = null)
        {
            self.View.EG_PropertyListSetRectTransform.gameObject.SetActive(false);
            self.InitShowPropertyList();
        }

        public static void OnImageButtonButton(this DlgCommonProperty self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CommonProperty);
        }

        public static void ShowSkillList(this DlgCommonProperty self, Unit unit)
        {
            if (unit.Type != UnitType.Monster)
            {
                return;
            }

            List<int> skillids = new List<int>();

            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unit.ConfigId);

            skillids.Add(monsterConfig.ActSkillID);
            if (monsterConfig.SkillID != null)
            {
                for (int i = 0; i < monsterConfig.SkillID.Length; i++)
                {
                    skillids.Add(monsterConfig.SkillID[i]);
                }
            }

            // for (int i = 0; i < skillids.Count; i++)
            // {
            //     if (skillids[i] == 0)
            //     {
            //         continue;
            //     }
            //
            //     SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillids[i]);
            //     if (CommonHelp.IfNull(skillConfig.SkillIcon))
            //     {
            //         return;
            //     }
            //
            //     GameObject skillItem = GameObject.Instantiate(bundleGameObject);
            //     UICommonHelper.SetParent(skillItem, self.SkillListNode);
            //     skillItem.SetActive(true);
            //     skillItem.transform.localScale = Vector3.one * 1f;
            //
            //     UICommonSkillItemComponent ui_item = self.AddChild<UICommonSkillItemComponent, GameObject>(skillItem);
            //     ui_item.OnUpdateUI(skillids[i]);
            // }
        }

        public static async ETTask InitPropertyShow(this DlgCommonProperty self, Unit unit)
        {
            M2C_UnitInfoResponse response = await UserInfoNetHelper.UnitInfoRequest(self.Root(), unit.Id);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            if (self.IsDisposed)
            {
                return;
            }

            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            for (int i = 0; i < response.Ks.Count; ++i)
            {
                numericComponent.Set(response.Ks[i], response.Vs[i]);
            }

            self.ShowSkillList(unit);
            self.View.E_NameTextText.text = MonsterConfigCategory.Instance.Get(unit.ConfigId).MonsterName;
            self.View.E_LvTextText.text = $"当前等级：{numericComponent.GetAsInt(NumericType.Now_Lv).ToString()}";

            for (int i = 0; i < self.ShowPropertyList.Count; i++)
            {
                GameObject go = UnityEngine.Object.Instantiate(self.View.EG_PropertyListSetRectTransform.gameObject,
                    self.View.EG_ProItemSetRectTransform, true);
                go.transform.localScale = new Vector3(1, 1, 1);
                go.transform.localPosition = new Vector3(0, 0, 0);
                go.SetActive(true);

                ShowPropertyList showList = self.ShowPropertyList[i];
                ReferenceCollector rc = go.GetComponent<ReferenceCollector>();

                rc.Get<GameObject>("Lab_PropertyType").GetComponent<Text>().text = showList.Name;

                if (self.ShowPropertyList[i].Type == 1)
                {
                    rc.Get<GameObject>("Lab_ProTypeValue").GetComponent<Text>().text = showList.NumericType == NumericType.Now_Speed
                            ? numericComponent.GetAsFloat(showList.NumericType).ToString()
                            : numericComponent.GetAsLong(showList.NumericType).ToString();
                    //显示图标
                    if (!string.IsNullOrEmpty(showList.IconID))
                    {
                        string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PropertyIcon, showList.IconID);
                        Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                        rc.Get<GameObject>("Img_Icon").GetComponent<Image>().sprite = sp;
                        rc.Get<GameObject>("Img_Icon").SetActive(true);
                    }
                }
                else
                {
                    float value = numericComponent.GetAsFloat(showList.NumericType) * 100.0f;
                    if (value.ToString().Contains("."))
                    {
                        using (zstring.Block())
                        {
                            rc.Get<GameObject>("Lab_ProTypeValue").GetComponent<Text>().text = zstring.Format("{0}%", value.ToString("F2"));
                        }
                    }
                    else
                    {
                        using (zstring.Block())
                        {
                            rc.Get<GameObject>("Lab_ProTypeValue").GetComponent<Text>().text = zstring.Format("{0}%", value.ToString());
                        }
                    }
                }
            }
        }

        public static void InitShowPropertyList(this DlgCommonProperty self)
        {
            self.ShowPropertyList.Add(AddShowProperList(NumericType.Now_MaxHp, "生命", "Pro_4", 1));
            self.ShowPropertyList.Add(AddShowProperList(NumericType.Now_MaxAct, "攻击", "Pro_5", 1));
            self.ShowPropertyList.Add(AddShowProperList(NumericType.Now_MaxDef, "防御", "Pro_3", 1));
            self.ShowPropertyList.Add(AddShowProperList(NumericType.Now_MaxAdf, "魔御", "Pro_9", 1));
            self.ShowPropertyList.Add(AddShowProperList(NumericType.Now_Hit, "命中概率", "", 2));
            self.ShowPropertyList.Add(AddShowProperList(NumericType.Now_Dodge, "闪避概率", "", 2));
            self.ShowPropertyList.Add(AddShowProperList(NumericType.Now_Cri, "暴击概率", "", 2));
            self.ShowPropertyList.Add(AddShowProperList(NumericType.Now_Res, "韧性概率", "", 2));
            self.ShowPropertyList.Add(AddShowProperList(NumericType.Now_Speed, "移动速度", "", 2));
        }

        public static ShowPropertyList AddShowProperList(int numericType, string name, string iconID, int type)
        {
            ShowPropertyList showList = new ShowPropertyList();
            showList.NumericType = numericType;
            showList.Name = name;
            showList.IconID = iconID;
            showList.Type = type;
            return showList;
        }
    }
}