using System.Collections.Generic;


namespace  ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class FriendComponent: Entity, IAwake, IDestroy
    {
        /// <summary>
        /// 未展开的聊天
        /// </summary>
        public List<long> FriendChatId = new List<long> ();

        public List<FriendInfo> FriendList = new List<FriendInfo>();

        public List<FriendInfo> ApplyList = new List<FriendInfo>();

        public List<FriendInfo> Blacklist = new List<FriendInfo>();

        public Dictionary<long, List<ChatInfo>> ChatMsgList = new Dictionary<long, List<ChatInfo>>();
    }
}