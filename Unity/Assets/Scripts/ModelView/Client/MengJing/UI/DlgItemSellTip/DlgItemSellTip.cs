namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgItemSellTip : Entity, IAwake, IUILogic
    {
        public DlgItemSellTipViewComponent View
        {
            get => this.GetComponent<DlgItemSellTipViewComponent>();
        }

        public long Num;

        private EntityRef<ItemInfo> bagInfo;
        public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
    }
}