using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgFangChengMiTip))]
    public static class DlgFangChengMiTipSystem
    {
        public static void RegisterUIEvent(this DlgFangChengMiTip self)
        {
        }

        public static void ShowWindow(this DlgFangChengMiTip self, Entity contextData = null)
        {
        }

        private static void OnCloseButton(this DlgFangChengMiTip self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_FangChengMiTip);
        }

        public static void InitData(this DlgFangChengMiTip self, string title, string content, Action okhandle)
        {
            if (!string.IsNullOrEmpty(title))
            {
                self.View.E_TitleText.text = title;
            }

            self.View.E_ContentText.text = content;
            self.View.E_TrueButton.AddListener(() =>
            {
                okhandle?.Invoke();
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_FangChengMiTip);
            });
        }
    }
}