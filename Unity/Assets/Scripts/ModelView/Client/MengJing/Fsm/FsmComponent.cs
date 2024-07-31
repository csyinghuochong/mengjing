namespace ET.Client
{
    //动画状态机组件
    [ComponentOf(typeof(Unit))]
    public class FsmComponent : Entity, IAwake, IDestroy
    {
        public int CurrentFsm;

        public long Timer;

        public long WaitIdleTime;

        public string LastAnimator;

        public bool Act_1;
        public bool Act_2;
        public bool Act_3;
    }
}