namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPetBattleFormation :Entity,IAwake,IUILogic
	{

		public DlgPetBattleFormationViewComponent View { get => this.GetComponent<DlgPetBattleFormationViewComponent>();} 

		 

	}
}
