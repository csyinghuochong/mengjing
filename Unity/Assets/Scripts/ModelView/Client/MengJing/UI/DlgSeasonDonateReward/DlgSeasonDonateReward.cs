using System.Collections.Generic;

namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgSeasonDonateReward :Entity,IAwake,IUILogic
	{

		public DlgSeasonDonateRewardViewComponent View { get => this.GetComponent<DlgSeasonDonateRewardViewComponent>();} 

		 
		public Dictionary<int, EntityRef<Scroll_Item_SeasonDonateItem>> ScrollItemRechargeItems;
	}
}
