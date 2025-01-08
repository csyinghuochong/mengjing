using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetMeleeLevelItem))]
    [EntitySystemOf(typeof(Scroll_Item_PetMeleeLevelItem))]
    public static partial class Scroll_Item_PetMeleeLevelItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PetMeleeLevelItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PetMeleeLevelItem self)
        {
            self.DestroyWidget();
        }

        public static void OnInit(this Scroll_Item_PetMeleeLevelItem self, int sceneId)
        {
            self.SceneId = sceneId;
            self.E_SelectedImage.gameObject.SetActive(false);
        }

        public static void SetSelected(this Scroll_Item_PetMeleeLevelItem self, int sceneId)
        {
            self.E_SelectedImage.gameObject.SetActive(self.SceneId == sceneId);
        }
    }
}