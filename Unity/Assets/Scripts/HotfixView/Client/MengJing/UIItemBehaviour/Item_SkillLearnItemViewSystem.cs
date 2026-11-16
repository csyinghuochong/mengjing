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

        /// <summary>
        /// 点符文孔位的回调：技能id + 孔位下标，由 ES_SkillLearn 打开符文背包
        /// </summary>
        public static void SetSkillRuneClickHandler(this Scroll_Item_SkillLearnItem self, Action<int, int> action)
        {
            self.SkillRuneClickHandler = action;
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

            self.RefreshSkillRuneSlots(weaponskill, skillConfig, isLocked);
        }

        /// <summary>
        /// 刷新四个技能符文孔位：锁着显示锁，空孔显示加号，镶了符文显示图标和等级。
        /// 孔位节点是美术在预制体里摆好的，按名字前缀 EG_SkillRune_ 找，节点名后缀就是孔位序号
        /// </summary>
        private static void RefreshSkillRuneSlots(this Scroll_Item_SkillLearnItem self, int skillId, SkillConfig skillConfig, bool isLocked)
        {
            bool showSlots = !isLocked && skillConfig != null && IsActiveSkillType(skillConfig.SkillType);
            SkillRuneComponentC skillRuneComponent = self.Root().GetComponent<SkillRuneComponentC>();
            int slotCount = GlobalValueConfigCategory.Instance.SkillRuneSlotCount;

            for (int childIndex = 0; childIndex < self.uiTransform.childCount; childIndex++)
            {
                Transform slotTrans = self.uiTransform.GetChild(childIndex);
                if (!slotTrans.name.StartsWith(SkillRuneSlotPrefix))
                {
                    continue;
                }

                if (!int.TryParse(slotTrans.name.Substring(SkillRuneSlotPrefix.Length), out int slotNumber))
                {
                    continue;
                }

                //节点名从 1 开始，配置和存档里的孔位下标从 0 开始
                int slotIndex = slotNumber - 1;

                //没解锁的技能、或者预制体节点数比配置的孔位多时，直接藏掉
                bool show = showSlots && slotIndex >= 0 && slotIndex < slotCount;
                slotTrans.gameObject.SetActive(show);
                if (!show)
                {
                    continue;
                }

                int unlockLevel = SkillHelp.GetSkillRuneSlotUnlockLevel(slotIndex);
                bool unlocked = skillConfig.SkillLv >= unlockLevel;
                long runeId = skillRuneComponent == null ? 0 : skillRuneComponent.GetSlotRuneId(skillId, slotIndex);
                SkillRuneConfig runeConfig = skillRuneComponent == null ? null : skillRuneComponent.GetRuneConfig(skillRuneComponent.GetRune(runeId));
                bool hasRune = unlocked && runeConfig != null;

                Transform lockTrans = slotTrans.Find("Image_Lock");
                if (lockTrans != null)
                {
                    lockTrans.gameObject.SetActive(!unlocked);
                }

                Transform addTrans = slotTrans.Find("Image_Add");
                if (addTrans != null)
                {
                    addTrans.gameObject.SetActive(unlocked && !hasRune);
                }

                Transform iconTrans = slotTrans.Find("Mask/Image_Icon");
                Image iconImage = iconTrans == null ? null : iconTrans.GetComponent<Image>();
                if (iconImage != null)
                {
                    iconImage.gameObject.SetActive(hasRune);
                    if (hasRune)
                    {
                        string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, runeConfig.Icon);
                        Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                        if (sp != null)
                        {
                            iconImage.sprite = sp;
                        }
                    }
                }

                Transform lvTrans = slotTrans.Find("Text_Lv");
                Text lvText = lvTrans == null ? null : lvTrans.GetComponent<Text>();
                if (lvText != null)
                {
                    lvText.gameObject.SetActive(hasRune);
                    if (hasRune)
                    {
                        lvText.text = CommonViewHelper.GetRomanLevel(runeConfig.Level);
                    }
                }

                Transform buttonTrans = slotTrans.Find("Button_Click");
                Button button = buttonTrans == null ? null : buttonTrans.GetComponent<Button>();
                if (button != null)
                {
                    button.AddListener(() =>
                    {
                        //锁着的孔位只提示解锁条件，不打开符文背包
                        if (!unlocked)
                        {
                            FlyTipComponent.Instance.ShowFlyTip($"技能达到{unlockLevel}级解锁");
                            return;
                        }

                        //点孔位先把技能选中，右侧技能信息跟着切
                        self.ClickHandler?.Invoke(self.SkillPro);
                        self.SkillRuneClickHandler?.Invoke(skillId, slotIndex);
                    });
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
