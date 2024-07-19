using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_SkillLearnItem))]
    [EntitySystemOf(typeof(Scroll_Item_SkillLearnItem))]
    public static partial class Scroll_Item_SkillLearnItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_SkillLearnItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_SkillLearnItem self)
        {
            self.DestroyWidget();
        }

        public static void OnButtonUp(this Scroll_Item_SkillLearnItem self)
        {
            self.OnButtonLearn();
        }

        public static void ShowReddot(this Scroll_Item_SkillLearnItem self)
        {
            int skillpoint = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Sp;
            List<int> uplist = self.Root().GetComponent<SkillSetComponentC>().GetCanUpSkill(skillpoint);
            self.EG_ReddotRectTransform.gameObject.SetActive(uplist.Contains(self.SkillPro.SkillID));
        }

        public static void OnButtonLearn(this Scroll_Item_SkillLearnItem self)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;

            SkillConfig skillConfig_base = SkillConfigCategory.Instance.Get(self.SkillPro.SkillID);

            int playerLv = userInfo.Lv;
            if (userInfo.Sp < skillConfig_base.CostSPValue)
            {
                FlyTipComponent.Instance.ShowFlyTip("技能点不足！!");
                return;
            }

            if (playerLv < skillConfig_base.LearnRoseLv)
            {
                FlyTipComponent.Instance.ShowFlyTip("等级不足！!");
                return;
            }

            if (userInfo.Gold < skillConfig_base.CostGoldValue)
            {
                FlyTipComponent.Instance.ShowFlyTip("金币不足！!");
                return;
            }

            if (skillConfig_base.NextSkillID == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("已满级！!");
                return;
            }

            SkillNetHelper.ActiveSkillID(self.Root(), self.SkillPro.SkillID).Coroutine();
        }

        public static void OnUpdateSkillInfo(this Scroll_Item_SkillLearnItem self, int baseskill)
        {
            //表现
            int itemEquipType = UnitHelper.GetEquipType(self.Root());

            //逻辑
            SkillConfig skillConfig_base = SkillConfigCategory.Instance.Get(baseskill);

            string[] skillDesc = Regex.Split(skillConfig_base.SkillDescribe, "\n\n", RegexOptions.IgnoreCase);

            if (skillDesc.Length == 1)
            {
                self.E_Text_DescText.text = skillDesc[0];
            }
            else
            {
                if (itemEquipType == ItemEquipType.Sword || itemEquipType == ItemEquipType.Wand)
                {
                    self.E_Text_DescText.text = skillDesc[0];
                }
                else
                {
                    self.E_Text_DescText.text = skillDesc[1];
                }
            }

            self.E_Text_DescText.text = self.E_Text_DescText.text.Replace("\\n", "\n");

            self.E_ButtonLearnButton.gameObject.SetActive(false);
            self.E_ButtonUpButton.gameObject.SetActive(false);
            self.E_ButtonMaxButton.gameObject.SetActive(false);

            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(self.SkillPro.SkillID);
            if (skillConfig.SkillLv == 0)
            {
                self.E_ButtonLearnButton.gameObject.SetActive(true);
            }
            else
            {
                self.E_ButtonMaxButton.gameObject.SetActive(skillConfig.NextSkillID == 0);
                self.E_ButtonUpButton.gameObject.SetActive(skillConfig.NextSkillID != 0);
            }
        }

        public static void OnSetSelected(this Scroll_Item_SkillLearnItem self, int SkillId)
        {
            self.E_Img_XuanZhongButton.gameObject.SetActive(self.SkillPro.SkillID == SkillId);
        }

        public static void OnImg_Button(this Scroll_Item_SkillLearnItem self)
        {
            if (!self.EG_Node_1RectTransform.gameObject.activeSelf)
            {
                return;
            }

            self.ClickHandler(self.SkillPro);
        }

        public static void SetClickHander(this Scroll_Item_SkillLearnItem self, Action<SkillPro> action)
        {
            self.ClickHandler = action;
        }

        public static void OnUpdateUI(this Scroll_Item_SkillLearnItem self, SkillPro skillPro)
        {
            self.EG_ReddotRectTransform.gameObject.SetActive(false);
            self.E_Img_ButtonButton.AddListener(self.OnImg_Button);
            self.E_ButtonUpButton.AddListener(self.OnButtonUp);
            self.E_ButtonLearnButton.AddListener(self.OnButtonLearn);

            self.SkillPro = skillPro;

            int playerLv = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;
            SkillConfig skillBaseConfig = SkillConfigCategory.Instance.Get(skillPro.SkillID);

            using (zstring.Block())
            {
                self.E_Lab_NeedSpText.text = (zstring)"需要技能点: " + skillBaseConfig.CostSPValue;
            }

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();

            int weaponskill = SkillHelp.GetWeaponSkill(self.SkillPro.SkillID, UnitHelper.GetEquipType(self.Root()), skillSetComponent.SkillList);
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(weaponskill);

            int baseskill = SkillHelp.GetBaseSkill(weaponskill);

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.SkillIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_Lab_SkillNameText.text = skillConfig.SkillName;
            self.E_Img_SkillIconImage.sprite = sp;

            self.E_Lab_SkillLvText.text = GameSettingLanguge.Instance.LoadLocalization("等级 ") + skillConfig.SkillLv;

            if (skillBaseConfig.SkillLv == 0)
            {
                using (zstring.Block())
                {
                    self.E_Lab_SkillLvText.text = (zstring)skillBaseConfig.LearnRoseLv + "级以后学习";
                }

                CommonViewHelper.SetImageGray(self.Root(), self.E_Img_SkillIconImage.gameObject, true);
            }
            else
            {
                CommonViewHelper.SetImageGray(self.Root(), self.E_Img_SkillIconImage.gameObject, false);
            }

            self.OnUpdateSkillInfo(baseskill);
            self.ShowReddot();
        }
    }
}