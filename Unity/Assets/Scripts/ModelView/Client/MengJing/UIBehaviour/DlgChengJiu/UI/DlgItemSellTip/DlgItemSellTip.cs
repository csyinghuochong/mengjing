namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgItemSellTip: Entity, IAwake, IUILogic
    {
        public DlgItemSellTipViewComponent View
        {
            get => this.GetComponent<DlgItemSellTipViewComponent>();
        }

        public long Num;
        public BagInfo BagInfo;
    }
}