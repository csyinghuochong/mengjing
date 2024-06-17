namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgSeason :Entity,IAwake,IUILogic
	{

		public DlgSeasonViewComponent View { get => this.GetComponent<DlgSeasonViewComponent>();} 

		 

	}
}
