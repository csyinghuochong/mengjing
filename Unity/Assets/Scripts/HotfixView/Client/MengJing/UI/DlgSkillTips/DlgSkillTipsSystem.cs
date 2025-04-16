using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgSkillTips))]
    public static class DlgSkillTipsSystem
    {
        public static void RegisterUIEvent(this DlgSkillTips self)
        {
            self.View.E_ImageButtonButton.AddListener(self.OnImageButtonButton);
        }

        public static void ShowWindow(this DlgSkillTips self, Entity contextData = null)
        {
        }

        private static void OnImageButtonButton(this DlgSkillTips self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_SkillTips);
        }

        public static void ShowUnActive(this DlgSkillTips self, int skillId, int skillNum)
        {
            self.View.EG_UnActiveTipRectTransform.gameObject.SetActive(true);

            int hideId = HideProListConfigCategory.Instance.PetSkillToHideProId[skillId];
            HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(hideId);
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillId);
            using (zstring.Block())
            {
                self.View.E_Lab_SkillNameText.text = zstring.Format("{0}{1}/{2}", skillConfig.SkillName, skillNum, hideProListConfig.NeedNumber);
                self.View.E_TextTip2Text.text = zstring.Format("套装技能穿戴{0}个时激活此技能", hideProListConfig.NeedNumber);
            }
        }

        public static void OnUpdateData(this DlgSkillTips self, int skillId, Vector3 vector3,
        string aBAtlasTypes = ABAtlasTypes.RoleSkillIcon, string addTip = "")
        {
            if (!SkillConfigCategory.Instance.Contain(skillId))
            {
                ///可能是道具
                return;
            }

            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillId);
            string path = ABPathHelper.GetAtlasPath_2(aBAtlasTypes, skillConfig.SkillIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.View.E_Image_SkillIconImage.sprite = sp;

            self.View.E_Lab_SkillNameText.text = skillConfig.SkillName;
            self.View.E_Lab_SkillDesText.text = skillConfig.SkillDescribe.Replace("\\n", "\n") + addTip;

            if (skillConfig.SkillType == (int)SkillTypeEnum.PassiveSkill ||
                skillConfig.SkillType == (int)SkillTypeEnum.PassiveAddProSkill ||
                skillConfig.SkillType == (int)SkillTypeEnum.PassiveAddProSkillNoFight)
            {
                self.View.E_Lab_SkillTypeText.text = LanguageComponent.Instance.LoadLocalization("类型：被动技能");
            }
            else
            {
                self.View.E_Lab_SkillTypeText.text = LanguageComponent.Instance.LoadLocalization("类型：主动技能");
            }

            LayoutRebuilder.ForceRebuildLayoutImmediate(self.View.E_Lab_SkillDesText.GetComponent<RectTransform>());
            float textHeight = self.View.E_Lab_SkillDesText.GetComponent<RectTransform>().rect.height;
            
            // 调整面板的高度
            self.View.E_BGImage.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 250f + textHeight);
            
            // 调整面板的位置
            if (vector3.x > Screen.width * -0.5 + 500)
            {
                self.View.EG_PositionNodeRectTransform.transform.localPosition = vector3 + new Vector3(-50f, 50f, 0f);
            }
            else
            {
                self.View.EG_PositionNodeRectTransform.transform.localPosition = vector3 + new Vector3(450f, 50f, 0f);
            }

            self.View.EG_UnActiveTipRectTransform.gameObject.SetActive(false);
        }
    }
}