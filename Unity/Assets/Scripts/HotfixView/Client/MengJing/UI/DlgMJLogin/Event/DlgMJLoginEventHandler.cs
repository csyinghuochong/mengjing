namespace ET.Client
{
    [FriendOf(typeof(UIBaseWindow))]
    [AUIEvent(WindowID.WindowID_MJLogin)]
    public class DlgMJLoginEventHandler : IAUIEventHandler
    {

        public void OnInitWindowCoreData(UIBaseWindow uiBaseWindow)
        {
            uiBaseWindow.windowType = UIWindowType.Normal;
        }

        public void OnInitComponent(UIBaseWindow uiBaseWindow)
        {
            uiBaseWindow.AddComponent<DlgMJLogin>().AddComponent<DlgMJLoginViewComponent>();
        }

        public void OnRegisterUIEvent(UIBaseWindow uiBaseWindow)
        {
            uiBaseWindow.GetComponent<DlgMJLogin>().RegisterUIEvent();
        }

        public void OnShowWindow(UIBaseWindow uiBaseWindow, Entity contextData = null)
        {
            uiBaseWindow.GetComponent<DlgMJLogin>().ShowWindow(contextData);
        }

        public void OnHideWindow(UIBaseWindow uiBaseWindow)
        {
        }

        public void BeforeUnload(UIBaseWindow uiBaseWindow)
        {
        }

    }
}
