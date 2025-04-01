using MemoryPack;
using System.Collections.Generic;

namespace ET
{
	[ChildOf]
	public class UserInfo : Entity, IAwake, ISerializeToEntity
	{
		public long AccInfoID { get; set; }
		public string Name { get; set; }
		public long Gold { get; set; }
		public long Diamond { get; set; }
		public int Lv { get; set; }
		public long Exp { get; set; }
		public long PiLao { get; set; }
		public int Occ { get; set; }
		public int OccTwo { get; set; }
		public int Combat { get; set; }
		public int RobotId { get; set; }
		public int Sp { get; set; }
		public int Vitality { get; set; }
		public long RongYu { get; set; }
		public string UnionName { get; set; }
		public long UserId { get; set; }
		public List<KeyValuePair> GameSettingInfos { get; set; } = new();
		public List<int> MakeList { get; set; } = new();
		public List<int> CompleteGuideIds { get; set; } = new();
		public List<KeyValuePairInt> DayFubenTimes { get; set; } = new();
		public List<KeyValuePair> MonsterRevives { get; set; } = new();
		public List<int> TowerRewardIds { get; set; } = new();
		public List<int> ChouKaRewardIds { get; set; } = new();
		public List<int> XiuLianRewardIds { get; set; } = new();
		public List<KeyValuePairInt> MysteryItems { get; set; } = new();
		public List<KeyValuePair> OpenChestList { get; set; } = new();
		public List<KeyValuePairInt> MakeIdList { get; set; } = new();
		public List<FubenPassInfo> FubenPassList { get; set; } = new();
		public List<KeyValuePairInt> DayItemUse { get; set; } = new();
		public List<int> HorseIds { get; set; } = new();
		public List<KeyValuePairInt> DayMonsters { get; set; } = new();
		public List<int> DayJingLing { get; set; } = new();
		public long JiaYuanFund { get; set; }
		public long JiaYuanExp { get; set; }
		public int JiaYuanLv { get; set; }
		public int BaoShiDu { get; set; }
		public List<KeyValuePair> FirstWinSelf { get; set; } = new();
		public long UnionZiJin { get; set; }
		public int ServerMailIdCur { get; set; }
		public List<int> DiamondGetWay { get; set; } = new();
		public string DemonName { get; set; }
		public List<int> PetMingRewards { get; set; } = new();
		public List<int> OpenJingHeIds { get; set; } = new();
		public int SeasonLevel { get; set; }
		public int SeasonExp { get; set; }
		public long SeasonCoin { get; set; }
		public List<int> WelfareTaskRewards { get; set; } = new();
		public long CreateTime { get; set; }
		public List<int> WelfareInvestList { get; set; } = new();
		public List<int> RechargeReward { get; set; } = new();
		public List<int> UnionKeJiList { get; set; } = new();
		public List<int> PetExploreRewardIds { get; set; } = new();
		public List<int> PetHeXinExploreRewardIds { get; set; } = new();
		public string StallName { get; set; }
		public List<int> SingleRechargeIds { get; set; } = new();
		public List<int> SingleRewardIds { get; set; } = new();
		public List<int> ItemXiLianNumRewardIds { get; set; } = new();
		public List<int> DefeatedBossIds { get; set; } = new();
		public List<KeyValuePairInt> BuyStoreItems { get; set; } = new();
		public int TalentPoints { get; set; }
		public List<int> SeasonDonateRewardIds { get; set; } = new();
	}

	[EntitySystemOf(typeof(UserInfo))]
	[FriendOf(typeof(UserInfo))]
	public static partial class UserInfoSystem
	{
		[EntitySystem]
		private static void Awake(this UserInfo self)
		{
		}

		public static void FromMessage(this UserInfo self, UserInfoProto proto)
		{
			self.AccInfoID = proto.AccInfoID;
			self.Name = proto.Name;
			self.Gold = proto.Gold;
			self.Diamond = proto.Diamond;
			self.Lv = proto.Lv;
			self.Exp = proto.Exp;
			self.PiLao = proto.PiLao;
			self.Occ = proto.Occ;
			self.OccTwo = proto.OccTwo;
			self.Combat = proto.Combat;
			self.RobotId = proto.RobotId;
			self.Sp = proto.Sp;
			self.Vitality = proto.Vitality;
			self.RongYu = proto.RongYu;
			self.UnionName = proto.UnionName;
			self.UserId = proto.UserId;
			self.GameSettingInfos = proto.GameSettingInfos;
			self.MakeList = proto.MakeList;
			self.CompleteGuideIds = proto.CompleteGuideIds;
			self.DayFubenTimes = proto.DayFubenTimes;
			self.MonsterRevives = proto.MonsterRevives;
			self.TowerRewardIds = proto.TowerRewardIds;
			self.ChouKaRewardIds = proto.ChouKaRewardIds;
			self.XiuLianRewardIds = proto.XiuLianRewardIds;
			self.MysteryItems = proto.MysteryItems;
			self.OpenChestList = proto.OpenChestList;
			self.MakeIdList = proto.MakeIdList;
			self.FubenPassList = proto.FubenPassList;
			self.DayItemUse = proto.DayItemUse;
			self.HorseIds = proto.HorseIds;
			self.DayMonsters = proto.DayMonsters;
			self.DayJingLing = proto.DayJingLing;
			self.JiaYuanFund = proto.JiaYuanFund;
			self.JiaYuanExp = proto.JiaYuanExp;
			self.JiaYuanLv = proto.JiaYuanLv;
			self.BaoShiDu = proto.BaoShiDu;
			self.FirstWinSelf = proto.FirstWinSelf;
			self.UnionZiJin = proto.UnionZiJin;
			self.ServerMailIdCur = proto.ServerMailIdCur;
			self.DiamondGetWay = proto.DiamondGetWay;
			self.DemonName = proto.DemonName;
			self.PetMingRewards = proto.PetMingRewards;
			self.OpenJingHeIds = proto.OpenJingHeIds;
			self.SeasonLevel = proto.SeasonLevel;
			self.SeasonExp = proto.SeasonExp;
			self.SeasonCoin = proto.SeasonCoin;
			self.WelfareTaskRewards = proto.WelfareTaskRewards;
			self.CreateTime = proto.CreateTime;
			self.WelfareInvestList = proto.WelfareInvestList;
			self.RechargeReward = proto.RechargeReward;
			self.UnionKeJiList = proto.UnionKeJiList;
			self.PetExploreRewardIds = proto.PetExploreRewardIds;
			self.PetHeXinExploreRewardIds = proto.PetHeXinExploreRewardIds;
			self.StallName = proto.StallName;
			self.SingleRechargeIds = proto.SingleRechargeIds;
			self.SingleRewardIds = proto.SingleRewardIds;
			self.ItemXiLianNumRewardIds = proto.ItemXiLianNumRewardIds;
			self.DefeatedBossIds = proto.DefeatedBossIds;
			self.BuyStoreItems = proto.BuyStoreItems;
			self.TalentPoints = proto.TalentPoints;
			self.SeasonDonateRewardIds = proto.SeasonDonateRewardIds;
		}

		public static UserInfoProto ToMessage(this UserInfo self)
		{
			UserInfoProto proto = UserInfoProto.Create();
			proto.AccInfoID = self.AccInfoID;
			proto.Name = self.Name;
			proto.Gold = self.Gold;
			proto.Diamond = self.Diamond;
			proto.Lv = self.Lv;
			proto.Exp = self.Exp;
			proto.PiLao = self.PiLao;
			proto.Occ = self.Occ;
			proto.OccTwo = self.OccTwo;
			proto.Combat = self.Combat;
			proto.RobotId = self.RobotId;
			proto.Sp = self.Sp;
			proto.Vitality = self.Vitality;
			proto.RongYu = self.RongYu;
			proto.UnionName = self.UnionName;
			proto.UserId = self.UserId;
			proto.GameSettingInfos = self.GameSettingInfos;
			proto.MakeList = self.MakeList;
			proto.CompleteGuideIds = self.CompleteGuideIds;
			proto.DayFubenTimes = self.DayFubenTimes;
			proto.MonsterRevives = self.MonsterRevives;
			proto.TowerRewardIds = self.TowerRewardIds;
			proto.ChouKaRewardIds = self.ChouKaRewardIds;
			proto.XiuLianRewardIds = self.XiuLianRewardIds;
			proto.MysteryItems = self.MysteryItems;
			proto.OpenChestList = self.OpenChestList;
			proto.MakeIdList = self.MakeIdList;
			proto.FubenPassList = self.FubenPassList;
			proto.DayItemUse = self.DayItemUse;
			proto.HorseIds = self.HorseIds;
			proto.DayMonsters = self.DayMonsters;
			proto.DayJingLing = self.DayJingLing;
			proto.JiaYuanFund = self.JiaYuanFund;
			proto.JiaYuanExp = self.JiaYuanExp;
			proto.JiaYuanLv = self.JiaYuanLv;
			proto.BaoShiDu = self.BaoShiDu;
			proto.FirstWinSelf = self.FirstWinSelf;
			proto.UnionZiJin = self.UnionZiJin;
			proto.ServerMailIdCur = self.ServerMailIdCur;
			proto.DiamondGetWay = self.DiamondGetWay;
			proto.DemonName = self.DemonName;
			proto.PetMingRewards = self.PetMingRewards;
			proto.OpenJingHeIds = self.OpenJingHeIds;
			proto.SeasonLevel = self.SeasonLevel;
			proto.SeasonExp = self.SeasonExp;
			proto.SeasonCoin = self.SeasonCoin;
			proto.WelfareTaskRewards = self.WelfareTaskRewards;
			proto.CreateTime = self.CreateTime;
			proto.WelfareInvestList = self.WelfareInvestList;
			proto.RechargeReward = self.RechargeReward;
			proto.UnionKeJiList = self.UnionKeJiList;
			proto.PetExploreRewardIds = self.PetExploreRewardIds;
			proto.PetHeXinExploreRewardIds = self.PetHeXinExploreRewardIds;
			proto.StallName = self.StallName;
			proto.SingleRechargeIds = self.SingleRechargeIds;
			proto.SingleRewardIds = self.SingleRewardIds;
			proto.ItemXiLianNumRewardIds = self.ItemXiLianNumRewardIds;
			proto.DefeatedBossIds = self.DefeatedBossIds;
			proto.BuyStoreItems = self.BuyStoreItems;
			proto.TalentPoints = self.TalentPoints;
			proto.SeasonDonateRewardIds = self.SeasonDonateRewardIds;
			return proto;
		}
	}
}
