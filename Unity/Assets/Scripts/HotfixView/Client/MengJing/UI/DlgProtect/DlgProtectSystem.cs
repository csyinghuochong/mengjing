using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgProtect))]
    public static class DlgProtectSystem
    {
        public static void RegisterUIEvent(this DlgProtect self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgProtect self, Entity contextData = null)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.ShowWindow(WindowID.WindowID_HuoBiSet);
            uiComponent.GetDlgLogic<DlgHuoBiSet>().AddCloseEvent(self.OnCloseButton);

            self.View.E_0Toggle.IsSelected(true);
        }

        private static void OnCloseButton(this DlgProtect self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

            uiComponent.CloseWindow(WindowID.WindowID_Protect);
        }

        private static void OnFunctionSetBtn(this DlgProtect self, int index)
        {
            UICommonHelper.SetToggleShow(self.View.E_0Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_1Toggle.gameObject, index == 1);

            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    break;
                case 1:
                    break;
            }
        }
    }
}