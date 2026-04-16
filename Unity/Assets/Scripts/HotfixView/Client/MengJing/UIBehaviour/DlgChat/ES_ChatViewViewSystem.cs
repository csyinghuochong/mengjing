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

            // self.E_FriendChatItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnFriendChatItemsRefresh);
            self.E_CloseChatButton.AddListener(self.OnCloseChatButton);
            self.E_InputInputField.onValueChanged.AddListener((string text) => { self.CheckSensitiveWords(); });
            self.E_SendButton.AddListenerAsync(self.OnSendButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_ChatView self)
        {
            self.DestroyWidget();
        }

        public static void CheckSensitiveWords(this ES_ChatView self)
        {
            string text_new = "";
            string text_old = self.E_InputInputField.text;
            MaskWordHelper.Instance.IsContainSensitiveWords(ref text_old, out text_new);
            self.E_InputInputField.text = text_old;
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

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.ShowChatInfos.Count; i++)
            {
                if (!self.ScrollItemFriendChatItems.ContainsKey(i))
                {
                    Scroll_Item_FriendChatItem item = self.AddChild<Scroll_Item_FriendChatItem>();
                    string path = "Assets/Bundles/UI/Item/Item_FriendChatItem.prefab";

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, self.E_FriendChatItemsLoopVerticalScrollRect.transform.Find("Content").gameObject.transform);
                    item.BindTrans(go.transform);
                    self.ScrollItemFriendChatItems.Add(i, item);
                }

                Scroll_Item_FriendChatItem scrollItemTaskGetItem = self.ScrollItemFriendChatItems[i];
                scrollItemTaskGetItem.uiTransform.gameObject.SetActive(true);
                scrollItemTaskGetItem.Refresh(self.ShowChatInfos[i]);
            }

            if (self.ScrollItemFriendChatItems.Count > self.ShowChatInfos.Count)
            {
                for (int i = self.ShowChatInfos.Count; i < self.ScrollItemFriendChatItems.Count; i++)
                {
                    Scroll_Item_FriendChatItem selfScrollItemFriendChatItem = self.ScrollItemFriendChatItems[i];
                    selfScrollItemFriendChatItem.uiTransform.gameObject.SetActive(false);
                }
            }

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

            bool mask = MaskWordHelper.Instance.IsContainSensitiveWords(text);
            if (mask)
            {
                flyTipComponent.ShowFlyTip("请重新输入！");
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
