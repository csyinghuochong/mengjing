namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPetMeleeMain :Entity,IAwake,IUILogic
	{

		public DlgPetMeleeMainViewComponent View { get => this.GetComponent<DlgPetMeleeMainViewComponent>();} 

		 

	}
}
