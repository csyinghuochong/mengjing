using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgTrialViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgTrial : Entity, IAwake, IUILogic
    {
        public DlgTrialViewComponent View { get => this.GetComponent<DlgTrialViewComponent>(); }
    }
}