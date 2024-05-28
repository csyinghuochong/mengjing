namespace ET.Client
{
	[FriendOf(typeof(UIBaseWindow))]
	[AUIEvent(WindowID.WindowID_Store)]
	public  class DlgStoreEventHandler : IAUIEventHandler
	{

		public void OnInitWindowCoreData(UIBaseWindow uiBaseWindow)
		{
		  uiBaseWindow.windowType = UIWindowType.Normal; 
		}

		public void OnInitComponent(UIBaseWindow uiBaseWindow)
		{
		  uiBaseWindow.AddComponent<DlgStore>().AddComponent<DlgStoreViewComponent>();
		}

		public void OnRegisterUIEvent(UIBaseWindow uiBaseWindow)
		{
		  uiBaseWindow.GetComponent<DlgStore>().RegisterUIEvent(); 
		}

		public void OnShowWindow(UIBaseWindow uiBaseWindow, Entity contextData = null)
		{
		  uiBaseWindow.GetComponent<DlgStore>().ShowWindow(contextData); 
		}

		public void OnHideWindow(UIBaseWindow uiBaseWindow)
		{
		}

		public void BeforeUnload(UIBaseWindow uiBaseWindow)
		{
		}

	}
}
