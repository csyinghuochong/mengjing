using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgPhoneCode))]
    public static class DlgPhoneCodeSystem
    {
        public static void RegisterUIEvent(this DlgPhoneCode self)
        {
            self.View.E_ImageCloseButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PhoneCode); });
            self.View.E_ButtonCommitCodeButton.AddListener(self.OnButtonCommitCode);
            self.View.E_ButtonGetCodeButton.AddListener(self.OnButtonGetCode);
        }

        public static void ShowWindow(this DlgPhoneCode self, Entity contextData = null)
        {
            self.View.EG_YanZhengRectTransform.gameObject.SetActive(false);
            self.View.EG_SendYanzhengRectTransform.gameObject.SetActive(false);

            // GameObject.Find("Global").GetComponent<SMSSDemo>().CommitCodeSucessHandler = (string text) => { self.OnCommitCodeHandler(text); };
        }

        public static void OnButtonGetCode(this DlgPhoneCode self)
        {
            string phoneNum = self.View.E_PhoneNumberInputField.text;
            // GlobalHelp.OnButtonGetCode(phoneNum);
            self.View.E_TextYanzhengText.text = $"已向手机号{phoneNum}发送短信验证";
            self.View.EG_SendYanzhengRectTransform.gameObject.SetActive(false);
            self.View.EG_YanZhengRectTransform.gameObject.SetActive(true);
        }

        public static void OnButtonCommitCode(this DlgPhoneCode self)
        {
            string phoneNum = self.View.E_PhoneNumberInputField.text;
            string code = self.View.E_TextPhoneCodeInputField.text;

#if UNITY_EDITOR
            self.OnCommitCodeHandler(phoneNum);
#else
            //GlobalHelp.OnButtonCommbitCode(self.OnCommitCodeHandler, phoneNum,code);
#endif
        }

        public static void OnSendYanzheng(this DlgPhoneCode self)
        {
            string phoneNum = self.View.E_PhoneNumberInputField.text;
            // GlobalHelp.OnButtonGetCode(phoneNum);
            self.View.E_TextYanzhengText.text = $"已向手机号{phoneNum}发送短信验证";
            self.View.EG_SendYanzhengRectTransform.gameObject.SetActive(false);
            self.View.EG_YanZhengRectTransform.gameObject.SetActive(true);
        }

        public static void OnCommitCodeHandler(this DlgPhoneCode self, string phone)
        {
            Log.Debug($"OnCommitCodeHandler : {phone}");

            self.OnRquestBingPhone(phone).Coroutine();

            FlyTipComponent.Instance.ShowFlyTipDi("功能暂未开放");
        }

        public static async ETTask OnRquestBingPhone(this DlgPhoneCode self, string phone)
        {
            // IPAddress[] xxc = Dns.GetHostEntry(ServerHelper.GetLogicServer(!GlobalHelp.IsOutNetMode, GlobalHelp.VersionMode)).AddressList;
            // //走的中心服
            // string address = GlobalHelp.IsOutNetMode? $"{xxc[0]}:{LoginHelper.GetAccountCenterPort(GlobalHelp.VersionMode)}"
            //         : $"127.0.0.1:{LoginHelper.GetAccountCenterPort(GlobalHelp.VersionMode)}";
            // AccountInfoComponent accountInfoComponent = self.ZoneScene().GetComponent<AccountInfoComponent>();
            // Scene zoneScene = self.ZoneScene();
            // NetKcpComponent netKcpComponent = zoneScene.GetComponent<NetKcpComponent>();
            // Session session = netKcpComponent.Create(NetworkHelper.ToIPEndPoint(address));
            // {
            //     Center2C_PhoneBinging m2C_Reload = await session.Call(new C2Center_PhoneBinging()
            //     {
            //         Account = accountInfoComponent.Account, AccountId = accountInfoComponent.AccountId, PhoneNumber = phone,
            //     }) as Center2C_PhoneBinging;
            // }
            // session.Dispose();
            await ETTask.CompletedTask;
        }
    }
}