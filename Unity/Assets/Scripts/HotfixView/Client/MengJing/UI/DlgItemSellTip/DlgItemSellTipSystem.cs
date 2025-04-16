using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (DlgItemSellTip))]
    public static class DlgItemSellTipSystem
    {
        public static void RegisterUIEvent(this DlgItemSellTip self)
        {
            self.View.E_AddButton.AddListener(self.OnAddButton);
            self.View.E_NumInputField.onValueChanged.AddListener(self.OnNumInputField);
            self.View.E_CostButton.AddListener(self.OnCostButton);
            self.View.E_CancelButton.AddListener(self.OnCancelButton);
            self.View.E_ChuShouButton.AddListenerAsync(self.OnChuShouButton);
            self.View.E_CloseButton.AddListener(self.OnCloseButton);
        }

        public static void ShowWindow(this DlgItemSellTip self, Entity contextData = null)
        {
        }

        public static void Init(this DlgItemSellTip self, ItemInfo bagInfo)
        {
            self.BagInfo = bagInfo;
            self.Num = bagInfo.ItemNum;
            self.View.E_NumInputField.text = self.Num.ToString();

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.BagInfo.ItemID);

            // self.View.ES_CommonItem.UseTextColor = true;
            self.View.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
            self.View.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);
            self.View.ES_CommonItem.E_ItemNameText.gameObject.SetActive(true);
            
            ItemConfig sellTypeItemConfig = ItemConfigCategory.Instance.Get(itemConfig.SellMoneyType);
            self.View.E_MoneyImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, sellTypeItemConfig.Icon));
            self.ChangeTotalPrices();
        }

        private static void OnAddButton(this DlgItemSellTip self)
        {
            if (self.Num >= self.BagInfo.ItemNum)
            {
                return;
            }

            self.Num++;
            self.ChangeTotalPrices();
            self.View.E_NumInputField.text = self.Num.ToString();
        }

        private static void OnNumInputField(this DlgItemSellTip self, string text)
        {
            long num = 0;
            if (long.TryParse(text, out num))
            {
                if (num > 0 && num <= self.BagInfo.ItemNum)
                {
                    self.Num = num;
                    self.ChangeTotalPrices();
                }
            }
        }

        private static void OnCostButton(this DlgItemSellTip self)
        {
            if (self.Num <= 1)
            {
                return;
            }

            self.Num--;
            self.ChangeTotalPrices();
            self.View.E_NumInputField.text = self.Num.ToString();
        }

        private static void ChangeTotalPrices(this DlgItemSellTip self)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.BagInfo.ItemID);
            long price = self.Num * itemConfig.SellMoneyValue;
            self.View.E_TotalPricesText.text = price.ToString();
        }

        private static void OnCancelButton(this DlgItemSellTip self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemSellTip);
        }

        private static async ETTask OnChuShouButton(this DlgItemSellTip self)
        {
            FlyTipComponent flyTipComponent = self.Root().GetComponent<FlyTipComponent>();
            if (self.BagInfo.IsProtect)
            {
                flyTipComponent.ShowFlyTip("锁定道具不能出售!");
            }

            int errorCode = await BagClientNetHelper.RequestSellItem(self.Root(), self.BagInfo, self.Num.ToString());
            if (errorCode == ErrorCode.ERR_Success)
            {
                flyTipComponent.ShowFlyTip("出售完成!");
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemSellTip);
        }
        public static void OnCloseButton(this DlgItemSellTip self)
        {
        }
    }
}
