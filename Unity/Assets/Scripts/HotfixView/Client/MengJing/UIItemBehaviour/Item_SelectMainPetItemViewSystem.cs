using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_SelectMainPetItem))]
    [EntitySystemOf(typeof(Scroll_Item_SelectMainPetItem))]
    public static partial class Scroll_Item_SelectMainPetItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_SelectMainPetItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_SelectMainPetItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_SelectMainPetItem self, RolePetInfo rolePetInfo)
        {
            self.E_TouchButton.AddListener(self.OnTouch);
            self.E_SelectedImage.gameObject.SetActive(false);

            self.PetId = rolePetInfo.Id;
            PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString());
            Sprite sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_IconImage.sprite = sprite;
            self.E_NameText.text = rolePetInfo.PetName;
            using (zstring.Block())
            {
                self.E_LvText.text = zstring.Format("{0}级", rolePetInfo.PetLv);
            }
        }

        private static void OnTouch(this Scroll_Item_SelectMainPetItem self)
        {
            self.OnSelectMainPetItem?.Invoke(self.PetId);
        }
    }
}