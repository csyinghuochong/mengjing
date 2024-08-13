namespace ET.Client
{
    [FriendOf(typeof (DlgRoleXiLianExplain))]
    public static class DlgRoleXiLianExplainSystem
    {
        public static void RegisterUIEvent(this DlgRoleXiLianExplain self)
        {
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_CloseButton);
        }

        public static void ShowWindow(this DlgRoleXiLianExplain self, Entity contextData = null)
        {
        }

        public static void OnBtn_CloseButton(this DlgRoleXiLianExplain self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_RoleXiLianExplain);
        }
    }
}
