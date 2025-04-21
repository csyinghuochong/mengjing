using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_TaskShopItem))]
    [EntitySystemOf(typeof(ES_TaskShop))]
    [FriendOfAttribute(typeof(ES_TaskShop))]
    public static partial class ES_TaskShopSystem
    {
        [EntitySystem]
        private static void Awake(this ES_TaskShop self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_TaskShopItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnTaskShopItemsRefresh);
            self.E_ButtonBuyButton.AddListenerAsync(self.OnButtonBuyButton);
            self.E_Btn_BuyNum_jia1Button.AddListener(() => { self.OnClickChangeBuyNum(1); });
            self.E_Btn_BuyNum_jia10Button.AddListener(() => { self.OnClickChangeBuyNum(10); });
            self.E_Btn_BuyNum_jian1Button.AddListener(() => { self.OnClickChangeBuyNum(-1); });
            self.E_Btn_BuyNum_jian10Button.AddListener(() => { self.OnClickChangeBuyNum(-10); });

            self.E_Lab_BuyNumText.text = "1";
            self.E_Lab_BuyPriceText.text = "0";

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_TaskShop self)
        {
            self.DestroyWidget();
        }

        private static void OnTaskShopItemsRefresh(this ES_TaskShop self, Transform transform, int index)
        {
            foreach (Scroll_Item_TaskShopItem item in self.ScrollItemTaskShopItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_TaskShopItem scrollItemBattleShopItem = self.ScrollItemTaskShopItems[index].BindTrans(transform);
            scrollItemBattleShopItem.OnUpdateData(self.ShowStoreSellConfigs[index]);
        }

        public static async ETTask OnButtonBuyButton(this ES_TaskShop self)
        {
            if (self.SellId == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("请选择道具！");
                return;
            }

            await BagClientNetHelper.RquestStoreBuy(self.Root(), self.SellId, self.BuyNum);
            self.UpdateItemNum();
        }

        public static void OnUpdateUI(this ES_TaskShop self)
        {
            self.OnClickHandler(0);
        }

        public static void OnClickHandler(this ES_TaskShop self, int sellId)
        {
            self.SellId = sellId;

            if (sellId != 0)
            {
                self.OnClickChangeBuyNum(1 - self.BuyNum);
            }
        }

        public static void OnInitUI(this ES_TaskShop self)
        {
            int shopSellid = int.Parse( GlobalValueConfigCategory.Instance.Get(120).Value);
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

            self.AddUIScrollItems(ref self.ScrollItemTaskShopItems, self.ShowStoreSellConfigs.Count);
            self.E_TaskShopItemsLoopVerticalScrollRect.SetVisible(true, self.ShowStoreSellConfigs.Count);

            self.UpdateItemNum();
        }

        public static void UpdateItemNum(this ES_TaskShop self)
        {
            long itemNum = self.Root().GetComponent<BagComponentC>().GetItemNumber(10010035);
            // 货币拥有数量显示
            self.E_Lab_BuyPriceText.text = itemNum.ToString();
        }

        //改变当前购买数量
        public static void OnClickChangeBuyNum(this ES_TaskShop self, int num)
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