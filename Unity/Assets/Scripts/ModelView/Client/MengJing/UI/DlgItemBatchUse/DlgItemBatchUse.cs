namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgItemBatchUse : Entity, IAwake, IUILogic
    {
        public DlgItemBatchUseViewComponent View { get => this.GetComponent<DlgItemBatchUseViewComponent>(); }

        public ItemInfo BagInfo { get; set; }
        public int UseNum;
        public bool IsHoldDown;
    }
}