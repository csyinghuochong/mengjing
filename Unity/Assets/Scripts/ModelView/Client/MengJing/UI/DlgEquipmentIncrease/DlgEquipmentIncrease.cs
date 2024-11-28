using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgEquipmentIncrease : Entity, IAwake, IUILogic
    {
        public DlgEquipmentIncreaseViewComponent View { get => this.GetComponent<DlgEquipmentIncreaseViewComponent>(); }
    }
}