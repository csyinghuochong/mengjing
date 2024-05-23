using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Options;

namespace ET.Server
{ 
    [BsonIgnoreExtraElements]
    public class DBCenterServerInfo : Entity
    {
        public int RechageOpen { get; set; } 

        public List<long> GmWhiteList  { get; set; } = new List<long>();

        public List<int> RechageDic { get; set; } = new List<int>();
    }
}
