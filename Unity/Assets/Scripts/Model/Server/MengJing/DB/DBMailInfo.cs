using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;


namespace ET.Server
{
    [ChildOf]
    [BsonIgnoreExtraElements]
    public class DBMailInfo : Entity, IAwake
    {
        public List<MailInfo> MailInfoList { get; set; } = new List<MailInfo>();
    }
}
