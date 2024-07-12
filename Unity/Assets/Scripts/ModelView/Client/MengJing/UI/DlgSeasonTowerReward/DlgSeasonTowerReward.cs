using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgSeasonTowerReward: Entity, IAwake, IUILogic
    {
        public DlgSeasonTowerRewardViewComponent View
        {
            get => this.GetComponent<DlgSeasonTowerRewardViewComponent>();
        }

        public List<RankRewardConfig> ShowRankRewardConfigs;
        public Dictionary<int, EntityRef<Scroll_Item_RankRewardItem>> ScrollItemRankRewardItems;
    }
}