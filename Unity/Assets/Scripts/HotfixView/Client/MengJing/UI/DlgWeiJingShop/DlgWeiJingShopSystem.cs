using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_WeiJingShopItem))]
    [FriendOf(typeof(DlgWeiJingShop))]
    public static class DlgWeiJingShopSystem
    {
        public static void RegisterUIEvent(this DlgWeiJingShop self)
        {
            self.View.E_ButtonBuyButton.AddListenerAsync(self.OnButtonBuy);
            self.View.E_Btn_BuyNum_jian10Button.AddListener(() => { self.OnBtn_BuyNum_jia(-10); });
            self.View.E_Btn_BuyNum_jian1Button.AddListener(() => { self.OnBtn_BuyNum_jia(-1); });
            self.View.E_Btn_BuyNum_jia10Button.AddListener(() => { self.OnBtn_BuyNum_jia(10); });
            self.View.E_Btn_BuyNum_jia1Button.AddListener(() => { self.OnBtn_BuyNum_jia(1); });
            self.View.E_Btn_CloseButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_WeiJingShop); });
            self.View.E_WeiJingShopItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnWeiJingShopItemsRefresh);
            
            self.OnUpdateUI();
            self.OnInitUI();
            //默认购买数量为1
            self.View.E_Lab_RmbNumInputField.text = "1";
        }

        public static void ShowWindow(this DlgWeiJingShop self, Entity contextData = null)
        {
        }

        private static void OnWeiJingShopItemsRefresh(this DlgWeiJingShop self, Transform transform, int index)
        {
            foreach (Scroll_Item_WeiJingShopItem item in self.ScrollItemWeiJingShopItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_WeiJingShopItem scrollItemWeiJingShopItem = self.ScrollItemWeiJingShopItems[index].BindTrans(transform);

            scrollItemWeiJingShopItem.OnUpdateData(self.ShowStoreSellConfigs[index]);
            scrollItemWeiJingShopItem.SetClickHandler(self.OnClickHandler);
        }

        public static async ETTask OnButtonBuy(this DlgWeiJingShop self)
        {
            if (self.SellId == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("请选择道具！");
                return;
            }

            int buyNum = int.Parse(self.View.E_Lab_RmbNumInputField.text);
            await BagClientNetHelper.RquestStoreBuy(self.Root(), self.SellId, buyNum);
            self.OnUpdateNumShow();
            if (self.ScrollItemWeiJingShopItems != null)
            {
                foreach (Scroll_Item_WeiJingShopItem item in self.ScrollItemWeiJingShopItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.UpdateLeftNumber();
                }
            }
        }

        public static void OnUpdateUI(this DlgWeiJingShop self)
        {
            self.OnClickHandler(0);
        }

        public static void OnClickHandler(this DlgWeiJingShop self, int sellId)
        {
            self.SellId = sellId;

            if (self.ScrollItemWeiJingShopItems != null)
            {
                foreach (Scroll_Item_WeiJingShopItem item in self.ScrollItemWeiJingShopItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.SetSelected(sellId);
                }
            }
        }

        public static void OnInitUI(this DlgWeiJingShop self)
        {
            int shopSellid = 90000001;
            int playLv = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;

            self.ShowStoreSellConfigs.Clear();
            while (shopSellid != 0)
            {
                StoreSellConfig storeSellConfig = StoreSellConfigCategory.Instance.Get(shopSellid);
                shopSellid = storeSellConfig.NextID;
                if (playLv < storeSellConfig.ShowRoleLvMin || playLv > storeSellConfig.ShowRoleLvMax)
                {
                    continue;
                }

                self.ShowStoreSellConfigs.Add(storeSellConfig);
            }

            self.AddUIScrollItems(ref self.ScrollItemWeiJingShopItems, self.ShowStoreSellConfigs.Count);
            self.View.E_WeiJingShopItemsLoopVerticalScrollRect.SetVisible(true, self.ShowStoreSellConfigs.Count);

            self.OnUpdateNumShow();
        }

        public static void OnUpdateNumShow(this DlgWeiJingShop self)
        {
            using (zstring.Block())
            {
                self.View.E_Lab_NumText.text = zstring.Format("当前拥有数量:{0}", self.Root().GetComponent<BagComponentC>().GetItemNumber(36));
            }
        }

        public static void OnBtn_BuyNum_jia(this DlgWeiJingShop self, int num)
        {
            long diamondsNumber = long.Parse(self.View.E_Lab_RmbNumInputField.text);

            if (num > 0 && diamondsNumber >= 100)
            {
                FlyTipComponent.Instance.ShowFlyTip("购买最多100个！");
                return;
            }

            diamondsNumber += num;
            if (diamondsNumber < 1)
                diamondsNumber = 1;

            if (diamondsNumber > 100)
            {
                diamondsNumber = 100;
            }

            self.View.E_Lab_RmbNumInputField.text = diamondsNumber.ToString();
        }
    }
}