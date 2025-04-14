using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_UnionApplyListItem))]
    [FriendOf(typeof(DlgUnionApplyList))]
    public static class DlgUnionApplyListSystem
    {
        public static void RegisterUIEvent(this DlgUnionApplyList self)
        {
            self.View.E_UnionApplyListItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnUnionApplyListItemsRefresh);
            self.View.E_ImageButtonButton.AddListener(self.ImageButton);

            self.OnUpdateUI().Coroutine();
        }

        public static void ShowWindow(this DlgUnionApplyList self, Entity contextData = null)
        {
        }

        private static void OnUnionApplyListItemsRefresh(this DlgUnionApplyList self, Transform transform, int index)
        {
            foreach (Scroll_Item_UnionApplyListItem item in self.ScrollItemUnionApplyListItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_UnionApplyListItem scrollItemUnionApplyListItem = self.ScrollItemUnionApplyListItems[index].BindTrans(transform);
            scrollItemUnionApplyListItem.OnUpdateUI(self.ApplyPlayerInfos[index]);
        }

        public static void ImageButton(this DlgUnionApplyList self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_UnionApplyList);
            self.ActionFunc?.Invoke();
        }

        public static void OnUnionApplyReply(this DlgUnionApplyList self, long userId)
        {
            for (int i = self.ApplyPlayerInfos.Count - 1; i >= 0; i--)
            {
                if (self.ApplyPlayerInfos[i].UserID == userId)
                {
                    self.ApplyPlayerInfos.RemoveAt(i);
                }
            }

            self.UpdatePlayerList();
        }

        public static void UpdatePlayerList(this DlgUnionApplyList self)
        {
            self.AddUIScrollItems(ref self.ScrollItemUnionApplyListItems, self.ApplyPlayerInfos.Count);
            self.View.E_UnionApplyListItemsLoopVerticalScrollRect.SetVisible(true, self.ApplyPlayerInfos.Count);
        }

        public static async ETTask OnUpdateUI(this DlgUnionApplyList self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            long unionId = unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.UnionId_0);

            U2C_UnionApplyListResponse response = await UnionNetHelper.UnionApplyListRequest(self.Root(), unionId);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.ApplyPlayerInfos = response.UnionPlayerList;
            self.UpdatePlayerList();
        }
    }
}