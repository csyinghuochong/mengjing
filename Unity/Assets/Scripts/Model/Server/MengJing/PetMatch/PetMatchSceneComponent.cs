using System.Collections.Generic;

namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class PetMatchSceneComponent: Entity, IAwake, IDestroy
    {

        public bool PetMatchOpen { get; set; } = false;

        /// <summary>
        /// 正在匹配的玩家
        /// </summary>
        public List<PetMatchPlayerInfo> MatchList { get; set; } = new List<PetMatchPlayerInfo>();
        
        public List<PetMatchPlayerInfo> RankList { get; set; } = new List<PetMatchPlayerInfo>();

        /// <summary>
        /// 胜利次数
        /// </summary>
        public Dictionary<long, int> WinTimesList { get; set; } = new Dictionary<long, int>();
        
        public Dictionary<long, int> FailTimesList { get; set; } = new Dictionary<long, int>();
    }
    
}

