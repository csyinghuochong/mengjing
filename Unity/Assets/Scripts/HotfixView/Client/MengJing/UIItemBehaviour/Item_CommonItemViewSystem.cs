using System;
using UnityEngine;
using UnityEngine.UI;

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

        public static void Refresh(this Scroll_Item_CommonItem self, BagInfo bagInfo, ItemOperateEnum itemOperateEnum,
        Action<BagInfo> onClickAction = null)
        {
            if (self.m_es_commonitem != null)
            {
                ES_CommonItem esCommonItem = self.m_es_commonitem;
                esCommonItem.Dispose();
                self.m_es_commonitem = null;
            }

            self.ES_CommonItem.UpdateItem(bagInfo, itemOperateEnum);
            self.ES_CommonItem.SetClickHandler(onClickAction);
        }

        public static void UpdateSelectStatus(this Scroll_Item_CommonItem self, BagInfo bagInfo)
        {
            self.ES_CommonItem.SetSelected(bagInfo);
        }
    }
}