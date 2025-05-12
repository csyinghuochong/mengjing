using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_BattleShopItem))]
    [EntitySystemOf(typeof (ES_UnionMystery_B))]
    [FriendOfAttribute(typeof (ES_UnionMystery_B))]
    public static partial class ES_UnionMystery_BSystem
    {
        [EntitySystem]
        private static void Awake(this ES_UnionMystery_B self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_BattleShopItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBattleShopItemsRefresh);
            self.E_ButtonBuyButton.AddListener(self.OnButtonBuyButton);

            self.E_Btn_BuyNum_jia1Button.AddListener(() => { self.OnClickChangeBuyNum(1); });
            self.E_Btn_BuyNum_jia10Button.AddListener(() => { self.OnClickChangeBuyNum(10); });

            self.E_Btn_BuyNum_jian1Button.AddListener(() => { self.OnClickChangeBuyNum(-1); });
            self.E_Btn_BuyNum_jian10Button.AddListener(() => { self.OnClickChangeBuyNum(-10); });

            self.E_Lab_BuyNumText.text = "1";
            self.E_Lab_BuyPriceText.text = "0";

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_UnionMystery_B self)
        {
            self.DestroyWidget();
        }

        public static void OnButtonBuyButton(this ES_UnionMystery_B self)
        {
            if (self.SellId == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("请选择道具！");
                return;
            }

            BagClientNetHelper.RquestStoreBuy(self.Root(), self.SellId, self.BuyNum).Coroutine();
        }

        public static void OnUpdateUI(this ES_UnionMystery_B self)
        {
            self.OnClickHandler(0);
        }

        public static void OnClickHandler(this ES_UnionMystery_B self, int sellId)
        {
            self.SellId = sellId;
            if (self.ScrollItemBattleShopItems != null)
            {
                foreach (Scroll_Item_BattleShopItem item in self.ScrollItemBattleShopItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.SetSelected(sellId);
                }
            }

            if (sellId != 0)
            {
                self.OnClickChangeBuyNum(1 - self.BuyNum);
            }
        }

        private static void OnBattleShopItemsRefresh(this ES_UnionMystery_B self, Transform transform, int index)
        {
            foreach (Scroll_Item_BattleShopItem item in self.ScrollItemBattleShopItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_BattleShopItem scrollItemBattleShopItem = self.ScrollItemBattleShopItems[index].BindTrans(transform);
            scrollItemBattleShopItem.OnUpdateData(self.ShowStoreSellConfigs[index]);
            scrollItemBattleShopItem.SetClickHandler(self.OnClickHandler);
        }

        public static void OnInitUI(this ES_UnionMystery_B self)
        {
            int shopSellid =  GlobalValueConfigCategory.Instance.UnionMystery_BId;
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

            self.AddUIScrollItems(ref self.ScrollItemBattleShopItems, self.ShowStoreSellConfigs.Count);
            self.E_BattleShopItemsLoopVerticalScrollRect.SetVisible(true, self.ShowStoreSellConfigs.Count);

            self.UpdateItemNum();
        }

        public static void UpdateItemNum(this ES_UnionMystery_B self)
        {
            long itemNum = self.Root().GetComponent<BagComponentC>().GetItemNumber(10000163);
            // 货币拥有数量显示
            self.E_Lab_BuyPriceText.text = itemNum.ToString();
        }

        //改变当前购买数量
        public static void OnClickChangeBuyNum(this ES_UnionMystery_B self, int num)
        {
            if (num > 0 && self.BuyNum >= 100)
            {
                FlyTipComponent.Instance.ShowFlyTip("单次购买数量最多为100");
                return;
            }

            self.BuyNum += num;
            if (self.BuyNum <= 1)
            {
                self.BuyNum = 1;
            }

            //单词购买最多100个
            if (self.BuyNum > 100)
            {
                self.BuyNum = 100;
            }

            //数量显示
            self.E_Lab_BuyNumText.text = self.BuyNum.ToString();
        }
    }
}
