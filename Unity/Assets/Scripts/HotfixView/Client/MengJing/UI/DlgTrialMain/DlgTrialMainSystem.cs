using System;
using Unity.Mathematics;

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
            self.View.E_ButtonDamageButton.AddListenerAsync(self.OnButtonDamageButton);
            
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
            self.View.EG_Text_FailTip.gameObject.SetActive(false);
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

        public static async ETTask OnButtonDamageButton(this DlgTrialMain self)
        {
            long instanceid = self.InstanceId;  
            M2C_DamageValueListResponse damageValueListResponse = await CellDungeonNetHelper.RequestDamageValueList( self.Root() );
            if (instanceid != self.InstanceId || damageValueListResponse == null)
            {
                return;
            }
            
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_DamageValue);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgDamageValue>().OnInitUI(damageValueListResponse);
        }

        public static void OnButtonTiaozhan(this DlgTrialMain self)
        {
            if (TimeHelper.ServerNow() - self.LastTiaoZhan < 1000)
            {
                return;
            }

            self.LastTiaoZhan = TimeHelper.ServerNow();

            PopupTipHelp.OpenPopupTip(self.Root(), "系统提示", "是否重新开始挑战，开始后倒计时和怪物生命将自动初始化。", () => { self.RequestTiaozhan().Coroutine(); }, null)
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
            self.ResetMainUI();
            self.ShowBossBronEffect();
        }

        private static void ShowBossBronEffect(this DlgTrialMain self)
        {
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            TowerConfig towerConfig = TowerConfigCategory.Instance.Get(mapComponent.SonSceneId);
            string[] monsterinfo = towerConfig.MonsterSet.Split(';');
            string[] positioninfo = monsterinfo[1].Split(',');
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            FunctionEffect.PlayEffectPosition(unit, 200007, new float3( float.Parse(positioninfo[0]), float.Parse(positioninfo[1]),  float.Parse(positioninfo[2]) ));
        }

        private static void ResetMainUI(this DlgTrialMain self)
        {
            DlgMain dlgMain = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>();
            dlgMain.DlgMainReset(MapTypeEnum.TrialDungeon);
        }

        public static void OnTimer(this DlgTrialMain self)
        {
            long leftTime = ( self.BeginTime + TimeHelper.Minute ) - TimeHelper.ServerNow();
            if (leftTime <= 0)
            {
                self.Root().GetComponent<ClientSenderCompnent>().Call(C2M_TrialDungeonFinishRequest.Create()).Coroutine();
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
                self.View.E_TextCoundownText.text = "00:00";
                self.View.EG_Text_FailTip.gameObject.SetActive(true);

                return;
            }

            using (zstring.Block())
            {
                self.View.E_TextCoundownText.text = zstring.Format("剩余时间 {0}", TimeHelper.FormatSecondsToTime(leftTime));
            }
        }
    }
}
