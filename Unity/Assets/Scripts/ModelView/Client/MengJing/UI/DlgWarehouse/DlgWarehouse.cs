using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgWarehouseViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgWarehouse : Entity, IAwake, IUILogic
    {
        public DlgWarehouseViewComponent View { get => this.GetComponent<DlgWarehouseViewComponent>(); }
    }
}