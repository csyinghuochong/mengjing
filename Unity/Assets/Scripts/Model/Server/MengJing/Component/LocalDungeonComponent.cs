namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class LocalDungeonComponent: Entity, IAwake, IDestroy
    {
        public long Timer { get; set; }
        public int FubenDifficulty { get; set; }

        private EntityRef<Unit> mainUnit;
        public Unit MainUnit
        {
            get
            {
                return this.mainUnit;
            }
            set
            {
                this.mainUnit = value;
            }
        }
    }
    
}

