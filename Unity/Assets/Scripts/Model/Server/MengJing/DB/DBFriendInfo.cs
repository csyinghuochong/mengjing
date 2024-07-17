using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{

    [BsonIgnoreExtraElements]
    [ChildOf]
    public class DBFriendInfo : Entity, IAwake
    {

        /// <summary>
        /// 好友列表
        /// </summary>
        public List<long> FriendList { get; set; } = new List<long>();

        /// <summary>
        /// 申请列表
        /// </summary>
        public List<long> ApplyList  { get; set; }= new List<long>();

        /// <summary>
        /// 黑名单
        /// </summary>
        public List<long> Blacklist  { get; set; }= new List<long>();

        /// <summary>
        /// 好友私聊
        /// </summary>
        public List<ChatInfo> FriendChats  { get; set; }= new List<ChatInfo>();   
    }
}
