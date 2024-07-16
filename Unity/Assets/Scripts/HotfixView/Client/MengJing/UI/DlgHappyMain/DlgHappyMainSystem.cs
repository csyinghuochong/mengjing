using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Invoke(TimerInvokeType.UIHappyMainTimer)]
    public class UIHappyMainTimer: ATimer<DlgHappyMain>
    {
        protected override void Run(DlgHappyMain self)
        {
            try
            {
                self.OnUpdate();
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
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
        }

        public static void ShowWindow(this DlgHappyMain self, Entity contextData = null)
        {
            self.EndTime = FunctionHelp.GetCloseTime(1055);

            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(TimeHelper.Second, TimerInvokeType.UIHappyMainTimer, self);
            self.OnInitUI();
            self.OnUpdateMoney();
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
                self.View.E_TextCoundownText.text = $"下次道具刷新: {minute}:{second}";
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
                self.View.E_EndTimeTextText.text = $"活动结束倒计时 {endTime / 60}:{endTime % 60}";
            }
            else
            {
                self.View.E_EndTimeTextText.text = $"活动结束还剩{endTime % 60}秒，活动结束将强制离开地图哦。";
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

            //金币消耗
            GlobalValueConfig globalValueConfig1 = GlobalValueConfigCategory.Instance.Get(94);
            self.View.E_TextTip_2Text.text = $"金币消耗:{globalValueConfig1.Value2}";

            //钻石消耗
            GlobalValueConfig globalValueConfig2 = GlobalValueConfigCategory.Instance.Get(95);
            self.View.E_TextTip_3Text.text = $"钻石消耗:{globalValueConfig2.Value2}";
        }

        public static void OnButtonPick(this DlgHappyMain self)
        {
            if (self.Root().GetComponent<BagComponentC>().GetBagLeftCell() <= 0)
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_BagIsFull);
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int cellindex = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.HappyCellIndex);

            List<DropInfo> ids = MapHelper.GetCanShiQuByCell(self.Root(), cellindex);
            if (ids.Count > 0)
            {
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.ES_MainSkill.RequestShiQu(ids).Coroutine();

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
                if (userInfoComponent.UserInfo.Gold < globalValueConfig.Value2)
                {
                    HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_GoldNotEnoughError);
                    return;
                }

                PopupTipHelp.OpenPopupTip(self.Root(), "喜从天降", $"是否消耗{globalValueConfig.Value2}金币?", async () =>
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
                return;
            }

            if (moveType == 3)
            {
                GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(95);
                if (userInfoComponent.UserInfo.Diamond < globalValueConfig.Value2)
                {
                    HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_DiamondNotEnoughError);
                    return;
                }

                PopupTipHelp.OpenPopupTip(self.Root(), "喜从天降", $"是否消耗{globalValueConfig.Value2}钻石?", async () =>
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
        private static void Awake(this ET.Client.DlgHappyMain self)
        {

        }
        
    }
}