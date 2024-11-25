
using System.Collections.Generic;

namespace ET
{
    public static class SeasonHelper
    {

        public const int SeasonBossId = 90000051;
        
        public static bool IsOpenSeason(int userLv)
        {
            if (userLv < 55)
            {
                return false;
            }
            long serverTime = TimeHelper.ServerNow();
            return serverTime >= ConfigData.SeasonOpenTime && serverTime <= ConfigData.SeasonCloseTime;
        }

        /// <summary>
        /// 第几赛季
        /// </summary>
        /// <param name="userLv"></param>
        /// <returns></returns>
        public static KeyValuePairLong GetOpenSeason(int userLv)
        {
            if (userLv < 55)
            {
                return null;
            }
            long serverTime = TimeHelper.ServerNow();
            //return SeasonOpenTime > 0 && serverTime >= SeasonOpenTime && serverTime <= SeasonCloseTime;
            for (int i = 0; i < ConfigData.SeasonTimeList.Count; i++)
            {
                if (serverTime > ConfigData. SeasonTimeList[i].Value && serverTime <= ConfigData.SeasonTimeList[i].Value2)
                {
                    return ConfigData.SeasonTimeList[i];
                }
            }

            return null;
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
                if (item.Value.EnterLv <= lv && item.Key < ConfigData.GMDungeonId)
                {
                    canEnterIds.Add(item.Key);
                }
            }

            return canEnterIds[RandomHelper.RandomNumber(0, canEnterIds.Count)];
        }

    }
}

