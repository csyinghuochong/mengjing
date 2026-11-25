using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

            bool isLocked = playerLv < skillBaseConfig.LearnRoseLv && skillBaseConfig.SkillLv == 0;
            if (isLocked)
            {
                self.E_NullImage.gameObject.SetActive(true);
                self.E_LearnLvText.gameObject.SetActive(true);
                self.E_LearnLvText.text = string.Format("{0}级以后学习", skillBaseConfig.LearnRoseLv);
            }
            else
            {
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.SkillIcon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                self.E_SkillNameText.gameObject.SetActive(true);
                self.E_SkillNameText.text = skillConfig.SkillName;
                self.E_SkillIconImage.gameObject.SetActive(true);
                self.E_SkillIconImage.sprite = sp;
                self.E_SkillLvText.gameObject.SetActive(true);
                self.E_SkillLvText.text = string.Format("{0}{1}", LanguageComponent.Instance.LoadLocalization("等级 "), skillConfig.SkillLv);
            }

            self.RefreshSkillRunes(skillConfig.Id);
        }

        private static void RefreshSkillRunes(this Scroll_Item_SkillLearnItem self, int skillId)
        {
            Scene root = self.Root();
            SkillRuneComponentC skillRuneComponent = root.GetComponent<SkillRuneComponentC>();
            List<SkillRuneConfig> runeConfigs = skillRuneComponent?.GetSkillRuneConfigs(skillId);
            int runeCount = runeConfigs?.Count ?? 0;
            RectTransform[] runeNodes =
            {
                self.EG_SkillRune_1RectTransform,
                self.EG_SkillRune_2RectTransform,
                self.EG_SkillRune_3RectTransform,
                self.EG_SkillRune_4RectTransform
            };

            ResourcesLoaderComponent resourcesLoaderComponent = root.GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < runeNodes.Length; i++)
            {
                RectTransform runeNode = runeNodes[i];
                if (runeNode == null)
                {
                    continue;
                }

                bool hasRune = i < runeCount;
                if (hasRune)
                {
                    Image iconImage = runeNode.Find("Mask/Image_Icon")?.GetComponent<Image>();
                    if (iconImage != null)
                    {
                        string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, runeConfigs[i].Icon);
                        iconImage.sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);
                        iconImage.gameObject.SetActive(true);
                    }
                }

                runeNode.gameObject.SetActive(hasRune);
            }
        }
    }
}
