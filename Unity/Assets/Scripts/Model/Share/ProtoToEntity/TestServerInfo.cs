using MemoryPack;
using System.Collections.Generic;

namespace ET
{
	[ChildOf]
	public class TestServerInfo : Entity, IAwake, ISerializeToEntity
	{
		public int Status { get; set; }
		public string ServerName { get; set; }
	}

	[EntitySystemOf(typeof(TestServerInfo))]
	[FriendOf(typeof(TestServerInfo))]
	public static partial class TestServerInfoSystem
	{
		[EntitySystem]
		private static void Awake(this TestServerInfo self)
		{
		}

		public static void FromMessage(this TestServerInfo self, TestServerInfoProto proto)
		{
			self.Status = proto.Status;
			self.ServerName = proto.ServerName;
		}

		public static TestServerInfoProto ToMessage(this TestServerInfo self)
		{
			TestServerInfoProto proto = TestServerInfoProto.Create();
			proto.Id = (int)self.Id;
			proto.Status = self.Status;
			proto.ServerName = self.ServerName;
			return proto;
		}
	}
}
