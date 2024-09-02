using MemoryPack;
using System.Collections.Generic;

namespace ET
{
	[ChildOf]
	public class ItemInfo : Entity, IAwake, ISerializeToEntity
	{
		public long BagInfoID { get; set; }
		public int ItemID { get; set; }
		public int ItemNum { get; set; }
		public string ItemPar { get; set; }
		public int HideID { get; set; }
		public string GemHole { get; set; }
		public int Loc { get; set; }
		public bool IfJianDing { get; set; }
		public List<HideProList> HideProLists { get; set; } = new();
		public List<HideProList> XiLianHideProLists { get; set; } = new();
		public List<int> HideSkillLists { get; set; } = new();
		public bool isBinging { get; set; }
		public List<HideProList> XiLianHideTeShuProLists { get; set; } = new();
		public string GetWay { get; set; }
		public string GemIDNew { get; set; }
		public string MakePlayer { get; set; }
		public List<HideProList> FumoProLists { get; set; } = new();
		public int InheritTimes { get; set; }
		public List<int> InheritSkills { get; set; } = new();
		public bool IsProtect { get; set; }
		public List<HideProList> IncreaseProLists { get; set; } = new();
		public List<int> IncreaseSkillLists { get; set; } = new();
		public int EquipPlan { get; set; }
		public int EquipIndex { get; set; }
		public int FuLing { get; set; }
	}

	[EntitySystemOf(typeof(ItemInfo))]
	[FriendOf(typeof(ItemInfo))]
	public static partial class ItemInfoSystem
	{
		[EntitySystem]
		private static void Awake(this ItemInfo self)
		{
		}

		public static void FromMessage(this ItemInfo self, ItemInfoProto proto)
		{
			self.BagInfoID = proto.BagInfoID;
			self.ItemID = proto.ItemID;
			self.ItemNum = proto.ItemNum;
			self.ItemPar = proto.ItemPar;
			self.HideID = proto.HideID;
			self.GemHole = proto.GemHole;
			self.Loc = proto.Loc;
			self.IfJianDing = proto.IfJianDing;
			self.HideProLists = proto.HideProLists;
			self.XiLianHideProLists = proto.XiLianHideProLists;
			self.HideSkillLists = proto.HideSkillLists;
			self.isBinging = proto.isBinging;
			self.XiLianHideTeShuProLists = proto.XiLianHideTeShuProLists;
			self.GetWay = proto.GetWay;
			self.GemIDNew = proto.GemIDNew;
			self.MakePlayer = proto.MakePlayer;
			self.FumoProLists = proto.FumoProLists;
			self.InheritTimes = proto.InheritTimes;
			self.InheritSkills = proto.InheritSkills;
			self.IsProtect = proto.IsProtect;
			self.IncreaseProLists = proto.IncreaseProLists;
			self.IncreaseSkillLists = proto.IncreaseSkillLists;
			self.EquipPlan = proto.EquipPlan;
			self.EquipIndex = proto.EquipIndex;
			self.FuLing = proto.FuLing;
		}

		public static ItemInfoProto ToMessage(this ItemInfo self)
		{
			ItemInfoProto proto = ItemInfoProto.Create();
			proto.BagInfoID = self.BagInfoID;
			proto.ItemID = self.ItemID;
			proto.ItemNum = self.ItemNum;
			proto.ItemPar = self.ItemPar;
			proto.HideID = self.HideID;
			proto.GemHole = self.GemHole;
			proto.Loc = self.Loc;
			proto.IfJianDing = self.IfJianDing;
			proto.HideProLists = self.HideProLists;
			proto.XiLianHideProLists = self.XiLianHideProLists;
			proto.HideSkillLists = self.HideSkillLists;
			proto.isBinging = self.isBinging;
			proto.XiLianHideTeShuProLists = self.XiLianHideTeShuProLists;
			proto.GetWay = self.GetWay;
			proto.GemIDNew = self.GemIDNew;
			proto.MakePlayer = self.MakePlayer;
			proto.FumoProLists = self.FumoProLists;
			proto.InheritTimes = self.InheritTimes;
			proto.InheritSkills = self.InheritSkills;
			proto.IsProtect = self.IsProtect;
			proto.IncreaseProLists = self.IncreaseProLists;
			proto.IncreaseSkillLists = self.IncreaseSkillLists;
			proto.EquipPlan = self.EquipPlan;
			proto.EquipIndex = self.EquipIndex;
			proto.FuLing = self.FuLing;
			return proto;
		}
	}
}
