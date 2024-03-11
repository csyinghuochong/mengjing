
using System.Collections.Generic;

namespace ET
{
    public static class SeasonHelper
    {

        public static bool IsOpenSeason(int userLv)
        {
            if (userLv < 55)
            {
                return false;
            }
            long serverTime = TimeHelper.ServerNow();
            return serverTime >= ConfigData.SeasonOpenTime && serverTime <= ConfigData.SeasonCloseTime;
        }

        public static int GetFubenId(int lv)
        {
            List<int> canEnterIds = new List<int>();
            Dictionary<int, DungeonConfig> keyValuePairs = DungeonConfigCategory.Instance.GetAll();
            foreach (var item in keyValuePairs)
            {
                if (item.Key >= 100000)
                {
                    continue;
                }
                if (DungeonSectionConfigCategory.Instance.MysteryDungeonList.Contains(item.Key))
                {
                    continue;
                }
                if (item.Value.EnterLv <= lv && item.Key < ConfigHelper.GMDungeonId())
                {
                    canEnterIds.Add(item.Key);
                }
            }

            return canEnterIds[RandomHelper.RandomNumber(0, canEnterIds.Count)];
        }

    }
}

