namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgSettingFrame :Entity,IAwake,IUILogic
	{

		public DlgSettingFrameViewComponent View { get => this.GetComponent<DlgSettingFrameViewComponent>();} 

		 

	}
}
