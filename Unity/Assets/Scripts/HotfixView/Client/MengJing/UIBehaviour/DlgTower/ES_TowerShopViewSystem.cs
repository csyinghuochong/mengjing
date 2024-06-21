using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_WeiJingShopItem))]
    [EntitySystemOf(typeof (ES_TowerShop))]
    [FriendOfAttribute(typeof (ES_TowerShop))]
    public static partial class ES_TowerShopSystem
    {
        [EntitySystem]
        private static void Awake(this ES_TowerShop self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_ButtonBuyButton.AddListenerAsync(self.OnButtonBuy);
            self.E_Btn_BuyNum_jian10Button.AddListener(() => { self.OnBtn_BuyNum_jia(-10); });
            self.E_Btn_BuyNum_jian1Button.AddListener(() => { self.OnBtn_BuyNum_jia(-1); });
            self.E_Btn_BuyNum_jia10Button.AddListener(() => { self.OnBtn_BuyNum_jia(10); });
            self.E_Btn_BuyNum_jia1Button.AddListener(() => { self.OnBtn_BuyNum_jia(1); });
            self.E_WeiJingShopItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnWeiJingShopItemsRefresh);

            self.OnUpdateUI();
            self.OnInitUI();

            //默认购买数量为1
            self.E_Lab_RmbNumInputField.text = "1";
        }

        [EntitySystem]
        private static void Destroy(this ES_TowerShop self)
        {
            self.DestroyWidget();
        }

        private static void OnWeiJingShopItemsRefresh(this ES_TowerShop self, Transform transform, int index)
        {
            Scroll_Item_WeiJingShopItem scrollItemWeiJingShopItem = self.ScrollItemWeiJingShopItems[index].BindTrans(transform);

            scrollItemWeiJingShopItem.OnUpdateData(self.ShowStoreSellConfigs[index]);
            scrollItemWeiJingShopItem.SetClickHandler(self.OnClickHandler);
            scrollItemWeiJingShopItem.E_Text_leftText.gameObject.SetActive(false);
        }

        public static async ETTask OnButtonBuy(this ES_TowerShop self)
        {
            if (self.SellId == 0)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("请选择道具！");
                return;
            }

            int buyNum = int.Parse(self.E_Lab_RmbNumInputField.text);
            await BagClientNetHelper.RquestStoreBuy(self.Root(), self.SellId, buyNum);
            self.OnUpdateNumShow();
        }

        public static void OnUpdateUI(this ES_TowerShop self)
        {
            self.OnClickHandler(0);
        }

        public static void OnClickHandler(this ES_TowerShop self, int sellId)
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

        public static void OnInitUI(this ES_TowerShop self)
        {
            int shopSellid = GlobalValueConfigCategory.Instance.Get(64).Value2;
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
            self.E_WeiJingShopItemsLoopVerticalScrollRect.SetVisible(true, self.ShowStoreSellConfigs.Count);

            //获取道具数量进行显示
            self.OnUpdateNumShow();
        }

        public static void OnUpdateNumShow(this ES_TowerShop self)
        {
            //获取道具数量进行显示
            self.E_Lab_NumText.text = "当前拥有数量:" + self.Root().GetComponent<BagComponentC>().GetItemNumber(10000148);
        }

        public static void OnBtn_BuyNum_jia(this ES_TowerShop self, int num)
        {
            long diamondsNumber = long.Parse(self.E_Lab_RmbNumInputField.text);

            if (num > 0 && diamondsNumber >= 100)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("购买最多100个！");
                return;
            }

            diamondsNumber += num;
            if (diamondsNumber < 1)
                diamondsNumber = 1;
            //单次兑换最多100
            if (diamondsNumber > 100)
            {
                diamondsNumber = 100;
            }

            self.E_Lab_RmbNumInputField.text = diamondsNumber.ToString();
        }
    }
}