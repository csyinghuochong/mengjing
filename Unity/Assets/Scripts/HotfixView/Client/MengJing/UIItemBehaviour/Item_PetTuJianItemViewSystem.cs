using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_PetTuJianItem))]
    [EntitySystemOf(typeof (Scroll_Item_PetTuJianItem))]
    public static partial class Scroll_Item_PetTuJianItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PetTuJianItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PetTuJianItem self)
        {
            self.DestroyWidget();
        }

        public static void OnImage_ItemButton(this Scroll_Item_PetTuJianItem self)
        {
            self.ClickHandler(self.PetId);
        }

        public static void SetSelected(this Scroll_Item_PetTuJianItem self, int petid)
        {
            self.E_Image_XuanZhongImage.gameObject.SetActive(self.PetId == petid);
        }

        public static void SetClickHandler(this Scroll_Item_PetTuJianItem self, Action<int> action)
        {
            self.ClickHandler = action;
        }

        public static void OnInitUI(this Scroll_Item_PetTuJianItem self, int petid)
        {
            self.PetId = petid;

            PetConfig petConfig = PetConfigCategory.Instance.Get(petid);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petConfig.HeadIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_Image_ItemIconImage.sprite = sp;
            self.E_Label_ItemNameText.text = petConfig.PetName;

            self.E_Image_ItemButtonButton.AddListener(self.OnImage_ItemButton);
        }
    }
}