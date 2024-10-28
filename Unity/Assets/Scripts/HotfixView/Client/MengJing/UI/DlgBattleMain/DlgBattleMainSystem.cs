using System;

namespace ET.Client
{
    [Invoke(TimerInvokeType.BattleMainTimer)]
    public class BattleMainTimer : ATimer<DlgBattleMain>
    {
        protected override void Run(DlgBattleMain self)
        {
            try
            {
                self.OnTimer();
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
            }
        }
    }

    [FriendOf(typeof(DlgBattleMain))]
    public static class DlgBattleMainSystem
    {
        public static void RegisterUIEvent(this DlgBattleMain self)
        {
            DateTime dateTime = TimeInfo.Instance.ToDateTime(TimeHelper.ServerNow());
            int huor = dateTime.Hour;
            int minute = dateTime.Minute;

            long curTime = (huor * 60 * 60 + minute * 60 + dateTime.Second) * 1000;
            long closeTime = FunctionHelp.GetCloseTime(1025) * 1000;
            self.CDTime = (int)(closeTime - curTime) - RandomHelper.RandomNumber(1000, 10000);
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.BattleMainTimer, self);

            self.OnUpdateSelfKill();
        }

        public static void ShowWindow(this DlgBattleMain self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgBattleMain self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void OnTimer(this DlgBattleMain self)
        {
            if (self.CDTime < 0)
            {
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
                EnterMapHelper.RequestQuitFuben(self.Root());
                return;
            }

            self.CDTime -= 1000;
            using (zstring.Block())
            {
                self.View.E_CountDownTimeText.text = zstring.Format("倒计时: {0}", TimeHelper.ShowLeftTime(self.CDTime));
            }
        }

        public static void OnUpdateUI(this DlgBattleMain self, M2C_BattleInfoResult message)
        {
            self.View.E_TextVS_1Text.text = message.CampKill_1.ToString();
            self.View.E_TextVS_2Text.text = message.CampKill_2.ToString();
        }

        public static void OnUpdateSelfKill(this DlgBattleMain self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            using (zstring.Block())
            {
                self.View.E_TextVS_KillText.text =
                        zstring.Format("自身已战胜{0}个玩家", unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.BattleTodayKill));
            }
        }
    }
}
