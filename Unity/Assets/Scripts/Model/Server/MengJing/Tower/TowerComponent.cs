namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class TowerComponent: Entity, IAwake, IDestroy
    {
        public int TowerId { get; set; }
        public long Timer;
        public long WaveTime{ get; set; }
        public int FubenDifficulty{ get; set; }
    }
}
