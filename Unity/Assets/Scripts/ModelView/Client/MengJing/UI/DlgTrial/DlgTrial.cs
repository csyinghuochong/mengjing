namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgTrial :Entity,IAwake,IUILogic
	{

		public DlgTrialViewComponent View { get => this.GetComponent<DlgTrialViewComponent>();} 

		 

	}
}
