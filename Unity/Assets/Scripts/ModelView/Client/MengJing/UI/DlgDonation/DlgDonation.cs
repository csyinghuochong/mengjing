using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_RoleBag))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgDonation : Entity, IAwake, IUILogic
    {
        public DlgDonationViewComponent View { get => this.GetComponent<DlgDonationViewComponent>(); }
    }
}