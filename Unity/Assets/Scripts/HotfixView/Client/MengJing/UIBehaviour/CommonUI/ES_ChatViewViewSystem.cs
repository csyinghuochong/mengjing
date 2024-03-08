using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (FriendComponent))]
    [EntitySystemOf(typeof (ES_ChatView))]
    [FriendOfAttribute(typeof (ES_ChatView))]
    public static partial class ES_ChatViewSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ChatView self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_FriendChatItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnFriendChatItemsRefresh);
        }

        [EntitySystem]
        private static void Destroy(this ES_ChatView self)
        {
            self.DestroyWidget();
        }

        private static void OnFriendChatItemsRefresh(this ES_ChatView self, Transform transform, int index)
        {
            Scroll_Item_FriendChatItem scrollItemFriendChatItem = self.ScrollItemFriendChatItems[index].BindTrans(transform);
            scrollItemFriendChatItem.Refresh(self.ShowChatInfos[index]);
        }

        public static void Refresh(this ES_ChatView self, FriendInfo friendInfo)
        {
            self.FriendInfo = friendInfo;
            self.RefreshFriendChatItems();
        }

        private static void RefreshFriendChatItems(this ES_ChatView self)
        {
            FriendComponent friendComponent = self.Root().GetComponent<FriendComponent>();
            List<ChatInfo> chatInfos = null;
            friendComponent.ChatMsgList.TryGetValue(self.FriendInfo.UserId, out chatInfos);
            self.ShowChatInfos.Clear();
            if (null != chatInfos)
            {
                self.ShowChatInfos.AddRange(chatInfos);
            }

            self.AddUIScrollItems(ref self.ScrollItemFriendChatItems, self.ShowChatInfos.Count);
            self.E_FriendChatItemsLoopVerticalScrollRect.SetVisible(true, self.ShowChatInfos.Count);
        }
    }
}