using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetbarSetSkillItem))]
    [EntitySystemOf(typeof(Scroll_Item_PetbarSetSkillItem))]
    public static partial class Scroll_Item_PetbarSetSkillItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PetbarSetSkillItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PetbarSetSkillItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this Scroll_Item_PetbarSetSkillItem self, int skillId, string skillAtlas = ABAtlasTypes.RoleSkillIcon)
        {
            self.SkillId = skillId;
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillId);
            string path = ABPathHelper.GetAtlasPath_2(skillAtlas, skillConfig.SkillIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_IconImage.sprite = sp;
            self.E_NameText.text = skillConfig.SkillName;
        }
    }
}