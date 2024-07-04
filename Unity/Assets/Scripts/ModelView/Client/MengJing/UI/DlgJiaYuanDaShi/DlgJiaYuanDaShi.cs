namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgJiaYuanDaShi :Entity,IAwake,IUILogic
	{

		public DlgJiaYuanDaShiViewComponent View { get => this.GetComponent<DlgJiaYuanDaShiViewComponent>();} 

		 

	}
}
