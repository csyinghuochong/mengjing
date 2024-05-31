using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_PaiMaiShop))]
    [FriendOf(typeof (DlgPaiMai))]
    public static class DlgPaiMaiSystem
    {
        public static void RegisterUIEvent(this DlgPaiMai self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgPaiMai self, Entity contextData = null)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.ShowWindow(WindowID.WindowID_HuoBiSet);
            uiComponent.GetDlgLogic<DlgHuoBiSet>().AddCloseEvent(self.OnCloseButton);
        }

        private static void OnCloseButton(this DlgPaiMai self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

            uiComponent.CloseWindow(WindowID.WindowID_PaiMai);
        }

        private static void OnFunctionSetBtn(this DlgPaiMai self, int index)
        {
            UICommonHelper.SetToggleShow(self.View.E_1Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_2Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_3Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_4Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_5Toggle.gameObject, index == 0);

            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_PaiMaiShop.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }
    }
}