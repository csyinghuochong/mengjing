using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_SettingGame))]
    [FriendOf(typeof (ES_SettingTitle))]
    [FriendOf(typeof (DlgSetting))]
    public static class DlgSettingSystem
    {
        public static void RegisterUIEvent(this DlgSetting self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgSetting self, Entity contextData = null)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.ShowWindow(WindowID.WindowID_HuoBiSet);
            uiComponent.GetDlgLogic<DlgHuoBiSet>().AddCloseEvent(self.OnCloseButton);

            self.View.E_1Toggle.IsSelected(true);
        }

        private static void OnCloseButton(this DlgSetting self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

            self.View.ES_SettingGame.OnBeforeClose();
            uiComponent.CloseWindow(WindowID.WindowID_Setting);
        }

        private static void OnFunctionSetBtn(this DlgSetting self, int index)
        {
            UICommonHelper.SetToggleShow(self.View.E_1Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_2Toggle.gameObject, index == 1);
            UICommonHelper.SetToggleShow(self.View.E_3Toggle.gameObject, index == 2);
            UICommonHelper.SetToggleShow(self.View.E_4Toggle.gameObject, index == 3);

            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_SettingGame.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_SettingTitle.uiTransform.gameObject.SetActive(true);
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }
    }
}