using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_SelectSkillItem))]
    [EntitySystemOf(typeof(Scroll_Item_SelectSkillItem))]
    public static partial class Scroll_Item_SelectSkillItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_SelectSkillItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_SelectSkillItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_SelectSkillItem self, int skillId)
        {
            self.E_TouchButton.AddListener(self.OnTouch);
            self.E_SelectedImage.gameObject.SetActive(false);

            self.SkillId = skillId;
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.SkillIcon);
            Sprite sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_IconImage.sprite = sprite;
            self.E_NameText.text = skillConfig.SkillName;
        }

        private static void OnTouch(this Scroll_Item_SelectSkillItem self)
        {
            self.OnSelectSkillItem?.Invoke(self.SkillId);
        }
    }
}