namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class FangChenMiComponentC : Entity, IAwake, IDestroy
    {
        public long Timer;

        public bool IsHoliday;
        public bool StopServer;
    }
}