namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgPaiMaiSellPrice: Entity, IAwake, IUILogic
    {
        public DlgPaiMaiSellPriceViewComponent View
        {
            get => this.GetComponent<DlgPaiMaiSellPriceViewComponent>();
        }

        public ItemInfo BagInfo { get; set; }
        public int oldPrice;
        public int nowPrice;
        public int priceProNum;
        public int SellNum;
        public bool IsHoldDown;
    }
}