namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPetMiningReward :Entity,IAwake,IUILogic
	{

		public DlgPetMiningRewardViewComponent View { get => this.GetComponent<DlgPetMiningRewardViewComponent>();} 

		 

	}
}
