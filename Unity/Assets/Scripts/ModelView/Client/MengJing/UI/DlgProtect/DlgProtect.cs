using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgProtectViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgProtect : Entity, IAwake, IUILogic
    {
        public DlgProtectViewComponent View { get => this.GetComponent<DlgProtectViewComponent>(); }
    }
}