namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgChouKaProbExplain :Entity,IAwake,IUILogic
	{

		public DlgChouKaProbExplainViewComponent View { get => this.GetComponent<DlgChouKaProbExplainViewComponent>();} 

		 

	}
}
