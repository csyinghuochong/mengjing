using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgRoleXiLianViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgRoleXiLian : Entity, IAwake, IUILogic
    {
        public DlgRoleXiLianViewComponent View { get => this.GetComponent<DlgRoleXiLianViewComponent>(); }
    }
}