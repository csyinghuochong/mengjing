namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class PetTianTiComponent: Entity, IAwake, IDestroy
    {
        public long EnemyId { get; set; }
        public Unit MainUnit{ get; set; }
        public long Timer = 0;
    }
}

