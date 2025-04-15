using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgTreasureOpen : Entity, IAwake, IUILogic
    {
        public DlgTreasureOpenViewComponent View { get => this.GetComponent<DlgTreasureOpenViewComponent>(); }

        public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
        public List<int> RewardShowItems = new();
        public ItemInfo BagInfo { get; set; }

        public long Interval = 0; //匀速
        public int TargetIndex = 0;
        public int CurrentIndex = 0;
        public bool OnStopTurn;
        public bool ifStop;
    }
}