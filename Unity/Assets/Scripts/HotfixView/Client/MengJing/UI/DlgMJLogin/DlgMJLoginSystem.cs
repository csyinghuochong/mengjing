using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgMJLogin))]
    public static class DlgMJLoginSystem
    {
        public static void RegisterUIEvent(this DlgMJLogin self)
        {
            self.View.E_LoginButton.AddListener(self.OnLogin);
        }

        public static void ShowWindow(this DlgMJLogin self, Entity contextData = null)
        {
            self.AddUIScrollItems(ref self.Dictionary, 100);
            self.View.E_AccountInputField.text = PlayerPrefs.GetString("MJ_Account");
            self.View.E_PasswordInputField.text = PlayerPrefs.GetString("MJ_Password");
        }

        public static void OnLoop(this DlgMJLogin self, Transform transform, int index)
        {
            Scroll_Item_test test = self.Dictionary[index].BindTrans(transform);
            test.ELabel_ContentText.text = index.ToString();
        }

        public static void OnLogin(this DlgMJLogin self)
        {
            LoginHelper.Login(self.Root(),
                self.View.E_AccountInputField.text,
                self.View.E_PasswordInputField.text).Coroutine();
            PlayerPrefs.SetString("MJ_Account", self.View.E_AccountInputField.text);
            PlayerPrefs.SetString("MJ_Password", self.View.E_PasswordInputField.text);
        }
    }
}