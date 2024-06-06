using System.Collections.Generic;


namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class FubenCenterComponent: Entity, IAwake
    {
        public List<long> FubenInstanceList { get; set; } = new List<long>();
        
        public Dictionary<int, ActorId> FubenActorIdList { get; set; } = new Dictionary<int, ActorId>();
        public Dictionary<int, long> YeWaiFubenList { get; set; } = new Dictionary<int, long>();
        public ServerInfo ServerInfo { get; set; }

        /// <summary>
        /// 奔跑大赛
        /// </summary>
        public bool RunRaceOpen = false;    
        public Dictionary<long, List<long>> RunRacePlayerList = new Dictionary<long, List<long>>();

        /// <summary>
        /// 恶魔大赛
        /// </summary>
        public bool DemonOpen = false;
        public Dictionary<long, List<long>> DemonPlayerList = new Dictionary<long, List<long>>();

    }
    
}

