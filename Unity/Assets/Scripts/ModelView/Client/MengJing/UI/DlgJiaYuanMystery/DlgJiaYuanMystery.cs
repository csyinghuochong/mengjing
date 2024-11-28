using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgJiaYuanMysteryViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgJiaYuanMystery : Entity, IAwake, IUILogic
    {
        public DlgJiaYuanMysteryViewComponent View { get => this.GetComponent<DlgJiaYuanMysteryViewComponent>(); }
    }
}