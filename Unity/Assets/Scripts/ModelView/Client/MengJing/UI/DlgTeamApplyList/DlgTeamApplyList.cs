using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgTeamApplyList : Entity, IAwake, IUILogic
    {
        public DlgTeamApplyListViewComponent View
        {
            get => this.GetComponent<DlgTeamApplyListViewComponent>();
        }

        public List<TeamPlayerInfo> ShowTeamPlayerInfos;
        public Dictionary<int, EntityRef<Scroll_Item_TeamApplyItem>> ScrollItemTeamApplyItems;
    }
}