using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_ChengJiuReward))]
    [FriendOf(typeof (DlgChengJiu))]
    public static class DlgChengJiuSystem
    {
        public static void RegisterUIEvent(this DlgChengJiu self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgChengJiu self, Entity contextData = null)
        {
            self.View.E_RewardToggle.IsSelected(true);

            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.ShowWindow(WindowID.WindowID_HuoBiSet);
            uiComponent.GetDlgLogic<DlgHuoBiSet>().AddCloseEvent(self.OnCloseButton);
        }

        private static void OnFunctionSetBtn(this DlgChengJiu self, int index)
        {
            UICommonHelper.SetToggleShow(self.View.E_RewardToggle.gameObject, index == 0);

            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_ChengJiuReward.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }

        private static void OnCloseButton(this DlgChengJiu self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

            uiComponent.CloseWindow(WindowID.WindowID_Task);
        }
    }
}