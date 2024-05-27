using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgRoleXiLianNumReward: Entity, IAwake, IUILogic
    {
        public DlgRoleXiLianNumRewardViewComponent View
        {
            get => this.GetComponent<DlgRoleXiLianNumRewardViewComponent>();
        }

        public Dictionary<int, Scroll_Item_ChouKaRewardItem> ScrollItemChouKaRewardItems;
        public List<int> ShowInfo = new();
    }
}