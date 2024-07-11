namespace ET.Server
{
    
    
    [ComponentOf(typeof(Scene))]
    public class BattleDungeonComponent: Entity, IAwake
    {
        public int CampKillNumber_1;
        public int CampKillNumber_2;
        public bool SendReward { get; set; }

        public long BattleOpenTime { get; set; } = 0;
        public M2C_BattleInfoResult m2C_BattleInfoResult { get; set; } = M2C_BattleInfoResult.Create();
    }
    
}
