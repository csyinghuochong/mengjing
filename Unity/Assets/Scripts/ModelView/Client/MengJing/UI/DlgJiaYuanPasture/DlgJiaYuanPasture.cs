namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgJiaYuanPasture :Entity,IAwake,IUILogic
	{

		public DlgJiaYuanPastureViewComponent View { get => this.GetComponent<DlgJiaYuanPastureViewComponent>();} 

		 

	}
}
