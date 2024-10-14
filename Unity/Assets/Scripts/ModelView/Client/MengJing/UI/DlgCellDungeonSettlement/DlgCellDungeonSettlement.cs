namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgCellDungeonSettlement :Entity,IAwake,IUILogic
	{

		public DlgCellDungeonSettlementViewComponent View { get => this.GetComponent<DlgCellDungeonSettlementViewComponent>();} 

		 

	}
}
