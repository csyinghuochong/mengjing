using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetBar : Entity, IAwake, IUILogic
    {
        public DlgPetBarViewComponent View { get => this.GetComponent<DlgPetBarViewComponent>(); }
    }
}