using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    
    [BsonIgnoreExtraElements]
    [ComponentOf(typeof(Unit))]
    public class ActivityComponentS : Entity , IAwake, ITransfer, IUnitCache, IDestroy, IDeserialize
    {
        /// <summary>
        /// 上次签到时间 免费
        /// </summary>
        public long LastSignTime { get; set; }= 0;
        /// <summary>
        /// 已经签到次数 免费
        /// </summary>
        public int TotalSignNumber { get; set; }= 0;
        
        /// <summary>
        /// 上次签到时间 VIP
        /// </summary>
        public long LastSignTime_VIP { get; set; }= 0;
        /// <summary>
        /// 已经签到次数 VIP
        /// </summary>
        public int TotalSignNumber_VIP { get; set; }= 0;

        public long LastLoginTime { get; set; }= 0;

        //每日特惠
        public List<int> DayTeHui { get; set; }= new List<int>();

        public List<int> ActivityReceiveIds { get; set; }= new List<int>();
        /// <summary>
        /// 令牌领取
        /// </summary>
        public List<TokenRecvive> QuTokenRecvive { get; set; }= new List<TokenRecvive>();

        public List<int> ZhanQuReceiveIds { get; set; }= new List<int>();

        [BsonIgnore]
        public ActivityV1Info ActivityV1Info { get; set; }
    }
}