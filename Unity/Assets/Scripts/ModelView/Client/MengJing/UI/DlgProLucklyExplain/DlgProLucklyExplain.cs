namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgProLucklyExplain :Entity,IAwake,IUILogic
	{

		public DlgProLucklyExplainViewComponent View { get => this.GetComponent<DlgProLucklyExplainViewComponent>();} 

		 

	}
}
