namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgDemonMain :Entity,IAwake,IUILogic
	{

		public DlgDemonMainViewComponent View { get => this.GetComponent<DlgDemonMainViewComponent>();} 

		 

	}
}
