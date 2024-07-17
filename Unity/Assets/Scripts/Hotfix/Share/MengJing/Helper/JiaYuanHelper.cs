using System.Collections.Generic;
using Unity.Mathematics;

namespace ET
{
    public static partial class JiaYuanHelper
    {

        public const long JiaYuanPurchaseRefresh = 15000;

        public static long GetCookBookCost(int itemLv)
        {
            return 10000 + itemLv * 500;
        }


        public static float3 GetRandomPos()
        {
            return new float3
                (
                    RandomHelper.RandomNumberFloat(-2.5f, 2.5f) + ConfigData.PastureInitPos.x,
                    ConfigData.PastureInitPos.y,
                    RandomHelper.RandomNumberFloat(-5f, 5f) + ConfigData.PastureInitPos.z
                );
        }


        public static int GetRandomMonster()
        {
            int[] monster = new int[ConfigData.JiaYuanMonster.Count];
            int[] weights = new int[ConfigData.JiaYuanMonster.Count];

            int index = 0;
            foreach (var item in ConfigData.JiaYuanMonster)
            {
                monster[index] = item.Key;
                weights[index] = item.Value;

                index++;
            }

            return monster[ RandomHelper.RandomByWeight(weights) ];
        }

        public static int GetPetMoodStar(int mood)
        {
            int star = (int)(mood * 1f / 20);
            return star;
        }

        public static float GetPetExpCoff(int mood)
        {
            mood = GetPetMoodStar(mood);

            switch (mood)
            {
                case 0:
                    return 0.3f;
                case 1:
                    return 0.5f;
                case 2:
                    return 0.65f;
                case 3:
                    return 0.8f;
                case 4:
                    return 0.9f;
                case 5:
                    return 1f;
                default:
                    return 0f;
            }
        }

        public static float3 GetMonsterPostion()
        {
            int positionId = 10001;
            List<MonsterPositionConfig> configs = new List<MonsterPositionConfig>();
            while (positionId > 0)
            {
                MonsterPositionConfig config = MonsterPositionConfigCategory.Instance.Get(positionId);
                configs.Add(config);
                positionId = config.NextID;
            }

            MonsterPositionConfig monsterPosition = configs[ RandomHelper.RandomNumber(0, configs.Count)];
            float range = (float)monsterPosition.CreateRange;
            string[] position = monsterPosition.Position.Split(',');
            float3 vector3 = new float3();
            vector3.x = float.Parse(position[0]) + RandomHelper.RandomNumberFloat(-1 * range, range);
            vector3.y = float.Parse(position[1]);
            vector3.z = float.Parse(position[2]) + RandomHelper.RandomNumberFloat(-1 * range, range);
            return vector3;
        }

        public static void InitPurchaseItemList(int jiayuanID, List<JiaYuanPurchaseItem> jiaYuanPurchases)
        {

            //int jiayuanID = 10001;
            JiaYuanConfig jiayuanCof = JiaYuanConfigCategory.Instance.Get(jiayuanID);

            List<JiaYuanPurchaseItem> newJiaYuanPurchases = new List<JiaYuanPurchaseItem>();
            //int[] dest =  RandomHelper.GetRandoms(4, 0, ConfigHelper.JiaYuanPurchaseList.Count);
            long serverTime = TimeHelper.ServerNow();
            for (int i = 0; i < ConfigData.JiaYuanPurchaseList.Count; i++)
            {
                JiaYuanPurchase jiaYuanPurchase = ConfigData.JiaYuanPurchaseList[i];
                ItemConfig itemCof = ItemConfigCategory.Instance.Get(jiaYuanPurchase.ItemID);
                //家园订单只给超过自身家园等级的
                if (itemCof.UseLv <= jiayuanCof.Lv)
                {
                    JiaYuanPurchaseItem jiaYuanPurchaseItem = JiaYuanPurchaseItem.Create();
                    jiaYuanPurchaseItem.ItemID = jiaYuanPurchase.ItemID;
                    jiaYuanPurchaseItem.LeftNum = jiaYuanPurchase.ItemNum;
                    jiaYuanPurchaseItem.BuyZiJin = jiaYuanPurchase.BuyMinZiJin;
                    int randHour = RandomHelper.RandomNumber(12,37);
                    jiaYuanPurchaseItem.EndTime = serverTime + TimeHelper.Hour * randHour;        //设置时间
                    newJiaYuanPurchases.Add(jiaYuanPurchaseItem);
                }
            }

            //每次循环5个订单出来

            for (int i = 0; i < 5; i++)
            {
                int randInt = RandomHelper.RandomNumber(0, newJiaYuanPurchases.Count);
                JiaYuanPurchaseItem jiaYuanPurchaseItem = CommonHelp.DeepCopy<JiaYuanPurchaseItem>(newJiaYuanPurchases[randInt]);


                int newPurchaseId = jiaYuanPurchases.Count + 1;
                for (int kk = 0; kk < jiaYuanPurchases.Count; kk++)
                {
                    if (jiaYuanPurchases[kk].PurchaseId == newPurchaseId)
                    {
                        newPurchaseId = 10000 + newPurchaseId;
                    }
                }

                jiaYuanPurchaseItem.PurchaseId = newPurchaseId;
                int randHour = RandomHelper.RandomNumber(12, 37);
                jiaYuanPurchaseItem.EndTime = serverTime + TimeHelper.Hour * randHour;        //设置时间
                jiaYuanPurchaseItem.BuyZiJin = RandomHelper.RandomNumber(jiaYuanPurchaseItem.BuyZiJin, jiaYuanPurchaseItem.BuyZiJin * 2);
                jiaYuanPurchases.Add(jiaYuanPurchaseItem);
                //Log.Info("newJiaYuanPurchases[randInt].EndTime = " + newJiaYuanPurchases[randInt].EndTime + "newJiaYuanPurchases[randInt].BuyZiJin = " + newJiaYuanPurchases[randInt].BuyZiJin);
            }
        }

        /// <summary>
        /// 牧场商店
        /// </summary>
        /// <param name="jiayuanLv"></param>
        /// <returns></returns>
        public static List<MysteryItemInfo> InitJiaYuanPastureList(int jiayuanLv)
        {
            List<MysteryItemInfo> mysteryItemInfos = new List<MysteryItemInfo>();
            //JiaYuanConfig jiaYuanConfig = JiaYuanConfigCategory.Instance.JiaYuanLvConfig[jiayuanLv];
            int totalNumber = 6;

            List<int> weightList = new List<int>();
            List<int> mystIdList = new List<int>();

            Dictionary<int, JiaYuanPastureConfig> keyValuePairs = JiaYuanPastureConfigCategory.Instance.GetAll();
            foreach(var item in keyValuePairs)
            {
                if (jiayuanLv < item.Value.BuyJiaYuanLv)
                {
                    continue;
                }

                mystIdList.Add(item.Key);
                weightList.Add(item.Value.BuyJiaYuanPro);
            }

            while (mysteryItemInfos.Count < totalNumber )
            {
                int index = RandomHelper.RandomByWeight(weightList);
                int mystId = mystIdList[index];
                JiaYuanPastureConfig mysteryConfig = JiaYuanPastureConfigCategory.Instance.Get(mystId);
                MysteryItemInfo MysteryItemInfo = MysteryItemInfo.Create();
                MysteryItemInfo.MysteryId = mystId;
                MysteryItemInfo.ItemID = mysteryConfig.GetItemID;
                MysteryItemInfo.ProductId = mysteryItemInfos.Count + 1;
                MysteryItemInfo.ItemNumber = 1;
                mysteryItemInfos.Add(MysteryItemInfo);
            }

            return mysteryItemInfos;
        }

        public static string GetPastureStageName(int state)
        {
            if (state == 0)
            {
                return "幼年期";
            }
            if (state == 1)
            {
                return "成年期";
            }
            if (state == 2)
            {
                return "壮年期";
            }
            if (state == 3)
            {
                return "衰老期";
            }

            return "老年期";
        }

        /// <summary>
        /// 动物缩放
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static float GetPastureStageScale(int state)
        {
            if (state == 0)
            {
                return 0.5f;
            }
            if (state == 1)
            {
                return 0.65f;
            }
            if (state == 2)
            {
                return 0.8f;
            }
            if (state == 3)
            {
                return 1f;
            }

            return 1f;
        }

        public static string GetPlanStageName(int state)
        {
            if (state == 0)
            {
                return "出苗期";
            }
            if (state == 1)
            {
                return "成长期";
            }
            if (state == 2)
            {
                return "成熟期";
            }
            if (state == 3)
            {
                return "收获期";
            }

            return "枯萎期";
        }

        public static string TimeToShow(string timeStr) {
            Log.Info("timeStr = " + timeStr);
            string retuenStr = timeStr.Substring(5, timeStr.Length - 5);
            return retuenStr;
        }

        public static long GetNextStateTime(int itemId, long StartTime)
        {
            long stageTime = 0;
            JiaYuanFarmConfig jiaYuanFarmConfig = JiaYuanFarmConfigCategory.Instance.Get(itemId);
            long serverTime = TimeHelper.ServerNow();
            for (int i = 0; i < jiaYuanFarmConfig.UpTime.Length; i++)
            {
                stageTime = StartTime + jiaYuanFarmConfig.UpTime[i] * 1000;
                if (serverTime < stageTime)
                {
                    break;
                }
            }
            return stageTime;
        }

        public static long GetPastureNextShouHuoTime(int itemid, long StartTime, int GatherNumber, long GatherLastTime)
        {
            JiaYuanPastureConfig jiaYuanFarmConfig = JiaYuanPastureConfigCategory.Instance.Get(itemid);
            long serverTime = TimeHelper.ServerNow();

            long firstTime = (long)(jiaYuanFarmConfig.UpTime[2]) * 1000 + StartTime;
            if (serverTime < firstTime)
            {
                return firstTime;
            }
            if (GatherNumber == 0)
            {
                return firstTime;
            }

            return GatherLastTime + jiaYuanFarmConfig.DropTime * 1000;
        }

        public static long GetPlanNextShouHuoTime(int itemid, long StartTime, int GatherNumber, long GatherLastTime)
        {
            JiaYuanFarmConfig jiaYuanFarmConfig = JiaYuanFarmConfigCategory.Instance.Get(itemid);
            long serverTime = TimeHelper.ServerNow();

            long firstTime = (long)(jiaYuanFarmConfig.UpTime[2]) * 1000 + StartTime;
            if (serverTime < firstTime)
            {
                return firstTime;
            }
            if (GatherNumber == 0)
            {
                return firstTime;
            }

            return GatherLastTime + jiaYuanFarmConfig.GetItemTime * 1000;
        }

        public static int GetPastureShouHuoItem(int itemId, long StartTime, int GatherNumber, long GatherLastTime)
        {
            JiaYuanPastureConfig jiaYuanFarmConfig = JiaYuanPastureConfigCategory.Instance.Get(itemId);
            long serverTime = TimeHelper.ServerNow();

            long firstTime = (long)(jiaYuanFarmConfig.UpTime[2]) * 1000 + StartTime;
            if (serverTime < firstTime)
            {
                return ErrorCode.ERR_CanNotGather;
            }
            if (GatherNumber > 0 && serverTime < GatherLastTime + jiaYuanFarmConfig.DropTime * 1000)
            {
                return ErrorCode.ERR_CanNotGather;
            }
            return ErrorCode.ERR_Success;
        }

        public static int GetPlanShouHuoItem(int itemId, long StartTime, int GatherNumber, long GatherLastTime)
        {
            JiaYuanFarmConfig jiaYuanFarmConfig = JiaYuanFarmConfigCategory.Instance.Get(itemId);
            long serverTime = TimeHelper.ServerNow();

            long firstTime = (long)(jiaYuanFarmConfig.UpTime[2]) * 1000 + StartTime;
            if (serverTime < firstTime)
            {
                return ErrorCode.ERR_CanNotGather;
            }
            if (GatherNumber >= jiaYuanFarmConfig.GetItemNum)
            {
                return ErrorCode.ERR_CanNotGather;
            }
            if (GatherNumber > 0 && serverTime < GatherLastTime + jiaYuanFarmConfig.GetItemTime * 1000)
            {
                return ErrorCode.ERR_CanNotGather;
            }
            return ErrorCode.ERR_Success;
        }

        public static int GetPastureState(int itemId, long StartTime, int GatherNumber)
        {
            int stage = 0;
            JiaYuanPastureConfig jiaYuanFarmConfig = JiaYuanPastureConfigCategory.Instance.Get(itemId);
            long passTime = TimeHelper.ServerNow() - StartTime;
            for (int i = 0; i < jiaYuanFarmConfig.UpTime.Length; i++)
            {
                if (passTime >= jiaYuanFarmConfig.UpTime[i] * 1000)
                {
                    stage = i + 1;
                }
            }

            //收货上限才为第四个阶段 0[种子] 1 2 3 4[废柴]
            if (stage < 3)
            {
                return stage;
            }
            return 3;
        }

        public static int GetPlanStage(int itemId, long StartTime, int GatherNumber)
        {
            int stage = 0;
            JiaYuanFarmConfig jiaYuanFarmConfig = JiaYuanFarmConfigCategory.Instance.Get(itemId);
            long passTime = TimeHelper.ServerNow() - StartTime;
            for (int i = 0; i < jiaYuanFarmConfig.UpTime.Length; i++)
            {
                if (passTime >= jiaYuanFarmConfig.UpTime[i] * 1000)
                {
                    stage = i + 1;
                }
            }

            //收货上限才为第四个阶段 0[种子] 1 2 3 4[废柴]
            if (stage < 3)
            {
                return stage;
            }
            if (GatherNumber >= jiaYuanFarmConfig.GetItemNum)
            {
                return stage;
            }
            else
            {
                return 3;
            }
        }

        //获取家园开启仓库格子消耗
        public static string GetOpenJiaYuanWarehouse(int page) {

            string costItems = GlobalValueConfigCategory.Instance.Get(86).Value;
            string[] costItemsList = costItems.Split('@');
            return costItemsList[page - 1];
            
        }
        
    }
}
