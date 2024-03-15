namespace ET.Server
{
    
    [ComponentOf(typeof(Unit))]
    public class ReviveTimeComponent : Entity, IAwake<long>, IDestroy
    {
        public long Timer;
    }
}