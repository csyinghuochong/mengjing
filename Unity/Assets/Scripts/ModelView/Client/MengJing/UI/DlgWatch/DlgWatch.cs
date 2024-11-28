using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgWatchViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgWatch : Entity, IAwake, IUILogic
    {
        public DlgWatchViewComponent View
        {
            get => this.GetComponent<DlgWatchViewComponent>();
        }

        public F2C_WatchPlayerResponse F2C_WatchPlayerResponse { get; set; }
        public bool CanClick;
    }
}