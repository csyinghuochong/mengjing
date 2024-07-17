using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{

    [ChildOf]
    [BsonIgnoreExtraElements]
    public class DBPopularizeInfo : Entity, IAwake
    {

        /// <summary>
        /// 我的推广码  前两位为区服 后六位为序号
        /// </summary>
        public long PopularizeCode { get; set; }

        /// <summary>
        /// 我推广的人
        /// </summary>
        public long BePopularizeId{ get; set; }

        /// <summary>
        /// 我的推广人
        /// </summary>
        public List<PopularizeInfo> MyPopularizeList{ get; set; } = new List<PopularizeInfo> { };
    }
}
