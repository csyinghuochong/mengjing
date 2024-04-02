using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class ChatComponent: Entity, IAwake
    {
        public Dictionary<int, List<ChatInfo>> ChatTypeList = new();

        public long LastSendWord;

        public ChatInfo LastChatInfo { get; set; }
    }
}