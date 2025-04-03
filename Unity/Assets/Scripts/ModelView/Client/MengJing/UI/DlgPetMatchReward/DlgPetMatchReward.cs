using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetMatchReward : Entity, IAwake, IUILogic
    {
        public DlgPetMatchRewardViewComponent View { get => this.GetComponent<DlgPetMatchRewardViewComponent>(); }
        public List<RankRewardConfig> ShowRankRewardConfigs;
        public Dictionary<int, EntityRef<Scroll_Item_RankRewardItem>> ScrollItemRankRewardItems;
    }
}