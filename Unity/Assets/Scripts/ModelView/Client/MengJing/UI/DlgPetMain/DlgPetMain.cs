namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPetMain :Entity,IAwake,IUILogic
	{

		public DlgPetMainViewComponent View { get => this.GetComponent<DlgPetMainViewComponent>();} 

		 

	}
}
