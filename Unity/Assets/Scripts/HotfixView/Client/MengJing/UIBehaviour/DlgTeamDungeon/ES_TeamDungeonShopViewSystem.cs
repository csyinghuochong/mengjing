using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_BattleShopItem))]
    [EntitySystemOf(typeof(ES_TeamDungeonShop))]
    [FriendOfAttribute(typeof(ES_TeamDungeonShop))]
    public static partial class ES_TeamDungeonShopSystem
    {
        [EntitySystem]
        private static void Awake(this ES_TeamDungeonShop self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_BattleShopItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBattleShopItemsRefresh);
            self.E_ButtonBuyButton.AddListener(self.OnButtonBuyButton);
            self.E_Btn_BuyNum_jia1Button.AddListener(() => { self.OnClickChangeBuyNum(1); });
            self.E_Btn_BuyNum_jia10Button.AddListener(() => { self.OnClickChangeBuyNum(10); });
            self.E_Btn_BuyNum_jian1Button.AddListener(() => { self.OnClickChangeBuyNum(-1); });
            self.E_Btn_BuyNum_jian10Button.AddListener(() => { self.OnClickChangeBuyNum(-10); });

            self.OnClickChangeBuyNum(1);
        }

        [EntitySystem]
        private static void Destroy(this ES_TeamDungeonShop self)
        {
            self.DestroyWidget();
        }

        public static void OnButtonBuyButton(this ES_TeamDungeonShop self)
        {
            if (self.SellId == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("请选择道具！");
                return;
            }

            BagClientNetHelper.RquestStoreBuy(self.Root(), self.SellId, self.BuyNum).Coroutine();
        }

        public static void OnClickHandler(this ES_TeamDungeonShop self, int sellId)
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

            self.OnClickChangeBuyNum(1 - self.BuyNum);
        }

        public static void OnClickChangeBuyNum(this ES_TeamDungeonShop self, int num)
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

        public static void OnUpdateUI(this ES_TeamDungeonShop self)
        {
            //更新自身拥有的货币显示
            int itemShowID = 10000149;
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemShowID.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_ItemIconShowImage.sprite = sp;
            self.E_ItemNumText.text = self.Root().GetComponent<BagComponentC>().GetItemNumber(itemShowID).ToString();

            if (self.ScrollItemBattleShopItems != null && self.ScrollItemBattleShopItems.Count > 0)
            {
                return;
            }

            int shopSellid = GlobalValueConfigCategory.Instance.TeamDungeonShopId;
            int playLv = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;
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
        }

        private static void OnBattleShopItemsRefresh(this ES_TeamDungeonShop self, Transform transform, int index)
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
    }
}
