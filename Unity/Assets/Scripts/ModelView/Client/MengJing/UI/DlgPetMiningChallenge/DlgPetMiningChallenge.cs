namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPetMiningChallenge :Entity,IAwake,IUILogic
	{

		public DlgPetMiningChallengeViewComponent View { get => this.GetComponent<DlgPetMiningChallengeViewComponent>();} 

		 

	}
}
