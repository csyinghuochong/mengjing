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
    }
}