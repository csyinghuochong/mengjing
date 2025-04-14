using System;
using UnityEngine;

namespace ET.Client
{
    [Invoke(TimerInvokeType.MainActivityTipTimer)]
    public class MainActivityTipTimer : ATimer<ES_MainActivityTip>
    {
        protected override void Run(ES_MainActivityTip self)
        {
            try
            {
                self.OnCheck();
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

    [EntitySystemOf(typeof(ES_MainActivityTip))]
    [FriendOfAttribute(typeof(ES_MainActivityTip))]
    public static partial class ES_MainActivityTipSystem
    {
        [EntitySystem]
        private static void Awake(this ES_MainActivityTip self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ImageButtonButton.AddListenerAsync(self.OnImageButtonButton);

            self.uiTransform.gameObject.SetActive(false);

            self.OnUpdateUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_MainActivityTip self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.DestroyWidget();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="self"></param>
        public static void OnUpdateUI(this ES_MainActivityTip self)
        {
            self.Index = 0;
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);

            long serverTime = TimeHelper.ServerNow();
            DateTime dateTime = TimeHelper.DateTimeNow();
            int hour = dateTime.Hour;
            int minute = dateTime.Minute;
            int second = dateTime.Second;
            int time1 = hour * 3600 + minute * 60 + second; //当前时间

            for (int i = 0; i < ConfigData.ActivityShowList.Count; i++)
            {
                ActivityTipConfig worldSayConfig = ConfigData.ActivityShowList[i];

                if (!worldSayConfig.OpenDay.Contains((int)dateTime.DayOfWeek) && worldSayConfig.OpenDay[0] != -1)
                {
                    continue;
                }

                int hour2 = (int)worldSayConfig.OpenTime / 100;
                int minute2 = (int)worldSayConfig.OpenTime % 100;
                int time2 = hour2 * 3600 + minute2 * 60; //开始时间

                int hour3 = (int)worldSayConfig.CloseTime / 100;
                int minute3 = (int)worldSayConfig.CloseTime % 100;
                int time3 = hour3 * 3600 + minute3 * 60; //结束时间

                if (time1 > time3)
                {
                    continue;
                }

                worldSayConfig.OpenTime = serverTime + (time2 - time1) * 1000;
                worldSayConfig.CloseTime = serverTime + (time3 - time1) * 1000;
                self.ActivityShowList.Add(worldSayConfig);
            }

            self.ActivityShowList.Sort(delegate(ActivityTipConfig a, ActivityTipConfig b) { return (a.OpenTime > b.OpenTime ? 1 : 0); });

            ///self.StartTimer();
        }

        public static void StartTimer(this ES_MainActivityTip self)
        {
            if (self.ActivityShowList.Count <= 0)
            {
                self.uiTransform.gameObject.SetActive(false);
                return;
            }

            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            long nextTime = self.Index == 0 ? self.ActivityShowList[0].OpenTime : self.ActivityShowList[0].CloseTime;
            nextTime = Math.Max(nextTime, TimeHelper.ServerNow() + 1);

            self.ActivtyCur = self.ActivityShowList[0];
            self.Timer = self.Root().GetComponent<TimerComponent>().NewOnceTimer(nextTime, TimerInvokeType.MainActivityTipTimer, self);
        }

        public static void OnCheck(this ES_MainActivityTip self)
        {
            self.uiTransform.gameObject.SetActive(true);
            if (self.Index == 0 && self.ActivityShowList.Count > 0)
            {
                self.E_TextNameText.text = self.ActivityShowList[0].Conent;
            }

            if (self.Index == 1 && self.ActivityShowList.Count > 0)
            {
                self.ActivityShowList.RemoveAt(0);
            }

            self.Index = self.Index == 0 ? 1 : 0;
            self.StartTimer();
        }

        public static async ETTask OnImageButtonButton(this ES_MainActivityTip self)
        {
            if (self.ActivtyCur.UIType != 0)
            {
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync((WindowID)self.ActivtyCur.UIType);
            }
            else
            {
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Country);
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgCountry>().View.E_FunctionSetBtnToggleGroup.OnSelectIndex(2);
            }
        }
    }
}
