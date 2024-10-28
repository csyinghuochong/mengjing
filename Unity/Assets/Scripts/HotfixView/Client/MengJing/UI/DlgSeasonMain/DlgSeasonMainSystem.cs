using System;

namespace ET.Client
{
    [Invoke(TimerInvokeType.SeasonTowerTimer)]
    public class SeasonTowerTimer : ATimer<DlgSeasonMain>
    {
        protected override void Run(DlgSeasonMain self)
        {
            try
            {
                self.OnUpdate();
            }
            catch (Exception e)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("move timer error: {0}\n{1}", self.Id, e.ToString()));
                }
            }
        }
    }

    [FriendOf(typeof(DlgSeasonMain))]
    public static class DlgSeasonMainSystem
    {
        public static void RegisterUIEvent(this DlgSeasonMain self)
        {
            self.CDTimer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.SeasonTowerTimer, self);
            self.CDdownTimeNumber = 100;
        }

        public static void ShowWindow(this DlgSeasonMain self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgSeasonMain self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.CDTimer);
        }

        public static async ETTask WaitReturn(this DlgSeasonMain self)
        {
            long instanceid = self.InstanceId;
            await self.Root().GetComponent<TimerComponent>().WaitAsync(5000);

            if (instanceid != self.InstanceId)
            {
                return;
            }

            EnterMapHelper.RequestQuitFuben(self.Root());
        }

        public static void OnUpdate(this DlgSeasonMain self)
        {
            if (self.CDdownTimeNumber < 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("本层赛季之塔的时间已经用尽，请返回主城!");
                self.Root().GetComponent<TimerComponent>().Remove(ref self.CDTimer);
                self.WaitReturn().Coroutine();
                return;
            }

            if (self.CDdownTimeNumber >= 0)
            {
                int showTime = self.CDdownTimeNumber;
                int minute = showTime / 60;
                int sceond = showTime % 60;
                using (zstring.Block())
                {
                    self.View.E_CDdownTimeTextText.text = zstring.Format("倒计时 {0}:{1}", minute, sceond);
                }
            }

            self.CDdownTimeNumber--;
        }
    }
}
