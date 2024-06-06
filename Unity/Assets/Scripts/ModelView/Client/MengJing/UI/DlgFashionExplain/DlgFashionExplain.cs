namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgFashionExplain :Entity,IAwake,IUILogic
	{

		public DlgFashionExplainViewComponent View { get => this.GetComponent<DlgFashionExplainViewComponent>();} 

		 

	}
}
