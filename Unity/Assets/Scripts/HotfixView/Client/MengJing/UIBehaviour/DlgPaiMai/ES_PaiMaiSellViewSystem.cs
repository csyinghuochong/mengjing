using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PaiMaiSellItem))]
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [EntitySystemOf(typeof(ES_PaiMaiSell))]
    [FriendOfAttribute(typeof(ES_PaiMaiSell))]
    public static partial class ES_PaiMaiSellSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PaiMaiSell self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.E_PaiMaiSellItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPaiMaiSellItemsRefresh);

            self.E_Btn_XiaJiaButton.AddListenerAsync(self.OnBtn_XiaJiaButton);
            self.E_Btn_ShangJiaButton.AddListenerAsync(self.OnBtn_ShangJiaButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_PaiMaiSell self)
        {
            self.DestroyWidget();
        }

        private static void OnItemTypeSet(this ES_PaiMaiSell self, int index)
        {
            self.CurrentItemType = index;
            self.OnClickPageButton(index);
        }

        private static void OnBagItemsRefresh(this ES_PaiMaiSell self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.PaiMaiSell, self.OnSelectItem);
        }

        private static void OnPaiMaiSellItemsRefresh(this ES_PaiMaiSell self, Transform transform, int index)
        {
            foreach (Scroll_Item_PaiMaiSellItem item in self.ScrollItemPaiMaiSellItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_PaiMaiSellItem scrollItemPaiMaiSellItem = self.ScrollItemPaiMaiSellItems[index].BindTrans(transform);
            scrollItemPaiMaiSellItem.SetClickHandler((bagInfo) => { self.OnSelectSellItem(bagInfo); });
            scrollItemPaiMaiSellItem.OnUpdateUI(self.ShowPaiMaiItemInfos[index]);
        }

        private static async ETTask RequestSelfPaiMaiList(this ES_PaiMaiSell self)
        {
            long instanceid = self.InstanceId;
            P2C_PaiMaiListResponse response =
                    await PaiMaiNetHelper.PaiMaiList(self.Root(), 0, 0, self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId);
            if (self.IsDisposed || instanceid != self.InstanceId)
            {
                return;
            }

            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }
            
            int openday = TimeHelper.GetServeOpenDay(self.Root().GetComponent<PlayerInfoComponent>().ServerItem.ServerOpenTime);

            self.PaiMaiItemInfos = response.PaiMaiItemInfos;
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            long sellgold = numericComponent.GetAsLong(NumericType.PaiMaiTodayGold);
            long todayGold = ConfigHelper.GetPaiMaiTodayGold(openday);

            float sellgold_1 = sellgold * 0.0001f;
            float todayGold_1 = todayGold * 0.0001f;

            using (zstring.Block())
            {
                self.E_PaiMaiGoldTextText.text = zstring.Format("今日获利:{0}万/{1}万", CommonViewHelper.ShowFloatValue(sellgold_1),
                    CommonViewHelper.ShowFloatValue(todayGold_1));
            }

            self.UpdateSellItemUILIist(self.CurrentItemType);
        }

        public static void OnUpdateUI(this ES_PaiMaiSell self)
        {
            self.UpdateBagItemUIList();
            self.E_ItemTypeSetToggleGroup.OnSelectIndex(0);
            self.RequestSelfPaiMaiList().Coroutine();
        }

        public static void OnClickPageButton(this ES_PaiMaiSell self, int page)
        {
            self.UpdateSellItemUILIist(page);
        }

        private static async ETTask OnBtn_XiaJiaButton(this ES_PaiMaiSell self)
        {
            if (self.PaiMaiItemInfoId == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("请选中道具");
                return;
            }

            int itemType = 0;
            for (int i = self.PaiMaiItemInfos.Count - 1; i >= 0; i--)
            {
                if (self.PaiMaiItemInfos[i].Id == self.PaiMaiItemInfoId)
                {
                    if (self.PaiMaiItemInfos[i].UserId != self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId)
                    {
                        FlyTipComponent.Instance.ShowFlyTip("数据错误!");
                        return;
                    }

                    itemType = ItemConfigCategory.Instance.Get(self.PaiMaiItemInfos[i].BagInfo.ItemID).ItemType;
                }
            }

            await PaiMaiNetHelper.PaiMaiXiaJia(self.Root(), itemType, self.PaiMaiItemInfoId);
            if (self.IsDisposed)
            {
                return;
            }

            for (int i = self.PaiMaiItemInfos.Count - 1; i >= 0; i--)
            {
                if (self.PaiMaiItemInfos[i].Id == self.PaiMaiItemInfoId)
                {
                    self.PaiMaiItemInfos.RemoveAt(i);
                }
            }

            self.PaiMaiItemInfoId = 0;

            self.UpdateBagItemUIList();
            self.UpdateSellItemUILIist(self.CurrentItemType);
        }

        public static async ETTask OnBtn_ShangJiaButton(this ES_PaiMaiSell self)
        {
            if (self.BagInfo == null)
            {
                FlyTipComponent.Instance.ShowFlyTip("请选中道具！");
                return;
            }

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.BagInfo.ItemID);
            if (itemConfig.IfStopPaiMai == 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("此道具禁止上架！");
                return;
            }

            if (!CommonHelp.IsShowPaiMai(itemConfig.ItemType, itemConfig.ItemSubType))
            {
                FlyTipComponent.Instance.ShowFlyTip("此道具不能上架！");
                return;
            }

            if (self.PaiMaiItemInfos.Count >= GlobalValueConfigCategory.Instance.MaxAuctionQuantity)
            {
                FlyTipComponent.Instance.ShowFlyTip("已经达到最大上架数量！");
                return;
            }

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PaiMaiSellPrice);
            DlgPaiMaiSellPrice dlgPaiMaiSellPrice = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPaiMaiSellPrice>();
            dlgPaiMaiSellPrice.InitPriceUI(self.BagInfo);
        }

        private static void UpdateBagItemUIList(this ES_PaiMaiSell self)
        {
            List<ItemInfo> equipInfos = self.Root().GetComponent<BagComponentC>().GetBagList();
            self.ShowBagInfos.Clear();
            for (int i = 0; i < equipInfos.Count; i++)
            {
                if (equipInfos[i].isBinging || equipInfos[i].IsProtect)
                {
                    continue;
                }

                self.ShowBagInfos.Add(equipInfos[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }

        public static void OnPaiBuyShangJia(this ES_PaiMaiSell self, PaiMaiItemInfo paiMaiItemInfo)
        {
            self.BagInfo = null;
            self.PaiMaiItemInfos.Add(paiMaiItemInfo);

            self.UpdateBagItemUIList();
            self.UpdateSellItemUILIist(self.CurrentItemType);
        }

        public static void OnSelectItem(this ES_PaiMaiSell self, ItemInfo bagInfo)
        {
            self.BagInfo = bagInfo;

            if (self.ScrollItemCommonItems != null)
            {
                foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.SetSelected(bagInfo);
                }
            }
        }

        private static void OnSelectSellItem(this ES_PaiMaiSell self, PaiMaiItemInfo paiMaiItemInfo)
        {
            self.PaiMaiItemInfoId = paiMaiItemInfo.Id;

            if (self.ScrollItemPaiMaiSellItems != null)
            {
                foreach (Scroll_Item_PaiMaiSellItem item in self.ScrollItemPaiMaiSellItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.SetSelected(paiMaiItemInfo.Id);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="subType">0 装备   1其他</param>
        private static void UpdateSellItemUILIist(this ES_PaiMaiSell self, int subType)
        {
            self.ShowPaiMaiItemInfos.Clear();
            for (int i = 0; i < self.PaiMaiItemInfos.Count; i++)
            {
                PaiMaiItemInfo paiMaiItemInfo = self.PaiMaiItemInfos[i];
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(paiMaiItemInfo.BagInfo.ItemID);
                if (subType == 1 && itemConfig.ItemType != ItemTypeEnum.Equipment)
                {
                    continue;
                }

                if (subType == 2 && itemConfig.ItemType == ItemTypeEnum.Equipment)
                {
                    continue;
                }

                self.ShowPaiMaiItemInfos.Add(paiMaiItemInfo);
            }

            self.AddUIScrollItems(ref self.ScrollItemPaiMaiSellItems, self.ShowPaiMaiItemInfos.Count);
            self.E_PaiMaiSellItemsLoopVerticalScrollRect.SetVisible(true, self.ShowPaiMaiItemInfos.Count);

            int maxNum = GlobalValueConfigCategory.Instance.MaxAuctionQuantity;
            using (zstring.Block())
            {
                self.E_Text_SellTimeText.text = zstring.Format("已上架:{0}/{1}", self.PaiMaiItemInfos.Count, maxNum);
            }
        }
    }
}
