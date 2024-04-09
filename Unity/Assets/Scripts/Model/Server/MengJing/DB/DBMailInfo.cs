using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;


namespace ET.Server
{
    [BsonIgnoreExtraElements]
    public class DBMailInfo : Entity
    {
        public List<MailInfo> MailInfoList { get; set; } = new List<MailInfo>();
    }
}
