using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_BagItem))]
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

        public static void Refresh(this Scroll_Item_BagItem self, BagInfo bagInfo, ItemOperateEnum itemOperateEnum,
        Action<BagInfo> onClickAction = null)
        {
            self.ES_CommonItem.Refresh(bagInfo, itemOperateEnum, onClickAction);
        }

        public static void UpdateSelectStatus(this Scroll_Item_BagItem self, BagInfo bagInfo)
        {
            self.ES_CommonItem.UpdateSelectStatus(bagInfo);
        }
    }
}