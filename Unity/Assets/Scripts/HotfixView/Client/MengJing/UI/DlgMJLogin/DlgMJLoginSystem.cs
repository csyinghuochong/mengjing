using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof(DlgMJLogin))]
    public static class DlgMJLoginSystem
    {
        public static void RegisterUIEvent(this DlgMJLogin self)
        {
            self.View.E_LoginButton.AddListenerAsync(self.OnLoginButton);
            self.View.E_SelectBtnButton.AddListener(self.OnSelectBtnButton);

            self.View.E_TextButton_1Button.AddListener(() => { self.View.EG_YinSiXieYiRectTransform.gameObject.SetActive(true);  });
            self.View.E_TextButton_2Button.AddListener(() => { self.View.EG_YongHuXieYiRectTransform.gameObject.SetActive(true); });
            self.View.E_YinSiXieYiCloseButton.AddListener(() => { self.View.EG_YinSiXieYiRectTransform.gameObject.SetActive(false); });
            self.View.E_YongHuXieYiCloseButton.AddListener(() => { self.View.EG_YongHuXieYiRectTransform.gameObject.SetActive(false); });

            self.View.E_buttonAgeTipButton.AddListener(() => { self.View.EG_UIAgeTipRectTransform.gameObject.SetActive(true); });
            self.View.E_AgeTipCloseButton.AddListener(() => { self.View.EG_UIAgeTipRectTransform.gameObject.SetActive(false); });
            self.View.E_AgeTipClose_2Button.AddListener(() => { self.View.EG_UIAgeTipRectTransform.gameObject.SetActive(false); });

            CommonViewHelper.TargetFrameRate(60);
            //SettingData.AnimController = GlobalHelp.GetVersionMode() == 0 ? 0 : 1;

            GlobalComponent.Instance.MainCamera.GetComponent<Camera>().farClipPlane = 1000;
            GameObject.Find("Global").GetComponent<Init>().TogglePatchWindow(false);
            
            self.View.E_AccountInputField.text = PlayerPrefsHelp.GetString("MJ_Account");
            self.View.E_PasswordInputField.text = PlayerPrefsHelp.GetString("MJ_Password");

            SettingData.AnimController = self.View.E_AccountInputField.text != "18319670288" ? 0 : 1;
            
            self.View.E_AccountInputField.onValueChanged.AddListener((string text) => { self.CheckSensitiveWords_Account(); });
            self.View.E_PasswordInputField.onValueChanged.AddListener((string text) => { self.CheckSensitiveWords_Password(); });

            self.View.E_TextYinSiText.gameObject.SetActive(false);
            UILoginHelper.ShowTextList(self.View.E_TextYinSiText.gameObject, GlobalHelp.GetPlatform());
          
            self.RequestServerList().Coroutine();

            // if (string.IsNullOrEmpty(PlayerPrefsHelp.GetString("UIYinSi0627")))
            // {
            //     self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_YinSi).Coroutine();
            //     PlayerPrefsHelp.SetString("UIYinSi0627", "1");
            // }
            //self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_YinSi).Coroutine();
        }

        public static void ShowWindow(this DlgMJLogin self, Entity contextData = null)
        {
        }
        
        public static void CheckSensitiveWords_Account(this DlgMJLogin self)
        {
            string original = self.View.E_AccountInputField.text;
            string result = original.Replace(" ", "").Trim(); //.ToLower(); 
            self.View.E_AccountInputField.text = result;
        }
        
        public static void CheckSensitiveWords_Password(this DlgMJLogin self)
        {
            string original = self.View.E_PasswordInputField.text;
            string result = original.Replace(" ", "").Trim(); //.ToLower(); 
            self.View.E_PasswordInputField.text = result;
        }
        
        private static void CheckServerList(this DlgMJLogin self, List<ServerItem> serverItems, int versionMode)
        {
            for (int i = serverItems.Count - 1; i >= 0; i--)
            {
                if (versionMode == VersionMode.BanHao)
                {
                    if (!CommonHelp.IsBanHaoZone(serverItems[i].ServerId))
                    {
                        serverItems.RemoveAt(i);
                        continue;
                    }
                }
                if (versionMode == VersionMode.Beta)
                {
                    if (CommonHelp.IsBanHaoZone(serverItems[i].ServerId))
                    {
                        serverItems.RemoveAt(i);
                    }
                }
                // string[] serverdomain = serverItems[i].ServerIp.Split(':');
                // if (!serverdomain[0].Contains("127")
                //     && !serverdomain[0].Contains("192")
                //     && !serverdomain[0].Contains("39"))
                // {
                //     IPAddress[] xxc = Dns.GetHostEntry(serverdomain[0]).AddressList;
                //     serverItems[i].ServerIp = $"{xxc[0]}:{serverdomain[1]}";
                // }
            }
        }

        public static async ETTask RequestServerList(this DlgMJLogin self)
        {
            //获取服务器列表
            R2C_ServerList r2CServerList = await LoginHelper.GetServerList(self.Root(), GlobalHelp.GetVersionMode());
            if (r2CServerList == null || r2CServerList.ServerItems.Count == 0)
            {
                return;
            }

            self.CheckServerList(r2CServerList.ServerItems, GlobalHelp.GetVersionMode());
            ServerItem serverItem = r2CServerList.ServerItems[r2CServerList.ServerItems.Count - 1];
            PlayerInfoComponent playerInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();
            playerInfoComponent.ServerItem = serverItem;
            playerInfoComponent.AllServerList = r2CServerList.ServerItems;

            int myserver = PlayerPrefsHelp.GetInt(PlayerPrefsHelp.MyServerID);
            myserver = playerInfoComponent.GetNewServerId(myserver);

            for (int i = 0; i < r2CServerList.ServerItems.Count; i++)
            {
                if (r2CServerList.ServerItems[i].ServerId == myserver)
                {
                    serverItem = r2CServerList.ServerItems[i];
                    break;
                }
            }

            self.OnSelectServer(serverItem);
            //如果之前登陆过游戏，记录一下服务器id. serverItem = ServerHelper.GetServerItem(oldid);
        }

        public static void OnLoop(this DlgMJLogin self, Transform transform, int index)
        {
            
        }

        public static void HideLoadingView(this DlgMJLogin self)
        {
            self.View.EG_LoadingRectTransform.gameObject.SetActive(false);
        }

        public static async ETTask OnLoginButton(this DlgMJLogin self)
        {
            if (TimeHelper.ServerNow() - self.LastLoginTime < 3000)
            {
                return;
            }
            if (self.ServerInfo == null)
            {
                self.RequestServerList().Coroutine();
                return;
            }

            self.LastLoginTime = TimeHelper.ServerNow();
            PlayerInfoComponent playerInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();
            playerInfoComponent.ServerItem = self.ServerInfo;
            playerInfoComponent.Account = self.View.E_AccountInputField.text.ToLower();
            playerInfoComponent.Password = self.View.E_PasswordInputField.text.ToLower();
            playerInfoComponent.VersionMode = GlobalHelp.GetVersionMode();
            self.View.EG_LoadingRectTransform.gameObject.SetActive(true);

            PlayerPrefsHelp.SetInt(PlayerPrefsHelp.MyServerID, self.ServerInfo.ServerId);
            PlayerPrefsHelp.SetOldServerIds(self.ServerInfo.ServerId);
            PlayerPrefsHelp.SetString("MJ_Account", self.View.E_AccountInputField.text);
            PlayerPrefsHelp.SetString("MJ_Password", self.View.E_PasswordInputField.text);

            int error =  await LoginHelper.Login(self.Root(), self.View.E_AccountInputField.text, self.View.E_PasswordInputField.text, 0, GlobalHelp.GetVersionMode());
            Log.Debug($"LoginHelper.Login:  {error}");
            if (error  != ErrorCode.ERR_Success &&  !self.IsDisposed)
            {
                self.HideLoadingView();
            }
        }

        public static void OnSelectServer(this DlgMJLogin self, ServerItem serverId)
        {
            self.ServerInfo = serverId;
            self.View.E_SelectServerNameText.text = serverId.ServerName;
        }

        private static void OnSelectBtnButton(this DlgMJLogin self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_SelectServer).Coroutine();
        }
    }
}
