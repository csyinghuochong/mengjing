using System.Collections.Generic;

namespace ET.Server
{
    
    
    [ComponentOf(typeof(Unit))]
    public class ActivityComponentS : Entity , IAwake, ITransfer, IUnitCache, IDestroy
    {
        /// <summary>
        /// 上次签到时间
        /// </summary>
        public long LastSignTime = 0;
        /// <summary>
        /// 已经签到次数
        /// </summary>
        public int TotalSignNumber = 0;

        public long LastLoginTime = 0;

        //每日特惠
        public List<int> DayTeHui = new List<int>();

        public List<int> ActivityReceiveIds = new List<int>();
        /// <summary>
        /// 令牌领取
        /// </summary>
        public List<TokenRecvive> QuTokenRecvive = new List<TokenRecvive>();

        public List<int> ZhanQuReceiveIds = new List<int>();

        public ActivityV1Info ActivityV1Info = new ActivityV1Info();
    }
}