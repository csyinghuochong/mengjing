using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgHuoBiSet))]
    public static class DlgHuoBiSetSystem
    {
        public static void RegisterUIEvent(this DlgHuoBiSet self)
        {
        }

        public static void ShowWindow(this DlgHuoBiSet self, Entity contextData = null)
        {
        }

        public static void AddCloseEvent(this DlgHuoBiSet self, UnityAction clickEventHandler)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            self.View.E_CloseButton.AddListener(() =>
            {
                clickEventHandler();
                uiComponent.HideWindow(WindowID.WindowID_HuoBiSet);
            });
            self.View.E_Close2Button.AddListener(() =>
            {
                clickEventHandler();
                uiComponent.HideWindow(WindowID.WindowID_HuoBiSet);
            });
        }
    }
}