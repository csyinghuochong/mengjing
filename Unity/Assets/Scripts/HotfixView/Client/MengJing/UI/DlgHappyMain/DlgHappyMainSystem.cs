using System;
using System.Collections.Generic;

namespace ET.Client
{
    [Invoke(TimerInvokeType.UIHappyMainTimer)]
    public class UIHappyMainTimer : ATimer<DlgHappyMain>
    {
        protected override void Run(DlgHappyMain self)
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

    [EntitySystemOf(typeof(DlgHappyMain))]
    [FriendOf(typeof(DlgHappyMain))]
    public static partial class DlgHappyMainSystem
    {
        public static void RegisterUIEvent(this DlgHappyMain self)
        {
            self.View.E_ButtonMove_3Button.AddListener(() => { self.OnButtonMove(3).Coroutine(); });
            self.View.E_ButtonMove_2Button.AddListener(() => { self.OnButtonMove(2).Coroutine(); });
            self.View.E_ButtonMove_1Button.AddListener(() => { self.OnButtonMove(1).Coroutine(); });

            self.View.E_ButtonPickButton.AddListener(() => { self.OnButtonPick(); });
            
            self.EndTime = FunctionHelp.GetCloseTime(1055);
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(TimeHelper.Second, TimerInvokeType.UIHappyMainTimer, self);
            self.OnInitUI();
            self.OnUpdateMoney();
        }

        public static void ShowWindow(this DlgHappyMain self, Entity contextData = null)
        {
        }

        public static void HideWindow(this DlgHappyMain self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void OnInitUI(this DlgHappyMain self)
        {
            M2C_HappyInfoResult m2C_Happy = self.Root().GetComponent<BattleMessageComponent>().M2C_HappyInfoResult;
            if (m2C_Happy != null)
            {
                self.OnUpdateUI(m2C_Happy);
            }
        }

        public static void OnUpdateUI(this DlgHappyMain self, M2C_HappyInfoResult m2C_Happy)
        {
            self.NextFefreshTime = m2C_Happy.NextRefreshTime;
            self.OnUpdate();
        }

        public static void OnUpdate(this DlgHappyMain self)
        {
            long leftTime = self.NextFefreshTime - TimeHelper.ServerNow();
            if (leftTime >= 0)
            {
                leftTime /= 1000;
                int minute = (int)(leftTime / 60);
                int second = (int)(leftTime % 60);
                using (zstring.Block())
                {
                    self.View.E_TextCoundownText.text = zstring.Format("下次道具刷新: {0}:{1}", minute, second);
                }
            }
            else
            {
                self.View.E_TextCoundownText.text = self.DefaultTime;
            }

            DateTime dateTime = TimeInfo.Instance.ToDateTime(TimeHelper.ServerNow());
            long curTime = (dateTime.Hour * 60 + dateTime.Minute) * 60 + dateTime.Second;
            long endTime = self.EndTime - curTime;
            if (endTime > 60)
            {
                using (zstring.Block())
                {
                    self.View.E_EndTimeTextText.text = zstring.Format("活动结束倒计时 {0}:{1}", endTime / 60, endTime % 60);
                }
            }
            else
            {
                using (zstring.Block())
                {
                    self.View.E_EndTimeTextText.text = zstring.Format("活动结束还剩{0}秒，活动结束将强制离开地图哦。", endTime % 60);
                }
            }

            if (endTime <= 0)
            {
                EnterMapHelper.RequestQuitFuben(self.Root());
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
                return;
            }

            long moveTime = self.NextMoveTime - TimeHelper.ServerNow();
            if (moveTime >= 0)
            {
                moveTime /= 1000;
                int minute = (int)(moveTime / 60);
                int second = (int)(moveTime % 60);
                self.View.E_TextTip_1Text.text = $"{minute}:{second}";
            }
            else
            {
                self.View.E_TextTip_1Text.text = "可以进行移动";
            }
        }

        public static void OnUpdateMoney(this DlgHappyMain self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            long lastmovetime = unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.HappyMoveTime);
            self.NextMoveTime = lastmovetime;

            using (zstring.Block())
            {
                //金币消耗
                GlobalValueConfig globalValueConfig1 = GlobalValueConfigCategory.Instance.Get(94);
                self.View.E_TextTip_2Text.text = zstring.Format("金币消耗:{0}", int.Parse(globalValueConfig1.Value));

                //钻石消耗
                GlobalValueConfig globalValueConfig2 = GlobalValueConfigCategory.Instance.Get(95);
                self.View.E_TextTip_3Text.text = zstring.Format("钻石消耗:{0}", int.Parse(globalValueConfig2.Value));
            }
        }

        public static void OnButtonPick(this DlgHappyMain self)
        {
            if (self.Root().GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag) <= 0)
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_BagIsFull);
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int cellindex = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.HappyCellIndex);

            List<Unit> units = MapHelper.GetCanShiQuByCell(self.Root(), cellindex);
            if (units.Count > 0)
            {
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.ES_MainSkill.RequestShiQu(units).Coroutine();

                //播放音效
                CommonViewHelper.PlayUIMusic("10004");
                return;
            }
        }

        public static async ETTask OnButtonMove(this DlgHappyMain self, int moveType)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();

            if (moveType == 1)
            {
                //非免费时间则返回
                long moveTime = self.NextMoveTime - TimeHelper.ServerNow();
                if (moveTime > 0)
                {
                    return;
                }
            }

            if (moveType == 2)
            {
                GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(94);
                if (userInfoComponent.UserInfo.Gold <int.Parse( globalValueConfig.Value))
                {
                    HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_GoldNotEnoughError);
                    return;
                }

                using (zstring.Block())
                {
                    PopupTipHelp.OpenPopupTip(self.Root(), "喜从天降", zstring.Format("是否消耗{0}金币?",int.Parse( globalValueConfig.Value)), async () =>
                    {
                        long instanceId = self.InstanceId;
                        int error = await ActivityNetHelper.HappyMoveRequest(self.Root(), moveType);
                        if (instanceId != self.InstanceId || error != ErrorCode.ERR_Success)
                        {
                            return;
                        }

                        Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());

                        FunctionEffect.PlayDropEffect(unit, 30000003);
                        self.OnButtonPick();

                        self.OnUpdateMoney();
                    }).Coroutine();
                }

                return;
            }

            if (moveType == 3)
            {
                GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(95);
                if (userInfoComponent.UserInfo.Diamond < int.Parse(globalValueConfig.Value))
                {
                    HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_DiamondNotEnoughError);
                    return;
                }

                using (zstring.Block())
                {
                    PopupTipHelp.OpenPopupTip(self.Root(), "喜从天降", zstring.Format("是否消耗{0}钻石?", int.Parse(globalValueConfig.Value)), async () =>
                    {
                        long instanceId = self.InstanceId;
                        int error = await ActivityNetHelper.HappyMoveRequest(self.Root(), moveType);
                        if (instanceId != self.InstanceId || error != ErrorCode.ERR_Success)
                        {
                            return;
                        }

                        Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());

                        FunctionEffect.PlayDropEffect(unit, 30000003);
                        self.OnButtonPick();

                        self.OnUpdateMoney();
                    }).Coroutine();
                }

                return;
            }

            long instanceId = self.InstanceId;
            int error = await ActivityNetHelper.HappyMoveRequest(self.Root(), moveType);
            if (instanceId != self.InstanceId || error != ErrorCode.ERR_Success)
            {
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());

            FunctionEffect.PlayDropEffect(unit, 30000003);
            self.OnButtonPick();

            self.OnUpdateMoney();
        }

        [EntitySystem]
        private static void Awake(this DlgHappyMain self)
        {
        }
    }
}
