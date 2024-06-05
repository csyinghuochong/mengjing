namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgSetting :Entity,IAwake,IUILogic
	{

		public DlgSettingViewComponent View { get => this.GetComponent<DlgSettingViewComponent>();} 

		 

	}
}
