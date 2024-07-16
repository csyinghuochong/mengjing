using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ET.Server
{
    
    [ChildOf]
    [BsonIgnoreExtraElements]
    public class DBAccountBagInfo : Entity, IAwake
    {
        public List<BagInfo> BagInfoList { get; set; } = new List<BagInfo>();
    }
}