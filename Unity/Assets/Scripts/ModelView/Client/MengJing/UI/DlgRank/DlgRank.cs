using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgRankViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgRank : Entity, IAwake, IUILogic
    {
        public DlgRankViewComponent View { get => this.GetComponent<DlgRankViewComponent>(); }
    }
}