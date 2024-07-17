using System;

namespace ET.Client
{
    [FriendOf(typeof (DlgPaiMaiBuyTip))]
    public static class DlgPaiMaiBuyTipSystem
    {
        public static void RegisterUIEvent(this DlgPaiMaiBuyTip self)
        {
            self.View.E_ImageButtonButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PaiMaiBuyTip); });
            self.View.E_Btn_BuyNum_jia1Button.AddListener(() => { self.OnClickChangeBuyNum(1); });
            self.View.E_Btn_BuyNum_jia10Button.AddListener(() => { self.OnClickChangeBuyNum(10); });
            self.View.E_Btn_BuyNum_jian1Button.AddListener(() => { self.OnClickChangeBuyNum(-1); });
            self.View.E_Btn_BuyNum_jian10Button.AddListener(() => { self.OnClickChangeBuyNum(-10); });
            self.View.E_Btn_BuyButton.AddListenerAsync(self.OnBtn_Buy);
        }

        public static void ShowWindow(this DlgPaiMaiBuyTip self, Entity contextData = null)
        {
        }

        public static void InitInfo(this DlgPaiMaiBuyTip self, PaiMaiItemInfo paiMaiItemInfo, Action<int> buyAction)
        {
            self.PaiMaiItemInfo = paiMaiItemInfo;
            self.BuyAction = buyAction;
            self.View.ES_CommonItem.UpdateItem(self.PaiMaiItemInfo.BagInfo, ItemOperateEnum.None);
            self.BuyNum = 1;
            self.View.E_Lab_RmbNumInputField.text = self.BuyNum.ToString();
            self.View.E_UnitPriceTextText.text = $"单价：{self.PaiMaiItemInfo.Price}";
            self.View.E_TotalPriceTextText.text = $"总价：{self.PaiMaiItemInfo.Price * self.BuyNum}";
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
            self.View.E_TotalPriceTextText.text = $"总价：{self.PaiMaiItemInfo.Price * self.BuyNum}";
        }

        public static async ETTask OnBtn_Buy(this DlgPaiMaiBuyTip self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (bagComponent.GetBagLeftCell() < 1)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("背包空间不足");
                return;
            }

            M2C_PaiMaiBuyResponse response = await PaiMaiNetHelper.PaiMaiBuy(self.Root(), self.PaiMaiItemInfo, self.BuyNum, 0);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.BuyAction?.Invoke(self.BuyNum);
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PaiMaiBuyTip);
        }
    }
}