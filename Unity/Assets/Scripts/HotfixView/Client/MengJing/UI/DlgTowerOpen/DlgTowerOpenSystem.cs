using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Invoke(TimerInvokeType.TowerOpenTimer)]
    public class TowerOpenTimer: ATimer<DlgTowerOpen>
    {
        protected override void Run(DlgTowerOpen self)
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

    [FriendOf(typeof (DlgTowerOpen))]
    public static class DlgTowerOpenSystem
    {
        public static void RegisterUIEvent(this DlgTowerOpen self)
        {
        }

        public static void ShowWindow(this DlgTowerOpen self, Entity contextData = null)
        {
            self.PassTime = 0f;
            self.M2C_FubenSettlement = null;

            ActivityNetHelper.TowerFightBeginRequest(self.Root()).Coroutine();
        }

        public static void BeforeUnload(this DlgTowerOpen self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void OnTimer(this DlgTowerOpen self)
        {
            self.PassTime += Time.deltaTime;
            if (self.PassTime < 2f)
            {
                float colorValue = 0.3f - 0.3f * self.PassTime / 2f;
                self.View.E_ImageDiImage.color = new(0, 0, 0, colorValue);
                self.View.E_Lab_ChapterNameText.color = new(1, 1, 1, 1 - self.PassTime / 2f);
            }
            else
            {
                self.View.EG_PostionSetRectTransform.gameObject.SetActive(false);
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            }
        }

        public static void RequestTowerQuit(this DlgTowerOpen self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "", GameSettingLanguge.LoadLocalization("战斗未结束，是否领取奖励？"),
                () => { ActivityNetHelper.TowerExitRequest(self.Root()).Coroutine(); },
                null).Coroutine();
        }

        public static async ETTask OnFubenResult(this DlgTowerOpen self, M2C_FubenSettlement message)
        {
            // if (self.M2C_FubenSettlement != null)
            // {
            //     return;
            // }
            //
            // try
            // {
            //     long instanceId = self.InstanceId;
            //     self.M2C_FubenSettlement = message;
            //     self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            //
            //     self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TowerFightReward);
            //     if (instanceId != self.InstanceId)
            //     {
            //         return;
            //     }
            //
            //     if (ui.GameObject == null)
            //     {
            //         return;
            //     }
            //
            //     ui.GetComponent<UITowerFightRewardComponent>()?.OnUpdateUI(message);
            // }
            // catch (Exception ex)
            // {
            //     Log.Error(ex.ToString());
            // }
        }

        public static void OnUpdateUI(this DlgTowerOpen self, int towerId)
        {
            self.PassTime = 0;
            self.View.EG_PostionSetRectTransform.gameObject.SetActive(true);
            self.View.E_ImageDiImage.color = new(0, 0, 0, 1);
            self.View.E_Lab_ChapterNameText.color = new(1, 1, 1, 1);
            self.View.E_Lab_ChapterNameText.text = TowerConfigCategory.Instance.Get(towerId).Name;
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.TowerOpenTimer, self);

            int numMax = 30;

            //难度传进来  if(towerId)
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (mapComponent.FubenDifficulty == 1)
            {
                numMax = 30;
            }

            if (mapComponent.FubenDifficulty == 2)
            {
                numMax = 40;
            }

            if (mapComponent.FubenDifficulty == 3)
            {
                numMax = 50;
            }

            self.View.E_TextTipText.text = "挑战之地：" + TowerConfigCategory.Instance.Get(towerId).CengNum + "/" + numMax;
        }
    }
}