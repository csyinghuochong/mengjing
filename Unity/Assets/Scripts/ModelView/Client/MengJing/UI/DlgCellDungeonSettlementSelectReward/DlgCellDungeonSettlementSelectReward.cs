using System.Collections.Generic;

namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgCellDungeonSettlementSelectReward :Entity,IAwake,IUILogic
	{

		public DlgCellDungeonSettlementSelectRewardViewComponent View { get => this.GetComponent<DlgCellDungeonSettlementSelectRewardViewComponent>();} 

		public List<ES_SettlementReward> RewardUIList { get; set; } = new();

		public int LeftTime;
		public float Time;

		public int GetPassTime = 0;

		public bool topSelect = false;
		public bool bottomSelect = false;
		public long Timer;
	}
}
