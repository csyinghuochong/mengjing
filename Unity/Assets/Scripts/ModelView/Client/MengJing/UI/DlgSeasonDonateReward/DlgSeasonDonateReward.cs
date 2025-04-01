namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgSeasonDonateReward :Entity,IAwake,IUILogic
	{

		public DlgSeasonDonateRewardViewComponent View { get => this.GetComponent<DlgSeasonDonateRewardViewComponent>();} 

		 

	}
}
