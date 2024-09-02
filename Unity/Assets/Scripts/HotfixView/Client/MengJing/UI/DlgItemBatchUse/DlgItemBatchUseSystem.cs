using System;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [FriendOf(typeof(DlgItemBatchUse))]
    public static class DlgItemBatchUseSystem
    {
        public static void RegisterUIEvent(this DlgItemBatchUse self)
        {
            self.View.E_ImageButtonButton.AddListener(self.OnImageButtonButton);
            self.View.E_PriceInputFieldInputField.onValueChanged.AddListener((string value) => { self.OnChange(value); });

            self.View.E_Btn_CostEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.PointerDown_Btn_CostNum(pdata as PointerEventData).Coroutine(); });
            self.View.E_Btn_CostEventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.PointerUp_Btn_CostNum(pdata as PointerEventData); });
            self.View.E_Btn_AddEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.PointerDown_Btn_AddNum(pdata as PointerEventData).Coroutine(); });
            self.View.E_Btn_AddEventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.PointerUp_Btn_AddNum(pdata as PointerEventData); });

            self.View.E_Btn_OpenButton.AddListener(self.OnBtn_OpenButton);
        }

        public static void ShowWindow(this DlgItemBatchUse self, Entity contextData = null)
        {
        }

        public static void OnInitUI(this DlgItemBatchUse self, ItemInfo bagInfo)
        {
            self.BagInfo = bagInfo;
            self.View.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
            self.UpdateNumber();
        }

        public static void OnImageButtonButton(this DlgItemBatchUse self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemBatchUse);
        }

        public static void OnChange(this DlgItemBatchUse self, string str)
        {
            int num = 0;
            try
            {
                num = int.Parse(str);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            if (num <= 0 || num > self.BagInfo.ItemNum)
            {
                return;
            }

            self.UseNum = num;
        }

        public static void OnAddNum(this DlgItemBatchUse self)
        {
            self.UseNum += 1;
            if (self.UseNum >= self.BagInfo.ItemNum)
            {
                self.UseNum = self.BagInfo.ItemNum;
            }

            self.View.E_PriceInputFieldInputField.SetTextWithoutNotify(self.UseNum.ToString());
        }

        public static void OnCostNum(this DlgItemBatchUse self)
        {
            self.UseNum -= 1;
            if (self.UseNum <= 1)
            {
                self.UseNum = 1;
            }

            self.View.E_PriceInputFieldInputField.SetTextWithoutNotify(self.UseNum.ToString());
        }

        public static async ETTask PointerDown_Btn_CostNum(this DlgItemBatchUse self, PointerEventData pdata)
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

                if (self.UseNum == 1)
                {
                    break;
                }

                await timerComponent.WaitFrameAsync();
            }
        }

        public static void PointerUp_Btn_CostNum(this DlgItemBatchUse self, PointerEventData pdata)
        {
            self.IsHoldDown = false;
        }

        public static async ETTask PointerDown_Btn_AddNum(this DlgItemBatchUse self, PointerEventData pdata)
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

                if (self.UseNum >= self.BagInfo.ItemNum)
                {
                    break;
                }

                await timerComponent.WaitFrameAsync();
            }
        }

        public static void PointerUp_Btn_AddNum(this DlgItemBatchUse self, PointerEventData pdata)
        {
            self.IsHoldDown = false;
        }

        public static void UpdateNumber(this DlgItemBatchUse self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            self.BagInfo = bagComponent.GetBagInfo(self.BagInfo.BagInfoID);
            self.View.E_Label_ItemNumText.text = self.BagInfo.ItemNum.ToString();
            self.View.E_PriceInputFieldInputField.text = self.BagInfo.ItemNum.ToString();
        }

        public static void OnBtn_OpenButton(this DlgItemBatchUse self)
        {
            if (self.UseNum > self.BagInfo.ItemNum || self.UseNum < 1)
            {
                return;
            }

            BagClientNetHelper.RequestUseItem(self.Root(), self.BagInfo, self.UseNum.ToString()).Coroutine();

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemBatchUse);
        }
    }
}