using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgYinSi))]
    public static class DlgYinSiSystem
    {
        public static void RegisterUIEvent(this DlgYinSi self)
        {
            self.View.E_TextButton_1Button.AddListener(() => { self.View.EG_YinSiXieYiRectTransform.gameObject.SetActive(true); });
            self.View.E_TextButton_2Button.AddListener(() => { self.View.EG_YongHuXieYiRectTransform.gameObject.SetActive(true); });

            self.View.E_TextYinSiText.gameObject.SetActive(false);
            UILoginHelper.ShowTextList(self.View.E_TextYinSiText.gameObject, GlobalHelp.GetPlatform());

            self.View.E_YongHuXieYiCloseButton.AddListener(() => { self.View.EG_YongHuXieYiRectTransform.gameObject.SetActive(false); });
            self.View.E_YinSiXieYiCloseButton.AddListener(() => { self.View.EG_YinSiXieYiRectTransform.gameObject.SetActive(false); });

            self.View.E_ButtonRefuseButton.AddListener(self.OnButtonRefuse);
            self.View.E_ButtonAgreeButton.AddListener(self.OnButtonAgree);
            self.View.E_ButtonCloseButton.AddListener(self.OnButtonRefuse);

            // GameObject.Find("Global").GetComponent<Init>().OnGetPermissionsHandler = self.onRequestPermissionsResult;

            self.AgreeNumber = 0;
        }

        public static void ShowWindow(this DlgYinSi self, Entity contextData = null)
        {
        }

        public static void OnButtonRefuse(this DlgYinSi self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "确认退出", "如您不同意用户协议和隐私协议，将无法进行游戏，请确认是否退出游戏？", () => { Application.Quit(); }, null).Coroutine();
        }

        public static void onRequestPermissionsResult(this DlgYinSi self, string permissons)
        {
            Log.Debug($"onRequestPermissionsResult: {permissons}");
            string[] values = permissons.Split('_');
            if (values[1] == "0")
            {
                Application.Quit();
                return;
            }

            self.AgreeNumber++;
            int needAgreeNumber = 2;
            if (self.AgreeNumber >= needAgreeNumber || permissons == "1_1")
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_YinSi);
            }
        }

        public static void OnButtonAgree(this DlgYinSi self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_YinSi);
            // GameObject.Find("Global").GetComponent<Init>().SetIsPermissionGranted();
        }
    }
}