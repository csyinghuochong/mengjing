using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetMelee : Entity, IAwake, IUILogic
    {
        public DlgPetMeleeViewComponent View { get => this.GetComponent<DlgPetMeleeViewComponent>(); }
    }
}