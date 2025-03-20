using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{

    [ChildOf]
    [BsonIgnoreExtraElements]
    public class DBUnionInfo : Entity, IAwake
    {
        public UnionInfo UnionInfo { get; set; } = UnionInfo.Create();

        public List<MysteryItemInfo> MysteryItemInfos{ get; set; } = new List<MysteryItemInfo>();

        public long MysteryFreshTime { get; set; }= 0;
        
        
    }
}
