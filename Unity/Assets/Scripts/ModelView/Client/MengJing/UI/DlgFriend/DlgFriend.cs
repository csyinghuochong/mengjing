using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgFriendViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgFriend : Entity, IAwake, IUILogic
    {
        public DlgFriendViewComponent View { get => this.GetComponent<DlgFriendViewComponent>(); }

        public bool ClickEnabled;
    }
}