using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgWelfareViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgWelfare : Entity, IAwake, IUILogic
    {
        public DlgWelfareViewComponent View { get => this.GetComponent<DlgWelfareViewComponent>(); }
    }
}