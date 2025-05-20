namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgDragonDungeonSettlement :Entity,IAwake,IUILogic
	{

		public DlgDragonDungeonSettlementViewComponent View { get => this.GetComponent<DlgDragonDungeonSettlementViewComponent>();} 

		 

	}
}
