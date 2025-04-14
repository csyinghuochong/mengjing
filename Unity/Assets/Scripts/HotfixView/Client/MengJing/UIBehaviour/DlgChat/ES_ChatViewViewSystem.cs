using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_FriendChatItem))]
    [FriendOf(typeof(FriendComponent))]
    [EntitySystemOf(typeof(ES_ChatView))]
    [FriendOfAttribute(typeof(ES_ChatView))]
    public static partial class ES_ChatViewSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ChatView self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_FriendChatItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnFriendChatItemsRefresh);
            self.E_CloseChatButton.AddListener(self.OnCloseChatButton);
            self.E_SendButton.AddListenerAsync(self.OnSendButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_ChatView self)
        {
            self.DestroyWidget();
        }

        private static void OnFriendChatItemsRefresh(this ES_ChatView self, Transform transform, int index)
        {
            foreach (Scroll_Item_FriendChatItem item in self.ScrollItemFriendChatItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_FriendChatItem scrollItemFriendChatItem = self.ScrollItemFriendChatItems[index].BindTrans(transform);
            scrollItemFriendChatItem.Refresh(self.ShowChatInfos[index]);
        }

        public static void Refresh(this ES_ChatView self, FriendInfo friendInfo)
        {
            self.FriendInfo = friendInfo;
            using (zstring.Block())
            {
                self.E_ChatPlayNameText.text = zstring.Format("与{0}私聊中...", friendInfo.PlayerName);
            }

            self.RefreshFriendChatItems();
        }

        public static void RefreshFriendChatItems(this ES_ChatView self)
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
            self.UpdatePosition().Coroutine();
        }

        private static async ETTask UpdatePosition(this ES_ChatView self)
        {
            await self.Root().GetComponent<TimerComponent>().WaitAsync(100);
            RectTransform rectTransform = self.E_FriendChatItemsLoopVerticalScrollRect.transform.Find("Content").GetComponent<RectTransform>();
            if (rectTransform.sizeDelta.y > 600)
            {
                rectTransform.anchoredPosition = new Vector2(0, rectTransform.sizeDelta.y - 600);
            }
        }

        private static void OnCloseChatButton(this ES_ChatView self)
        {
            self.uiTransform.gameObject.SetActive(false);
        }

        private static async ETTask OnSendButton(this ES_ChatView self)
        {
            FlyTipComponent flyTipComponent = self.Root().GetComponent<FlyTipComponent>();
            string text = self.E_InputInputField.text;
            if (string.IsNullOrEmpty(text) || text.Length == 0)
            {
                flyTipComponent.ShowFlyTip("请输入聊天内容！");
                return;
            }

            int error = await ChatNetHelper.RequestSendChat(self.Root(), ChannelEnum.Friend, text, self.FriendInfo.UserId);
            if (error == ErrorCode.ERR_Success)
            {
                self.E_InputInputField.text = "";
            }
        }
    }
}
