using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_JiaYuanPastureItem))]
    [EntitySystemOf(typeof(ES_JiaYuanPasture_B))]
    [FriendOfAttribute(typeof(ES_JiaYuanPasture_B))]
    public static partial class ES_JiaYuanPasture_BSystem
    {
        [EntitySystem]
        private static void Awake(this ES_JiaYuanPasture_B self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_JiaYuanPastureItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnJiaYuanPastureItemsRefresh);

            self.RequestMystery().Coroutine();
            self.ShowCDTime().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_JiaYuanPasture_B self)
        {
            self.DestroyWidget();
        }

        public static async ETTask ShowCDTime(this ES_JiaYuanPasture_B self)
        {
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            using (zstring.Block())
            {
                while (!self.IsDisposed)
                {
                    DateTime dateTime = TimeInfo.Instance.ToDateTime(TimeHelper.ServerNow());
                    long curTime = dateTime.Hour * 60 * 60 + dateTime.Minute * 60 + dateTime.Second;
                    long cdTime = 0;

                    if (dateTime.Hour < 6)
                    {
                        cdTime = 6 * 60 * 60 - curTime;
                    }
                    else if (dateTime.Hour < 12)
                    {
                        cdTime = 12 * 60 * 60 - curTime;
                    }
                    else if (dateTime.Hour < 18)
                    {
                        cdTime = 18 * 60 * 60 - curTime;
                    }
                    else
                    {
                        cdTime = 24 * 60 * 60 - curTime;
                    }

                    self.E_Text_CDTimeText.text = zstring.Format("刷新倒计时: {0}", TimeHelper.ShowLeftTime(cdTime * 1000));

                    await timerComponent.WaitAsync(1000);
                    if (self.IsDisposed)
                    {
                        break;
                    }
                }
            }
        }

        private static void OnJiaYuanPastureItemsRefresh(this ES_JiaYuanPasture_B self, Transform transform, int index)
        {
            foreach (Scroll_Item_JiaYuanPastureItem item in self.ScrollItemJiaYuanPastureItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_JiaYuanPastureItem scrollItemJiaYuanPastureItem = self.ScrollItemJiaYuanPastureItems[index].BindTrans(transform);
            scrollItemJiaYuanPastureItem.OnUpdateUI(self.ShowMysteryItemInfos[index], index);
        }

        public static void UpdateMysteryItem(this ES_JiaYuanPasture_B self, List<MysteryItemInfo> mysteryItemInfos)
        {
            self.ShowMysteryItemInfos = mysteryItemInfos;

            self.AddUIScrollItems(ref self.ScrollItemJiaYuanPastureItems, self.ShowMysteryItemInfos.Count);
            self.E_JiaYuanPastureItemsLoopVerticalScrollRect.SetVisible(true, self.ShowMysteryItemInfos.Count);
        }

        public static async ETTask RequestMystery(this ES_JiaYuanPasture_B self)
        {
            M2C_JiaYuanPastureListResponse response = await JiaYuanNetHelper.JiaYuanPastureListRequest(self.Root());
            self.UpdateMysteryItem(response.MysteryItemInfos);
        }
    }
}
