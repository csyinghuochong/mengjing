using System.Collections.Generic;

namespace ET.Server
{
    
    
    public class RankSceneComponent: Entity, IAwake,IDestroy
    {
        public long Timer = 0;

        public long PassTime = 0;

        public DBRankInfo DBRankInfo { get; set; } = new DBRankInfo();

        public DBServerInfo DBServerInfo{ get; set; } = new DBServerInfo();

        public long RankingTrialLastTime = 0;
        public List<RankingTrialInfo> RankingTrials = new List<RankingTrialInfo>();

        public long RankSeasonTowerLastTime = 0;
        public List<RankSeasonTowerInfo> RankSeasonTowers = new List<RankSeasonTowerInfo>();

        public int UpdateCombat = 0;
    }
    
    
}
