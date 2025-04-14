using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_FriendBlackItem))]
    [FriendOf(typeof (FriendComponent))]
    [EntitySystemOf(typeof (ES_FriendBlack))]
    [FriendOfAttribute(typeof (ES_FriendBlack))]
    public static partial class ES_FriendBlackSystem
    {
        [EntitySystem]
        private static void Awake(this ES_FriendBlack self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_FriendBlackItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnFriendBlackItemsRefresh);
            self.Refresh();
        }

        [EntitySystem]
        private static void Destroy(this ES_FriendBlack self)
        {
            self.DestroyWidget();
        }

        private static void OnFriendBlackItemsRefresh(this ES_FriendBlack self, Transform transform, int index)
        {
            foreach (Scroll_Item_FriendBlackItem item in self.ScrollItemFriendBlackItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_FriendBlackItem scrollItemFriendBlackItem = self.ScrollItemFriendBlackItems[index].BindTrans(transform);
            scrollItemFriendBlackItem.Refresh(self.ShowFriendInfos[index], self.Refresh);
        }

        private static void Refresh(this ES_FriendBlack self)
        {
            self.ShowFriendInfos.Clear();
            self.ShowFriendInfos.AddRange(self.Root().GetComponent<FriendComponent>().Blacklist);
            
            self.AddUIScrollItems(ref self.ScrollItemFriendBlackItems, self.ShowFriendInfos.Count);
            self.E_FriendBlackItemsLoopVerticalScrollRect.SetVisible(true, self.ShowFriendInfos.Count);
        }
    }
}
