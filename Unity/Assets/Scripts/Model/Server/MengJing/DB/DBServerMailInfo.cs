using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.Server
{
    
    [ChildOf]
    [BsonIgnoreExtraElements]
    public class DBServerMailInfo : Entity, IAwake
    {
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, ServerMailItem> ServerMailList { get; set; } = new Dictionary<int, ServerMailItem>();
    }
}
