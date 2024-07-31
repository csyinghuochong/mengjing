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
    }
}