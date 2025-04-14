using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_JiaYuanMysteryItem_A))]
    [EntitySystemOf(typeof(ES_JiaYuanMystery_A))]
    [FriendOfAttribute(typeof(ES_JiaYuanMystery_A))]
    public static partial class ES_JiaYuanMystery_ASystem
    {
        [EntitySystem]
        private static void Awake(this ES_JiaYuanMystery_A self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_JiaYuanMysteryItem_AsLoopVerticalScrollRect.AddItemRefreshListener(self.OnJiaYuanMysteryItemsRefresh);
        }

        [EntitySystem]
        private static void Destroy(this ES_JiaYuanMystery_A self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this ES_JiaYuanMystery_A self)
        {
            self.RequestMystery();
        }

        public static List<int> GetMysteryList(this ES_JiaYuanMystery_A self, int mysteryStartId)
        {
            List<int> itemList = new List<int>();

            while (mysteryStartId != 0)
            {
                itemList.Add(mysteryStartId);

                MysteryConfig mysteryConfig = MysteryConfigCategory.Instance.Get(mysteryStartId);
                mysteryStartId = mysteryConfig.NextId;
            }

            return itemList;
        }

        private static void OnJiaYuanMysteryItemsRefresh(this ES_JiaYuanMystery_A self, Transform transform, int index)
        {
            foreach (Scroll_Item_JiaYuanMysteryItem_A item in self.ScrollItemJiaYuanMysteryItemAs.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_JiaYuanMysteryItem_A scrollItemCommonItem = self.ScrollItemJiaYuanMysteryItemAs[index].BindTrans(transform);
            scrollItemCommonItem.OnUpdateUI(self.ShowMysteryItemInfos[index]);
        }

        public static void UpdateMysteryItem(this ES_JiaYuanMystery_A self, int mysteryStartId)
        {
            List<int> itemList = self.GetMysteryList(mysteryStartId);

            self.ShowMysteryItemInfos.Clear();
            for (int i = 0; i < itemList.Count; i++)
            {
                MysteryConfig mysteryConfig = MysteryConfigCategory.Instance.Get(itemList[i]);

                MysteryItemInfo mysteryItemInfo = MysteryItemInfo.Create();
                mysteryItemInfo.ItemID = mysteryConfig.SellItemID;
                mysteryItemInfo.ItemNumber = 1;
                mysteryItemInfo.MysteryId = itemList[i];
                mysteryItemInfo.ProductId = -1;

                self.ShowMysteryItemInfos.Add(mysteryItemInfo);
            }

            self.AddUIScrollItems(ref self.ScrollItemJiaYuanMysteryItemAs, self.ShowMysteryItemInfos.Count);
            self.E_JiaYuanMysteryItem_AsLoopVerticalScrollRect.SetVisible(true, self.ShowMysteryItemInfos.Count);
        }

        public static void RequestMystery(this ES_JiaYuanMystery_A self)
        {
            int npcID = self.Root().GetComponent<UIComponent>().CurrentNpcId;
            if (npcID == 0)
            {
                return;
            }

            int mysteryStartId = 0;
            if (npcID == 30000001) // 农场管理员
            {
                mysteryStartId = 500001;
            }
            else if (npcID == 30000002) // 牧场管理员
            {
            }
            else if (npcID == 30000013) // 家园商店
            {
            }

            //显示当前商品
            self.UpdateMysteryItem(mysteryStartId);
        }
    }
}
