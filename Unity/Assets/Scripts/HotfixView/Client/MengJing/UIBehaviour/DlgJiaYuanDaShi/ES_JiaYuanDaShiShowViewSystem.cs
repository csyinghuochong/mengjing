using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_JiaYuanDaShiShowItem))]
    [EntitySystemOf(typeof (ES_JiaYuanDaShiShow))]
    [FriendOfAttribute(typeof (ES_JiaYuanDaShiShow))]
    public static partial class ES_JiaYuanDaShiShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_JiaYuanDaShiShow self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_JiaYuanDaShiShowItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnJiaYuanDaShiShowItemsRefresh);
        }

        [EntitySystem]
        private static void Destroy(this ES_JiaYuanDaShiShow self)
        {
            self.DestroyWidget();
        }

        private static void OnJiaYuanDaShiShowItemsRefresh(this ES_JiaYuanDaShiShow self, Transform transform, int index)
        {
            foreach (Scroll_Item_JiaYuanDaShiShowItem item in self.ScrollItemJiaYuanDaShiShowItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_JiaYuanDaShiShowItem scrollItemJiaYuanDaShiShowItem = self.ScrollItemJiaYuanDaShiShowItems[index].BindTrans(transform);
            JiaYuanComponentC jiaYuanComponentC = self.Root().GetComponent<JiaYuanComponentC>();
            scrollItemJiaYuanDaShiShowItem.OnUpdateUI(self.ShowIndex[index], jiaYuanComponentC.JiaYuanDaShiTime_1);
        }

        public static void OnUpdateUI(this ES_JiaYuanDaShiShow self)
        {
            List<KeyValuePair> jiayuandashi = ConfigData.JiaYuanDaShiPro;
            self.ShowIndex.Clear();
            for (int i = 0; i < jiayuandashi.Count / 3; i++)
            {
                self.ShowIndex.Add(i);
            }

            self.AddUIScrollItems(ref self.ScrollItemJiaYuanDaShiShowItems, self.ShowIndex.Count);
            self.E_JiaYuanDaShiShowItemsLoopVerticalScrollRect.SetVisible(true, self.ShowIndex.Count);
        }
    }
}
