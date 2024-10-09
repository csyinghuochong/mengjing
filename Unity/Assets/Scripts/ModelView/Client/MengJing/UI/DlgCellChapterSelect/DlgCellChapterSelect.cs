namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgCellChapterSelect :Entity,IAwake,IUILogic
	{

		public DlgCellChapterSelectViewComponent View { get => this.GetComponent<DlgCellChapterSelectViewComponent>();} 

		 

	}
}
