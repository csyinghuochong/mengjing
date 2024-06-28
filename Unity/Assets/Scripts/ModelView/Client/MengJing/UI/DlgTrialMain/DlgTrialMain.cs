namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgTrialMain: Entity, IAwake, IUILogic
    {
        public DlgTrialMainViewComponent View
        {
            get => this.GetComponent<DlgTrialMainViewComponent>();
        }

        public int Countdown;
        public long Timer;
        public long LastTiaoZhan;
        public long HurtValue;
        public float FightTime;
    }
}