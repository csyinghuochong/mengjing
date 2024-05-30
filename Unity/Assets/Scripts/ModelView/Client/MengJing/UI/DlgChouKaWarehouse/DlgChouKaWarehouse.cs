namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgChouKaWarehouse :Entity,IAwake,IUILogic
	{

		public DlgChouKaWarehouseViewComponent View { get => this.GetComponent<DlgChouKaWarehouseViewComponent>();} 

		 

	}
}
