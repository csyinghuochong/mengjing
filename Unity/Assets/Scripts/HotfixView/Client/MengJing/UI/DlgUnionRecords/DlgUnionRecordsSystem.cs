using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_UnionRecordsItem))]
    [FriendOf(typeof (DlgUnionRecords))]
    public static class DlgUnionRecordsSystem
    {
        public static void RegisterUIEvent(this DlgUnionRecords self)
        {
            self.View.E_ButtonCloseButton.AddListener(self.OnButtonClose);
            self.View.E_UnionRecordsItemLoopVerticalScrollRect.AddItemRefreshListener(self.OnUnionRecordsItemsRefresh);
        }

        public static void ShowWindow(this DlgUnionRecords self, Entity contextData = null)
        {
        }

        public static void Refresh(this DlgUnionRecords self, UnionInfo unionInfo)
        {
            self.ShowInfo.Clear();
            self.ShowInfo.AddRange(unionInfo.ActiveRecord);

            self.AddUIScrollItems(ref self.ScrollItemUnionRecordsItems, self.ShowInfo.Count);
            self.View.E_UnionRecordsItemLoopVerticalScrollRect.SetVisible(true, self.ShowInfo.Count);
        }

        private static void OnUnionRecordsItemsRefresh(this DlgUnionRecords self, Transform transform, int index)
        {
            foreach (Scroll_Item_UnionRecordsItem item in self.ScrollItemUnionRecordsItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_UnionRecordsItem scrollItemChatItem = self.ScrollItemUnionRecordsItems[index].BindTrans(transform);
            scrollItemChatItem.Refresh(self.ShowInfo[index]);
        }

        public static void OnButtonClose(this DlgUnionRecords self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_UnionRecords);
        }
    }
}