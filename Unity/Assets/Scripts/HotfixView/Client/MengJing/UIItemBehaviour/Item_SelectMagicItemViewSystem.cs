using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_SelectMagicItem))]
    [EntitySystemOf(typeof(Scroll_Item_SelectMagicItem))]
    public static partial class Scroll_Item_SelectSkillItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_SelectMagicItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_SelectMagicItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_SelectMagicItem self, int magicId)
        {
            self.E_TouchButton.AddListener(self.OnTouch);
            self.E_SelectedImage.gameObject.SetActive(false);

            self.magicId = magicId;
            PetMagicCardConfig petMagicCardConfig = PetMagicCardConfigCategory.Instance.Get(magicId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, petMagicCardConfig.Icon.ToString());
            Sprite sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_IconImage.sprite = sprite;
            self.E_NameText.text = petMagicCardConfig.Name;
        }

        private static void OnTouch(this Scroll_Item_SelectMagicItem self)
        {
            self.OnSelectSkillItem?.Invoke(self.magicId);
        }
    }
}