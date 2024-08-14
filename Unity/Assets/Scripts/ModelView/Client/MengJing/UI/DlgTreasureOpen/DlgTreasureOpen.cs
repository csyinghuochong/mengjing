namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgTreasureOpen :Entity,IAwake,IUILogic
	{

		public DlgTreasureOpenViewComponent View { get => this.GetComponent<DlgTreasureOpenViewComponent>();} 

		 

	}
}
