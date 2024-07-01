namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgTowerOpen :Entity,IAwake,IUILogic
	{

		public DlgTowerOpenViewComponent View { get => this.GetComponent<DlgTowerOpenViewComponent>();} 

		 

	}
}
