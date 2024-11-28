using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgZuoQiViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgZuoQi : Entity, IAwake, IUILogic
    {
        public DlgZuoQiViewComponent View { get => this.GetComponent<DlgZuoQiViewComponent>(); }
    }
}