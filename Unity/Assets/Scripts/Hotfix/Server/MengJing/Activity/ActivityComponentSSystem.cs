using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{

    [EntitySystemOf(typeof(ActivityComponentS))]
    [FriendOf(typeof(ActivityComponentS))]
    public static partial class ActivityComponentSSystem
    {
        [EntitySystem]
        private static void Awake(this ActivityComponentS self)
        {
            if (self.ActivityV1Info == null)
            {
                self.ActivityV1Info = self.AddChild<ActivityV1Info>();
            }
        }
        [EntitySystem]
        private static void Destroy(this ActivityComponentS self)
        {

        }
        
        [EntitySystem]
        private static void Deserialize(this ActivityComponentS self)
        {
            foreach (Entity entity in self.Children.Values)
            {
                ActivityV1Info activityV1Info = entity as ActivityV1Info;

                self.ActivityV1Info = activityV1Info;
            }
            
            if (self.ActivityV1Info == null)
            {
                self.ActivityV1Info = self.AddChild<ActivityV1Info>();
            }
        }
        
        /// <summary>
        /// 取到当前可以领取的最小等级
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static int GetCurActivityId(this ActivityComponentS self, int rechargeNumb)
        {
            int activityId = 0;
            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < activityConfigs.Count; i++)
            {
                if (activityConfigs[i].ActivityType != 101)
                {
                    continue;
                }
                activityId = activityConfigs[i].Id;
                int needNumber = int.Parse(activityConfigs[i].Par_2);
                if (rechargeNumb < needNumber)
                {
                    break;
                }
                if (rechargeNumb >= needNumber && !self.ActivityReceiveIds.Contains(activityId))
                {
                    break;
                }
            }
            return activityId;
        }
                
        public static int GetMaxActivityId(this ActivityComponentS self, int rechargeNumb)
        {
            int activityId = 0;
            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < activityConfigs.Count; i++)
            {
                if (activityConfigs[i].ActivityType != 101)
                {
                    continue;
                }
                int needNumber = int.Parse(activityConfigs[i].Par_2);
                if (rechargeNumb < needNumber)
                {
                    break;
                }
                activityId = activityConfigs[i].Id;
            }
            return activityId;
        }

        public static void OnLogin(this ActivityComponentS self, int level)
        {
            if (self.DayTeHui.Count == 0)
            {
                self.DayTeHui = DayTeHuiHelper.GetDayTeHuiList(2, level);
            }
            if (self.ActivityV1Info.LiBaoAllIds.Count == 0)
            {
                self.ActivityV1Info.LiBaoAllIds = ActivityConfigHelper.GetLiBaoList( );
            }
            if (string.IsNullOrEmpty(self.ActivityV1Info.ChouKa2ItemList))
            {
                self.ActivityV1Info.ChouKa2ItemList = ActivityConfigHelper.GetChouKa2RewardList();
            }
        }

        public static void ClearJieRiActivty(this ActivityComponentS self)
        {
            for (int i = self.ActivityReceiveIds.Count - 1; i >= 0; i--)
            {
                ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(self.ActivityReceiveIds[i]);
                if (activityConfig.ActivityType == (int)ActivityEnum.Type_33)
                {
                    self.ActivityReceiveIds.RemoveAt(i);
                }
            }
        }

        public static void OnZeroClockUpdate(this ActivityComponentS self, int level)
        {
            self.DayTeHui = DayTeHuiHelper.GetDayTeHuiList(2, level);
            
            //重置每日特惠 和 新春活动
            for (int i = self.ActivityReceiveIds.Count -1; i >= 0; i--)
            {
                ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(self.ActivityReceiveIds[i]);
                if (activityConfig.ActivityType == (int)ActivityEnum.Type_2 || activityConfig.ActivityType == (int)ActivityEnum.Type_32)
                {
                    self.ActivityReceiveIds.RemoveAt(i);
                }
            }

            // 周期重置签到活动
            if (self.TotalSignNumber >= ActivityConfigCategory.Instance.GetNumByType((int)ActivityEnum.Type_23))
            {
                self.TotalSignNumber = 0;
                for (int i = self.ActivityReceiveIds.Count - 1; i >= 0; i--)
                {
                    ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(self.ActivityReceiveIds[i]);
                    if (activityConfig.ActivityType == (int)ActivityEnum.Type_23 || 
                        activityConfig.ActivityType == (int)ActivityEnum.Type_26)
                    {
                        self.ActivityReceiveIds.RemoveAt(i);
                    }
                }
            }
            if (self.TotalSignNumber_VIP >= ActivityConfigCategory.Instance.GetNumByType((int)ActivityEnum.Type_25))
            {
                self.TotalSignNumber_VIP = 0;
                for (int i = self.ActivityReceiveIds.Count - 1; i >= 0; i--)
                {
                    ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(self.ActivityReceiveIds[i]);
                    if (activityConfig.ActivityType == (int)ActivityEnum.Type_25 || 
                        activityConfig.ActivityType == (int)ActivityEnum.Type_27)
                    {
                        self.ActivityReceiveIds.RemoveAt(i);
                    }
                }
            }


            self.ActivityV1Info.LiBaoAllIds = ActivityConfigHelper.GetLiBaoList();
            self.ActivityV1Info.LiBaoBuyIds.Clear();
            self.ActivityV1Info.LastGuessReward.Clear();
            self.ActivityV1Info.ChouKaNumberReward.Clear(); 
            self.ActivityV1Info.ConsumeDiamondReward.Clear();   
        }

    }
}