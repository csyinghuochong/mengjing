using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgChouKaProbExplain))]
    public static class DlgChouKaProbExplainSystem
    {
        public static void RegisterUIEvent(this DlgChouKaProbExplain self)
        {
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_Close);
        }

        public static void ShowWindow(this DlgChouKaProbExplain self, Entity contextData = null)
        {
        }

        public static void OnBtn_Close(this DlgChouKaProbExplain self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ChouKaProbExplain);
        }
    }
}