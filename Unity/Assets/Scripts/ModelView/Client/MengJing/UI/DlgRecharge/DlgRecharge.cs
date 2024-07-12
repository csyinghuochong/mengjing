using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgRecharge: Entity, IAwake, IUILogic
    {
        public DlgRechargeViewComponent View
        {
            get => this.GetComponent<DlgRechargeViewComponent>();
        }

        public int PayType; //1微信  2支付宝
        public int ReChargeNumber;

        public Dictionary<int, EntityRef<Scroll_Item_RechargeItem>> ScrollItemRechargeItems;
    }
}