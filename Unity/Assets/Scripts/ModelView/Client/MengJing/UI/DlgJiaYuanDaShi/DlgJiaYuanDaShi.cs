using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgJiaYuanDaShiViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgJiaYuanDaShi : Entity, IAwake, IUILogic
    {
        public DlgJiaYuanDaShiViewComponent View { get => this.GetComponent<DlgJiaYuanDaShiViewComponent>(); }
    }
}