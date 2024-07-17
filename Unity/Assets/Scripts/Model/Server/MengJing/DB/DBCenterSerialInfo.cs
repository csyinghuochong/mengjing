using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{

    [BsonIgnoreExtraElements]
    public class DBCenterSerialInfo : Entity, IAwake
    {
        public int SerialIndex = 0;
        public List<KeyValuePair> SerialList = new List<KeyValuePair>();
    }
}
