using System;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgPaiMaiBuyTip: Entity, IAwake, IUILogic
    {
        public DlgPaiMaiBuyTipViewComponent View
        {
            get => this.GetComponent<DlgPaiMaiBuyTipViewComponent>();
        }

        public Action<int> BuyAction;
        public int BuyNum;
        public PaiMaiItemInfo PaiMaiItemInfo;
    }
}