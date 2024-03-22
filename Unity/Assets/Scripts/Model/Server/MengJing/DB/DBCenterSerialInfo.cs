using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Options;

namespace ET.Server
{

    [BsonIgnoreExtraElements]
    public class DBCenterSerialInfo : Entity, IAwake
    {
        public int SerialIndex = 0;
        public List<KeyValuePair> SerialList = new List<KeyValuePair>();
    }
}
