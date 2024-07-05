namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgJiaYuanWarehouse :Entity,IAwake,IUILogic
	{

		public DlgJiaYuanWarehouseViewComponent View { get => this.GetComponent<DlgJiaYuanWarehouseViewComponent>();} 

		 

	}
}
