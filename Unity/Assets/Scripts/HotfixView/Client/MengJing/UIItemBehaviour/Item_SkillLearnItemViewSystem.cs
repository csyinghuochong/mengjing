using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_SkillLearnItem))]
    [EntitySystemOf(typeof(Scroll_Item_SkillLearnItem))]
    public static partial class Scroll_Item_SkillLearnItemSystem
    {
        /// <summary>
        /// 预制体里技能符文孔位的节点名前缀，节点名形如 EG_SkillRune_1
        /// </summary>
        private const string SkillRuneSlotPrefix = "EG_SkillRune_";

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

            self.RefreshSkillRuneSlots(skillConfig, isLocked);
        }

        /// <summary>
        /// 刷新四个技能符文孔位：锁着显示锁，空孔显示加号，镶了符文显示图标和等级。
        /// 孔位节点是美术在预制体里摆好的，按名字前缀 EG_SkillRune_ 找，节点名后缀就是孔位序号
        /// </summary>
        private static void RefreshSkillRuneSlots(this Scroll_Item_SkillLearnItem self, SkillConfig skillConfig, bool isLocked)
        {
            bool showSlots = !isLocked && skillConfig != null && IsActiveSkillType(skillConfig.SkillType);
            Scene root = self.Root();
            SkillRuneComponentC skillRuneComponent = root.GetComponent<SkillRuneComponentC>();
            int slotCount = GlobalValueConfigCategory.Instance.SkillRuneSlotCount;

            for (int childIndex = 0; childIndex < self.uiTransform.childCount; childIndex++)
            {
                Transform slot = self.uiTransform.GetChild(childIndex);
                if (!slot.name.StartsWith(SkillRuneSlotPrefix))
                {
                    continue;
                }

                if (!int.TryParse(slot.name.Substring(SkillRuneSlotPrefix.Length), out int slotNumber))
                {
                    continue;
                }

                int slotIndex = slotNumber - 1;
                bool show = showSlots && slotIndex >= 0 && slotIndex < slotCount;
                slot.gameObject.SetActive(show);
                if (!show)
                {
                    continue;
                }

                bool unlocked = skillConfig.SkillLv >= SkillHelp.GetSkillRuneSlotUnlockLevel(slotIndex);
                SkillRuneConfig runeConfig = null;
                if (unlocked && skillRuneComponent != null)
                {
                    long runeId = skillRuneComponent.GetSlotRuneId(skillConfig.Id, slotIndex);
                    runeConfig = skillRuneComponent.GetRuneConfig(skillRuneComponent.GetRune(runeId));
                }

                bool hasRune = runeConfig != null;
                slot.Find("Image_Lock")?.gameObject.SetActive(!unlocked);
                slot.Find("Image_Add")?.gameObject.SetActive(unlocked && !hasRune);

                Image iconImage = slot.Find("Mask/Image_Icon")?.GetComponent<Image>();
                if (iconImage != null)
                {
                    iconImage.gameObject.SetActive(hasRune);
                    if (hasRune)
                    {
                        string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, runeConfig.Icon);
                        iconImage.sprite = root.GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                    }
                }

                Text lvText = slot.Find("Text_Lv")?.GetComponent<Text>();
                if (lvText != null)
                {
                    lvText.gameObject.SetActive(hasRune);
                    if (hasRune)
                    {
                        lvText.text = CommonViewHelper.GetRomanLevel(runeConfig.Level);
                    }
                }
            }
        }

        /// <summary>
        /// 1 主动技能，6 武器总技能，技能界面主动技能页就是这两种
        /// </summary>
        private static bool IsActiveSkillType(int skillType)
        {
            return skillType == (int)SkillTypeEnum.ActiveSkill || skillType == 6;
        }
    }
}
