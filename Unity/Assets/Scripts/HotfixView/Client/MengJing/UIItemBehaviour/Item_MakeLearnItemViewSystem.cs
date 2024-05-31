using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_MakeLearnItem))]
    [EntitySystemOf(typeof (Scroll_Item_MakeLearnItem))]
    public static partial class Scroll_Item_MakeLearnItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_MakeLearnItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_MakeLearnItem self)
        {
            self.DestroyWidget();
        }

        public static void SetSelected(this Scroll_Item_MakeLearnItem self, int makeid)
        {
            self.E_ImageSelectImage.gameObject.SetActive(self.MakeId == makeid);
        }

        public static void OnImageButton(this Scroll_Item_MakeLearnItem self)
        {
            self.ClickHandler(self.MakeId);
        }

        public static void SetClickHandler(this Scroll_Item_MakeLearnItem self, Action<int> action)
        {
            self.ClickHandler = action;
        }

        public static void OnUpdateUI(this Scroll_Item_MakeLearnItem self, int makeid)
        {
            self.E_ImageButtonButton.AddListener(self.OnImageButton);
            self.E_ImageSelectImage.gameObject.SetActive(false);
            self.MakeId = makeid;

            EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(makeid);
            self.E_Label_LearnLvText.text = string.Format("学习等级:{0}级", equipMakeConfig.LearnLv);

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(equipMakeConfig.MakeItemID);
            self.E_Label_ItemNameText.text = itemConfig.ItemName;
            self.E_Label_ItemNameText.color = FunctionUI.QualityReturnColor(itemConfig.ItemQuality);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_Image_ItemIconImage.sprite = sp;

            string ItemQuality = FunctionUI.ItemQualiytoPath(itemConfig.ItemQuality);
            string path2 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, ItemQuality);
            Sprite sp2 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path2);

            self.E_Image_ItemQualityImage.sprite = sp2;
        }
    }
}