using System.Collections.Generic;

namespace ET.Server
{
    public struct ArenaPlayerStatu
    {
        public int States;   //0关闭之后离开  1关闭之后离开  2 结束时还在
        public int KillNumber;
        public int RankId;
        public long UnitId;
    }
    
    [ChildOf]
    public class BattleInfo : Entity, IAwake
    {
        public int SceneId { get; set; } = 0;
        public long FubenId { get; set; }= 0;
        public int PlayerNumber { get; set; }= 0;
        public long ProgressId { get; set; }= 0;
        public long FubenInstanceId { get; set; }= 0;
        
        public ActorId ActorId { get; set; }

        public List<long> Camp1Player{ get; set; } = new List<long>();
        public List<long> Camp2Player{ get; set; } = new List<long>();
        
        public Dictionary<long, ArenaPlayerStatu> PlayerList { get; set; } = new Dictionary<long, ArenaPlayerStatu>();
    }
    
    
    [ComponentOf(typeof(Scene))]
    public class FubenCenterComponent: Entity, IAwake
    {
        public List<long> FubenInstanceList { get; set; } = new List<long>();
        
        public Dictionary<int, ActorId> FubenActorIdList { get; set; } = new Dictionary<int, ActorId>();
        public Dictionary<int, long> YeWaiFubenList { get; set; } = new Dictionary<int, long>();
        
        /// 战场1025 角斗场1031  喜从天降1055   变身比赛1058 恶魔比赛1059
        /// <summary>
        /// 奔跑大赛
        /// </summary>
        public bool RunRaceOpen = false;    
        public List<BattleInfo> RunRaceInfos { get; set; } = new List<BattleInfo>();

        /// <summary>
        /// 恶魔大赛
        /// </summary>
        public bool DemonOpen = false;
        public List<BattleInfo> DemonInfos { get; set; } = new List<BattleInfo>();

        /// <summary>
        /// 战场
        /// </summary>
        public bool BattleOpen = false;
        public List<BattleInfo> BattleInfos { get; set; } = new List<BattleInfo>();
        
        
        /// <summary>
        /// 喜从天降
        /// </summary>
        public bool HappyOpen = false;
        public List<BattleInfo> HappyInfos { get; set; } = new List<BattleInfo>();
        
        /// <summary>
        /// 勇士角斗
        /// </summary>
        public bool ArenaOpen = false;
        public List<BattleInfo> ArenaInfos { get; set; } = new List<BattleInfo>();
        
        /// <summary>
        /// 公会争霸
        /// </summary>
        public BattleInfo UnionRaceScene { get; set; } 
        
        /// <summary>
        /// 公会地图
        /// </summary>
        public Dictionary<long, ActorId> UnionFubens = new Dictionary<long, ActorId>();   //unionid->actorid

        /// <summary>
        /// 家园地图
        /// </summary>
        public Dictionary<long, ActorId> JiaYuanFubens = new Dictionary<long, ActorId>();
        
    }
    
}

