namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class LocalDungeonComponent: Entity, IAwake, IDestroy
    {
        public long Timer { get; set; }
        public int FubenDifficulty { get; set; }

        public int RandomMonster { get; set; }
        public int RandomJingLing { get; set; }

        public Unit MainUnit { get; set; }
    }
    
}

