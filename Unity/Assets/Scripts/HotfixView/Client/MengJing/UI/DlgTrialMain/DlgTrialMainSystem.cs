using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Invoke(TimerInvokeType.TrialMainTimer)]
    public class TrialMainTimer: ATimer<DlgTrialMain>
    {
        protected override void Run(DlgTrialMain self)
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

    [FriendOf(typeof (DlgTrialMain))]
    public static class DlgTrialMainSystem
    {
        public static void RegisterUIEvent(this DlgTrialMain self)
        {
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

        public static void OnUpdateHurt(this DlgTrialMain self, long hurt)
        {
            if (hurt > 0)
            {
                return;
            }

            hurt *= -1;
            self.HurtValue += hurt;

            if (self.FightTime <= 0)
            {
                self.FightTime = 1;
            }

            self.View.E_TextHurtText.text = $"伤害总值:{self.HurtValue}\n伤害秒值:{(int)((float)self.HurtValue / self.FightTime)}";
        }

        public static void BeginTimer(this DlgTrialMain self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.Countdown = 60;
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.TrialMainTimer, self);
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
            self.HurtValue = 0;
            self.OnUpdateHurt(0);
            self.FightTime = 0;
        }

        public static void OnTimer(this DlgTrialMain self)
        {
            if (self.Countdown <= 0)
            {
                self.Root().GetComponent<ClientSenderCompnent>().Call(new C2M_TrialDungeonFinishRequest()).Coroutine();
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);

                self.View.E_TextCoundownText.text = $"未能在60秒内击败怪物,请点击重新挑战";

                return;
            }

            self.View.E_TextCoundownText.text = $"倒计时 {self.Countdown - 1}";
            self.Countdown--;
            self.FightTime++;
        }
    }
}