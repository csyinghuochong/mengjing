namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgTrialMain: Entity, IAwake, IUILogic
    {
        public DlgTrialMainViewComponent View
        {
            get => this.GetComponent<DlgTrialMainViewComponent>();
        }
        
        public long Timer;
        public long LastTiaoZhan;
        public long BeginTime;
        public long HurtValue;  
    }
}