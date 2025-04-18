using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgPaiMaiStallBuy))]
    public static class DlgPaiMaiStallBuySystem
    {
        public static void RegisterUIEvent(this DlgPaiMaiStallBuy self)
        {
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_Close);

            self.View.E_Btn_CostNumEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.PointerDown_Btn_CostNum(pdata as PointerEventData).Coroutine(); });
            self.View.E_Btn_CostNumEventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.PointerUp_Btn_CostNum(pdata as PointerEventData); });

            self.View.E_Btn_AddNumEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.PointerDown_Btn_AddNum(pdata as PointerEventData).Coroutine(); });
            self.View.E_Btn_AddNumEventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.PointerUp_Btn_AddNum(pdata as PointerEventData); });

            self.View.E_Btn_BuyButton.AddListener(() => { self.OnBtn_Buy().Coroutine(); });

            self.IsHoldDown = false;
            self.PaiMaiItemInfo = null;
        }

        public static void ShowWindow(this DlgPaiMaiStallBuy self, Entity contextData = null)
        {
        }

        public static async ETTask PointerDown_Btn_CostNum(this DlgPaiMaiStallBuy self, PointerEventData pdata)
        {
            self.IsHoldDown = true;
            while (self.IsHoldDown)
            {
                self.OnCostNum();
                if (self.SellNum == 1)
                {
                    break;
                }

                await self.Root().GetComponent<TimerComponent>().WaitAsync(200);
            }
        }

        public static void OnAddNum(this DlgPaiMaiStallBuy self)
        {
            self.SellNum += 1;
            if (self.SellNum >= self.PaiMaiItemInfo.BagInfo.ItemNum)
            {
                self.SellNum = self.PaiMaiItemInfo.BagInfo.ItemNum;
            }

            self.View.E_Text_NumberText.text = self.SellNum.ToString();
            //self.Lab_ChuShouPrice.GetComponent<Text>().text = self.PaiMaiItemInfo.ToString .Price.ToString();
        }

        public static void OnCostNum(this DlgPaiMaiStallBuy self)
        {
            self.SellNum -= 1;
            if (self.SellNum <= 1)
            {
                self.SellNum = 1;
            }

            self.View.E_Text_NumberText.text = self.SellNum.ToString();
        }

        public static void PointerUp_Btn_CostNum(this DlgPaiMaiStallBuy self, PointerEventData pdata)
        {
            self.IsHoldDown = false;
        }

        public static async ETTask PointerDown_Btn_AddNum(this DlgPaiMaiStallBuy self, PointerEventData pdata)
        {
            self.IsHoldDown = true;
            while (self.IsHoldDown)
            {
                self.OnAddNum();
                if (self.SellNum >= self.PaiMaiItemInfo.BagInfo.ItemNum)
                {
                    break;
                }

                await self.Root().GetComponent<TimerComponent>().WaitAsync(200);
            }
        }

        public static void PointerUp_Btn_AddNum(this DlgPaiMaiStallBuy self, PointerEventData pdata)
        {
            self.IsHoldDown = false;
        }

        public static void OnUpdateUI(this DlgPaiMaiStallBuy self, PaiMaiItemInfo paiMaiItemInfo)
        {
            if (paiMaiItemInfo == null)
            {
                return;
            }

            self.PaiMaiItemInfo = paiMaiItemInfo;
            self.SellNum = paiMaiItemInfo.BagInfo.ItemNum;
            self.View.E_Text_NumberText.text = paiMaiItemInfo.BagInfo.ItemNum.ToString();

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(paiMaiItemInfo.BagInfo.ItemID);
            self.View.E_Lab_ItemNameText.text = itemConfig.ItemName;
            self.View.E_Lab_ChuShouPriceText.text = paiMaiItemInfo.Price.ToString();
            ItemInfo itemInfo = new ItemInfo();
            itemInfo.FromMessage(paiMaiItemInfo.BagInfo);
            self.View.ES_CommonItem.UpdateItem(itemInfo, ItemOperateEnum.None);
        }

        public static void OnBtn_Close(this DlgPaiMaiStallBuy self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PaiMaiStallBuy);
        }

        public static async ETTask OnBtn_Buy(this DlgPaiMaiStallBuy self)
        {
            await PaiMaiNetHelper.RequestStallBuy(self.Root(), self.PaiMaiItemInfo);

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPaiMaiStall>()?.RequestStallInfo().Coroutine();

            self.OnBtn_Close();
        }
    }
}