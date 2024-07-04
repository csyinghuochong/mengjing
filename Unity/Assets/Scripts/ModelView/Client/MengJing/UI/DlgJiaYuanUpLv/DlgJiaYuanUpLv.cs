namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgJiaYuanUpLv :Entity,IAwake,IUILogic
	{

		public DlgJiaYuanUpLvViewComponent View { get => this.GetComponent<DlgJiaYuanUpLvViewComponent>();} 

		 

	}
}
