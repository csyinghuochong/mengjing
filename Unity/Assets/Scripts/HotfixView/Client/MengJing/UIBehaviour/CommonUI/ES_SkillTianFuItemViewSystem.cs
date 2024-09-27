using UnityEngine;
using UnityEngine.UI;

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

        public static void Refresh(this ES_SkillTianFuItem self, int type)
        {
            if (self.Position == 0)
            {
                return;
            }
            
            // TalentConfig talentConfig = TalentConfigCategory.Instance.Get(self.TalentId);
            // string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, talentConfig.Icon.ToString());
            // Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            // self.E_ImageIconImage.sprite = sp;
            // SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            // List<int> activeList = skillSetComponent.TianFuList();
            // CommonViewHelper.SetImageGray(self.Root(), self.E_ImageIconImage.gameObject, !activeList.Contains(self.TalentId));
        }
    }
}