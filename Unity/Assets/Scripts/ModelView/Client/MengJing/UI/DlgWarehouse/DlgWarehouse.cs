namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgWarehouse: Entity, IAwake, IUILogic
    {
        public DlgWarehouseViewComponent View
        {
            get => this.GetComponent<DlgWarehouseViewComponent>();
        }
    }
}