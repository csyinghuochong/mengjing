namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgJiaYuanPlanWatch :Entity,IAwake,IUILogic
	{

		public DlgJiaYuanPlanWatchViewComponent View { get => this.GetComponent<DlgJiaYuanPlanWatchViewComponent>();} 

		 

	}
}
