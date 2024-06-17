namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgPaiMaiAuction: Entity, IAwake, IUILogic
    {
        public DlgPaiMaiAuctionViewComponent View
        {
            get => this.GetComponent<DlgPaiMaiAuctionViewComponent>();
        }

        public long AuctionTimer;
        public long LeftTime;
        public long AuctionStart; //起拍价
        public bool BaoZhenJin;

        public bool AuctionJoin;
    }
}