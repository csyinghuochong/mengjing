namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgSeasonLordDetail :Entity,IAwake,IUILogic
	{

		public DlgSeasonLordDetailViewComponent View { get => this.GetComponent<DlgSeasonLordDetailViewComponent>();} 

		 

	}
}
