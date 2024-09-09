namespace ET.Client
{
	[FriendOf(typeof(UIBaseWindow))]
	[AUIEvent(WindowID.WindowID_Skill)]
	public  class DlgSkillEventHandler : IAUIEventHandler
	{

		public void OnInitWindowCoreData(UIBaseWindow uiBaseWindow)
		{
		  uiBaseWindow.windowType = UIWindowType.Normal; 
		}

		public void OnInitComponent(UIBaseWindow uiBaseWindow)
		{
		  uiBaseWindow.AddComponent<DlgSkill>().AddComponent<DlgSkillViewComponent>();
		}

		public void OnRegisterUIEvent(UIBaseWindow uiBaseWindow)
		{
		  uiBaseWindow.GetComponent<DlgSkill>().RegisterUIEvent(); 
		}

		public void OnShowWindow(UIBaseWindow uiBaseWindow, Entity contextData = null)
		{
		  uiBaseWindow.GetComponent<DlgSkill>().ShowWindow(contextData); 
		}

		public void OnHideWindow(UIBaseWindow uiBaseWindow)
		{
		}

		public void BeforeUnload(UIBaseWindow uiBaseWindow)
		{
			uiBaseWindow.GetComponent<DlgSkill>().BeforeUnload(); 	
		}

	}
}
