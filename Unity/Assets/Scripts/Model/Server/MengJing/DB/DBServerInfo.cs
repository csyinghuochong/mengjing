using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{

	//RankServer
	[ComponentOf()]
    [BsonIgnoreExtraElements]
	public class DBServerInfo : Entity, IAwake
	{
		public ServerInfo ServerInfo { get; set; } = ServerInfo.Create();
	}

}
