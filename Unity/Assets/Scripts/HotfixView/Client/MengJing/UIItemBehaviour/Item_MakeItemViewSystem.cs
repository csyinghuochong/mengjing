using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_MakeItem))]
    [EntitySystemOf(typeof (Scroll_Item_MakeItem))]
    public static partial class Scroll_Item_MakeItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_MakeItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_MakeItem self)
        {
            self.DestroyWidget();
        }

        public static void OnSelectMakeItem(this Scroll_Item_MakeItem self, bool select)
        {
            self.E_Image_SelectImage.gameObject.SetActive(select);
        }

        public static void OnUpdateUI(this Scroll_Item_MakeItem self, int makeId)
        {
            self.E_Btn_XuanZhongButton.AddListener(self.OnClickItem);

            self.MakeID = makeId;
            self.ItemID = EquipMakeConfigCategory.Instance.Get(makeId).MakeItemID;

            ItemConfig itemconfig = ItemConfigCategory.Instance.Get(self.ItemID);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemconfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_ItemHeroIonImage.sprite = sp;
            string qualityiconStr = FunctionUI.ItemQualiytoPath(itemconfig.ItemQuality);
            string path2 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconStr);
            Sprite sp2 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path2);

            self.E_ImageQualityImage.sprite = sp2;

            self.E_Lab_PetNameText.text = itemconfig.ItemName;
            self.E_Lab_PetNameText.color = FunctionUI.QualityReturnColor(itemconfig.ItemQuality);
        }

        public static void SetClickAction(this Scroll_Item_MakeItem self, Action<int> action)
        {
            self.ActionClick = action;
        }

        public static void OnClickItem(this Scroll_Item_MakeItem self)
        {
            self.ActionClick(self.MakeID);
        }
    }
}