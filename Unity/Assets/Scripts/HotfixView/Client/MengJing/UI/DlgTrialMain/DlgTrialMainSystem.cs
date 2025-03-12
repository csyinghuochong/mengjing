using System;

namespace ET.Client
{
    [Invoke(TimerInvokeType.TrialMainTimer)]
    public class TrialMainTimer : ATimer<DlgTrialMain>
    {
        protected override void Run(DlgTrialMain self)
        {
            try
            {
                self.OnTimer();
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

    [FriendOf(typeof(DlgTrialMain))]
    public static class DlgTrialMainSystem
    {
        public static void RegisterUIEvent(this DlgTrialMain self)
        {
            self.View.E_ButtonTiaozhanButton.AddListener(self.OnButtonTiaozhan);
            
            self.OnResetHurt();
            self.BeginTimer();
        }

        public static void ShowWindow(this DlgTrialMain self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgTrialMain self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void StopTimer(this DlgTrialMain self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void OnResetHurt(this DlgTrialMain self)
        {
            self.View.E_TextHurtText.text = "伤害总值:0\n伤害秒值:0";
        }

        public static void OnUpdateHurt(this DlgTrialMain self, M2C_TrialDungeonDamage dungeonDamage)
        {
            self.HurtValue = dungeonDamage.HurtValue;
            self.BeginTime = dungeonDamage.BeginTime;
            
            long leftTime = TimeHelper.ServerNow() - dungeonDamage.BeginTime;
            leftTime = Math.Clamp( leftTime, 0, TimeHelper.Minute );
            float fightTime = (TimeHelper.Minute - leftTime) * 0.001f;
            
            using (zstring.Block())
            {
                self.View.E_TextHurtText.text = zstring.Format("伤害总值:{0}\n伤害秒值:{1}",dungeonDamage.HurtValue, (int)((float)dungeonDamage.HurtValue / fightTime));
            }
        }

        public static void BeginTimer(this DlgTrialMain self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.BeginTime = TimeHelper.ServerNow() ;
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.TrialMainTimer, self);
            self.OnTimer(); 
        }

        public static void OnButtonTiaozhan(this DlgTrialMain self)
        {
            if (TimeHelper.ServerNow() - self.LastTiaoZhan < 1000)
            {
                return;
            }

            self.LastTiaoZhan = TimeHelper.ServerNow();

            PopupTipHelp.OpenPopupTip(self.Root(), "系统提示", "是否重新开始挑战,开始后倒计时和怪物生命将自动初始化", () => { self.RequestTiaozhan().Coroutine(); }, null)
                    .Coroutine();
        }

        public static async ETTask RequestTiaozhan(this DlgTrialMain self)
        {
            int error = await ActivityNetHelper.TrialDungeonBeginRequest(self.Root());
            if (error != ErrorCode.ERR_Success)
            {
                return;
            }
            
            self.BeginTimer();
            self.OnResetHurt();
        }

        public static void OnTimer(this DlgTrialMain self)
        {
            long leftTime = ( self.BeginTime + TimeHelper.Minute ) - TimeHelper.ServerNow();
            if (leftTime <= 0)
            {
                self.Root().GetComponent<ClientSenderCompnent>().Call(C2M_TrialDungeonFinishRequest.Create()).Coroutine();
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
                self.View.E_TextCoundownText.text = "00:00";
                //self.View.E_TextCoundownText.text = "未能在60秒内击败怪物,请点击重新挑战";

                return;
            }

            using (zstring.Block())
            {
                self.View.E_TextCoundownText.text = zstring.Format("剩余时间 {0}", TimeHelper.FormatSecondsToTime(leftTime));
            }
        }
    }
}