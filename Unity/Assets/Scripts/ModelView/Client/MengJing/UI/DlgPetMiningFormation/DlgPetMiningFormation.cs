namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPetMiningFormation :Entity,IAwake,IUILogic
	{

		public DlgPetMiningFormationViewComponent View { get => this.GetComponent<DlgPetMiningFormationViewComponent>();} 

		 

	}
}
