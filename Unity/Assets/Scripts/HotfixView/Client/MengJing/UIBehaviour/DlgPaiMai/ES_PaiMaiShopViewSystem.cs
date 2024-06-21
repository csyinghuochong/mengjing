using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_PaiMaiShopItem))]
    [EntitySystemOf(typeof (ES_PaiMaiShop))]
    [FriendOfAttribute(typeof (ES_PaiMaiShop))]
    public static partial class ES_PaiMaiShopSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PaiMaiShop self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Btn_BuyItemButton.AddListener(() => { self.OnBtn_BuyItem().Coroutine(); });
            self.E_Btn_BuyNum_jia1Button.AddListener(() => { self.OnClickChangeBuyNum(1); });
            self.E_Btn_BuyNum_jia10Button.AddListener(() => { self.OnClickChangeBuyNum(10); });
            self.E_Btn_BuyNum_jian1Button.AddListener(() => { self.OnClickChangeBuyNum(-1); });
            self.E_Btn_BuyNum_jian10Button.AddListener(() => { self.OnClickChangeBuyNum(-10); });
            self.E_PaiMaiShopItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPaiMaiShopItemsRefresh);

            ReferenceCollector rc = self.uiTransform.GetComponent<ReferenceCollector>();
            self.UIPaiMaiShopType = rc.Get<GameObject>("UIPaiMaiShopType");
            self.UIPaiMaiShopType.SetActive(false);

            self.RequestPaiMaiShopData().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_PaiMaiShop self)
        {
            self.DestroyWidget();
        }

        public static async ETTask RequestPaiMaiShopData(this ES_PaiMaiShop self)
        {
            long instanceId = self.InstanceId;

            P2C_PaiMaiShopShowListResponse response = await PaiMaiNetHelper.PaiMaiShopShowList(self.Root());

            if (instanceId != self.InstanceId)
            {
                return;
            }

            foreach (PaiMaiShopItemInfo data in response.PaiMaiShopItemInfos)
            {
                self.PaiMaiShopItemInfos.Add(data.Id, data);
            }

            DlgPaiMai dlgPaiMai = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPaiMai>();
            dlgPaiMai.PaiMaiShopItemInfos = self.PaiMaiShopItemInfos;

            self.InitPaiMaiType();
        }

        public static void InitPaiMaiType(this ES_PaiMaiShop self)
        {
            long instanceid = self.InstanceId;
            if (instanceid != self.InstanceId)
            {
                return;
            }

            for (int i = (int)PaiMaiTypeEnum.CaiLiao; i < (int)PaiMaiTypeEnum.Number; i++)
            {
                GameObject go = UnityEngine.Object.Instantiate(self.UIPaiMaiShopType);
                go.SetActive(true);
                UICommonHelper.SetParent(go, self.EG_TypeListNodeRectTransform.gameObject);

                UIPaiMaiShopTypeComponent itemComponent = self.AddChild<UIPaiMaiShopTypeComponent, GameObject>(go);
                itemComponent.OnUpdateData(i);
                itemComponent.SetClickTypeHandler((int typeid) => { self.OnClickType(typeid); });
                itemComponent.SetClickTypeItemHandler((int typeid, int chapterId) => { self.OnClickTypeItem(typeid, chapterId); });

                self.TypeItemUIList.Add(itemComponent);
            }

            self.TypeItemUIList[0].OnClickTypeButton();
        }

        public static async ETTask OnBtn_BuyItem(this ES_PaiMaiShop self)
        {
            if (self.PaiMaiSellId == 0)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("请选中要拍卖的商品！");
                return;
            }

            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            PaiMaiSellConfig paiMaiSellConfig = PaiMaiSellConfigCategory.Instance.Get(self.PaiMaiSellId);
            if (userInfo.Lv < paiMaiSellConfig.BuyLv)
            {
                FlyTipComponent.Instance.ShowFlyTipDi($"{paiMaiSellConfig.BuyLv}级才能购买！");
                return;
            }

            if (self.Root().GetComponent<BagComponentC>().GetBagLeftCell() < 1)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("背包已满！");
                return;
            }

            await PaiMaiNetHelper.PaiMaiShop(self.Root(), self.PaiMaiSellId, self.BuyNum);
        }

        public static void OnClickType(this ES_PaiMaiShop self, int typeid)
        {
            self.PaiMaiTypeId = typeid;
            for (int i = 0; i < self.TypeItemUIList.Count; i++)
            {
                UIPaiMaiShopTypeComponent uIChengJiuTypeComponent = self.TypeItemUIList[i];
                uIChengJiuTypeComponent.SetSelected(typeid).Coroutine();
            }
        }

        public static void OnClickTypeItem(this ES_PaiMaiShop self, int typeid, int chapterId)
        {
            self.PaiMaiTypeId = typeid;
            long instanceid = self.InstanceId;
            List<int> ids = PaiMaiHelper.GetItemsByChapter(typeid, chapterId);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            self.ShowPaiMaiIds.Clear();
            self.ShowPaiMaiIds.AddRange(ids);

            self.AddUIScrollItems(ref self.ScrollItemPaiMaiShopItems, self.ShowPaiMaiIds.Count);
            self.E_PaiMaiShopItemsLoopVerticalScrollRect.SetVisible(true, self.ShowPaiMaiIds.Count);

            if (ids.Count > 0)
            {
                if (self.ScrollItemPaiMaiShopItems != null && self.ScrollItemPaiMaiShopItems.Count > 0 &&
                    self.ScrollItemPaiMaiShopItems[0].uiTransform != null)
                {
                    self.ScrollItemPaiMaiShopItems[0].ImageButton();
                }
            }
        }

        private static void OnPaiMaiShopItemsRefresh(this ES_PaiMaiShop self, Transform transform, int index)
        {
            Scroll_Item_PaiMaiShopItem scrollItemPaiMaiShopItem = self.ScrollItemPaiMaiShopItems[index].BindTrans(transform);
            scrollItemPaiMaiShopItem.SetClickHandler((int paimaiId) => { self.OnClickPaiMaiBuyItem(paimaiId); });
            scrollItemPaiMaiShopItem.OnUpdateData(self.ShowPaiMaiIds[index],
                self.PaiMaiShopItemInfos[PaiMaiSellConfigCategory.Instance.Get(self.ShowPaiMaiIds[index]).ItemID]);
        }

        public static void OnClickPaiMaiBuyItem(this ES_PaiMaiShop self, int paimaiId)
        {
            self.PaiMaiSellId = paimaiId;
            if (self.ScrollItemPaiMaiShopItems != null)
            {
                foreach (var item in self.ScrollItemPaiMaiShopItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.SetSelected(paimaiId);
                }
            }

            PaiMaiShopItemInfo shopInfo = self.PaiMaiShopItemInfos[PaiMaiSellConfigCategory.Instance.Get(paimaiId).ItemID];
            self.E_Lab_BuyPriceText.text = shopInfo.Price.ToString();

            self.BuyNum = 1;
            self.E_Lab_BuyNumText.text = self.BuyNum.ToString();
        }

        public static void OnClickChangeBuyNum(this ES_PaiMaiShop self, int num)
        {
            if (num > 0 && self.BuyNum >= 100)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("单次购买数量最多为100");
                return;
            }

            self.BuyNum += num;
            if (self.BuyNum <= 1)
            {
                self.BuyNum = 1;
            }

            if (self.BuyNum > 100)
            {
                self.BuyNum = 100;
            }

            self.E_Lab_BuyNumText.text = self.BuyNum.ToString();

            PaiMaiShopItemInfo shopInfo = self.PaiMaiShopItemInfos[PaiMaiSellConfigCategory.Instance.Get(self.PaiMaiSellId).ItemID];

            self.E_Lab_BuyPriceText.text = (shopInfo.Price * self.BuyNum).ToString();
        }
    }
}