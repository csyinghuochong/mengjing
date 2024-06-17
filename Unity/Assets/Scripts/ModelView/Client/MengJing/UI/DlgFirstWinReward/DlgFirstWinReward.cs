namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgFirstWinReward: Entity, IAwake, IUILogic
    {
        public DlgFirstWinRewardViewComponent View
        {
            get => this.GetComponent<DlgFirstWinRewardViewComponent>();
        }

        public int FristWinId;
    }
}