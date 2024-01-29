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

        public static void Refresh(this Scroll_Item_BagItem self, long id)
        {
            Log.Debug($"更新背包Item :{id}");
            // Item item = self.ZoneScene().GetComponent<BagComponent>().GetItemById(id);
            //
            // self.E_IconImage.overrideSprite = IconHelper.LoadIconSprite("Icons", item.Config.Icon);
            // self.E_QualityImage.color = item.ItemQualityColor();
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