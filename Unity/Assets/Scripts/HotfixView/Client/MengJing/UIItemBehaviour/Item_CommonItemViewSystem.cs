using System;

namespace ET.Client
{
    [FriendOf(typeof (ES_CommonItem))]
    [FriendOf(typeof (Scroll_Item_CommonItem))]
    [EntitySystemOf(typeof (Scroll_Item_CommonItem))]
    public static partial class Scroll_Item_CommonItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_CommonItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_CommonItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_CommonItem self, ItemInfo bagInfo, ItemOperateEnum itemOperateEnum,
        Action<ItemInfo> onClickAction = null, int currentHouse = -1)
        {
            self.ES_CommonItem.UpdateItem(bagInfo, itemOperateEnum);
            self.ES_CommonItem.SetClickHandler(onClickAction);
            self.ES_CommonItem.SetCurrentHouse(currentHouse);
        }

        public static void UpdateSelectStatus(this Scroll_Item_CommonItem self, ItemInfo bagInfo)
        {
            self.ES_CommonItem.SetSelected(bagInfo);
        }
    }
}