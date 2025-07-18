using System;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [FriendOf(typeof(DlgItemExpBox))]
    public static class DlgItemExpBoxSystem
    {
        public static void RegisterUIEvent(this DlgItemExpBox self)
        {
            self.View.E_ImageButtonButton.AddListener(self.OnImageButtonButton);
            self.View.E_Btn_ZuanShiOpenButton.AddListener(() => { self.OnButtonOpen(1).Coroutine(); });
            self.View.E_Btn_MianFeiOpenButton.AddListener(() => { self.OnButtonOpen(2).Coroutine(); });
            self.View.E_PriceInputFieldInputField.onValueChanged.AddListener((string value) => { self.OnChange(value); });

            self.View.E_Btn_CostEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.PointerDown_Btn_CostNum(pdata as PointerEventData).Coroutine(); });
            self.View.E_Btn_CostEventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.PointerUp_Btn_CostNum(pdata as PointerEventData); });
            self.View.E_Btn_AddEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.PointerDown_Btn_AddNum(pdata as PointerEventData).Coroutine(); });
            self.View.E_Btn_AddEventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.PointerUp_Btn_AddNum(pdata as PointerEventData); });
        }

        public static void ShowWindow(this DlgItemExpBox self, Entity contextData = null)
        {
        }

        public static void OnInitUI(this DlgItemExpBox self, ItemInfo bagInfo)
        {
            self.BagInfo = bagInfo;
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            string[] expInfos = itemConfig.ItemUsePar.Split('@');
            self.Price = int.Parse(expInfos[0]);
            self.View.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
            self.UpdateNumber();
            self.worldLv().Coroutine();
        }

        public static void OnAddNum(this DlgItemExpBox self)
        {
            self.UseNum += 1;
            if (self.UseNum >= self.BagInfo.ItemNum)
            {
                self.UseNum = self.BagInfo.ItemNum;
            }

            self.View.E_PriceInputFieldInputField.SetTextWithoutNotify(self.UseNum.ToString());
            self.View.E_Text_ZuanShiText.text = (self.UseNum * self.Price).ToString();
        }

        public static void OnCostNum(this DlgItemExpBox self)
        {
            self.UseNum -= 1;
            if (self.UseNum <= 1)
            {
                self.UseNum = 1;
            }

            self.View.E_PriceInputFieldInputField.SetTextWithoutNotify(self.UseNum.ToString());
            self.View.E_Text_ZuanShiText.text = (self.UseNum * self.Price).ToString();
        }

        public static async ETTask PointerDown_Btn_CostNum(this DlgItemExpBox self, PointerEventData pdata)
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

        public static void PointerUp_Btn_CostNum(this DlgItemExpBox self, PointerEventData pdata)
        {
            self.IsHoldDown = false;
        }

        public static async ETTask PointerDown_Btn_AddNum(this DlgItemExpBox self, PointerEventData pdata)
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

        public static void PointerUp_Btn_AddNum(this DlgItemExpBox self, PointerEventData pdata)
        {
            self.IsHoldDown = false;
        }

        public static async ETTask worldLv(this DlgItemExpBox self)
        {
            R2C_WorldLvResponse response = await UserInfoNetHelper.WorldLv(self.Root());
            if (self.IsDisposed)
            {
                return;
            }

            RankingInfo rankingInfo = response.ServerInfo.RankingInfo;

            if (rankingInfo != null)
            {
                self.WorldPlayerLv = rankingInfo.PlayerLv;
            }
        }

        public static long UpdateNumber(this DlgItemExpBox self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            self.BagInfo = bagComponent.GetBagInfo(self.BagInfo.BagInfoID);
            if (self.BagInfo == null)
            {
                return 0;
            }

            self.UseNum = self.BagInfo.ItemNum;
            self.View.E_Label_ItemNumText.text = self.BagInfo.ItemNum.ToString();
            self.View.E_PriceInputFieldInputField.text = self.BagInfo.ItemNum.ToString();
            self.View.E_Text_ZuanShiText.text = (self.UseNum * self.Price).ToString();
            return self.BagInfo.ItemNum;
        }

        public static void OnChange(this DlgItemExpBox self, string str)
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
            self.View.E_Text_ZuanShiText.text = (self.UseNum * self.Price).ToString();
        }

        /// <summary>
        /// 1 钻石开启 2免费开启
        /// </summary>
        public static async ETTask OnButtonOpen(this DlgItemExpBox self, int openType)
        {
            if (self.UseNum > self.BagInfo.ItemNum || self.UseNum <= 0)
            {
                return;
            }

            // AccountInfoComponent accountInfoComponent = self.ZoneScene().GetComponent<AccountInfoComponent>();
            // if (ServerHelper.GetOpenServerDay(!GlobalHelp.IsOutNetMode, accountInfoComponent.ServerId) <= 1)
            // {
            //     //开区第一天
            //     if (self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv + 3 > self.WorldPlayerLv)
            //     {
            //         FlyTipComponent.Instance.ShowFlyTip($"等级第一的玩家为:{self.WorldPlayerLv}级，开服第一天低于第一等级玩家3级内才可使用!");
            //         return;
            //     }
            // }

            if (openType == 1 && self.Root().GetComponent<UserInfoComponentC>().UserInfo.Diamond < self.UseNum * self.Price)
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_DiamondNotEnoughError);
                return;
            }

            long instanceid = self.InstanceId;
            await BagClientNetHelper.RequestUseItem(self.Root(), self.BagInfo, openType + ";" + self.UseNum);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            if (self.UpdateNumber() <= 0)
            {
                self.OnImageButtonButton();
            }
        }

        public static void OnImageButtonButton(this DlgItemExpBox self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemExpBox);
        }
    }
}
