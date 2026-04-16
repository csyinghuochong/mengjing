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
            // self.E_FriendListItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnFriendListItemsRefresh);

            self.ES_ChatView.uiTransform.gameObject.SetActive(false);

            self.Refresh();
        }

        [EntitySystem]
        private static void Destroy(this ES_FriendList self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this ES_FriendList self)
        {
            FriendComponent friendComponent = self.Root().GetComponent<FriendComponent>();
            self.ShowFriendInfos.Clear();
            self.ShowFriendInfos.AddRange(friendComponent.FriendList);

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.ShowFriendInfos.Count; i++)
            {
                if (!self.ScrollItemFriendListItems.ContainsKey(i))
                {
                    Scroll_Item_FriendListItem item = self.AddChild<Scroll_Item_FriendListItem>();
                    string path = "Assets/Bundles/UI/Item/Item_FriendListItem.prefab";

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, self.E_FriendListItemsLoopVerticalScrollRect.transform.Find("Content").gameObject.transform);
                    item.BindTrans(go.transform);
                    self.ScrollItemFriendListItems.Add(i, item);
                }

                Scroll_Item_FriendListItem scrollItemFriendListItem = self.ScrollItemFriendListItems[i];
                scrollItemFriendListItem.uiTransform.gameObject.SetActive(true);
                scrollItemFriendListItem.Refresh(self.ShowFriendInfos[i], self.OnDeleteHandler, self.OnChatHandler, friendComponent.FriendChatId.Contains(friendComponent.FriendList[i].UserId));
            }

            if (self.ScrollItemFriendListItems.Count > self.ShowFriendInfos.Count)
            {
                for (int i = self.ShowFriendInfos.Count; i < self.ScrollItemFriendListItems.Count; i++)
                {
                    Scroll_Item_FriendListItem scrollItemFriendListItem = self.ScrollItemFriendListItems[i];
                    scrollItemFriendListItem.uiTransform.gameObject.SetActive(false);
                }
            }
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
