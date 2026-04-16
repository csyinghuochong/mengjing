using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgRegister))]
    public static class DlgRegisterSystem
    {
        public static void RegisterUIEvent(this DlgRegister self)
        {
            self.View.E_ButtonCloseButton.AddListener(self.OnButtonCloseButton);
        }

        public static void ShowWindow(this DlgRegister self, Entity contextData = null)
        {
        }

        public static void OnButtonCloseButton(this DlgRegister self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Register);
        }
    }
}