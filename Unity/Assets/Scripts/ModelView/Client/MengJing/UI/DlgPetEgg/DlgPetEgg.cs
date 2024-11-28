using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgPetEggViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetEgg : Entity, IAwake, IUILogic
    {
        public DlgPetEggViewComponent View { get => this.GetComponent<DlgPetEggViewComponent>(); }
    }
}