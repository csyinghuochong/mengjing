namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgSeasonMain :Entity,IAwake,IUILogic
	{

		public DlgSeasonMainViewComponent View { get => this.GetComponent<DlgSeasonMainViewComponent>();} 

		 

	}
}
