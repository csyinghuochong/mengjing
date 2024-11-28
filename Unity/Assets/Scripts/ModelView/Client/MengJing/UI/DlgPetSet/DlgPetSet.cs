using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgPetSetViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetSet : Entity, IAwake, IUILogic
    {
        public DlgPetSetViewComponent View { get => this.GetComponent<DlgPetSetViewComponent>(); }
    }
}