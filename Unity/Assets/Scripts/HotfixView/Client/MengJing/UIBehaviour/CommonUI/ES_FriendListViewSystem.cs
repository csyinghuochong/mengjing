using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
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
            Scroll_Item_FriendListItem scrollItemFriendListItem = self.ScrollItemFriendListItems[index].BindTrans(transform);
            scrollItemFriendListItem.Refresh(self.ShowFriendInfos[index]);
        }

        private static void Refresh(this ES_FriendList self)
        {
            FriendComponent friendComponent = self.Root().GetComponent<FriendComponent>();
            self.ShowFriendInfos.Clear();
            self.ShowFriendInfos.AddRange(friendComponent.FriendList);

            self.AddUIScrollItems(ref self.ScrollItemFriendListItems, self.ShowFriendInfos.Count);
            self.E_FriendListItemsLoopVerticalScrollRect.SetVisible(true, self.ShowFriendInfos.Count);
        }
    }
}