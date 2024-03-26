namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPet :Entity,IAwake,IUILogic
	{

		public DlgPetViewComponent View { get => this.GetComponent<DlgPetViewComponent>();} 

		 

	}
}
