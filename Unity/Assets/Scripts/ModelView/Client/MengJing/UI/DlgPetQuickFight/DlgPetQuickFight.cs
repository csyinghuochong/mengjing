namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPetQuickFight :Entity,IAwake,IUILogic
	{

		public DlgPetQuickFightViewComponent View { get => this.GetComponent<DlgPetQuickFightViewComponent>();} 

		 

	}
}
