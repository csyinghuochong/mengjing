namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgBaoXiangReward :Entity,IAwake,IUILogic
	{

		public DlgBaoXiangRewardViewComponent View { get => this.GetComponent<DlgBaoXiangRewardViewComponent>();} 

		 

	}
}
