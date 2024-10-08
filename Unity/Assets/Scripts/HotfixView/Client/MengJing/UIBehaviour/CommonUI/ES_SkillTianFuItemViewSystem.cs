using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_SkillTianFuItem))]
    [FriendOfAttribute(typeof(ES_SkillTianFuItem))]
    public static partial class ES_SkillTianFuItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_SkillTianFuItem self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_ImageIconButton.AddListener(self.OnImageIcon);
        }

        [EntitySystem]
        private static void Destroy(this ES_SkillTianFuItem self)
        {
            self.DestroyWidget();
        }

        public static void Init(this ES_SkillTianFuItem self, int position)
        {
            self.Position = position;
        }

        public static void Refresh(this ES_SkillTianFuItem self)
        {
            int talentType = self.Root().GetComponent<SkillSetComponentC>().TianFuPlan + 1;
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            List<int> oldtalentlist = skillSetComponent.TianFuList();
            int talentId = TalentHelpter.GetTalentIdByPosition(self.Position, oldtalentlist);

            bool active = true;
            if (talentId == 0)
            {
                active = false;
                List<int> talentConfigs = TalentConfigCategory.Instance.GetTalentIdByPosition(userInfo.Occ, talentType, self.Position);
                if (talentConfigs == null)
                {
                    // 这个位置还未配置
                    self.uiTransform.gameObject.SetActive(false);
                    return;
                }

                talentId = talentConfigs[0];
            }

            TalentConfig talentConfig = TalentConfigCategory.Instance.Get(talentId);
            self.uiTransform.gameObject.SetActive(true);

            int curlv = TalentHelpter.GetTalentCurLevel(userInfo.Occ, talentType, self.Position, talentId);
            int maxlv = TalentHelpter.GetTalentMaxLevel(userInfo.Occ, talentType, self.Position);

            using (zstring.Block())
            {
                if (active)
                {
                    self.E_PointText.text = zstring.Format("{0}/{1}", curlv, maxlv);
                }
                else
                {
                    self.E_PointText.text = zstring.Format("{0}/{1}", 0, maxlv);
                }
            }

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, talentConfig.Icon.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_ImageIconImage.sprite = sp;
            CommonViewHelper.SetImageGray(self.Root(), self.E_ImageIconImage.gameObject, !active);
        }

        public static void OnImageIcon(this ES_SkillTianFuItem self)
        {
            self.GetParent<ES_SkillTianFu>().OnClickTianFuItem(self.Position);
        }
    }
}