using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PaiMaiShopItem))]
    [EntitySystemOf(typeof(ES_PaiMaiShop))]
    [FriendOfAttribute(typeof(ES_PaiMaiShop))]
    public static partial class ES_PaiMaiShopSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PaiMaiShop self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Btn_BuyItemButton.AddListener(() => { self.OnBtn_BuyItemButton().Coroutine(); });
            self.E_Btn_BuyNum_jia1Button.AddListener(() => { self.OnClickChangeBuyNum(1); });
            self.E_Btn_BuyNum_jia10Button.AddListener(() => { self.OnClickChangeBuyNum(10); });
            self.E_Btn_BuyNum_jian1Button.AddListener(() => { self.OnClickChangeBuyNum(-1); });
            self.E_Btn_BuyNum_jian10Button.AddListener(() => { self.OnClickChangeBuyNum(-10); });
            self.E_PaiMaiShopItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPaiMaiShopItemsRefresh);

            self.RequestPaiMaiShopData().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_PaiMaiShop self)
        {
            self.DestroyWidget();
        }

        private static async ETTask RequestPaiMaiShopData(this ES_PaiMaiShop self)
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
            
            self.UITypeViewComponent = self.AddChild<UITypeViewComponent, GameObject>(self.EG_TypeListNodeRectTransform.gameObject);
            self.UITypeViewComponent.TypeButtonItemAsset = ABPathHelper.GetUGUIPath("Common/UIPaiMaiShopTypeItem");
            self.UITypeViewComponent.TypeButtonAsset = ABPathHelper.GetUGUIPath("Common/UIPaiMaiShopType");
            self.UITypeViewComponent.ClickTypeItemHandler = (itemType, itemSubType) => { self.OnClickTypeItem(itemType, itemSubType); };

            self.UITypeViewComponent.TypeButtonInfos = self.InitTypeButtonInfos();
            self.UITypeViewComponent.OnInitUI().Coroutine();
        }

        public static List<TypeButtonInfo> InitTypeButtonInfos(this ES_PaiMaiShop self)
        {
            TypeButtonInfo typeButtonInfo = new();
            List<TypeButtonInfo> typeButtonInfos = new List<TypeButtonInfo>();
            typeButtonInfo = new TypeButtonInfo();
            foreach (int key in PaiMaiHelper.GetChaptersByType(PaiMaiTypeEnum.CaiLiao))
            {
                typeButtonInfo.typeButtonItems.Add(new TypeButtonItem() { SubTypeId = key, ItemName = PaiMaiData.PaiMaiIndexText[key] });
            }
            typeButtonInfo.TypeId = (int)PaiMaiTypeEnum.CaiLiao;
            typeButtonInfo.TypeName = PaiMaiData.PaiMaiTypeText[(int)PaiMaiTypeEnum.CaiLiao];
            typeButtonInfos.Add(typeButtonInfo);

            typeButtonInfo = new TypeButtonInfo();
            foreach (int key in PaiMaiHelper.GetChaptersByType(PaiMaiTypeEnum.CostItem))
            {
                typeButtonInfo.typeButtonItems.Add(new TypeButtonItem() { SubTypeId = key, ItemName = PaiMaiData.PaiMaiIndexText[key] });
            }
            typeButtonInfo.TypeId = (int)PaiMaiTypeEnum.CostItem;
            typeButtonInfo.TypeName = PaiMaiData.PaiMaiTypeText[(int)PaiMaiTypeEnum.CostItem];
            typeButtonInfos.Add(typeButtonInfo);
            
            typeButtonInfo = new TypeButtonInfo();
            foreach (int key in PaiMaiHelper.GetChaptersByType(PaiMaiTypeEnum.PetItem))
            {
                typeButtonInfo.typeButtonItems.Add(new TypeButtonItem() { SubTypeId = key, ItemName = PaiMaiData.PaiMaiIndexText[key] });
            }
            typeButtonInfo.TypeId = (int)PaiMaiTypeEnum.PetItem;
            typeButtonInfo.TypeName = PaiMaiData.PaiMaiTypeText[(int)PaiMaiTypeEnum.PetItem];
            typeButtonInfos.Add(typeButtonInfo);

            return typeButtonInfos;
        }

        public static async ETTask OnBtn_BuyItemButton(this ES_PaiMaiShop self)
        {
            if (self.PaiMaiSellId == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("请选中要拍卖的商品！");
                return;
            }

            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            PaiMaiSellConfig paiMaiSellConfig = PaiMaiSellConfigCategory.Instance.Get(self.PaiMaiSellId);
            if (userInfo.Lv < paiMaiSellConfig.BuyLv)
            {
                using (zstring.Block())
                {
                    FlyTipComponent.Instance.ShowFlyTip(zstring.Format("{0}级才能购买！", paiMaiSellConfig.BuyLv));
                }

                return;
            }

            if (self.Root().GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("背包已满！");
                return;
            }

            await PaiMaiNetHelper.PaiMaiShop(self.Root(), self.PaiMaiSellId, self.BuyNum);
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
                Scroll_Item_PaiMaiShopItem scrollItemPaiMaiShopItem = self.ScrollItemPaiMaiShopItems[0];
                if (self.ScrollItemPaiMaiShopItems != null && self.ScrollItemPaiMaiShopItems.Count > 0 &&
                    scrollItemPaiMaiShopItem.uiTransform != null)
                {
                    scrollItemPaiMaiShopItem.ImageButton();
                }
            }
        }

        private static void OnPaiMaiShopItemsRefresh(this ES_PaiMaiShop self, Transform transform, int index)
        {
            foreach (Scroll_Item_PaiMaiShopItem item in self.ScrollItemPaiMaiShopItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
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
                foreach (Scroll_Item_PaiMaiShopItem item in self.ScrollItemPaiMaiShopItems.Values)
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
                FlyTipComponent.Instance.ShowFlyTip("单次购买数量最多为100");
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
