
using System.Collections.Generic;

namespace ET
{
    public static class SeasonHelper
    {
        
         /// <summary>
         /// 赛季结束奖励
         /// </summary>
         public static string GetSeasonOverReward(int seasonLevel)
         {
             if (seasonLevel >= 20)
             {
                 return "1;1000000@10000159;30@10010094;1@10000165;10";
             }
             if (seasonLevel >= 15)
             {
                 return "1;500000@10000159;20@10010093;1@10000165;5";
             }
             if (seasonLevel >= 10)
             {
                 return "1;300000@10000159;10@10010093;1";
             }
             if (seasonLevel >= 5)
             {
                 return "1;100000@10000159;5@10010092;1";
             }
             if (seasonLevel >= 1)
             {
                 return "1;10000@10000159;2";
             }
        
             return string.Empty;
         }

         public static int GetOpenLv()
         {
             return 12;
         }

         /// <summary>
        /// 第几赛季
        /// </summary>
        /// <param name="userLv"></param>
        /// <returns></returns>
        public static KeyValuePairLong GetOpenSeason(int userLv)
        {
            if (userLv < GetOpenLv())
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

