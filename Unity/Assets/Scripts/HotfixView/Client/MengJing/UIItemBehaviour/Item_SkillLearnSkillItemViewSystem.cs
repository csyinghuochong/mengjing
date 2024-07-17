using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_SkillLearnSkillItem))]
    [EntitySystemOf(typeof (Scroll_Item_SkillLearnSkillItem))]
    public static partial class Scroll_Item_SkillLearnSkillItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_SkillLearnSkillItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_SkillLearnSkillItem self)
        {
            self.DestroyWidget();
        }

        public static void ShowReddot(this Scroll_Item_SkillLearnSkillItem self)
        {
            int skillpoint = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Sp;
            List<int> uplist = self.Root().GetComponent<SkillSetComponentC>().GetCanUpSkill(skillpoint);
            self.E_ReddotImage.gameObject.SetActive(uplist.Contains(self.SkillPro.SkillID));
        }

        public static void OnImg_Button(this Scroll_Item_SkillLearnSkillItem self)
        {
            self.ClickHandler(self.SkillPro);
        }

        public static void SetClickHander(this Scroll_Item_SkillLearnSkillItem self, Action<SkillPro> action)
        {
            self.ClickHandler = action;
        }

        public static void OnUpdateUI(this Scroll_Item_SkillLearnSkillItem self, SkillPro skillPro)
        {
            self.SkillPro = skillPro;
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillPro.SkillID);

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.SkillIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_SkillNameTextText.text = skillConfig.SkillName;
            // 未学习显示灰色
            int baseskill = SkillConfigCategory.Instance.GetInitSkill(skillPro.SkillID);
            if (baseskill == skillPro.SkillID)
            {
                Material mat = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Material>(ABPathHelper.GetMaterialPath("UI_Hui"));
                self.E_SkillIconImgImage.material = mat;
            }
            else
            {
                self.E_SkillIconImgImage.material = null;
            }

            self.E_SkillIconImgImage.sprite = sp;

            self.E_ReddotImage.gameObject.SetActive(false);
            self.E_BorderImgImage.gameObject.SetActive(false);
            self.E_SkillIconImgButton.AddListener(self.OnImg_Button);
            // self.ShowReddot();
        }
    }
}