using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
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
            self.View.E_RegisterButton.AddListenerAsync(self.OnRegisterButton);
        }

        public static void ShowWindow(this DlgRegister self, Entity contextData = null)
        {
        }

        private static void OnButtonCloseButton(this DlgRegister self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Register);
        }

        private static async ETTask OnRegisterButton(this DlgRegister self)
        {
            if (TimeHelper.ServerNow() - self.LastRegisterTime < 1000)
            {
                return;
            }

            string account = self.View.E_AccountInputField.text;
            string password = self.View.E_PasswordInputField.text;
            string confirmPassword = self.View.E_ConfirmPasswordInputField.text;

            if (password != confirmPassword)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("2次输入密码不一致");
                return;
            }

            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password))
            {
                FlyTipComponent.Instance.ShowFlyTipDi("账号或密码为空");
                return;
            }

            if (!Regex.IsMatch(account.Trim(), @"^[A-Za-z0-9_]+$")) //只能是字母/数字/_
            {
                FlyTipComponent.Instance.ShowFlyTipDi("账号格式错误");
                return;
            }

            if (!Regex.IsMatch(password, @"^[A-Za-z0-9@#]+$")) //只能是字母/数字/@/#
            {
                FlyTipComponent.Instance.ShowFlyTipDi("密码格式错误");
                return;
            }

            self.LastRegisterTime = TimeHelper.ServerNow();

            int errCode = await LoginHelper.Register(self.Root(), account, password, GlobalHelp.GetVersionMode());

            if (errCode == ErrorCode.ERR_Success)
            {
                EventSystem.Instance.Publish(self.Root(), new CommonPopup() { HintText = "创建成功！" });
            }
            else
            {
                string errstr = string.Empty;
                ErrorViewData.ErrorHints.TryGetValue(errCode, out errstr);
                EventSystem.Instance.Publish(self.Root(), new CommonPopup() { HintText = errstr });
            }
        }
    }
}