namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgItemBatchUse : Entity, IAwake, IUILogic
    {
        public DlgItemBatchUseViewComponent View { get => this.GetComponent<DlgItemBatchUseViewComponent>(); }

        private EntityRef<ItemInfo> bagInfo;
        public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
        public int UseNum;
        public bool IsHoldDown;
    }
}