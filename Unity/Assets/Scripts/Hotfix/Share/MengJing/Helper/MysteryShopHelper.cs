using System.Collections.Generic;

namespace ET
{
    public static class MysteryShopHelper
    {

		public static List<int> GetMysteryList(int shopValue)
		{
			List<int> itemList = new List<int>();
			while (shopValue != 0)
			{
				if (itemList.Count > 10000)
				{
					Log.Error($"itemList.Count > 10000");
					break;
				}

				itemList.Add(shopValue);
				MysteryConfig mysteryConfig = MysteryConfigCategory.Instance.Get(shopValue);
				shopValue = mysteryConfig.NextId;
			}

			return itemList;
		}

		public static List<MysteryItemInfo> InitMysteryTypeItems(int openserverDay , int shopValue, int totalNumber)
		{
			List<MysteryItemInfo> mysteryItemInfos = new List<MysteryItemInfo>();
			if (openserverDay == 0)
			{
				return mysteryItemInfos;
			}

			List<int> mysteryids = GetMysteryList(shopValue);
			List<int> weightList = new List<int>();
			List<int> mystIdList = new List<int>();

			for(int i = 0; i < mysteryids.Count; i++)
			{
				MysteryConfig mysteryConfig = MysteryConfigCategory.Instance.Get(mysteryids[i]);
				if (openserverDay < mysteryConfig.ShowServerDay)
				{
					continue;
				}

				weightList.Add(mysteryConfig.ShowPro);
				mystIdList.Add(mysteryConfig.Id);
			}

			while (mysteryItemInfos.Count < totalNumber)
			{
				int index = RandomHelper.RandomByWeight(weightList);
				int mystId = mystIdList[index];
				MysteryConfig mysteryConfig = MysteryConfigCategory.Instance.Get(mystId);

				MysteryItemInfo MysteryItemInfo = MysteryItemInfo.Create();
				MysteryItemInfo.MysteryId = mystId;
				MysteryItemInfo.ItemID = mysteryConfig.SellItemID;
				MysteryItemInfo.ItemNumber = RandomHelper.RandomNumber(mysteryConfig.NumberLimit[0], mysteryConfig.NumberLimit[1]);
				mysteryItemInfos.Add(MysteryItemInfo);
				weightList.RemoveAt(index);
				mystIdList.RemoveAt(index);
			}

			return mysteryItemInfos;
		}

		public static List<MysteryItemInfo> InitJiaYuanMysteryTypeItems(int openserverDay, int shopValue, int totalNumber, int jiayualv)
		{
			List<MysteryItemInfo> mysteryItemInfos = new List<MysteryItemInfo>();
			if (openserverDay == 0)
			{
				return mysteryItemInfos;
			}

			List<int> mysteryids = GetMysteryList(shopValue);
			List<int> weightList = new List<int>();
			List<int> mystIdList = new List<int>();

			for (int i = 0; i < mysteryids.Count; i++)
			{
				MysteryConfig mysteryConfig = MysteryConfigCategory.Instance.Get(mysteryids[i]);
				if (openserverDay < mysteryConfig.ShowServerDay || jiayualv < mysteryConfig.JiaYuanLv)
				{
					continue;
				}

				weightList.Add(mysteryConfig.ShowPro);
				mystIdList.Add(mysteryConfig.Id);
			}

			while (mysteryItemInfos.Count < totalNumber )
			{
				int index = RandomHelper.RandomByWeight(weightList);
				int mystId = mystIdList[index];
				MysteryConfig mysteryConfig = MysteryConfigCategory.Instance.Get(mystId);
				MysteryItemInfo MysteryItemInfo = MysteryItemInfo.Create();
				MysteryItemInfo.MysteryId = mystId;
				MysteryItemInfo.ItemID = mysteryConfig.SellItemID;
				MysteryItemInfo.ItemNumber = RandomHelper.RandomNumber(mysteryConfig.NumberLimit[0], mysteryConfig.NumberLimit[1]);
				mysteryItemInfos.Add(MysteryItemInfo);
			}

			return mysteryItemInfos;
		}

		public static List<MysteryItemInfo> InitJiaYuanPlanItemInfos(int openserverDay, int jiayuanLv,string globalValueConfig)
		{
			List<MysteryItemInfo> mysteryItemInfos = new List<MysteryItemInfo>();

			//GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(87);
			string[] itemList = globalValueConfig.Split('@');

			for (int i = 0; i < itemList.Length; i++)
			{
				string[] iteminfo = itemList[i].Split(';');
				List<MysteryItemInfo> teamList = InitJiaYuanMysteryTypeItems(openserverDay, int.Parse(iteminfo[0]), int.Parse(iteminfo[1]), jiayuanLv);
				for (int kk = 0; kk < teamList.Count; kk++)
				{
					teamList[kk].ProductId = mysteryItemInfos.Count + 1;
					mysteryItemInfos.Add(teamList[kk]);
				}
			}

			return mysteryItemInfos;
		}

		public static List<MysteryItemInfo> InitMysteryItemInfos(int openserverDay)
		{
			List<MysteryItemInfo> mysteryItemInfos = new List<MysteryItemInfo>();

			GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(11);
			string[] itemList =  globalValueConfig.Value.Split('@');

			for (int i = 0; i < itemList.Length; i++)
			{
				string[] iteminfo = itemList[i].Split(';');
				mysteryItemInfos.AddRange(InitMysteryTypeItems(openserverDay,int.Parse(iteminfo[0]), int.Parse(iteminfo[1])));
			}

			return mysteryItemInfos;
		}
		
		public static List<MysteryItemInfo> InitUnionMysteryItemInfos(int openserverDay)
		{
			List<MysteryItemInfo> mysteryItemInfos = new List<MysteryItemInfo>();

			GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(92);
			string[] itemList = globalValueConfig.Value.Split('@');

			for (int i = 0; i < itemList.Length; i++)
			{
				string[] iteminfo = itemList[i].Split(';');
				mysteryItemInfos.AddRange(InitMysteryTypeItems(openserverDay, int.Parse(iteminfo[0]), int.Parse(iteminfo[1])));
			}

			return mysteryItemInfos;
		}
		
	}
}
