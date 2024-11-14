namespace ET.Client
{
	[FriendOf(typeof(UIBaseWindow))]
	[AUIEvent(WindowID.WindowID_PetBar)]
	public  class DlgPetBarEventHandler : IAUIEventHandler
	{

		public void OnInitWindowCoreData(UIBaseWindow uiBaseWindow)
		{
		  uiBaseWindow.windowType = UIWindowType.Normal; 
		}

		public void OnInitComponent(UIBaseWindow uiBaseWindow)
		{
		  uiBaseWindow.AddComponent<DlgPetBar>().AddComponent<DlgPetBarViewComponent>();
		}

		public void OnRegisterUIEvent(UIBaseWindow uiBaseWindow)
		{
		  uiBaseWindow.GetComponent<DlgPetBar>().RegisterUIEvent(); 
		}

		public void OnShowWindow(UIBaseWindow uiBaseWindow, Entity contextData = null)
		{
		  uiBaseWindow.GetComponent<DlgPetBar>().ShowWindow(contextData); 
		}

		public void OnHideWindow(UIBaseWindow uiBaseWindow)
		{
		}

		public void BeforeUnload(UIBaseWindow uiBaseWindow)
		{
		}

	}
}
