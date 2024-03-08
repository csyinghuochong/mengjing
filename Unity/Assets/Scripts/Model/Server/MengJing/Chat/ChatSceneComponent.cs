using System.Collections.Generic;

namespace ET.Server
{
    [ChildOf(typeof (ChatSceneComponent))]
    public class ChatInfoUnit: Entity, IAwake, IDestroy
    {
        public long LastSendChat;

        public long GateSessionActorId; //player.InstanceId

        public long UnionId;

        public string Name;
    }

    [ComponentOf(typeof (Scene))]
    public class ChatSceneComponent: Entity, IAwake, IDestroy
    {
        public long Timer;

        public List<WorldSayConfig> WordSayList = new();

        //全服玩家GateSessionActorId
        public Dictionary<long, ChatInfoUnit> ChatInfoUnitsDict = new();

        //世界列表记录
        public List<ChatInfo> WordChatInfos = new();
    }
}