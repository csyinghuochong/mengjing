using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgHuntViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgHunt : Entity, IAwake, IUILogic
    {
        public DlgHuntViewComponent View { get => this.GetComponent<DlgHuntViewComponent>(); }
    }
}