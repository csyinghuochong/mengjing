namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPaiMaiSellPrice : Entity, IAwake, IUILogic
    {
        public DlgPaiMaiSellPriceViewComponent View
        {
            get => this.GetComponent<DlgPaiMaiSellPriceViewComponent>();
        }

        private EntityRef<ItemInfo> bagInfo;
        public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
        public int oldPrice;
        public int nowPrice;
        public int priceProNum;
        public int SellNum;
        public bool IsHoldDown;
    }
}