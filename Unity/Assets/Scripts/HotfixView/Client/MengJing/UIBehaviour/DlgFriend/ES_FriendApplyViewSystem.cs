using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_FriendApplyItem))]
    [FriendOf(typeof (FriendComponent))]
    [EntitySystemOf(typeof (ES_FriendApply))]
    [FriendOfAttribute(typeof (ES_FriendApply))]
    public static partial class ES_FriendApplySystem
    {
        [EntitySystem]
        private static void Awake(this ES_FriendApply self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_FriendApplyItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnFriendBlackItemsRefresh);
            self.Refresh();
        }

        [EntitySystem]
        private static void Destroy(this ES_FriendApply self)
        {
            self.DestroyWidget();
        }

        private static void OnFriendBlackItemsRefresh(this ES_FriendApply self, Transform transform, int index)
        {
            foreach (Scroll_Item_FriendApplyItem item in self.ScrollItemFriendApplyItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_FriendApplyItem scrollItemFriendApplyItem = self.ScrollItemFriendApplyItems[index].BindTrans(transform);
            scrollItemFriendApplyItem.Refresh(self.ShowFriendInfos[index]);
        }

        public static void Refresh(this ES_FriendApply self)
        {
            self.ShowFriendInfos.Clear();
            self.ShowFriendInfos.AddRange(self.Root().GetComponent<FriendComponent>().ApplyList);
            
            self.AddUIScrollItems(ref self.ScrollItemFriendApplyItems, self.ShowFriendInfos.Count);
            self.E_FriendApplyItemsLoopVerticalScrollRect.SetVisible(true, self.ShowFriendInfos.Count);
        }
    }
}
