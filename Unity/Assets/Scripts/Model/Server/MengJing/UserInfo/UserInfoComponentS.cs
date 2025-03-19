using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    
    [ComponentOf(typeof(Unit))]
    public class UserInfoComponentS : Entity, IAwake, IDestroy, ITransfer, IUnitCache, IDeserialize
    {
        public string Account { get; set; }

        [BsonIgnore]
        public UserInfo UserInfo { get; set; }
        
        /// <summary>
        /// 领地经验
        /// </summary>
        public int LingDiOnLine;

        /// <summary>
        /// 今日在线时长
        /// </summary>
        public long TodayOnLine { get; set; }  //秒

        public long LastJiaYuanExpTime = 0;
        public string RemoteAddress { get; set; }
        public string DeviceName;
        public string UserName { get; set; }

        /// <summary>
        /// 狩猎击杀野怪数量
        /// </summary>
        public int ShouLieKill;

        public long ShouLieSendTime;

        public long UpdateRankTime;

        [BsonIgnore]
        public readonly M2C_RoleDataBroadcast m2C_RoleDataBroadcast = M2C_RoleDataBroadcast.Create();

        [BsonIgnore]
        public long ShouLieUpLoadTimer;
    }
}