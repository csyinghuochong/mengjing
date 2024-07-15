﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Invoke(TimerInvokeType.DungeonHappyMainTimer)]
    public class DungeonHappyMainTimer: ATimer<DlgDungeonHappyMain>
    {
        protected override void Run(DlgDungeonHappyMain self)
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

    [FriendOf(typeof (DlgDungeonHappyMain))]
    public static class DlgDungeonHappyMainSystem
    {
        public static void RegisterUIEvent(this DlgDungeonHappyMain self)
        {
            self.View.E_ButtonMove_3Button.AddListener(() => { self.OnButtonMove(3).Coroutine(); });
            self.View.E_ButtonMove_2Button.AddListener(() => { self.OnButtonMove(2).Coroutine(); });
            self.View.E_ButtonMove_1Button.AddListener(() => { self.OnButtonMove(1).Coroutine(); });

            self.View.E_ButtonPickButton.AddListener(() => { self.OnButtonPick(); });
        }

        public static void ShowWindow(this DlgDungeonHappyMain self, Entity contextData = null)
        {
            self.View.E_TextTip_3Text.gameObject.SetActive(false);
            self.View.E_TextTip_2Text.gameObject.SetActive(false);

            self.View.E_ButtonMove_3Button.gameObject.SetActive(false);
            self.View.E_ButtonMove_2Button.gameObject.SetActive(false);

            self.EndTime = TimeHelper.ServerNow() + TimeHelper.Minute * 10;
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(TimeHelper.Second, TimerInvokeType.DungeonHappyMainTimer, self);
            self.OnUpdateMoney();
            self.OnUpdate();
        }

        public static void BeforeUnload(this DlgDungeonHappyMain self)
        {
        }

        public static void OnUpdate(this DlgDungeonHappyMain self)
        {
            long endTime = self.EndTime - TimeHelper.ServerNow();
            endTime /= 1000;
            if (endTime > 60)
            {
                self.View.E_EndTimeTextText.text = $"神秘之门倒计时 {endTime / 60}:{endTime % 60}";
            }
            else
            {
                self.View.E_EndTimeTextText.text = $"神秘之门还剩{endTime % 60}秒，活动结束将强制离开地图哦。";
            }

            if (endTime <= 60)
            {
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
                int sceneid = self.Root().GetComponent<BattleMessageComponent>().LastDungeonId;
                if (sceneid == 0)
                {
                    EnterMapHelper.RequestQuitFuben(self.Root());
                }
                else
                {
                    EnterMapHelper.RequestTransfer(self.Root(), SceneTypeEnum.LocalDungeon, sceneid, 0, "0").Coroutine();
                }

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

        public static void OnUpdateMoney(this DlgDungeonHappyMain self)
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

            int useTimes = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.HappyMoveNumber);
            self.View.E_TextTip_MianFeiTimeText.text = $"移动次数: {5 - useTimes}/5";
        }

        public static void OnButtonPick(this DlgDungeonHappyMain self)
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

        public static async ETTask OnButtonMove(this DlgDungeonHappyMain self, int moveType)
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

                PopupTipHelp.OpenPopupTip(self.Root(), "神秘之门", $"是否消耗{globalValueConfig.Value2}金币?", async () =>
                {
                    long instanceId = self.InstanceId;
                    int error = await ActivityNetHelper.DungeonHappyMoveRequest(self.Root(), moveType);
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

                PopupTipHelp.OpenPopupTip(self.Root(), "神秘之门", $"是否消耗{globalValueConfig.Value2}钻石?", async () =>
                {
                    long instanceId = self.InstanceId;
                    int error = await ActivityNetHelper.DungeonHappyMoveRequest(self.Root(), moveType);
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
            int error = await ActivityNetHelper.DungeonHappyMoveRequest(self.Root(), moveType);
            if (instanceId != self.InstanceId || error != ErrorCode.ERR_Success)
            {
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            FunctionEffect.PlayDropEffect(unit, 30000003);
            self.OnButtonPick();
            self.OnUpdateMoney();

            int moveNumber = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.HappyMoveNumber);
            if (moveNumber >= 5)
            {
                await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
                if (instanceId != self.InstanceId)
                {
                    return;
                }

                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().OnBtn_RerurnDungeon();
            }
        }
    }
}