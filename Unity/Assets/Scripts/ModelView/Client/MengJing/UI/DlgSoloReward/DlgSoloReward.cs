namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgSoloReward :Entity,IAwake,IUILogic
	{

		public DlgSoloRewardViewComponent View { get => this.GetComponent<DlgSoloRewardViewComponent>();} 

		 

	}
}
