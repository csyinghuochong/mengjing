using MemoryPack;
using System.Collections.Generic;

namespace ET
{
	[ChildOf]
	public class ActivityV1Info : Entity, IAwake, ISerializeToEntity
	{
		public List<int> GuessIds { get; set; } = new();
		public List<int> LastGuessReward { get; set; } = new();
		public List<int> ConsumeDiamondReward { get; set; } = new();
		public List<int> ChouKaNumberReward { get; set; } = new();
		public int ChouKaDropId { get; set; }
		public List<int> LiBaoAllIds { get; set; } = new();
		public List<int> LiBaoBuyIds { get; set; } = new();
		public int BaoShiDu { get; set; }
		public string ChouKa2ItemList { get; set; }
		public List<int> ChouKa2RewardIds { get; set; } = new();
		public List<int> OpenGuessIds { get; set; } = new();
	}

	[EntitySystemOf(typeof(ActivityV1Info))]
	[FriendOf(typeof(ActivityV1Info))]
	public static partial class ActivityV1InfoSystem
	{
		[EntitySystem]
		private static void Awake(this ActivityV1Info self)
		{
		}

		public static void FromMessage(this ActivityV1Info self, ActivityV1InfoProto proto)
		{
			self.GuessIds = proto.GuessIds;
			self.LastGuessReward = proto.LastGuessReward;
			self.ConsumeDiamondReward = proto.ConsumeDiamondReward;
			self.ChouKaNumberReward = proto.ChouKaNumberReward;
			self.ChouKaDropId = proto.ChouKaDropId;
			self.LiBaoAllIds = proto.LiBaoAllIds;
			self.LiBaoBuyIds = proto.LiBaoBuyIds;
			self.BaoShiDu = proto.BaoShiDu;
			self.ChouKa2ItemList = proto.ChouKa2ItemList;
			self.ChouKa2RewardIds = proto.ChouKa2RewardIds;
			self.OpenGuessIds = proto.OpenGuessIds;
		}

		public static ActivityV1InfoProto ToMessage(this ActivityV1Info self)
		{
			ActivityV1InfoProto proto = ActivityV1InfoProto.Create();
			proto.GuessIds = self.GuessIds;
			proto.LastGuessReward = self.LastGuessReward;
			proto.ConsumeDiamondReward = self.ConsumeDiamondReward;
			proto.ChouKaNumberReward = self.ChouKaNumberReward;
			proto.ChouKaDropId = self.ChouKaDropId;
			proto.LiBaoAllIds = self.LiBaoAllIds;
			proto.LiBaoBuyIds = self.LiBaoBuyIds;
			proto.BaoShiDu = self.BaoShiDu;
			proto.ChouKa2ItemList = self.ChouKa2ItemList;
			proto.ChouKa2RewardIds = self.ChouKa2RewardIds;
			proto.OpenGuessIds = self.OpenGuessIds;
			return proto;
		}
	}
}
