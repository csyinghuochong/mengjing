using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgChouKaWarehouse))]
    public static class DlgChouKaWarehouseSystem
    {
        public static void RegisterUIEvent(this DlgChouKaWarehouse self)
        {
        }

        public static void ShowWindow(this DlgChouKaWarehouse self, Entity contextData = null)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.ShowWindow(WindowID.WindowID_HuoBiSet);
            uiComponent.GetDlgLogic<DlgHuoBiSet>().AddCloseEvent(self.OnCloseButton);
        }

        private static void OnCloseButton(this DlgChouKaWarehouse self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

            uiComponent.CloseWindow(WindowID.WindowID_ChouKaWarehouse);
        }
    }
}