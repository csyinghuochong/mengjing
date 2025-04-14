using System;
using UnityEngine;

namespace ET.Client
{
    [Invoke(TimerInvokeType.JiaYuanPurchaseTimer)]
    public class JiaYuanPurchaseTimer : ATimer<ES_JiaYuanPurchase>
    {
        protected override void Run(ES_JiaYuanPurchase self)
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

    [FriendOf(typeof(Scroll_Item_JiaYuanPurchaseItem))]
    [EntitySystemOf(typeof(ES_JiaYuanPurchase))]
    [FriendOfAttribute(typeof(ES_JiaYuanPurchase))]
    public static partial class ES_JiaYuanPurchaseSystem
    {
        [EntitySystem]
        private static void Awake(this ES_JiaYuanPurchase self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_ButtonRefreshButton.AddListener(self.OnButtonRefreshButton);
            self.E_JiaYuanPurchaseItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnJiaYuanPurchaseItemsRefresh);

            self.JiaYuanComponentC = self.Root().GetComponent<JiaYuanComponentC>();
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.JiaYuanPurchaseTimer, self);

            self.OnUpdateUI();
            self.ShowCDTime();
        }

        [EntitySystem]
        private static void Destroy(this ES_JiaYuanPurchase self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.DestroyWidget();
        }

        public static void OnButtonRefreshButton(this ES_JiaYuanPurchase self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            long jiayuanzijin = self.Root().GetComponent<UserInfoComponentC>().UserInfo.JiaYuanFund;
            int refreshtime = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.JiaYuanPurchaseRefresh);
            long needzijin = refreshtime >= 1 ? JiaYuanData.JiaYuanPurchaseRefresh : 0;

            if (refreshtime >= 3)
            {
                FlyTipComponent.Instance.ShowFlyTip("今日次数不足!");
                return;
            }

            if (jiayuanzijin < needzijin)
            {
                FlyTipComponent.Instance.ShowFlyTip("家园资金不足!");
                return;
            }

            if (needzijin > 0)
            {
                using (zstring.Block())
                {
                    PopupTipHelp.OpenPopupTip(self.Root(), "家园刷新", zstring.Format("是否花费{0}家园资金刷新", needzijin),
                                () => { self.RquestFresh().Coroutine(); }, null)
                            .Coroutine();
                }
            }
            else
            {
                self.RquestFresh().Coroutine();
            }
        }

        public static async ETTask RquestFresh(this ES_JiaYuanPurchase self)
        {
            M2C_JiaYuanPurchaseRefresh response = await JiaYuanNetHelper.JiaYuanPurchaseRefresh(self.Root());

            if (self.IsDisposed || response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.Root().GetComponent<JiaYuanComponentC>().PurchaseItemList_7 = response.PurchaseItemList;
            self.OnUpdateUI();
        }

        public static void OnTimer(this ES_JiaYuanPurchase self)
        {
            long removeid = 0;
            if (self.ScrollItemJiaYuanPurchaseItems != null)
            {
                for (int i = self.ScrollItemJiaYuanPurchaseItems.Count - 1; i >= 0; i--)
                {
                    Scroll_Item_JiaYuanPurchaseItem scrollItemJiaYuanPurchaseItem = self.ScrollItemJiaYuanPurchaseItems[i];

                    if (scrollItemJiaYuanPurchaseItem.uiTransform == null)
                    {
                        continue;
                    }

                    bool leftTime = scrollItemJiaYuanPurchaseItem.UpdateLeftTime();
                    if (leftTime)
                    {
                        continue;
                    }

                    scrollItemJiaYuanPurchaseItem.uiTransform.gameObject.SetActive(false);
                    removeid = scrollItemJiaYuanPurchaseItem.JiaYuanPurchaseItem.PurchaseId;
                }
            }

            if (removeid > 0)
            {
                for (int k = self.JiaYuanComponentC.PurchaseItemList_7.Count - 1; k >= 0; k--)
                {
                    if (self.JiaYuanComponentC.PurchaseItemList_7[k].PurchaseId == removeid)
                    {
                        self.JiaYuanComponentC.PurchaseItemList_7.RemoveAt(k);
                    }
                }
            }

            self.ShowCDTime();
        }

        public static void ShowCDTime(this ES_JiaYuanPurchase self)
        {
            DateTime dateTime = TimeInfo.Instance.ToDateTime(TimeHelper.ServerNow());
            long curTime = dateTime.Hour * 60 * 60 + dateTime.Minute * 60 + dateTime.Second;
            long cdTime = 0;
            if (dateTime.Hour < 12)
            {
                cdTime = 12 * 60 * 60 - curTime;
            }
            else
            {
                cdTime = 24 * 60 * 60 - curTime;
            }

            using (zstring.Block())
            {
                self.E_Text_TimeText.text = zstring.Format("刷新倒计时: {0}", TimeHelper.ShowLeftTime(cdTime * 1000));
            }
        }

        public static void OnUpdateItem(this ES_JiaYuanPurchase self)
        {
            self.OnUpdateUI();
        }

        private static void OnJiaYuanPurchaseItemsRefresh(this ES_JiaYuanPurchase self, Transform transform, int index)
        {
            foreach (Scroll_Item_JiaYuanPurchaseItem item in self.ScrollItemJiaYuanPurchaseItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_JiaYuanPurchaseItem scrollItemJiaYuanPurchaseItem = self.ScrollItemJiaYuanPurchaseItems[index].BindTrans(transform);
            scrollItemJiaYuanPurchaseItem.OnUpdateUI(self.JiaYuanComponentC.PurchaseItemList_7[index], self.OnUpdateItem);
        }

        public static void OnUpdateUI(this ES_JiaYuanPurchase self)
        {
            self.AddUIScrollItems(ref self.ScrollItemJiaYuanPurchaseItems, self.JiaYuanComponentC.PurchaseItemList_7.Count);
            self.E_JiaYuanPurchaseItemsLoopVerticalScrollRect.SetVisible(true, self.JiaYuanComponentC.PurchaseItemList_7.Count);
        }
    }
}