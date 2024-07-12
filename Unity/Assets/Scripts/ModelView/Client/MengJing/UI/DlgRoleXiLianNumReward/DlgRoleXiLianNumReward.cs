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

        public Dictionary<int, EntityRef<Scroll_Item_RoleXiLianNumRewardItem>> ScrollItemRoleXiLianNumRewardItems;
        public List<int> ShowInfo = new();
    }
}