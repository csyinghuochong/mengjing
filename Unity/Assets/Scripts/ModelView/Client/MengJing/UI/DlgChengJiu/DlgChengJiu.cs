using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgChengJiuViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgChengJiu : Entity, IAwake, IUILogic
    {
        public DlgChengJiuViewComponent View { get => this.GetComponent<DlgChengJiuViewComponent>(); }
    }
}