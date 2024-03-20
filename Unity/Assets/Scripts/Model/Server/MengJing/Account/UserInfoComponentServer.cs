using ET;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    
    [ComponentOf(typeof(Unit))]
    public class UserInfoComponentServer : Entity, IAwake, IDestroy, ITransfer, IUnitCache
    {
        public string Account { get; set; }
        public UserInfo UserInfo = new UserInfo();

          /// <summary>
        /// 登录或者零点刷新的时候会改变.主要用来体力恢复，刷新数据
        /// </summary>
        public long LastLoginTime;

        /// <summary>
        /// 领地经验
        /// </summary>
        public int LingDiOnLine;

        /// <summary>
        /// 今日在线时长
        /// </summary>
        public long TodayOnLine { get; set; }

        public long LastJiaYuanExpTime = 0;
        public string RemoteAddress;
        public string DeviceName;
        public string UserName  { get; set; }

        /// <summary>
        /// 狩猎击杀野怪数量
        /// </summary>
        public int ShouLieKill;

        public long ShouLieSendTime;

        public long UpdateRankTime;

        [BsonIgnore]
        public readonly M2C_RoleDataBroadcast m2C_RoleDataBroadcast  = new M2C_RoleDataBroadcast();
        [BsonIgnore]
        public readonly M2C_RoleDataUpdate m2C_RoleDataUpdate = new M2C_RoleDataUpdate();

        [BsonIgnore]
        public long ShouLieUpLoadTimer;
    }

}