namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgTowerFightReward :Entity,IAwake,IUILogic
	{

		public DlgTowerFightRewardViewComponent View { get => this.GetComponent<DlgTowerFightRewardViewComponent>();} 

		 

	}
}
