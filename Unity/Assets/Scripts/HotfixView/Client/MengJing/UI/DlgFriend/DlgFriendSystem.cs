namespace ET.Client
{
    
    [FriendOf(typeof(DlgFriend))]
    [FriendOf(typeof (DlgFriendBlack))]
    [FriendOf(typeof (DlgFriendList))]
    [FriendOf(typeof (ES_RoleBag))]
    public static class DlgFriendSystem
    {
        public static void RegisterUIEvent(this DlgFriend self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgFriend self, Entity contextData = null)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.ShowWindow(WindowID.WindowID_HuoBiSet);
            uiComponent.GetDlgLogic<DlgHuoBiSet>().AddCloseEvent(self.OnCloseButton);

        }
        
        private static void OnFunctionSetBtn(this DlgFriend self, int index)
        {
            Log.Debug($"按下Toggle：{index}");
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            
            self.View.ES_DlgFriendList.uiTransform.gameObject.SetActive(false);
            self.View.ES_DlgFriendBlack.uiTransform.gameObject.SetActive(false);
            switch (index)
            {
                case 0:
                    self.View.ES_DlgFriendList.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_DlgFriendBlack.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }
        
        private static void OnCloseButton(this DlgFriend self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

            uiComponent.CloseWindow(WindowID.WindowID_Friend);
        }
    }
    
}

