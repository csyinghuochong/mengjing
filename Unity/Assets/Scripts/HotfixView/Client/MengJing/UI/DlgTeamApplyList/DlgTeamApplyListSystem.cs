using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_TeamApplyItem))]
    [FriendOf(typeof (DlgTeamApplyList))]
    public static class DlgTeamApplyListSystem
    {
        public static void RegisterUIEvent(this DlgTeamApplyList self)
        {
            self.View.E_Img_ButtonButton.AddListener(self.OnImg_ButtonButton);
            self.View.E_TeamApplyItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnTeamApplyItemsRefresh);
            
            self.OnUpdateUI();
        }

        public static void ShowWindow(this DlgTeamApplyList self, Entity contextData = null)
        {
        }

        public static void OnImg_ButtonButton(this DlgTeamApplyList self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TeamApplyList);
        }

        private static void OnTeamApplyItemsRefresh(this DlgTeamApplyList self, Transform transform, int index)
        {
            foreach (Scroll_Item_TeamApplyItem item in self.ScrollItemTeamApplyItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_TeamApplyItem scrollItemTeamApplyItem = self.ScrollItemTeamApplyItems[index].BindTrans(transform);
            scrollItemTeamApplyItem.OnUpdateUI(self.ShowTeamPlayerInfos[index]);
        }

        public static void OnUpdateUI(this DlgTeamApplyList self)
        {
            self.ShowTeamPlayerInfos = self.Root().GetComponent<TeamComponentC>().ApplyList;

            self.AddUIScrollItems(ref self.ScrollItemTeamApplyItems, self.ShowTeamPlayerInfos.Count);
            self.View.E_TeamApplyItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTeamPlayerInfos.Count);
        }
    }
}
