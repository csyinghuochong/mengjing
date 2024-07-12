using System;
using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgTrialReward : Entity, IAwake, IUILogic
    {
        public DlgTrialRewardViewComponent View
        {
            get => this.GetComponent<DlgTrialRewardViewComponent>();
        }

        public List<RankRewardConfig> ShowRankRewardConfigs;
        public Dictionary<int, EntityRef<Scroll_Item_RankRewardItem>> ScrollItemRankRewardItems;
        public Action ClickOnClose { get; set; }
    }
}