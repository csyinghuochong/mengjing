using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [EntitySystemOf(typeof(ES_WarehouseAccount))]
    [FriendOf(typeof(ES_WarehouseAccount))]
    public static partial class ES_WarehouseAccountSystem
    {
        [EntitySystem]
        private static void Awake(this ES_WarehouseAccount self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_BagItems1LoopVerticalScrollRect.AddItemRefreshListener(self.OnHouseItemsRefresh);
            self.E_BagItems2LoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);

            self.Init().Coroutine();
            self.RefreshBagItems();
        }

        [EntitySystem]
        private static void Destroy(this ES_WarehouseAccount self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnBtn_ZhengLi(this ES_WarehouseAccount self)
        {
            await BagClientNetHelper.RequestAccountWarehousOperate(self.Root(), 3, 0);
            ItemHelper.ItemLitSort(self.AccountBagInfos);
            self.RefreshHouseItems();
        }

        public static void OnAccountWarehous(this ES_WarehouseAccount self, string paramstr, long baginfoId)
        {
            if (paramstr == "1")
            {
                if (self.BagInfoPutIn == null || self.BagInfoPutIn.BagInfoID != baginfoId)
                {
                    return;
                }

                for (int i = self.AccountBagInfos.Count - 1; i >= 0; i--)
                {
                    if (self.AccountBagInfos[i].BagInfoID == baginfoId)
                    {
                        return;
                    }
                }

                self.AccountBagInfos.Add(self.BagInfoPutIn);
                self.RefreshHouseItems();
                self.RefreshBagItems();
            }

            if (paramstr == "2")
            {
                for (int i = self.AccountBagInfos.Count - 1; i >= 0; i--)
                {
                    if (self.AccountBagInfos[i].BagInfoID == baginfoId)
                    {
                        self.AccountBagInfos.RemoveAt(i);
                    }
                }

                self.RefreshHouseItems();
                self.RefreshBagItems();
            }
        }

        private static async ETTask Init(this ES_WarehouseAccount self)
        {
            await BagClientNetHelper.RequestAccountWarehousInfo(self.Root());
            self.RefreshHouseItems();
        }

        private static void RefreshHouseItems(this ES_WarehouseAccount self)
        {
            int hourseNumber = GlobalValueConfigCategory.Instance.AccountBagMax;
            hourseNumber = self.AccountBagInfos.Count > hourseNumber ? self.AccountBagInfos.Count : hourseNumber;

            self.AddUIScrollItems(ref self.ScrollItemHouseItems, hourseNumber);
            self.E_BagItems1LoopVerticalScrollRect.SetVisible(true, hourseNumber);
        }

        public static void RefreshBagItems(this ES_WarehouseAccount self)
        {
            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();

            self.ShowBagBagInfos.Clear();
            self.ShowBagBagInfos.AddRange(bagComponentC.GetItemsByType((int)ItemLocType.ItemLocBag));
            int allNumber = bagComponentC.GetBagShowCell();

            self.AddUIScrollItems(ref self.ScrollItemBagItems, allNumber);
            self.E_BagItems2LoopVerticalScrollRect.SetVisible(true, allNumber);
        }

        private static void OnHouseItemsRefresh(this ES_WarehouseAccount self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemHouseItems[index].BindTrans(transform);

            if (index < self.AccountBagInfos.Count)
            {
                scrollItemCommonItem.Refresh(self.AccountBagInfos[index], ItemOperateEnum.AccountBag, self.UpdateHouseSelect);
            }
            else
            {
                scrollItemCommonItem.Refresh(null, ItemOperateEnum.None);
            }
        }

        private static void OnBagItemsRefresh(this ES_WarehouseAccount self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemBagItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(index < self.ShowBagBagInfos.Count ? self.ShowBagBagInfos[index] : null, ItemOperateEnum.CangkuBag,
                self.UpdateBagSelect);
        }

        private static void UpdateHouseSelect(this ES_WarehouseAccount self, BagInfo bagInfo)
        {
            for (int i = 0; i < self.ScrollItemHouseItems.Keys.Count - 1; i++)
            {
                Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemHouseItems[i];
                if (scrollItemCommonItem.uiTransform != null)
                {
                    scrollItemCommonItem.UpdateSelectStatus(bagInfo);
                }
            }
        }

        private static void UpdateBagSelect(this ES_WarehouseAccount self, BagInfo bagInfo)
        {
            for (int i = 0; i < self.ScrollItemBagItems.Keys.Count - 1; i++)
            {
                Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemHouseItems[i];
                if (scrollItemCommonItem.uiTransform != null)
                {
                    scrollItemCommonItem.UpdateSelectStatus(bagInfo);
                }
            }
        }
    }
}