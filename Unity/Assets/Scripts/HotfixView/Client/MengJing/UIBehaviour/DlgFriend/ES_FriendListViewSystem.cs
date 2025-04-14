using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_FriendListItem))]
    [FriendOf(typeof (FriendComponent))]
    [FriendOf(typeof (ES_ChatView))]
    [EntitySystemOf(typeof (ES_FriendList))]
    [FriendOfAttribute(typeof (ES_FriendList))]
    public static partial class ES_FriendListSystem
    {
        [EntitySystem]
        private static void Awake(this ES_FriendList self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_FriendListItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnFriendListItemsRefresh);

            self.ES_ChatView.uiTransform.gameObject.SetActive(false);

            self.Refresh();
        }

        [EntitySystem]
        private static void Destroy(this ES_FriendList self)
        {
            self.DestroyWidget();
        }

        private static void OnFriendListItemsRefresh(this ES_FriendList self, Transform transform, int index)
        {
            foreach (Scroll_Item_FriendListItem item in self.ScrollItemFriendListItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_FriendListItem scrollItemFriendListItem = self.ScrollItemFriendListItems[index].BindTrans(transform);
            scrollItemFriendListItem.Refresh(self.ShowFriendInfos[index], self.OnDeleteHandler, self.OnChatHandler);
        }

        public static void Refresh(this ES_FriendList self)
        {
            FriendComponent friendComponent = self.Root().GetComponent<FriendComponent>();
            self.ShowFriendInfos.Clear();
            self.ShowFriendInfos.AddRange(friendComponent.FriendList);

            self.AddUIScrollItems(ref self.ScrollItemFriendListItems, self.ShowFriendInfos.Count);
            self.E_FriendListItemsLoopVerticalScrollRect.SetVisible(true, self.ShowFriendInfos.Count);
        }

        private static void OnChatHandler(this ES_FriendList self, FriendInfo friendInfo)
        {
            self.ES_ChatView.uiTransform.gameObject.SetActive(true);
            self.ES_ChatView.Refresh(friendInfo);

            FriendComponent friendComponent = self.Root().GetComponent<FriendComponent>();
            if (friendComponent.FriendChatId.Contains(friendInfo.UserId))
            {
                friendComponent.FriendChatId.Remove(friendInfo.UserId);
            }
            
            if (friendComponent.FriendChatId.Count == 0)
            {
                ReddotComponentC redPointComponent = self.Root().GetComponent<ReddotComponentC>();
                redPointComponent.RemoveReddont(ReddotType.FriendChat);
            }
            
            FriendNetHelper.RequestFriendChatRead(self.Root(), friendInfo.UserId).Coroutine();
        }

        private static void OnDeleteHandler(this ES_FriendList self)
        {
            self.Refresh();
        }
        
        public static void OnFriendChat(this ES_FriendList self)
        {
            if (!self.ES_ChatView.uiTransform.gameObject.activeSelf)
                return;

            self.ES_ChatView.RefreshFriendChatItems();
        }
    }
}
