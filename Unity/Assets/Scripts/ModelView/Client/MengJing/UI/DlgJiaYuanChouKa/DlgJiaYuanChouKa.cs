namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgJiaYuanChouKa :Entity,IAwake,IUILogic
	{

		public DlgJiaYuanChouKaViewComponent View { get => this.GetComponent<DlgJiaYuanChouKaViewComponent>();} 

		 

	}
}
