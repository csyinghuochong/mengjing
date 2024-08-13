namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class PetMingDungeonComponent: Entity, IAwake, IDestroy
    {
        public int MineType{ get; set; }
        public int Position{ get; set; }

        /// <summary>
        /// 挑战者的队伍
        /// </summary>
        public int TeamId{ get; set; }
        
        public long Timer;

        public int CombatResultEnum;

        public long EnemyId;
    }
}

