namespace ET.Client
{
    [ComponentOf(typeof(Session))]
    public class PingComponent: Entity, IAwake, IDestroy
    {
        public long Ping { get; set; } //延迟值

        public int SceneType { get; set; }

        public long Timer { get; set; }
    }
}