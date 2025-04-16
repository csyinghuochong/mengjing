namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PaiMaiBuyItem))]
    [EntitySystemOf(typeof(Scroll_Item_PaiMaiBuyItem))]
    public static partial class Scroll_Item_PaiMaiBuyItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PaiMaiBuyItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PaiMaiBuyItem self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnOpenPDList(this Scroll_Item_PaiMaiBuyItem self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_WatchPaiMai);
            DlgWatchPaiMai dlgWatchPaiMai = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgWatchPaiMai>();
            dlgWatchPaiMai.OnUpdateUI(self.FastSeach);
        }

        public static void FastSeach(this Scroll_Item_PaiMaiBuyItem self)
        {
            self.GetParent<ES_PaiMaiBuy>().E_InputFieldInputField.text = self.E_Text_NameText.text;
        }

        public static async ETTask RequestBuy(this Scroll_Item_PaiMaiBuyItem self)
        {
            long instanceId = self.InstanceId;
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();

            M2C_PaiMaiBuyNewResponse response = await PaiMaiNetHelper.PaiMaiBuyNew(self.Root(), self.PaiMaiItemInfo, 1, numericComponent.GetAsInt(NumericType.RechargeNumber));
            if (instanceId != self.InstanceId)
            {
                return;
            }
            if (response.Error == 0)
            {
                if (self.uiTransform.gameObject != null)
                {
                    self.uiTransform.gameObject.SetActive(false);
                }
            
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.PaiMaiItemInfo.BagInfo.ItemID);
                self.GetParent<ES_PaiMaiBuy>().RemoveItem(itemConfig.ItemType, self.PaiMaiItemInfo);
            }
            // else
            // {
            //     FlyTipComponent.Instance.ShowFlyTip("道具已经被买走了！");
            // }
        }

        public static async ETTask OnClickButtonBuy(this Scroll_Item_PaiMaiBuyItem self)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.PaiMaiItemInfo.BagInfo.ItemID);

            if (itemConfig.ItemQuality >= 5 && itemConfig.ItemType == 3)
            {
                FlyTipComponent.Instance.ShowFlyTip("橙色品质及以上的装备不能购买！");
                return;
            }

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("背包空间不足");
                return;
            }

            bool canBuy = false;
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int openPaiMai = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PaiMaiOpen);
            if (openPaiMai == 1)
            {
                canBuy = true;
            }

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            int createDay = userInfoComponent.GetCreateDay();

            if (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.RechargeNumber) > 0)
            {
                canBuy = true;
            }

            if (CommonHelp.IsCanPaiMai_KillBoss(userInfoComponent.UserInfo.MonsterRevives, userInfoComponent.UserInfo.Lv))
            {
                canBuy = true;
            }

            int needLv = CommonHelp.IsCanPaiMai_Level(createDay, userInfoComponent.UserInfo.Lv);
            if (needLv == 0)
            {
                canBuy = true;
            }

            if (!canBuy)
            {
                using (zstring.Block())
                {
                    FlyTipComponent.Instance.ShowFlyTip(zstring.Format("等级需达到{0}级或赞助任意金额开启拍卖行购买功能！", needLv));
                }

                return;
            }

            if (self.PaiMaiItemInfo.BagInfo.ItemNum > 1)
            {
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PaiMaiBuyTip);
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPaiMaiBuyTip>().InitInfo(self.PaiMaiItemInfo, (int buyNum) =>
                {
                    if (buyNum < self.PaiMaiItemInfo.BagInfo.ItemNum)
                    {
                        self.PaiMaiItemInfo.BagInfo.ItemNum -= buyNum;
                        self.OnUpdateItem(self.PaiMaiItemInfo);
                    }
                    else
                    {
                        if (self.uiTransform.gameObject != null)
                        {
                            self.uiTransform.gameObject.SetActive(false);
                        }

                        ItemConfig itemConfig1 = ItemConfigCategory.Instance.Get(self.PaiMaiItemInfo.BagInfo.ItemID);
                        self.GetParent<ES_PaiMaiBuy>().RemoveItem(itemConfig1.ItemType, self.PaiMaiItemInfo);
                    }
                });
            }
            else
            {
                if (self.PaiMaiItemInfo.Price * self.PaiMaiItemInfo.BagInfo.ItemNum >= 500000)
                {
                    using (zstring.Block())
                    {
                        PopupTipHelp.OpenPopupTip(self.Root(), "购买道具",
                            zstring.Format("你购买的道具需要花费{0}金币，是否购买？", self.PaiMaiItemInfo.Price * self.PaiMaiItemInfo.BagInfo.ItemNum),
                            () => { self.RequestBuy().Coroutine(); },
                            null).Coroutine();
                    }
                }
                else
                {
                    self.RequestBuy().Coroutine();
                }
            }
        }

        public static void OnUpdateItem(this Scroll_Item_PaiMaiBuyItem self, PaiMaiItemInfo paiMaiItemInfo)
        {
            self.E_PDListBtnButton.AddListenerAsync(self.OnOpenPDList);
            self.E_ButtonBuyButton.AddListenerAsync(self.OnClickButtonBuy);

            self.PaiMaiItemInfo = paiMaiItemInfo;
            if (paiMaiItemInfo == null || self.ES_CommonItem == null)
                return;

            ItemInfo itemInfo = new ItemInfo();
            itemInfo.FromMessage(paiMaiItemInfo.BagInfo);
            self.ES_CommonItem.UpdateItem(itemInfo, ItemOperateEnum.PaiMaiBuy);
            self.E_Text_OwnerText.text = paiMaiItemInfo.PlayerName;

            FunctionUI.ItemObjShowName(self.E_Text_NameText.gameObject, self.PaiMaiItemInfo.BagInfo.ItemID);

            int sumPrice = paiMaiItemInfo.Price * paiMaiItemInfo.BagInfo.ItemNum;
            self.E_Text_PriceText.text = sumPrice.ToString();

            self.E_Text_LeftTimeText.text = TimeHelper.TimeToShowCostTimeStr(paiMaiItemInfo.SellTime, 48);

            ItemConfig itemCof = ItemConfigCategory.Instance.Get(self.PaiMaiItemInfo.BagInfo.ItemID);
            if (itemCof.ItemType == 3)
            {
                self.ES_CommonItem.E_ItemNumText.gameObject.SetActive(true);
                using (zstring.Block())
                {
                    self.ES_CommonItem.E_ItemNumText.text = zstring.Format("{0}级", itemCof.UseLv);
                }
            }
        }
    }
}