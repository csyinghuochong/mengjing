using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class FriendComponent: Entity, IAwake, IDestroy
    {
        /// <summary>
        /// 未展开的聊天
        /// </summary>
        public List<long> FriendChatId { get; set; } = new();

        public List<FriendInfo> FriendList { get; set; } = new();

        public List<FriendInfo> ApplyList { get; set; } = new();

        public List<FriendInfo> Blacklist { get; set; } = new();

        public Dictionary<long, List<ChatInfo>> ChatMsgList { get; set; } = new();
    }
}