using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgJiaYuanPastureViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgJiaYuanPasture : Entity, IAwake, IUILogic
    {
        public DlgJiaYuanPastureViewComponent View { get => this.GetComponent<DlgJiaYuanPastureViewComponent>(); }
    }
}