using System.Collections.Generic;


namespace ET.Server
{
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
    }
    
    
    [ComponentOf(typeof(Scene))]
    public class FubenCenterComponent: Entity, IAwake
    {
        public ServerInfo ServerInfo { get; set; }
        
        public List<long> FubenInstanceList { get; set; } = new List<long>();
        
        public Dictionary<int, ActorId> FubenActorIdList { get; set; } = new Dictionary<int, ActorId>();
        public Dictionary<int, long> YeWaiFubenList { get; set; } = new Dictionary<int, long>();
      
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
        public bool BattleOpen = true;
        public List<BattleInfo> BattleInfos { get; set; } = new List<BattleInfo>();
    }
    
}

