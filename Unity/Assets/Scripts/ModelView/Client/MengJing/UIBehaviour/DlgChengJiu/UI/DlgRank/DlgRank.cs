namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgRank :Entity,IAwake,IUILogic
	{

		public DlgRankViewComponent View { get => this.GetComponent<DlgRankViewComponent>();} 

		 

	}
}
