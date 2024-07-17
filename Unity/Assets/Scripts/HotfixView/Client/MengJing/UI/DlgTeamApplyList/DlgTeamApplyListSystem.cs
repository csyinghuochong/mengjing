using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (DlgTeamApplyList))]
    public static class DlgTeamApplyListSystem
    {
        public static void RegisterUIEvent(this DlgTeamApplyList self)
        {
            self.View.E_Img_ButtonButton.AddListener(self.OnImg_Button);
            self.View.E_TeamApplyItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnTeamApplyItemsRefresh);
        }

        public static void ShowWindow(this DlgTeamApplyList self, Entity contextData = null)
        {
            self.OnUpdateUI();
        }

        public static void OnImg_Button(this DlgTeamApplyList self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TeamApplyList);
        }

        private static void OnTeamApplyItemsRefresh(this DlgTeamApplyList self, Transform transform, int index)
        {
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