using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_CommonItem))]
    [EntitySystemOf(typeof (ES_WarehouseAccount))]
    [FriendOfAttribute(typeof (ES_WarehouseAccount))]
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
            await self.SendAccountWarehousOperate(3, 0);
            ItemHelper.ItemLitSort(self.AccountBagInfos);
            self.RefreshHouseItems();
        }

        public static async ETTask SendAccountWarehousOperate(this ES_WarehouseAccount self, int operateType, long operateId)
        {
            C2M_AccountWarehousOperateRequest request = new() { OperatateType = operateType, OperateBagID = operateId };
            M2C_AccountWarehousOperateResponse response =
                    (M2C_AccountWarehousOperateResponse)await self.Root().GetComponent<ClientSenderCompnent>().Call(request);
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

        public static async ETTask Init(this ES_WarehouseAccount self)
        {
            long accountId = self.Root().GetComponent<PlayerComponent>().AccountId;
            // C2E_AccountWarehousInfoRequest reuqest = new C2E_AccountWarehousInfoRequest() { AccInfoID = accountId };
            // E2C_AccountWarehousInfoResponse response =
            //         (E2C_AccountWarehousInfoResponse)await self.ZoneScene().GetComponent<ClientSenderCompnent>().Call(reuqest);

            self.RefreshHouseItems();
            await ETTask.CompletedTask;
        }

        /// <summary>
        /// 刷新仓库
        /// </summary>
        /// <param name="self"></param>
        public static void RefreshHouseItems(this ES_WarehouseAccount self)
        {
            int hourseNumber = GlobalValueConfigCategory.Instance.AccountBagMax;
            hourseNumber = self.AccountBagInfos.Count > hourseNumber? self.AccountBagInfos.Count : hourseNumber;

            self.AddUIScrollItems(ref self.ScrollItemHouseItems, hourseNumber);
            self.E_BagItems1LoopVerticalScrollRect.SetVisible(true, hourseNumber);
        }

        /// <summary>
        /// 刷新背包
        /// </summary>
        /// <param name="self"></param>
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
            scrollItemCommonItem.Refresh(index < self.ShowBagBagInfos.Count? self.ShowBagBagInfos[index] : null, ItemOperateEnum.CangkuBag,
                self.UpdateBagSelect);
        }

        private static void UpdateHouseSelect(this ES_WarehouseAccount self, BagInfo bagInfo)
        {
            for (int i = 0; i < self.ScrollItemHouseItems.Keys.Count - 1; i++)
            {
                if (self.ScrollItemHouseItems[i].uiTransform != null)
                {
                    self.ScrollItemHouseItems[i].UpdateSelectStatus(bagInfo);
                }
            }
        }

        private static void UpdateBagSelect(this ES_WarehouseAccount self, BagInfo bagInfo)
        {
            for (int i = 0; i < self.ScrollItemBagItems.Keys.Count - 1; i++)
            {
                if (self.ScrollItemBagItems[i].uiTransform != null)
                {
                    self.ScrollItemBagItems[i].UpdateSelectStatus(bagInfo);
                }
            }
        }
    }
}