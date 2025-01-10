using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class DragonDungeonComponentS : Entity, IAwake, IDestroy
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
        
        public int ChapterId { get; set; }
        
        public long HurtValue { get; set; }
        public CellGenerateConfig ChapterConfig { get; set; }
        public int FubenDifficulty { get; set; }

        public FubenInfo FubenInfo { get; set; } = FubenInfo.Create();
        public SonFubenInfo SonFubenInfo { get; set; } = SonFubenInfo.Create();

        public CellDungeonInfo[][] FubenCellInfoList { get; set; }

        //神秘商品
        public List<int> EnergySkills { get; set; } = new List<int>() { };
        public List<MysteryItemInfo> MysteryItemInfos  { get; set; }= new List<MysteryItemInfo>();
        public CellDungeonInfo CurrentFubenCell { get; set; }
    }
    
}