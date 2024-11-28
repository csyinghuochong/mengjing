using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgJiaYuanPetViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgJiaYuanPet : Entity, IAwake, IUILogic
    {
        public DlgJiaYuanPetViewComponent View { get => this.GetComponent<DlgJiaYuanPetViewComponent>(); }
    }
}