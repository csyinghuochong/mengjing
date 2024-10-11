using System;
using System.Collections.Generic;

namespace ET.Client
{
    [Invoke(TimerInvokeType.UITeamDropTimer)]
    public class UITeamDropTimer : ATimer<DlgTeamMain>
    {
        protected override void Run(DlgTeamMain self)
        {
            try
            {
                self.Check();
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

    [FriendOf(typeof(DlgTeamMain))]
    public static class DlgTeamMainSystem
    {
        public static void RegisterUIEvent(this DlgTeamMain self)
        {
            self.LeftTime = 0;
            self.CurDrop = null;
            self.DropInfos.Clear();

            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_Close);
            self.View.E_Btn_NeedButton.AddListener(self.OnBtn_Need);
        }

        public static void ShowWindow(this DlgTeamMain self, Entity contextData = null)
        {
            self.View.EG_TeamDropItemRectTransform.gameObject.SetActive(false);
        }

        public static void BeforeUnload(this DlgTeamMain self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void OnTeamPickNotice(this DlgTeamMain self, List<UnitInfo> dropInfos)
        {
            UnitComponent unitComponent = self.Root().CurrentScene().GetComponent<UnitComponent>();
            for (int i = 0; i < dropInfos.Count; i++)
            {
                Unit unitDrop = unitComponent.Get(dropInfos[i].UnitId);
                if (unitDrop == null)
                {
                    continue;
                }

                unitDrop.GetComponent<NumericComponentC>()
                        .ApplyValue(NumericType.BeKillId, TimeHelper.ServerNow() + TimeHelper.Second * 50 + self.DropInfos.Count);
                self.DropInfos.Add(unitDrop);
            }

            if (self.Timer == 0)
            {
                self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.UITeamDropTimer, self);
            }
        }

        public static void UpdateDropItem(this DlgTeamMain self)
        {
            self.CurDrop = self.DropInfos[0];
            Unit unitDrop = self.CurDrop;
            self.LeftTime = (int)(unitDrop.GetComponent<NumericComponentC>().GetAsInt(NumericType.BeKillId) - TimeHelper.ServerNow()) / 1000;
            self.DropInfos.RemoveAt(0);
            self.View.EG_TeamDropItemRectTransform.gameObject.SetActive(true);
            self.View.ES_CommonItem.UpdateItem(new()
            {
                ItemID = unitDrop.GetComponent<NumericComponentC>().GetAsInt(NumericType.DropItemId),
                ItemNum = unitDrop.GetComponent<NumericComponentC>().GetAsInt(NumericType.DropItemNum)
            }, ItemOperateEnum.None);
            using (zstring.Block())
            {
                Log.Debug(zstring.Format("self.DropInfos {0}", self.DropInfos.Count));
            }
        }

        public static void SendTeamPick(this DlgTeamMain self, Unit dropInfo, int needType)
        {
            if (dropInfo == null)
            {
                return;
            }

            TeamNetHelper.TeamPickRequest(self.Root(), dropInfo, needType);
        }

        public static void OnBtn_Close(this DlgTeamMain self)
        {
            self.SendTeamPick(self.CurDrop, 2);
            self.LeftTime = 0;
            self.CurDrop = null;
            self.View.EG_TeamDropItemRectTransform.gameObject.SetActive(false);
        }

        public static void OnBtn_Need(this DlgTeamMain self)
        {
            self.SendTeamPick(self.CurDrop, 1);
            self.LeftTime = 0;
            self.CurDrop = null;
            self.View.EG_TeamDropItemRectTransform.gameObject.SetActive(false);
        }

        public static void Check(this DlgTeamMain self)
        {
            long serverTime = TimeHelper.ServerNow();
            for (int i = self.DropInfos.Count - 1; i >= 0; i--)
            {
                Unit unitDrop = self.DropInfos[i];
                if (serverTime >= unitDrop.GetComponent<NumericComponentC>().GetAsInt(NumericType.BeKillId))
                {
                    self.SendTeamPick(self.DropInfos[i], 2);
                    self.DropInfos.RemoveAt(i);
                }
            }

            if (self.LeftTime < 0)
            {
                self.SendTeamPick(self.CurDrop, 2);
                self.CurDrop = null;
                self.View.EG_TeamDropItemRectTransform.gameObject.SetActive(false);
            }

            Unit curUnitDrop = self.CurDrop;
            if (curUnitDrop == null && self.DropInfos.Count == 0)
            {
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            }

            if (curUnitDrop == null && self.DropInfos.Count > 0)
            {
                self.UpdateDropItem();
            }

            self.LeftTime--;
            int timeStr = self.LeftTime;
            if (self.LeftTime < 0)
            {
                timeStr = 0;
            }

            using (zstring.Block())
            {
                self.View.E_Label_LeftTimeText.text = zstring.Format("拾取剩余:{0}秒", timeStr);
            }
        }
    }
}