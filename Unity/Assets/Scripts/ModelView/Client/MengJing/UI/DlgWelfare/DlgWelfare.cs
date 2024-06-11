namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgWelfare :Entity,IAwake,IUILogic
	{

		public DlgWelfareViewComponent View { get => this.GetComponent<DlgWelfareViewComponent>();} 

		 

	}
}
