using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ComponentOf(typeof(RankSceneComponent))]
    [BsonIgnoreExtraElements]
    public class DBRankInfo : Entity, IAwake
    {
        public List<RankPetInfo> rankingPets{ get; set; }  = new List<RankPetInfo>();     //宠物天梯
        
        public List<long> LastRewardPetIds { get; set; } = new List<long>();
        
        public List<RankingInfo> rankingCombats { get; set; } = new List<RankingInfo>();    //战力排行
        
        public List<long> LastRewardCombatIds { get; set; } = new List<long>();
        
        public List<RankingInfo> rankingCamp1 { get; set; } = new List<RankingInfo>();    //正派
        public List<RankingInfo> rankingCamp2 { get; set; } = new List<RankingInfo>();    //邪派
        public List<RankingInfo> rankSoloInfo { get; set; } = new List<RankingInfo>();    //solo
        
        public List<RankingInfo> petMatchInfo { get; set; } = new List<RankingInfo>();    //petmatch
        
        public List<RankShouLieInfo> rankShowLie { get; set; } = new List<RankShouLieInfo>(); //狩猎
        public List<RankShouLieInfo> rankUnionRace { get; set; } = new List<RankShouLieInfo>();//公会战
        public List<RankingInfo> rankRunRace { get; set; } = new List<RankingInfo>();     //奔跑大赛
        public List<RankingInfo> rankingDemon { get; set; } = new List<RankingInfo>();     //恶魔活动
        public List<KeyValuePairLong> rankingTrial { get; set; } = new List<KeyValuePairLong>(); //试炼副本伤害排行
        public List<KeyValuePairLong> rankSeasonTower { get; set; } = new List<KeyValuePairLong>();   //试炼副本伤害排行  id/层数/时间
    }
}
