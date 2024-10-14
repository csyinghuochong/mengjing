namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgCellChapterOpen :Entity,IAwake,IUILogic
	{

		public DlgCellChapterOpenViewComponent View { get => this.GetComponent<DlgCellChapterOpenViewComponent>();} 

		 

	}
}
