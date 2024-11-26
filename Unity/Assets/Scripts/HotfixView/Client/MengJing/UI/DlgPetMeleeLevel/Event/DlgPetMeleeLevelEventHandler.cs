namespace ET.Client
{
	[FriendOf(typeof(UIBaseWindow))]
	[AUIEvent(WindowID.WindowID_PetMeleeLevel)]
	public  class DlgPetMeleeLevelEventHandler : IAUIEventHandler
	{

		public void OnInitWindowCoreData(UIBaseWindow uiBaseWindow)
		{
		  uiBaseWindow.windowType = UIWindowType.Normal; 
		}

		public void OnInitComponent(UIBaseWindow uiBaseWindow)
		{
		  uiBaseWindow.AddComponent<DlgPetMeleeLevel>().AddComponent<DlgPetMeleeLevelViewComponent>();
		}

		public void OnRegisterUIEvent(UIBaseWindow uiBaseWindow)
		{
		  uiBaseWindow.GetComponent<DlgPetMeleeLevel>().RegisterUIEvent(); 
		}

		public void OnShowWindow(UIBaseWindow uiBaseWindow, Entity contextData = null)
		{
		  uiBaseWindow.GetComponent<DlgPetMeleeLevel>().ShowWindow(contextData); 
		}

		public void OnHideWindow(UIBaseWindow uiBaseWindow)
		{
		}

		public void BeforeUnload(UIBaseWindow uiBaseWindow)
		{
		}

	}
}
