using System.Collections.Generic;

namespace ET
{

    /// <summary>
    /// 活动相关配置
    /// </summary>

    public static class ActivityConfigHelper
    {

        public const int ActivityV1_ChouKa = 1;    //抽卡
        public const int ActivityV1_Guess = 2;     //竞猜
        public const int ActivityV1_Consume = 3;     //消费
        public const int ActivityV1_HongBao = 4;     //红包
        public const int ActivityV1_Shop = 5;          //商店
        public const int ActivityV1_DuiHuanWord = 6;   //兑换
        public const int ActivityV1_ChouKa2 = 7;            //抽卡2  当奖励已经领取超过50%可进行奖励刷新
        public const int ActivityV1_Task = 8;           //活动任务，每日刷新  TaskComponent.TaskCountryList   TaskCountryType.ActivityV1
        public const int ActivityV1_LiBao = 9;          //每日礼包  ActivityConfig ActivityType = 102
        public const int ActivityV1_Feed = 10;          //喂食


        /// <summary>
        /// UI切页也据此显示
        /// </summary>
        public static List<int> ActivityV1OpenList()
        {
            return new List<int>() { 
                ActivityV1_ChouKa, ActivityV1_Guess, ActivityV1_Consume,ActivityV1_HongBao, ActivityV1_Shop,
                ActivityV1_DuiHuanWord, ActivityV1_ChouKa2, ActivityV1_Task,ActivityV1_LiBao, ActivityV1_Feed };  
        }

      
        ///可供竞猜的数量。（数量6对应对个字）
        public static int GuessNumber()
        {
            return 6;
        }

        /// <summary>
        /// 第一个字免费， 第二个字开始消耗道具.  
        /// </summary>
        public static string GuessCostItem()
        {
            return "1;100@1;200@1;300@1;400@1;500@1;600";
        }


        /// <summary>
        /// 竞猜时间点奖励
        /// </summary>
        public static Dictionary<int, string> GuessRewardList()
        {
            return  new Dictionary<int, string>()
            {
                { 0, "1;100"},
                { 14, "1;200"},
                { 18, "1;300"},
                { 21, "1;400"},
            };
        }

        /// <summary>
        /// 开启消耗
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string GetGuessCostItem(int index)
        {
            if (index == 0)
            {
                return string.Empty;
            }
            string[] costitem = GuessCostItem().Split('@');
            if (index > costitem.Length)
            {
                return costitem[costitem.Length - 1];
            }
            return costitem[index - 1]; 
        }
       
      
        /// <summary>
        /// 每档随机取几个。抽满一半可以刷新
        /// </summary>
        public static Dictionary<int, List<string>> ChouKa2ItemList()
        {
            return new Dictionary<int, List<string>>()
            {
                {  1, new List<string>(){ "10030013;1", "10030013;1",  "10030013;1",  "10030013;1",  "10030013;1"} },
                {  2, new List<string>(){ "10030013;1", "10030013;1", "10030013;1", "10030013;1", "10030013;1" } },
                {  3, new List<string>(){ "10030013;1", "10030013;1", "10030013;1", "10030013;1", "10030013;1"  } },
            };
        }

        public static List<string> GetRewardListByType(int id, int number)
        {
            List<string> randomList = new List<string>();   
            List<string> rewardList = ChouKa2ItemList()[id];
            int[] randomIds = RandomHelper.GetRandoms(number, 0, rewardList.Count);
            for (int i = 0; i < randomIds.Length; i++)
            {
                randomList.Add(rewardList[randomIds[i]]);
            }
            return randomList;
        }

        public static string GetChouKa2RewardList()
        {
            string rewardList = string.Empty;
            List<string> allrewardList = new List<string>();

            ////每一档取不同的数量
            allrewardList.AddRange(GetRewardListByType(1, 2) );
            allrewardList.AddRange(GetRewardListByType(2, 4));
            allrewardList.AddRange(GetRewardListByType(3, 2));

            for (int i = 0; i < allrewardList.Count; i++)
            {
                rewardList += $"{allrewardList[i]}";
                if (i == allrewardList.Count - 1)
                {
                    break;
                }
                rewardList += "@";
            }
            return rewardList;
        }

        public static int GetChouKa2RewardIndex(string rewardList, List<int> rewardIds)
        {
            List<int> leftIds = new List<int>();  
            int allnumber = rewardList.Split('@').Length;
            for (int i = 0; i < allnumber; i++)
            {
                if (!rewardIds.Contains(i))
                {
                    leftIds.Add(i);
                }
            }
            if (leftIds.Count == 0)
            {
                return -1;
            }
            return leftIds[ RandomHelper.RandomNumber(0, leftIds.Count) ];
        }

        public static List<int> GetLiBaoList()
        {
            return new List<int> { 1, 2, 3 };
        }

    }
}