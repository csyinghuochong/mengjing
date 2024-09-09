namespace ET.Client
{
    [FriendOf(typeof (UIBaseWindow))]
    [AUIEvent(WindowID.WindowID_Role)]
    public class DlgRoleEventHandler: IAUIEventHandler
    {
        public void OnInitWindowCoreData(UIBaseWindow uiBaseWindow)
        {
            uiBaseWindow.windowType = UIWindowType.Normal;
        }

        public void OnInitComponent(UIBaseWindow uiBaseWindow)
        {
            uiBaseWindow.AddComponent<DlgRole>().AddComponent<DlgRoleViewComponent>();
        }

        public void OnRegisterUIEvent(UIBaseWindow uiBaseWindow)
        {
            uiBaseWindow.GetComponent<DlgRole>().RegisterUIEvent();
        }

        public void OnShowWindow(UIBaseWindow uiBaseWindow, Entity contextData = null)
        {
            uiBaseWindow.GetComponent<DlgRole>().ShowWindow(contextData);
        }

        public void OnHideWindow(UIBaseWindow uiBaseWindow)
        {
        }

        public void BeforeUnload(UIBaseWindow uiBaseWindow)
        {
            uiBaseWindow.GetComponent<DlgRole>().BeforeUnload();
        }
    }
}