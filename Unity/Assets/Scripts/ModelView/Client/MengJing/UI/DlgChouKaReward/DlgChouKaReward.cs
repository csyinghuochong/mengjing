using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgChouKaReward: Entity, IAwake, IUILogic
    {
        public DlgChouKaRewardViewComponent View
        {
            get => this.GetComponent<DlgChouKaRewardViewComponent>();
        }

        public List<TakeCardRewardConfig> TakeCardRewardConfigs;
        public Dictionary<int, EntityRef<Scroll_Item_ChouKaRewardItem>> ScrollItemChouKaRewardItems = new();
        public List<string> AssetList { get; set; } = new();
    }
}