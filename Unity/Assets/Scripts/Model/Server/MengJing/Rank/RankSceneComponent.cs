using System.Collections.Generic;

namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class RankSceneComponent: Entity, IAwake,IDestroy
    {
        public long Timer = 0;

        public long PassTime = 0;

        public DBRankInfo DBRankInfo { get; set; } = new DBRankInfo();

        public DBServerInfo DBServerInfo{ get; set; } = new DBServerInfo();

        public long RankingTrialLastTime { get; set; }= 0;
        public List<RankingTrialInfo> RankingTrials { get; set; }= new List<RankingTrialInfo>();

        public long RankSeasonTowerLastTime { get; set; } = 0;
        public List<RankSeasonTowerInfo> RankSeasonTowers { get; set; } = new List<RankSeasonTowerInfo>();

        public int UpdateCombat = 0;
    }
    
    
}
