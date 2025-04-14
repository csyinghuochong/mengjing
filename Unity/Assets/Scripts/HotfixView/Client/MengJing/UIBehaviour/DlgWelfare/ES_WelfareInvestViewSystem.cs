using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_WelfareInvestItem))]
    [EntitySystemOf(typeof(ES_WelfareInvest))]
    [FriendOfAttribute(typeof(ES_WelfareInvest))]
    public static partial class ES_WelfareInvestSystem
    {
        [EntitySystem]
        private static void Awake(this ES_WelfareInvest self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ReceiveBtnButton.AddListenerAsync(self.OnReceiveBtnButton);
            self.EndTime = TimeInfo.Instance.ToDateTime(self.Root().GetComponent<UserInfoComponentC>().UserInfo.CreateTime).AddDays(6);
            self.E_WelfareInvestItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnWelfareInvestItemsRefresh);

            self.InitTask();
            self.UpdateInfo();
            self.UpdateTime().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_WelfareInvest self)
        {
            self.DestroyWidget();
        }

        private static void OnWelfareInvestItemsRefresh(this ES_WelfareInvest self, Transform transform, int index)
        {
            foreach (Scroll_Item_WelfareInvestItem item in self.ScrollItemWelfareInvestItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_WelfareInvestItem scrollItemWelfareInvestItem = self.ScrollItemWelfareInvestItems[index].BindTrans(transform);
            scrollItemWelfareInvestItem.OnUpdateData(index);
        }

        public static void InitTask(this ES_WelfareInvest self)
        {
            self.AddUIScrollItems(ref self.ScrollItemWelfareInvestItems, 6);
            self.E_WelfareInvestItemsLoopVerticalScrollRect.SetVisible(true, 6);
        }

        public static void UpdateInfo(this ES_WelfareInvest self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int touzi = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.InvestMent);
            self.E_InvestNumTextText.text = touzi.ToString();

            int total = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.InvestTotal);
            int lirun = CommonHelp.GetWelfareTotalLiRun(total, touzi);
            self.E_ProfitNumTextText.text = lirun.ToString();

            self.E_TotalReturnNumTextText.text = total.ToString();

            // 是否领过
            if (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.InvestReward) == 1)
            {
                self.E_ReceiveBtnButton.gameObject.SetActive(false);
                self.E_ReceivedImgImage.gameObject.SetActive(true);
            }
            else
            {
                self.E_ReceiveBtnButton.gameObject.SetActive(true);
                self.E_ReceivedImgImage.gameObject.SetActive(false);
            }
        }

        public static async ETTask OnReceiveBtnButton(this ES_WelfareInvest self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.InvestReward) == 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("已经领取!");
                return;
            }

            if (self.Root().GetComponent<UserInfoComponentC>().GetCrateDay() - 1 < 6)
            {
                FlyTipComponent.Instance.ShowFlyTip("今天还不能领取!");
                return;
            }

            // 投资奖励. 第七天领取奖励
            await ActivityNetHelper.WelfareInvestReward(self.Root());
            self.UpdateInfo();
        }

        public static async ETTask UpdateTime(this ES_WelfareInvest self)
        {
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            while (!self.IsDisposed)
            {
                DateTime nowTime = TimeInfo.Instance.ToDateTime(TimeHelper.ServerNow());
                TimeSpan ts = self.EndTime - nowTime;
                if (ts.TotalMinutes > 0)
                {
                    using (zstring.Block())
                    {
                        self.E_TimeTextText.text = zstring.Format("{0}天{1}小时{2}分", ts.Days, ts.Hours, ts.Minutes);
                    }
                }
                else
                {
                    self.E_TimeTextText.text = "赶快领取!!";
                }

                await timerComponent.WaitAsync(60000);
                if (self.IsDisposed)
                {
                    break;
                }
            }
        }
    }
}
