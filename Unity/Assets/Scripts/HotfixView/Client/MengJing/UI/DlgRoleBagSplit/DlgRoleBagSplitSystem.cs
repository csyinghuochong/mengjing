using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgRoleBagSplit))]
    public static class DlgRoleBagSplitSystem
    {
        public static void RegisterUIEvent(this DlgRoleBagSplit self)
        {
            self.View.E_AddNumButton.AddListener(self.OnAddNumButton);
            self.View.E_NumInputField.onValueChanged.AddListener(self.OnOnNumInputField);
            self.View.E_CostNumButton.AddListener(self.OnCostNumButton);
            self.View.E_CloseButton.AddListener(self.OnCloseButton);
            self.View.E_SplitButton.AddListenerAsync(self.OnSplitButton);
        }

        public static void ShowWindow(this DlgRoleBagSplit self, Entity contextData = null)
        {
        }

        public static void Init(this DlgRoleBagSplit self, BagInfo bagInfo)
        {
            self.BagInfo = bagInfo;
            self.Num = 1;
            self.View.ES_CommonItem.Refresh(bagInfo, ItemOperateEnum.None);
            self.View.E_NumInputField.text = self.Num.ToString();
        }

        private static void OnAddNumButton(this DlgRoleBagSplit self)
        {
            if (self.Num >= self.BagInfo.ItemNum)
            {
                return;
            }

            self.Num++;
            self.View.E_NumInputField.text = self.Num.ToString();
        }

        private static void OnOnNumInputField(this DlgRoleBagSplit self, string text)
        {
            long num = 0;
            if (long.TryParse(text, out num))
            {
                if (num > 0 && num <= self.BagInfo.ItemNum)
                {
                    self.Num = num;
                }
            }
        }

        private static void OnCostNumButton(this DlgRoleBagSplit self)
        {
            if (self.Num <= 1)
            {
                return;
            }

            self.Num--;
            self.View.E_NumInputField.text = self.Num.ToString();
        }

        private static void OnCloseButton(this DlgRoleBagSplit self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_RoleBagSplit);
        }

        private static async ETTask OnSplitButton(this DlgRoleBagSplit self)
        {
            FlyTipComponent flyTipComponent = self.Root().GetComponent<FlyTipComponent>();
            int errorCode = await BagClientNetHelper.RequestSplitItem(self.Root(), self.BagInfo, (int)self.Num);
            if (errorCode == ErrorCode.ERR_Success)
            {
                flyTipComponent.SpawnFlyTipDi("拆分完成!");
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemSellTip);
        }
    }
}