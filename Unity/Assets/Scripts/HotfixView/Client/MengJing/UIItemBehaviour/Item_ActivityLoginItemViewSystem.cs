using System.Collections.Generic;
using System.Linq;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_ActivityLoginItem))]
    [EntitySystemOf(typeof (Scroll_Item_ActivityLoginItem))]
    public static partial class Scroll_Item_ActivityLoginItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_ActivityLoginItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_ActivityLoginItem self)
        {
            self.DestroyWidget();
        }

        public static bool CanReceive(this Scroll_Item_ActivityLoginItem self, int activityId)
        {
            List<int> allIds = new List<int>();
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < activityConfigs.Count; i++)
            {
                if (activityConfigs[i].ActivityType != 31)
                {
                    continue;
                }

                if (activityConfigs[i].Id < activityId)
                {
                    allIds.Add(activityConfigs[i].Id);
                }
            }

            for (int i = 0; i < allIds.Count; i++)
            {
                if (!activityComponent.ActivityReceiveIds.Contains(allIds[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static async ETTask OnBtn_Receive(this Scroll_Item_ActivityLoginItem self)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            if (userInfo.Lv < 10)
            {
                FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("10级才能领取！"));
                return;
            }

            if (!self.CanReceive(self.ActivityConfig.Id))
            {
                FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("未达到领取条件！"));
                return;
            }

            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            if (CommonHelp.GetDayByTime(activityComponent.LastLoginTime) == CommonHelp.GetDayByTime(TimeHelper.ServerNow()))
            {
                FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("今天的奖励已领取"));
                return;
            }

 
            M2C_ActivityReceiveResponse response =  await ActivityNetHelper.ActivityReceive(self.Root(), self.ActivityConfig.ActivityType, self.ActivityConfig.Id);
            if (response == null || response.Error != ErrorCode.ERR_Success)
            {
                return;
            }
            self.SetReceived(true);
            self.Root().GetComponent<ReddotComponentC>().UpdateReddont(ReddotType.WelfareLogin);
        }

        public static void OnUpdateUI(this Scroll_Item_ActivityLoginItem self, ActivityConfig activityConfig)
        {
            self.E_Btn_ReceiveButton.AddListenerAsync(self.OnBtn_Receive);

            self.ActivityConfig = activityConfig;

            self.E_Lab_NameText.text = activityConfig.Par_4;
            self.ES_RewardList.Refresh(activityConfig.Par_3, 0.8f);
        }

        public static void SetReceived(this Scroll_Item_ActivityLoginItem self, bool received)
        {
            self.E_Btn_ReceiveButton.gameObject.SetActive(!received);
            self.E_ImageReceivedImage.gameObject.SetActive(received);
        }
    }
}