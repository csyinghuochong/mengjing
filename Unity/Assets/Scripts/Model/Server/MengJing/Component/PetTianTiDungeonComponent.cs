namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class PetTianTiDungeonComponent : Entity, IAwake, IDestroy
    {
        public long EnemyId { get; set; }
        private EntityRef<Unit> mainUnit;
        public Unit MainUnit { get => this.mainUnit; set => mainUnit = value; }
        public long Timer = 0;
    }
}