namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgJiaYuanMain :Entity,IAwake,IUILogic
	{

		public DlgJiaYuanMainViewComponent View { get => this.GetComponent<DlgJiaYuanMainViewComponent>();} 

		 

	}
}
