using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ChildOf]
    [BsonIgnoreExtraElements]
    public class DBMailInfo : Entity, IAwake
    {
        public List<MailInfo> MailInfoList { get; set; } = new List<MailInfo>();
    }
}
