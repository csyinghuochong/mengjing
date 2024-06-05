namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgTower :Entity,IAwake,IUILogic
	{

		public DlgTowerViewComponent View { get => this.GetComponent<DlgTowerViewComponent>();} 

		 

	}
}
