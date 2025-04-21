namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgSingleHappyMain :Entity,IAwake,IUILogic
	{

		public DlgSingleHappyMainViewComponent View { get => this.GetComponent<DlgSingleHappyMainViewComponent>();}

		public long Timer;

		public long RecoverTime;

	}
}
