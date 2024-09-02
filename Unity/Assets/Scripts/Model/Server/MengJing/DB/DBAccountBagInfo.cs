using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    
    [ChildOf]
    [BsonIgnoreExtraElements]
    public class DBAccountBagInfo : Entity, IAwake
    {
        public List<ItemInfo> BagInfoList { get; set; } = new();
    }
}