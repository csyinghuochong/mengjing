namespace ET.Client
{
    
    [FriendOf(typeof(DlgFriend))]
    public static class DlgFriendSystem
    {
        public static void RegisterUIEvent(this DlgFriend self)
        {
           
        }

        public static void ShowWindow(this DlgFriend self, Entity contextData = null)
        {
           
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.ShowWindow(WindowID.WindowID_HuoBiSet);
            uiComponent.GetDlgLogic<DlgHuoBiSet>().AddCloseEvent(self.OnCloseButton);

        }
        
        private static void OnCloseButton(this DlgFriend self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

            uiComponent.CloseWindow(WindowID.WindowID_Friend);
        }
    }
    
}

