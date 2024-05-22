using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;


namespace ET.Server
{

    [BsonIgnoreExtraElements]
    public class DBUnionInfo : Entity
    {
        public UnionInfo UnionInfo { get; set; } = new UnionInfo();

        public List<MysteryItemInfo> MysteryItemInfos{ get; set; } = new List<MysteryItemInfo>();

        public long MysteryFreshTime { get; set; }= 0;
    }
}
