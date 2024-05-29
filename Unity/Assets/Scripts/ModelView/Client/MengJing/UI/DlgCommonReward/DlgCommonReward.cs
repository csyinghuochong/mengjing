namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgCommonReward :Entity,IAwake,IUILogic
	{

		public DlgCommonRewardViewComponent View { get => this.GetComponent<DlgCommonRewardViewComponent>();} 

		 

	}
}
