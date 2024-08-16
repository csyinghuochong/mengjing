using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgBattleRecruit : Entity, IAwake, IUILogic
    {
        public DlgBattleRecruitViewComponent View { get => this.GetComponent<DlgBattleRecruitViewComponent>(); }

        public Dictionary<int, EntityRef<Scroll_Item_BattleRecruitItem>> ScrollItemBattleRecruitItems = new();
        public List<BattleSummonConfig> ShowBattleSummonInfos = new();

        public List<BattleSummonInfo> BattleSummonInfos = new();
    }
}