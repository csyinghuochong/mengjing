using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ET.Server
{

	//RankServer
	[ChildOf]
    [BsonIgnoreExtraElements]
	public class DBServerInfo : Entity, IAwake
	{
		public ServerInfo ServerInfo { get; set; } = new ServerInfo();
	}

}
