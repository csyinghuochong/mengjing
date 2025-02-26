using System.Collections.Generic;
using System.Linq;

namespace ET.Client
{
    [FriendOf(typeof (ActivityComponentC))]
    [EntitySystemOf(typeof (ActivityComponentC))]
    public static partial class ActivityComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this ActivityComponentC self)
        {
        }

        public static int GetCurActivityId(this ActivityComponentC self, int rechargeNumb)
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

        public static bool HaveLoginReward(this ActivityComponentC self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (userInfoComponent.UserInfo.Lv < 10)
            {
                return false;
            }

            int unGetId = 0;
            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < activityConfigs.Count; i++)
            {
                if (activityConfigs[i].ActivityType != 31)
                {
                    continue;
                }

                if (!self.ActivityReceiveIds.Contains(activityConfigs[i].Id))
                {
                    unGetId = activityConfigs[i].Id;
                    break;
                }
            }

            if (unGetId == 0)
            {
                return false;
            }

            return CommonHelp.GetDayByTime(TimeHelper.ServerNow()) != CommonHelp.GetDayByTime(self.LastLoginTime);
        }

        public static void OnZeroClockUpdate(this ActivityComponentC self)
        {
            //重置每日特惠
            for (int i = self.ActivityReceiveIds.Count - 1; i >= 0; i--)
            {
                ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(self.ActivityReceiveIds[i]);
                if (activityConfig.ActivityType == (int)ActivityEnum.Type_2 || activityConfig.ActivityType == (int)ActivityEnum.Type_32)
                {
                    self.ActivityReceiveIds.RemoveAt(i);
                }
            }
        }
    }
}