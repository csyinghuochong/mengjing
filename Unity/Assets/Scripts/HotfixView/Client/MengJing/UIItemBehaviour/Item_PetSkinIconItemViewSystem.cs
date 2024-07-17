using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_PetSkinIconItem))]
    [EntitySystemOf(typeof (Scroll_Item_PetSkinIconItem))]
    public static partial class Scroll_Item_PetSkinIconItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PetSkinIconItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PetSkinIconItem self)
        {
            self.DestroyWidget();
        }

        public static void SetClickHandler(this Scroll_Item_PetSkinIconItem self, Action<int> action)
        {
            self.ClickHandler = action;
        }

        public static void OnImage_ItemButton(this Scroll_Item_PetSkinIconItem self)
        {
            self.ClickHandler(self.SkinId);
        }

        public static void OnSelected(this Scroll_Item_PetSkinIconItem self, int skinId)
        {
            self.E_Image_XuanZhongImage.gameObject.SetActive(self.SkinId == skinId);
        }

        public static void OnUpdateUI(this Scroll_Item_PetSkinIconItem self, int skinId, bool unlocked)
        {
            self.SkinId = skinId;
            PetSkinConfig skillConfig = PetSkinConfigCategory.Instance.Get(skinId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, skillConfig.IconID.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_Image_ItemIconImage.sprite = sp;
            self.E_TextSkinNameText.text = skillConfig.Name;
            CommonViewHelper.SetImageGray(self.Root(), self.E_Image_ItemIconImage.gameObject, !unlocked);
            CommonViewHelper.SetImageGray(self.Root(), self.E_Image_ItemQualityImage.gameObject, !unlocked);
            self.E_JiHuoSetText.gameObject.SetActive(unlocked);

            self.E_Image_XuanZhongImage.gameObject.SetActive(false);
            self.E_Image_ItemButtonButton.AddListener(self.OnImage_ItemButton);
        }
    }
}