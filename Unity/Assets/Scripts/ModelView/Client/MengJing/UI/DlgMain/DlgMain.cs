namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgMain :Entity,IAwake,IUILogic
	{

		public DlgMainViewComponent View { get => this.GetComponent<DlgMainViewComponent>();} 

		 

	}
}
