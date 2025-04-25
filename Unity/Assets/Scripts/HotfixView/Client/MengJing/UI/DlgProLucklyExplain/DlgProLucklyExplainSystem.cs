using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgProLucklyExplain))]
    public static class DlgProLucklyExplainSystem
    {
        public static void RegisterUIEvent(this DlgProLucklyExplain self)
        {
            self.View.E_CloseButton.AddListener(self.OnCloseButton);
        }

        public static void ShowWindow(this DlgProLucklyExplain self, Entity contextData = null)
        {
        }

        private static void OnCloseButton(this DlgProLucklyExplain self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ProLucklyExplain);
        }
    }
}