namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgTowerOfSealMain :Entity,IAwake,IUILogic
	{

		public DlgTowerOfSealMainViewComponent View { get => this.GetComponent<DlgTowerOfSealMainViewComponent>();} 

		 

	}
}
