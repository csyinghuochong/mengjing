using ET;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{

    public class UserInfoComponentServer : Entity, IAwake, IDestroy, ITransfer, IUnitCache
    {
        public string Account;
        public UserInfo UserInfo = new UserInfo();

          /// <summary>
        /// ��¼�������ˢ�µ�ʱ���ı�.��Ҫ���������ָ���ˢ������
        /// </summary>
        public long LastLoginTime;

        /// <summary>
        /// ��ؾ���
        /// </summary>
        public int LingDiOnLine;

        /// <summary>
        /// ��������ʱ��
        /// </summary>
        public long TodayOnLine;

        public long LastJiaYuanExpTime = 0;
        public string RemoteAddress;
        public string DeviceName;
        public string UserName;

        /// <summary>
        /// ���Ի�ɱҰ������
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