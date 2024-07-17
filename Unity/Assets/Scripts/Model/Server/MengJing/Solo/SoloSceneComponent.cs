using System.Collections.Generic;

namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class SoloSceneComponent: Entity, IAwake
    {
        public long SoloTimer;      

        public List<SoloPlayerInfo> MatchList{ get; set; } = new List<SoloPlayerInfo>();         //竞技场匹配列表

        public Dictionary<long, SoloMatchInfo> MatchResult { get; set; }= new Dictionary<long, SoloMatchInfo>();

        public M2C_SoloMatchResult m2C_SoloMatchResult { get; set; } = M2C_SoloMatchResult.Create();

        public Dictionary<long, int> PlayerIntegralList { get; set; } = new Dictionary<long, int>(); //竞技场列表添加

        public Dictionary<long, long> PlayerCombatList { get; set; }= new Dictionary<long, long>();  

        public Dictionary<long, SoloPlayerInfo> AllPlayerDateList { get; set; }= new Dictionary<long, SoloPlayerInfo>();     //玩家进入添加缓存,方便获取玩家的基本信息

        //数据缓存
        public List<SoloPlayerResultInfo> SoloResultInfoList{ get; set; } = new List<SoloPlayerResultInfo>();
        public long ResultTime{ get; set; }
    }
    
}
