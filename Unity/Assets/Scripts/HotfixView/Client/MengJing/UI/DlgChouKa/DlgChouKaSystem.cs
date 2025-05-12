using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class DataUpdate_ChouKaWarehouseAddItem_Refresh : AEvent<Scene, ChouKaWarehouseAddItem>
    {
        protected override async ETTask Run(Scene root, ChouKaWarehouseAddItem args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgChouKa>()?.SetRedDot(true);

            await ETTask.CompletedTask;
        }
    }

    [Invoke(TimerInvokeType.UIChouKaTimer)]
    public class UIChouKaTimer : ATimer<DlgChouKa>
    {
        protected override void Run(DlgChouKa self)
        {
            try
            {
                self.OnUpdateMianFeiTime();
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

    [FriendOf(typeof(ES_ChouKaChapterSelect))]
    [FriendOf(typeof(DlgChouKa))]
    public static class DlgChouKaSystem
    {
        public static void RegisterUIEvent(this DlgChouKa self)
        {
            self.View.E_Btn_ChouKaProbExplainButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_ChouKaProbExplain).Coroutine();
            });
            self.View.E_Btn_WarehouseButton.AddListener(self.OnBtn_WarehouseButton);
            self.View.E_Btn_ZhangJieXuanZeButton.AddListener(self.OnBtn_ZhangJieXuanZeButton);
            self.View.E_Btn_ChouKaNumRewardButton.AddListener(self.OnBtn_ChouKaNumRewardButton);
            self.View.E_Btn_ChouKaTenButton.AddListener(() => { self.OnBtn_ChouKaOne(10).Coroutine(); });
            self.View.E_Btn_ChouKaOneButton.AddListener(() => { self.OnBtn_ChouKaOne(1).Coroutine(); });
            self.View.ES_ChouKaChapterSelect.uiTransform.gameObject.SetActive(false);
            self.View.ES_ChouKaChapterSelect.SetClickHandler((int cid) => { self.OnSelectChapterID(cid); });

            self.OnSelectChapterID(self.GetChouKaId());
            self.OnUpdateUI();

            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.UIChouKaTimer, self);
        }

        public static void ShowWindow(this DlgChouKa self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgChouKa self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static int GetChouKaId(this DlgChouKa self)
        {
            int takeCardId = 0;
            int userLv = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;
            List<TakeCardConfig> takeCardConfigs = TakeCardConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < takeCardConfigs.Count; i++)
            {
                if (userLv >= takeCardConfigs[i].RoseLvLimit)
                {
                    takeCardId = takeCardConfigs[i].Id;
                }
            }

            return takeCardId;
        }

        public static void OnBtn_WarehouseButton(this DlgChouKa self)
        {
            self.SetRedDot(false);
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_ChouKaWarehouse).Coroutine();
        }

        public static void OnSelectChapterID(this DlgChouKa self, int chapterid)
        {
            self.TakeCardId = chapterid;

            self.OnUpdateCost();
            self.UpdateRewardShowList();
        }

        public static void UpdateRewardShowList(this DlgChouKa self)
        {
            int cindex = self.TakeCardId % 1000;
            using (zstring.Block())
            {
                self.View.E_Text_ChapterText.text = zstring.Format("第{0}章探宝", cindex);
            }

            TakeCardConfig takeCardConfig = TakeCardConfigCategory.Instance.Get(self.TakeCardId);
            string dropShow = takeCardConfig.DropShow;
            List<RewardItem> droplist = new List<RewardItem>();
            droplist = DropHelper.DropIDToShowItem(takeCardConfig.DropID, 1);
            string itemList = "";
            for (int i = 0; i < droplist.Count; i++)
            {
                itemList += droplist[i].ItemID + ";" + 1 + "@";
            }

            itemList += dropShow;
            self.View.ES_RewardList.Refresh(itemList, 0.8f);
        }

        public static void OnBtn_ZhangJieXuanZeButton(this DlgChouKa self)
        {
            self.View.ES_ChouKaChapterSelect.uiTransform.gameObject.SetActive(true);
        }

        public static void OnBtn_ChouKaNumRewardButton(this DlgChouKa self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_ChouKaReward).Coroutine();
        }

        public static async ETTask ShowRewardView(this DlgChouKa self, List<RewardItem> rewardItems)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_CommonReward);
            DlgCommonReward dlgCommonReward = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgCommonReward>();
            dlgCommonReward.OnUpdateUI(rewardItems);
        }

        public static async ETTask OnBtn_ChouKaOne(this DlgChouKa self, int times)
        {
            M2C_ChouKaResponse response = await BagClientNetHelper.ChouKa(self.Root(), self.TakeCardId, times);
            if (response.Error != 0)
            {
                return;
            }

            self.OnUpdateUI();
            self.OnUpdateCost();
            self.ShowRewardView(response.RewardList).Coroutine();

            //             //记录tap数据
            //             AccountInfoComponent accountInfoComponent = self.Root().GetComponent<AccountInfoComponent>();
            //             string serverName = accountInfoComponent.ServerName;
            //             UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            // #if UNITY_ANDROID
            //             TapSDKHelper.UpLoadPlayEvent(userInfo.Name, serverName,userInfo.Lv, 1, times);
            // #endif
        }

        public static void OnUpdateCost(this DlgChouKa self)
        {
            TakeCardConfig takeCardConfig = TakeCardConfigCategory.Instance.Get(self.TakeCardId);
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            int totalTimes = numericComponent.GetAsInt(NumericType.ChouKa);
            if (totalTimes >= 250)
            {
                int oneCost = Mathf.CeilToInt(takeCardConfig.ZuanShiNum * 0.8f);
                int tenCost = Mathf.CeilToInt(takeCardConfig.ZuanShiNum_Ten * 0.8f);
                self.View.E_TextOneCostText.text = oneCost.ToString();
                self.View.E_TextTenCostText.text = tenCost.ToString();
            }
            else
            {
                self.View.E_TextOneCostText.text = takeCardConfig.ZuanShiNum.ToString();
                self.View.E_TextTenCostText.text = takeCardConfig.ZuanShiNum_Ten.ToString();
            }
        }

        public static void OnUpdateTotalTime(this DlgChouKa self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            int totalTimes = numericComponent.GetAsInt(NumericType.ChouKa);
            using (zstring.Block())
            {
                self.View.E_Text_TotalNumberText.text = zstring.Format("次数：{0}/{1}", totalTimes, GlobalValueConfigCategory.Instance.ChouKaLimit);
            }
        }

        public static void OnUpdateMianFeiTime(this DlgChouKa self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            long curTime = TimeHelper.ServerNow();
            long passTime_1 = curTime - numericComponent.GetAsLong(NumericType.ChouKaOneTime);
            long passTime_2 = curTime - numericComponent.GetAsLong(NumericType.ChouKaTenTime);
            long cdTime_1 = long.Parse(GlobalValueConfigCategory.Instance.Get(35).Value) * 1000;
            long cdTime_2 = long.Parse(GlobalValueConfigCategory.Instance.Get(36).Value) * 1000;
            self.View.E_Text_MianFeiTime_1Text.text = passTime_1 > cdTime_1 ? "免费抽卡" : TimeHelper.ShowLeftTime(cdTime_1 - passTime_1);
            self.View.E_Text_MianFeiTime_2Text.text = passTime_2 > cdTime_2 ? "免费抽卡" : TimeHelper.ShowLeftTime(cdTime_2 - passTime_2);
        }

        public static void OnUpdateUI(this DlgChouKa self)
        {
            self.OnUpdateTotalTime();
            self.OnUpdateMianFeiTime();
        }

        public static void SetRedDot(this DlgChouKa self, bool show)
        {
            self.View.E_Btn_WarehouseButton.transform.Find("RedDot").gameObject.SetActive(show);
        }
    }
}
