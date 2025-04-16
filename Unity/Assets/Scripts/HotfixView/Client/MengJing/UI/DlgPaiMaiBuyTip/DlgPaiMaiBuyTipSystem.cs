using System;

namespace ET.Client
{
    [FriendOf(typeof(DlgPaiMaiBuyTip))]
    public static class DlgPaiMaiBuyTipSystem
    {
        public static void RegisterUIEvent(this DlgPaiMaiBuyTip self)
        {
            self.View.E_ImageButtonButton.AddListener(self.OnImageButtonButton);
            self.View.E_Btn_BuyNum_jia1Button.AddListener(() => { self.OnClickChangeBuyNum(1); });
            self.View.E_Btn_BuyNum_jia10Button.AddListener(() => { self.OnClickChangeBuyNum(10); });
            self.View.E_Btn_BuyNum_jian1Button.AddListener(() => { self.OnClickChangeBuyNum(-1); });
            self.View.E_Btn_BuyNum_jian10Button.AddListener(() => { self.OnClickChangeBuyNum(-10); });
            self.View.E_Btn_BuyButton.AddListenerAsync(self.OnBtn_BuyButton);
        }

        public static void ShowWindow(this DlgPaiMaiBuyTip self, Entity contextData = null)
        {
        }

        public static void OnImageButtonButton(this DlgPaiMaiBuyTip self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PaiMaiBuyTip);
        }

        public static void InitInfo(this DlgPaiMaiBuyTip self, PaiMaiItemInfo paiMaiItemInfo, Action<int> buyAction)
        {
            self.PaiMaiItemInfo = paiMaiItemInfo;
            self.BuyAction = buyAction;
            ItemInfo itemInfo = new ItemInfo();
            itemInfo.FromMessage(self.PaiMaiItemInfo.BagInfo);
            self.View.ES_CommonItem.UpdateItem(itemInfo, ItemOperateEnum.None);
            self.BuyNum = 1;
            self.View.E_Lab_RmbNumInputField.text = self.BuyNum.ToString();
            using (zstring.Block())
            {
                self.View.E_UnitPriceTextText.text = zstring.Format("单价：{0}", self.PaiMaiItemInfo.Price);
                self.View.E_TotalPriceTextText.text = zstring.Format("总价：{0}", self.PaiMaiItemInfo.Price * self.BuyNum);
            }
        }

        public static void OnClickChangeBuyNum(this DlgPaiMaiBuyTip self, int num)
        {
            self.BuyNum += num;
            if (self.BuyNum < 1)
            {
                self.BuyNum = 1;
            }

            if (self.BuyNum > self.PaiMaiItemInfo.BagInfo.ItemNum)
            {
                self.BuyNum = self.PaiMaiItemInfo.BagInfo.ItemNum;
            }

            self.View.E_Lab_RmbNumInputField.text = self.BuyNum.ToString();
            using (zstring.Block())
            {
                self.View.E_TotalPriceTextText.text = zstring.Format("总价：{0}", self.PaiMaiItemInfo.Price * self.BuyNum);
            }
        }

        public static async ETTask OnBtn_BuyButton(this DlgPaiMaiBuyTip self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("背包空间不足");
                return;
            }

            M2C_PaiMaiBuyNewResponse response = await PaiMaiNetHelper.PaiMaiBuyNew(self.Root(), self.PaiMaiItemInfo, self.BuyNum, 0);
            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }
            
            self.BuyAction?.Invoke(self.BuyNum);
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PaiMaiBuyTip);
        }
    }
}