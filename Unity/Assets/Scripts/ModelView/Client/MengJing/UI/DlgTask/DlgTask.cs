using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgTaskViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgTask : Entity, IAwake, IUILogic
    {
        public DlgTaskViewComponent View { get => this.GetComponent<DlgTaskViewComponent>(); }
    }
}