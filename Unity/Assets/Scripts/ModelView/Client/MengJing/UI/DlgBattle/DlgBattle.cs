using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgBattleViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgBattle : Entity, IAwake, IUILogic
    {
        public DlgBattleViewComponent View { get => this.GetComponent<DlgBattleViewComponent>(); }
    }
}