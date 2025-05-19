using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Invoke(TimerInvokeType.UICellDungeonSettlement)]
    public class UICellDungeonSettlement : ATimer<DlgCellDungeonSettlement>
    {
        protected override void Run(DlgCellDungeonSettlement self)
        {
            try
            {
                self.Update();
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

    [FriendOf(typeof(ES_SettlementReward))]
    [FriendOf(typeof(DlgCellDungeonSettlement))]
    public static class DlgCellDungeonSettlementSystem
    {
        public static void RegisterUIEvent(this DlgCellDungeonSettlement self)
        {
            self.GetPassTime = 0;
            self.topSelect = false;
            self.bottomSelect = false;
            self.RewardUIList.Clear();

            self.View.E_closeButtonButton.AddListener(self.OnCloseButton);
            self.View.E_Star_1_liangImage.gameObject.SetActive(false);
            self.View.E_Star_2_liangImage.gameObject.SetActive(false);
            self.View.E_Star_3_liangImage.gameObject.SetActive(false);
            self.View.EG_SelectEffectSetRectTransform.gameObject.SetActive(false);

            self.View.ES_SettlementReward_1.SetClickHandler((int index) => { self.OnClickRewardItem(index).Coroutine(); }, 0);
            self.View.ES_SettlementReward_2.SetClickHandler((int index) => { self.OnClickRewardItem(index).Coroutine(); }, 1);
            self.View.ES_SettlementReward_3.SetClickHandler((int index) => { self.OnClickRewardItem(index).Coroutine(); }, 2);
            self.View.ES_SettlementReward_4.SetClickHandler((int index) => { self.OnClickRewardItem(index).Coroutine(); }, 3);
            self.View.ES_SettlementReward_5.SetClickHandler((int index) => { self.OnClickRewardItem(index).Coroutine(); }, 4);
            self.View.ES_SettlementReward_6.SetClickHandler((int index) => { self.OnClickRewardItem(index).Coroutine(); }, 5);
            self.RewardUIList.Add(self.View.ES_SettlementReward_1);
            self.RewardUIList.Add(self.View.ES_SettlementReward_2);
            self.RewardUIList.Add(self.View.ES_SettlementReward_3);
            self.RewardUIList.Add(self.View.ES_SettlementReward_4);
            self.RewardUIList.Add(self.View.ES_SettlementReward_5);
            self.RewardUIList.Add(self.View.ES_SettlementReward_6);

            self.View.E_Button_continueButton.AddListener(self.OnButtonContinue);
            self.View.E_Button_exitButton.AddListener(self.OnExitButton);
            self.Time = 0;
            self.LeftTime = 10;
            
            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.UICellDungeonSettlement, self);
        }

        public static void ShowWindow(this DlgCellDungeonSettlement self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgCellDungeonSettlement self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void Update(this DlgCellDungeonSettlement self)
        {
            self.Time += TimeInfo.Instance.DeltaTime;
            if (self.Time < 1f)
                return;
            self.Time = 0;
            self.Check();
        }

        public static void Check(this DlgCellDungeonSettlement self)
        {
            self.LeftTime--;
            if (self.LeftTime < 0)
            {
                self.OnCheckGetReward();
            }
            else
            {
                using (zstring.Block())
                {
                    self.View.E_Text_LeftTimeText.text = zstring.Format("选择剩余时间:{0}秒", self.LeftTime);
                }
            }

            if (self.topSelect && self.bottomSelect)
            {
                self.GetPassTime++;
            }
        }

        public static void OnCloseButton(this DlgCellDungeonSettlement self)
        {
            if (self.GetPassTime <= 3)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CellDungeonSettlement);
        }

        public static void OnExitButton(this DlgCellDungeonSettlement self)
        {
            EnterMapHelper.RequestQuitFuben(self.Root());
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CellDungeonSettlement);
        }

        public static void OnCheckGetReward(this DlgCellDungeonSettlement self)
        {
            if (self.topSelect && self.bottomSelect)
            {
                return;
            }

            //默认选中第一个
            if (!self.topSelect)
            {
                self.RewardUIList[0].OnClickItem();
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (!self.bottomSelect && unit.IsYueKaEndStates())
            {
                self.RewardUIList[3].OnClickItem();
            }
        }

        public static async ETTask OnClickRewardItem(this DlgCellDungeonSettlement self, int index)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (index >= 3 && !unit.IsYueKaEndStates())
            {
                FlyTipComponent.Instance.ShowFlyTip("周卡用户才能开启！");
                return;
            }

            ES_SettlementReward select = self.RewardUIList[index];
            CommonViewHelper.SetParent(self.View.EG_SelectEffectSetRectTransform.gameObject, select.uiTransform.gameObject);
            self.View.EG_SelectEffectSetRectTransform.gameObject.SetActive(true);
            await CellDungeonNetHelper.RequestGetFubenReward(self.Root(), select.RewardItem);

            if (!self.topSelect) self.topSelect = index < 3;
            if (!self.bottomSelect) self.bottomSelect = index >= 3;

            //屏蔽点击
            int startIndex = select.Index < 3 ? 0 : 3;
            for (int i = startIndex; i < startIndex + 3; i++)
            {
                self.RewardUIList[i].DisableClick();
            }
        }

        public static void OnButtonContinue(this DlgCellDungeonSettlement self)
        {
            if (self.Root().GetComponent<UserInfoComponentC>().UserInfo.PiLao <= 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("体力不足!");
                return;
            }

            int chapterId = self.Root().GetComponent<CellDungeonComponentC>().ChapterId;
            int difficulty = self.Root().GetComponent<CellDungeonComponentC>().FubenDifficulty;
            EnterMapHelper.RequestTransfer(self.Root(),  MapTypeEnum.CellDungeon, chapterId, difficulty, "0").Coroutine();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CellDungeonSettlement);
        }

        public static async ETTask OnUpdateUI(this DlgCellDungeonSettlement self, M2C_FubenSettlement m2C_FubenSettlement, int sceneTypeEnum)
        {
            self.View.E_Button_continueButton.gameObject.SetActive(sceneTypeEnum == MapTypeEnum.CellDungeon);
            self.View.E_Text_expText.text = m2C_FubenSettlement.RewardExp.ToString();
            self.View.E_Text_goldText.text = m2C_FubenSettlement.RewardGold.ToString();

            self.View.E_Star_3_OKImage.gameObject.SetActive(m2C_FubenSettlement.StarInfos[2] == 1);
            self.View.E_Star_2_OKImage.gameObject.SetActive(m2C_FubenSettlement.StarInfos[1] == 1);
            self.View.E_Star_1_OKImage.gameObject.SetActive(m2C_FubenSettlement.StarInfos[0] == 1);

            //奖励列表
            for (int i = 0; i < m2C_FubenSettlement.RewardList.Count; i++)
            {
                self.RewardUIList[i].OnUpdateData(m2C_FubenSettlement.RewardList[i]);
            }

            for (int i = 0; i < m2C_FubenSettlement.RewardListExcess.Count; i++)
            {
                self.RewardUIList[i + 3].OnUpdateData(m2C_FubenSettlement.RewardListExcess[i]);
            }

            long instanceid = self.InstanceId;
            await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            if (instanceid != self.InstanceId)
                return;
            self.View.E_Star_1_liangImage.gameObject.SetActive(m2C_FubenSettlement.StarInfos[0] == 1);
            await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            if (instanceid != self.InstanceId)
                return;
            self.View.E_Star_2_liangImage.gameObject.SetActive(m2C_FubenSettlement.StarInfos[1] == 1);
            await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            if (instanceid != self.InstanceId)
                return;
            self.View.E_Star_3_liangImage.gameObject.SetActive(m2C_FubenSettlement.StarInfos[2] == 1);
        }
    }
}