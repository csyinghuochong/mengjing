using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_JiaYuanMysteryItem))]
    [EntitySystemOf(typeof(ES_JiaYuanMystery_B))]
    [FriendOfAttribute(typeof(ES_JiaYuanMystery_B))]
    public static partial class ES_JiaYuanMystery_BSystem
    {
        [EntitySystem]
        private static void Awake(this ES_JiaYuanMystery_B self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_JiaYuanMysteryItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnJiaYuanMysteryItemsRefresh);

            self.ShowCDTime().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_JiaYuanMystery_B self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this ES_JiaYuanMystery_B self)
        {
            self.RequestMystery().Coroutine();
        }

        private static void OnJiaYuanMysteryItemsRefresh(this ES_JiaYuanMystery_B self, Transform transform, int index)
        {
            foreach (Scroll_Item_JiaYuanMysteryItem item in self.ScrollItemJiaYuanMysteryItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_JiaYuanMysteryItem scrollItemCommonItem = self.ScrollItemJiaYuanMysteryItems[index].BindTrans(transform);
            scrollItemCommonItem.OnUpdateUI(self.ShowMysteryItemInfos[index]);
        }

        public static void UpdateMysteryItem(this ES_JiaYuanMystery_B self, List<MysteryItemInfo> mysteryItemInfos)
        {
            self.ShowMysteryItemInfos.Clear();

            for (int i = 0; i < mysteryItemInfos.Count; i++)
            {
                if (mysteryItemInfos[i].ItemNumber <= 0)
                {
                    continue;
                }

                self.ShowMysteryItemInfos.Add(mysteryItemInfos[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemJiaYuanMysteryItems, self.ShowMysteryItemInfos.Count);
            self.E_JiaYuanMysteryItemsLoopVerticalScrollRect.SetVisible(true, self.ShowMysteryItemInfos.Count);
        }

        public static async ETTask RequestMystery(this ES_JiaYuanMystery_B self)
        {
            int npcID = 30000001;
            if (self.Root().GetComponent<UIComponent>().CurrentNpcId != 0)
            {
                npcID = self.Root().GetComponent<UIComponent>().CurrentNpcId;
            }

            //显示当前商品
            M2C_JiaYuanMysteryListResponse response = await JiaYuanNetHelper.JiaYuanMysteryListRequest(self.Root(), npcID);
            self.UpdateMysteryItem(response.MysteryItemInfos);
        }

        public static async ETTask ShowCDTime(this ES_JiaYuanMystery_B self)
        {
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
                    await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);

                    if (self.IsDisposed)
                    {
                        break;
                    }
                }
            }
        }
    }
}
