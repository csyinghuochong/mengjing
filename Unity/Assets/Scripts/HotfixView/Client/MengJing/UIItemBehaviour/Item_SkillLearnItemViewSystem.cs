using System;
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

        public static void OnSetSelected(this Scroll_Item_SkillLearnItem self, int SkillId)
        {
            self.E_HighlightImage.gameObject.SetActive(self.SkillPro.SkillID == SkillId);
            
            //Log.Error($"OnSetSelected:  {self.SkillPro.SkillID}   {SkillId}  {self.SkillPro.SkillID == SkillId}  {SkillConfigCategory.Instance.Get(self.SkillPro.SkillID).SkillName}");
        }

        public static void OnClick(this Scroll_Item_SkillLearnItem self)
        {
            if (self.E_NullImage.gameObject.activeSelf)
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
            self.SkillPro = skillPro;
            self.E_ClickButton.AddListener(self.OnClick);
            self.E_SkillIconImage.gameObject.SetActive(false);
            self.E_NullImage.gameObject.SetActive(false);
            self.E_SkillNameText.gameObject.SetActive(false);
            self.E_SkillLvText.gameObject.SetActive(false);
            self.E_LearnLvText.gameObject.SetActive(false);

            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();

            int playerLv = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;
            SkillConfig skillBaseConfig = SkillConfigCategory.Instance.Get(skillPro.SkillID);
            int weaponskill = SkillHelp.GetWeaponSkill(self.SkillPro.SkillID, UnitHelper.GetEquipType(self.Root()), skillSetComponent.SkillList);
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(weaponskill);

            if (playerLv < skillBaseConfig.LearnRoseLv && skillBaseConfig.SkillLv == 0)
            {
                using (zstring.Block())
                {
                    self.E_NullImage.gameObject.SetActive(true);
                    self.E_LearnLvText.gameObject.SetActive(true);
                    self.E_LearnLvText.text = zstring.Format("{0}级以后学习", skillBaseConfig.LearnRoseLv);
                }
            }
            else
            {
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.SkillIcon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                self.E_SkillNameText.gameObject.SetActive(true);
                self.E_SkillNameText.text = skillConfig.SkillName;
                self.E_SkillIconImage.gameObject.SetActive(true);
                self.E_SkillIconImage.sprite = sp;
                using (zstring.Block())
                {
                    self.E_SkillLvText.gameObject.SetActive(true);
                    self.E_SkillLvText.text = zstring.Format("{0}{1}", LanguageComponent.Instance.LoadLocalization("等级 "), skillConfig.SkillLv);
                }
            }
        }
    }
}