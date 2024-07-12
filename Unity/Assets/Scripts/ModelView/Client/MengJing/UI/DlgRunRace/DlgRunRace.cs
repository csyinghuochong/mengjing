using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgRunRace: Entity, IAwake, IUILogic
    {
        public DlgRunRaceViewComponent View
        {
            get => this.GetComponent<DlgRunRaceViewComponent>();
        }

        public List<RankRewardConfig> ShowRankRewardConfigs;
        public Dictionary<int, EntityRef<Scroll_Item_RunRaceItem>> ScrollItemRunRaceItems;
    }
}