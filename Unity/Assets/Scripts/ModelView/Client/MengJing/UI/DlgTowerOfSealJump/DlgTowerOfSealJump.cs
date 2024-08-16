namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgTowerOfSealJump : Entity, IAwake, IUILogic
    {
        public DlgTowerOfSealJumpViewComponent View { get => this.GetComponent<DlgTowerOfSealJumpViewComponent>(); }

        public int Finished;
        public int DiceResult;
        public int CostType; // 10之前花钻石 11之前花门票
    }
}