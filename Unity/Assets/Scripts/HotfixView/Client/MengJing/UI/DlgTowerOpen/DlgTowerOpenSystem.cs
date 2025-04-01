using System;
using UnityEngine;

namespace ET.Client
{
    [Invoke(TimerInvokeType.TowerOpenTimer)]
    public class TowerOpenTimer : ATimer<DlgTowerOpen>
    {
        protected override void Run(DlgTowerOpen self)
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

    [FriendOf(typeof(DlgTowerOpen))]
    public static class DlgTowerOpenSystem
    {
        public static void RegisterUIEvent(this DlgTowerOpen self)
        {
            self.PassTime = 0f;
            self.M2C_FubenSettlement = null;

            ActivityNetHelper.TowerFightBeginRequest(self.Root()).Coroutine();
        }

        public static void ShowWindow(this DlgTowerOpen self, Entity contextData = null)
        {
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
            PopupTipHelp.OpenPopupTip(self.Root(), "", LanguageComponent.Instance.LoadLocalization("战斗未结束，是否领取奖励？"),
                () => { ActivityNetHelper.TowerExitRequest(self.Root()).Coroutine(); },
                null).Coroutine();
        }

        public static async ETTask OnFubenResult(this DlgTowerOpen self, M2C_FubenSettlement message)
        {
            if (self.M2C_FubenSettlement != null)
            {
                return;
            }

            try
            {
                long instanceId = self.InstanceId;
                self.M2C_FubenSettlement = message;
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);

                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TowerFightReward);
                DlgTowerFightReward dlgTowerFightReward = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgTowerFightReward>();
                if (instanceId != self.InstanceId)
                {
                    return;
                }

                dlgTowerFightReward.OnUpdateUI(message);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
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

            using (zstring.Block())
            {
                self.View.E_TextTipText.text = zstring.Format("勇者之境：{0}/{1}", TowerConfigCategory.Instance.Get(towerId).CengNum, numMax);
            }
        }
    }
}