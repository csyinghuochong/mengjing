namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgArenaMain :Entity,IAwake,IUILogic
	{

		public DlgArenaMainViewComponent View { get => this.GetComponent<DlgArenaMainViewComponent>();} 

		 

	}
}
