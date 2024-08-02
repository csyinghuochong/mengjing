namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgTeamDungeonSettlement :Entity,IAwake,IUILogic
	{

		public DlgTeamDungeonSettlementViewComponent View { get => this.GetComponent<DlgTeamDungeonSettlementViewComponent>();} 

		 

	}
}
