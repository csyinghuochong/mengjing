using System.Collections.Generic;

namespace ET.Server
{
    [ChildOf(typeof (ChatSceneComponent))]
    public class ChatInfoUnit: Entity, IAwake, IDestroy
    {
        public long LastSendChat{ get; set; }

        public long GateSessionActorId { get; set; } //player.InstanceId

        public long UnionId{ get; set; }

        public string Name{ get; set; }
        
        public int Level { get; set; }
    }
    
    [EnableClass]
    public class BeReportedInfo
    {
        public long JinYanTime;
        public List<long> ReportedList = new List<long>();
    }
    
    
    [ComponentOf(typeof (Scene))]
    public class ChatSceneComponent: Entity, IAwake, IDestroy
    {
        public long Timer;

        public List<WorldSayConfig> WordSayList  { get; set; } = new();

        //全服玩家GateSessionActorId
        public Dictionary<long, ChatInfoUnit> ChatInfoUnitsDict { get; set; } = new();

        //世界列表记录
        public List<ChatInfo> WordChatInfos  { get; set; } = new();
        
        
        public Dictionary<long, BeReportedInfo> BeReportedNumber { get; set; } = new Dictionary<long, BeReportedInfo> ();   
    }
}