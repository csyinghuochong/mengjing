using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_RolePetBagItem))]
    [EntitySystemOf(typeof (Scroll_Item_RolePetBagItem))]
    public static partial class Scroll_Item_RolePetBagItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_RolePetBagItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_RolePetBagItem self)
        {
            self.DestroyWidget();
        }

        public static void OnImage_ItemButton(this Scroll_Item_RolePetBagItem self)
        {
            self.ClickHandler(self.RolePetInfo);
        }

        public static void SetSelected(this Scroll_Item_RolePetBagItem self, long petid)
        {
            self.E_Image_XuanZhongImage.gameObject.SetActive(self.RolePetInfo.Id == petid);
        }

        public static void SetClickHandler(this Scroll_Item_RolePetBagItem self, Action<RolePetInfo> action)
        {
            self.ClickHandler = action;
        }

        public static void OnInitUI(this Scroll_Item_RolePetBagItem self, RolePetInfo rolePetInfo)
        {
            self.RolePetInfo = rolePetInfo;

            PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_Image_ItemIconImage.sprite = sp;
            self.E_Label_ItemNameText.text = rolePetInfo.PetName;

            self.E_Image_ItemButtonButton.AddListener(self.OnImage_ItemButton);
        }
    }
}