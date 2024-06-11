namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgTowerOfSeal :Entity,IAwake,IUILogic
	{

		public DlgTowerOfSealViewComponent View { get => this.GetComponent<DlgTowerOfSealViewComponent>();} 

		 

	}
}
