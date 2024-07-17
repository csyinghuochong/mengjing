using System.Collections.Generic;

namespace ET.Server
{

    [FriendOf(typeof(DBDayActivityInfo))]
    public static partial class DBDayActivityInfoSystem
    {
        
        public static void AddGuessPlayerList(this DBDayActivityInfo self, Dictionary<int, List<long>> guessPlayerList)
        {
            foreach (var item in guessPlayerList)
            {
                if (!self.GuessPlayerList.ContainsKey(item.Key))
                {
                    self.GuessPlayerList.Add(item.Key, new List<long>());
                }

                if (item.Value.Count > 0 && self.GuessPlayerList[item.Key].Contains(item.Value[0]))
                {
                    continue;
                }

                self.GuessPlayerList[item.Key].AddRange(item.Value);
            }
        }

        public static void AddGuessRewardList(this DBDayActivityInfo self, Dictionary<int, List<long>> guessRewardList)
        {
            foreach (var item in guessRewardList)
            {
                if (!self.GuessRewardList.ContainsKey(item.Key))
                {
                    self.GuessRewardList.Add(item.Key, new List<long>());
                }

                if (item.Value.Count > 0 && self.GuessRewardList[item.Key].Contains(item.Value[0]))
                {
                    continue;
                }

                self.GuessRewardList[item.Key].AddRange(item.Value);
            }
        }
    }

}