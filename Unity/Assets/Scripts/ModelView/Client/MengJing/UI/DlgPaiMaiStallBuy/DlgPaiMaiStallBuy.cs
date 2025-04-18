namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPaiMaiStallBuy : Entity, IAwake, IUILogic
    {
        public DlgPaiMaiStallBuyViewComponent View { get => this.GetComponent<DlgPaiMaiStallBuyViewComponent>(); }
        public PaiMaiItemInfo PaiMaiItemInfo;

        public int SellNum;
        public bool IsHoldDown;
    }
}