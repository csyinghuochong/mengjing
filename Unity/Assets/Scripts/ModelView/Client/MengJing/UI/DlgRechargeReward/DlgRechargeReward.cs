namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgRechargeReward: Entity, IAwake, IUILogic
    {
        public DlgRechargeRewardViewComponent View
        {
            get => this.GetComponent<DlgRechargeRewardViewComponent>();
        }

        public int CurrentIndex;
    }
}