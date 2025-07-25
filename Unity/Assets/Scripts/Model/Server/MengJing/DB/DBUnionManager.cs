using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{

    [BsonIgnoreExtraElements]
    [ChildOf]
    public class DBUnionManager : Entity, IAwake
    {
        /// <summary>
        /// 捐献榜
        /// </summary>
        public List<RankingInfo> rankingDonation { get; set; } = new List<RankingInfo>();

        /// <summary>
        /// 报名公会
        /// </summary>
        public List<long> SignupUnions { get; set; } = new List<long> { };

        /// <summary>
        /// 总捐献
        /// </summary>
        public long TotalDonation { get; set; } = 0;

        /// <summary>
        /// 上周捐献
        /// </summary>
        public long LastWeakDonation { get; set; } = 0;

        /// <summary>
        /// 公会争霸赛次数
        /// </summary>
        public int UnionRaceTime { get; set; } = 0;

        /// <summary>
        /// 胜利公会
        /// </summary>
        public long WinUnionId { get; set; }

        public long GetBaseJiangJin
        {
            get
            {
                if (UnionRaceTime == 0)
                {
                    return 10000000;
                }

                if (UnionRaceTime == 1)
                {
                    return 5000000;
                }

                return 3000000;
            }
        }

    }
}
