namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgJueXing :Entity,IAwake,IUILogic
	{

		public DlgJueXingViewComponent View { get => this.GetComponent<DlgJueXingViewComponent>();} 

		 

	}
}
