using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgSelectReward: Entity, IAwake, IUILogic
    {
        public DlgSelectRewardViewComponent View
        {
            get => this.GetComponent<DlgSelectRewardViewComponent>();
        }

        public string[] Items;
        public Dictionary<int, EntityRef<Scroll_Item_SelectRewardItem>> ScrollItemSelectRewardItems;
        public int Key;
        public int Type; // 0等级领取 1击败领取
    }
}