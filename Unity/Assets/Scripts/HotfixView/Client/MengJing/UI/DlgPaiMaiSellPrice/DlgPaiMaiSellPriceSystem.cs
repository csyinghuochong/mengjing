using UnityEngine.EventSystems;

namespace ET.Client
{
    [FriendOf(typeof(DlgPaiMaiSellPrice))]
    public static class DlgPaiMaiSellPriceSystem
    {
        public static void RegisterUIEvent(this DlgPaiMaiSellPrice self)
        {
            self.View.E_ImageButtonButton.AddListener(self.OnImageButtonButton);
            self.View.E_Btn_ChuShouButton.AddListenerAsync(self.OnBtn_ChuShouButton);
            self.View.E_Btn_CostButton.AddListener(self.OnBtn_CostButton);
            self.View.E_Btn_AddButton.AddListener(self.OnBtn_AddButton);
            self.View.E_PriceInputFieldInputField.onValueChanged.AddListener((value) => { self.OnChange(value); });

            self.View.E_Btn_CostNumEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.PointerDown_Btn_CostNum(pdata as PointerEventData).Coroutine(); });
            self.View.E_Btn_CostNumEventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.PointerUp_Btn_CostNum(pdata as PointerEventData); });

            self.View.E_Btn_AddNumEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.PointerDown_Btn_AddNum(pdata as PointerEventData).Coroutine(); });
            self.View.E_Btn_AddNumEventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.PointerUp_Btn_AddNum(pdata as PointerEventData); });
        }

        public static void ShowWindow(this DlgPaiMaiSellPrice self, Entity contextData = null)
        {
        }

        public static async ETTask PointerDown_Btn_CostNum(this DlgPaiMaiSellPrice self, PointerEventData pdata)
        {
            int interval = 0;
            self.IsHoldDown = true;
            self.OnCostNum();
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            while (self.IsHoldDown)
            {
                interval++;
                if (interval > 60)
                {
                    self.OnCostNum();
                }

                if (self.SellNum == 1)
                {
                    break;
                }

                await timerComponent.WaitFrameAsync();
            }
        }

        public static void PointerUp_Btn_CostNum(this DlgPaiMaiSellPrice self, PointerEventData pdata)
        {
            self.IsHoldDown = false;
        }

        public static async ETTask PointerDown_Btn_AddNum(this DlgPaiMaiSellPrice self, PointerEventData pdata)
        {
            int interval = 0;
            self.IsHoldDown = true;
            self.OnAddNum();
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            while (self.IsHoldDown)
            {
                interval++;
                if (interval > 60)
                {
                    self.OnAddNum();
                }

                if (self.SellNum >= self.BagInfo.ItemNum)
                {
                    break;
                }

                await timerComponent.WaitFrameAsync();
            }
        }

        public static void PointerUp_Btn_AddNum(this DlgPaiMaiSellPrice self, PointerEventData pdata)
        {
            self.IsHoldDown = false;
        }

        public static void OnImageButtonButton(this DlgPaiMaiSellPrice self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PaiMaiSellPrice);
        }

        public static async ETTask OnBtn_ChuShouButton(this DlgPaiMaiSellPrice self)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.BagInfo.ItemID);

            if (itemConfig.ItemQuality >= 5 && itemConfig.ItemType == 3)
            {
                FlyTipComponent.Instance.ShowFlyTip("橙色品质及以上的装备不能上架！");
                return;
            }

            PaiMaiItemInfo paiMaiItemInfo = new();
            paiMaiItemInfo.BagInfo = CommonHelp.DeepCopy(self.BagInfo.ToMessage());
            paiMaiItemInfo.BagInfo.ItemNum = self.SellNum;
            paiMaiItemInfo.Price = self.nowPrice;
            DlgPaiMai dlgPaiMai = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPaiMai>();
            if (dlgPaiMai.PaiMaiShopItemInfos.ContainsKey(paiMaiItemInfo.BagInfo.ItemID))
            {
                int oldPrice = dlgPaiMai.PaiMaiShopItemInfos[paiMaiItemInfo.BagInfo.ItemID].Price;

                int nowPrice = (int)((float)paiMaiItemInfo.Price);
                if (nowPrice < (int)(oldPrice * 0.5f))
                {
                    using (zstring.Block())
                    {
                        FlyTipComponent.Instance.ShowFlyTip(zstring.Format("{0}{1}", LanguageComponent.Instance.LoadLocalization("出售价格过低，当前最低价格为:"),
                            (int)(oldPrice * 0.5f) * paiMaiItemInfo.BagInfo.ItemNum));
                    }

                    return;
                }
            }

            if (paiMaiItemInfo.Price * self.SellNum >= 1000000)
            {
                //FlyTipComponent.Instance.ShowFlyTip("上架总金额不能超过100万金币！");
                PopupTipHelp.OpenPopupTip_2(self.Root(), "系统提示", "上架总金额不能超过100万金币！", null).Coroutine();
                return;
            }

            long instanceid = self.InstanceId;
            M2C_PaiMaiSellResponse response = await PaiMaiNetHelper.PaiMaiSell(self.Root(), paiMaiItemInfo);
            if (instanceid != self.InstanceId || response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            if (itemConfig.ItemQuality >= 4 && response.PaiMaiItemInfo != null)
            {
                long paimaiItemId = response.PaiMaiItemInfo.Id;
                using (zstring.Block())
                {
                    string text = zstring.Format("在拍卖行上架道具<color=#{0}>{1}</color>！<color=#00FF00>点击前往拍卖行 </color><link=paimai_{2}_{3}></link>",
                        CommonHelp.QualityReturnColor(4), itemConfig.ItemName, itemConfig.ItemType, paimaiItemId);
                    ChatNetHelper.RequestSendChat(self.Root(), ChannelEnum.PaiMai, text).Coroutine();
                }
            }

            dlgPaiMai.View.ES_PaiMaiSell.OnPaiBuyShangJia(response.PaiMaiItemInfo);

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PaiMaiSellPrice);
        }

        public static void InitPriceUI(this DlgPaiMaiSellPrice self, ItemInfo bagInfo)
        {
            self.BagInfo = bagInfo;

            self.View.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
            FunctionUI.ItemObjShowName(self.View.E_Lab_NameText.gameObject, bagInfo.ItemID);

            //设置价格
            self.oldPrice = 10000; //临时
            //获取是否是快捷购买的道具列表
            DlgPaiMai dlgPaiMai = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPaiMai>();
            if (dlgPaiMai.PaiMaiShopItemInfos.ContainsKey(bagInfo.ItemID))
            {
                self.oldPrice = dlgPaiMai.PaiMaiShopItemInfos[bagInfo.ItemID].Price;
            }

            self.nowPrice = self.oldPrice;
            self.SellNum = bagInfo.ItemNum;

            self.View.E_Lab_TuijianText.text = self.oldPrice.ToString();
            self.View.E_Text_NumText.text = self.SellNum.ToString();

            self.priceProNum = 1;
            self.OnBtn_CostButton();
        }

        public static void OnBtn_AddButton(this DlgPaiMaiSellPrice self)
        {
            self.priceProNum += 1;
            if (self.priceProNum >= 10)
            {
                self.priceProNum = 10;
                FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("如需再提高价格，请手动修改价格!"));
            }

            self.nowPrice = (int)(self.oldPrice * (1f + 0.1f * self.priceProNum));
            self.View.E_Lab_SellSumProText.text = ((int)(self.oldPrice * (1f + 0.1f * self.priceProNum) * self.SellNum)).ToString();
            self.View.E_PriceInputFieldInputField.text = self.nowPrice.ToString();
        }

        public static void OnBtn_CostButton(this DlgPaiMaiSellPrice self)
        {
            self.priceProNum -= 1;
            if (self.priceProNum <= -10)
            {
                self.priceProNum = -10;
            }

            self.nowPrice = (int)(self.oldPrice * (1f + 0.1f * self.priceProNum));
            self.View.E_Lab_SellSumProText.text = ((int)(self.oldPrice * (1f + 0.1f * self.priceProNum) * self.SellNum)).ToString();
            self.View.E_PriceInputFieldInputField.text = self.nowPrice.ToString();
        }

        public static void OnAddNum(this DlgPaiMaiSellPrice self)
        {
            self.SellNum += 1;
            if (self.SellNum >= self.BagInfo.ItemNum)
            {
                self.SellNum = self.BagInfo.ItemNum;
            }

            self.View.E_Text_NumText.text = self.SellNum.ToString();
            self.View.E_Lab_SellSumProText.text = ((int)(self.oldPrice * (1f + 0.1f * self.priceProNum) * self.SellNum)).ToString();
        }

        public static void OnCostNum(this DlgPaiMaiSellPrice self)
        {
            self.SellNum -= 1;
            if (self.SellNum <= 1)
            {
                self.SellNum = 1;
            }

            self.View.E_Text_NumText.text = self.SellNum.ToString();
            self.View.E_Lab_SellSumProText.text = ((int)(self.oldPrice * (1f + 0.1f * self.priceProNum) * self.SellNum)).ToString();
        }

        public static void OnChange(this DlgPaiMaiSellPrice self, string str)
        {
            self.nowPrice = int.Parse(str);
        }
    }
}
