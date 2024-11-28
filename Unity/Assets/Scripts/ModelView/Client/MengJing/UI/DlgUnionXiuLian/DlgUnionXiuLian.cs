using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgUnionXiuLianViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgUnionXiuLian : Entity, IAwake, IUILogic
    {
        public DlgUnionXiuLianViewComponent View { get => this.GetComponent<DlgUnionXiuLianViewComponent>(); }
    }
}