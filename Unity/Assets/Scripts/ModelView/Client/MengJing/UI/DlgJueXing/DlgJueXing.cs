using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgJueXingViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgJueXing : Entity, IAwake, IUILogic
    {
        public DlgJueXingViewComponent View { get => this.GetComponent<DlgJueXingViewComponent>(); }
    }
}