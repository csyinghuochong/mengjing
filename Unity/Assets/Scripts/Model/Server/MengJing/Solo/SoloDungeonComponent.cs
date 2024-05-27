namespace ET.Server
{
    
    
    [ComponentOf(typeof(Scene))]
    public class SoloDungeonComponent: Entity, IAwake, IDestroy
    {
        public long Timer;
        public long TimerNum;
        public bool SendReward { get; set; }
    }
    
}