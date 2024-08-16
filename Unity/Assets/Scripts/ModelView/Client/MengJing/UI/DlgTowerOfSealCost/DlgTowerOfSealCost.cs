namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgTowerOfSealCost :Entity,IAwake,IUILogic
	{

		public DlgTowerOfSealCostViewComponent View { get => this.GetComponent<DlgTowerOfSealCostViewComponent>();} 

		 

	}
}
