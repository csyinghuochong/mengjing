using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    
    [ChildOf]
    public class TeamDropItem : Entity, IAwake
    {
        public long EndTime{ get; set; } = 0;   //-1已分配好
        public UnitInfo DropInfo{ get; set; }
        public List<long> NeedPlayers { get; set; } = new List<long>();
        public List<long> GivePlayers { get; set; }= new List<long>();
    }

    
    [ComponentOf(typeof(Scene))]
    public class TeamDungeonComponent : Entity, IAwake, IDestroy
    {
        public long Timer;
        public int FubenType { get; set; }
        public long EnterTime { get; set; }
        
        public long TeamId { get; set; }
        
        public Dictionary<long, TeamPlayerInfo> TeamPlayers  { get; set; }= new Dictionary<long, TeamPlayerInfo>();

        public List<int> BoxReward  { get; set; }= new List<int>();
        public List<int> KillBossList  { get; set; }= new List<int>();
        
        public List<TeamDropItem> TeamDropItems { get; set; } = new List<TeamDropItem>();
        public Dictionary<long, long> ItemFlags  { get; set; }= new Dictionary<long, long>();

        public M2C_TeamPickMessage m2C_TeamPickMessage { get; set; } = M2C_TeamPickMessage.Create();

        public float3 BossDeadPosition  { get; set; }= float3.zero;
    }
    
}