using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_ShouJiList))]
    [FriendOf(typeof (ES_ShouJiTreasure))]
    [FriendOf(typeof (DlgShouJi))]
    public static class DlgShouJiSystem
    {
        public static void RegisterUIEvent(this DlgShouJi self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgShouJi self, Entity contextData = null)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.ShowWindow(WindowID.WindowID_HuoBiSet);
            uiComponent.GetDlgLogic<DlgHuoBiSet>().AddCloseEvent(self.OnCloseButton);

            self.View.E_1Toggle.IsSelected(true);
        }

        private static void OnCloseButton(this DlgShouJi self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

            uiComponent.CloseWindow(WindowID.WindowID_ShouJi);
        }

        private static void OnFunctionSetBtn(this DlgShouJi self, int index)
        {
            UICommonHelper.SetToggleShow(self.View.E_1Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_2Toggle.gameObject, index == 1);

            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_ShouJiList.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_ShouJiTreasure.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }

        public static void OnShouJiTreasure(this DlgShouJi self)
        {
            self.View.ES_ShouJiTreasure.OnShouJiTreasure();
        }
    }
}