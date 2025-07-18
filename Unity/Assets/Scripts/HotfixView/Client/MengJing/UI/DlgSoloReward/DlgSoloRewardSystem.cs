using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof(DlgSoloReward))]
    public static class DlgSoloRewardSystem
    {
        public static void RegisterUIEvent(this DlgSoloReward self)
        {
            self.View.E_Btn_ReturnButton.AddListener(self.ReturnBtn);
        }

        public static void ShowWindow(this DlgSoloReward self, Entity contextData = null)
        {
        }

        public static void OnInit(this DlgSoloReward self, int type, List<RewardItem> rewardItem)
        {
            if (type == 1)
            {
                self.View.E_Text_CengText.text = "恭喜你！获得本场挑战的胜利";
            }
            else
            {
                self.View.E_Text_CengText.text = "非常遗憾！你在本场挑战失败，请再接再厉。";
            }

            //显示奖励列表
            if (rewardItem != null && rewardItem.Count != 0)
            {
                self.View.ES_RewardList.Refresh(rewardItem);
            }

            self.TimeDestory().Coroutine();
        }

        public static async ETTask TimeDestory(this DlgSoloReward self)
        {
            //10秒后强退
            long instanceid = self.InstanceId;
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            for (int i = 10; i >= 0; i--)
            {
                await timerComponent.WaitAsync(1000);
                if (instanceid != self.InstanceId)
                {
                    break;
                }

                if (self.View.E_Text_ReturnTimeText != null)
                {
                    using (zstring.Block())
                    {
                        self.View.E_Text_ReturnTimeText.text = zstring.Format("{0}秒后自动回城", i);
                    }
                }

                if (i <= 0)
                {
                    self.ReturnBtn();
                }
            }
        }

        public static void ReturnBtn(this DlgSoloReward self)
        {
            Log.Debug("我点击了返回主城按钮");

            EnterMapHelper.RequestQuitFuben(self.Root());
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_SoloReward);
        }
    }
}
