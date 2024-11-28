using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgCountryViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgCountry : Entity, IAwake, IUILogic
    {
        public DlgCountryViewComponent View { get => this.GetComponent<DlgCountryViewComponent>(); }
    }
}