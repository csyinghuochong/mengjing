using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_BattleShop))]
    [FriendOfAttribute(typeof (ES_BattleShop))]
    public static partial class ES_BattleShopSystem
    {
        [EntitySystem]
        private static void Awake(this ES_BattleShop self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_BattleShopItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBattleShopItemsRefresh);
            self.E_ButtonBuyButton.AddListener(self.OnButtonBuy);
            self.E_Btn_BuyNum_jia1Button.AddListener(() => { self.OnClickChangeBuyNum(1); });
            self.E_Btn_BuyNum_jia10Button.AddListener(() => { self.OnClickChangeBuyNum(10); });
            self.E_Btn_BuyNum_jian1Button.AddListener(() => { self.OnClickChangeBuyNum(-1); });
            self.E_Btn_BuyNum_jian10Button.AddListener(() => { self.OnClickChangeBuyNum(-10); });

            self.E_Lab_BuyNumText.text = "1";
            self.E_Lab_BuyPriceText.text = "0";

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_BattleShop self)
        {
            self.DestroyWidget();
        }

        private static void OnBattleShopItemsRefresh(this ES_BattleShop self, Transform transform, int index)
        {
            Scroll_Item_BattleShopItem scrollItemBattleShopItem = self.ScrollItemBattleShopItems[index].BindTrans(transform);
            scrollItemBattleShopItem.OnUpdateData(self.ShowStoreSellConfigs[index]);
            scrollItemBattleShopItem.SetClickHandler(self.OnClickHandler);
        }

        public static void OnButtonBuy(this ES_BattleShop self)
        {
            if (self.SellId == 0)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("请选择道具！");
                return;
            }

            BagClientNetHelper.RquestStoreBuy(self.Root(), self.SellId, self.BuyNum).Coroutine();
        }

        public static void OnUpdateUI(this ES_BattleShop self)
        {
            self.OnClickHandler(0);
        }

        public static void OnClickHandler(this ES_BattleShop self, int sellId)
        {
            self.SellId = sellId;
            if (self.ScrollItemBattleShopItems != null)
            {
                foreach (Scroll_Item_BattleShopItem item in self.ScrollItemBattleShopItems.Values)
                {
                    if (item == null)
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

        public static void OnInitUI(this ES_BattleShop self)
        {
            int shopSellid = GlobalValueConfigCategory.Instance.Get(55).Value2;
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

        public static void UpdateItemNum(this ES_BattleShop self)
        {
            long itemNum = self.Root().GetComponent<BagComponentC>().GetItemNumber(10010035);
            // 货币拥有数量显示
            self.E_Lab_BuyPriceText.text = itemNum.ToString();
        }

        //改变当前购买数量
        public static void OnClickChangeBuyNum(this ES_BattleShop self, int num)
        {
            if (num > 0 && self.BuyNum >= 100)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("单次购买数量最多为100");
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