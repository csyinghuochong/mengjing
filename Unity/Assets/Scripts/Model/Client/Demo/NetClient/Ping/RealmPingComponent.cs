namespace ET.Client
{
    [ComponentOf(typeof(Session))]
    public class RealmPingComponent: Entity, IAwake, IDestroy
    {
        public long Ping { get; set; } //延迟值
        
        public long Timer { get; set; }
    }
}