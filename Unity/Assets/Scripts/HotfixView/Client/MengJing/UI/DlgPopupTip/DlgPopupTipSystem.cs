using System;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgPopupTip))]
    public static class DlgPopupTipSystem
    {
        public static void RegisterUIEvent(this DlgPopupTip self)
        {
            self.View.E_CloseButton.AddListener(self.OnCloseButton);
            self.View.E_TrueButton.AddListener(self.OnTrueButton);
            self.View.E_FalseButton.AddListener(self.OnFalseButton);
        }

        public static void ShowWindow(this DlgPopupTip self, Entity contextData = null)
        {
        }

        private static void OnCloseButton(this DlgPopupTip self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PopupTip);
        }

        public static void InitData(this DlgPopupTip self, string title, string content, Action okhandle, Action cancelHandle, string okButtonText,
        string cancelButtonText)
        {
            if (!string.IsNullOrEmpty(title))
            {
                self.View.E_TitleText.text = title;
            }

            if (!string.IsNullOrEmpty(okButtonText))
            {
                self.View.E_TrueButton.transform.Find("Text").GetComponent<Text>().text = okButtonText;
            }

            if (!string.IsNullOrEmpty(cancelButtonText))
            {
                self.View.E_FalseButton.transform.Find("Text").GetComponent<Text>().text = cancelButtonText;
            }

            self.View.E_ContentText.text = content;
            self.View.E_TrueButton.AddListener(() =>
            {
                okhandle?.Invoke();
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PopupTip);
            });
            self.View.E_FalseButton.AddListener(() =>
            {
                cancelHandle?.Invoke();
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PopupTip);
            });
        }
        public static void OnTrueButton(this DlgPopupTip self)
        {
        }
        public static void OnFalseButton(this DlgPopupTip self)
        {
        }
    }
}
