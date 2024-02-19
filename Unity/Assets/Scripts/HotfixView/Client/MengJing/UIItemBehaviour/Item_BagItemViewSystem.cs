using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (Scroll_Item_BagItem))]
    public static partial class Scroll_Item_BagItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_BagItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_BagItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_BagItem self, BagInfo bagInfo)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            self.E_ItemNumText.text = bagInfo.ItemNum.ToString();
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
            self.E_ItemIconImage.overrideSprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            string qualityiconStr = FunctionUI.ItemQualiytoPath(itemConfig.ItemQuality);
            string path2 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconStr);
            self.E_ItemQualityImage.overrideSprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path2);
            // self.E_SelectButton.AddListenerWithId(self.OnShowItemEntryPopUpHandler, id);
        }

        public static void OnShowItemEntryPopUpHandler(this Scroll_Item_BagItem self, long Id)
        {
            // self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_ItemPopUp);
            // Item item = self.ZoneScene().GetComponent<BagComponent>().GetItemById(Id);
            // self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgItemPopUp>().RefreshInfo(item, ItemContainerType.Bag);
        }
    }
}