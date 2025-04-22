using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace ET.Client
{
    [FriendOf(typeof(DlgMJLogin))]
    public static class DlgMJLoginSystem
    {
        public static void RegisterUIEvent(this DlgMJLogin self)
        {
            self.View.E_LoginButton.AddListenerAsync(self.OnLoginButton);
            self.View.E_SelectBtnButton.AddListener(self.OnSelectBtnButton);

            self.View.E_TextButton_1Button.AddListener(() => { self.View.EG_YongHuXieYiRectTransform.gameObject.SetActive(true);  });
            self.View.E_TextButton_2Button.AddListener(() => { self.View.EG_YinSiXieYiRectTransform.gameObject.SetActive(true); });
            self.View.E_YinSiXieYiCloseButton.AddListener(() => { self.View.EG_YinSiXieYiRectTransform.gameObject.SetActive(false); });
            self.View.E_YongHuXieYiCloseButton.AddListener(() => { self.View.EG_YongHuXieYiRectTransform.gameObject.SetActive(false); });
            
            Application.targetFrameRate = 60;
            GameObject.Find("Global").GetComponent<Init>().TogglePatchWindow(false);
            
            self.View.E_AccountInputField.text = PlayerPrefsHelp.GetString("MJ_Account");
            self.View.E_PasswordInputField.text = PlayerPrefsHelp.GetString("MJ_Password");

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
        
        

        public static async ETTask RequestServerList(this DlgMJLogin self)
        {
            //获取服务器列表
            R2C_ServerList r2CServerList = await LoginHelper.GetServerList(self.Root(), GlobalHelp.GetVersionMode());
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
            if (self.ServerInfo == null)
            {
                return;
            }

            PlayerInfoComponent playerInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();
            playerInfoComponent.ServerItem = self.ServerInfo;
            playerInfoComponent.Account = self.View.E_AccountInputField.text;
            playerInfoComponent.Password = self.View.E_PasswordInputField.text;
            playerInfoComponent.VersionMode = GlobalHelp.GetVersionMode();
            self.View.EG_LoadingRectTransform.gameObject.SetActive(true);

            PlayerPrefsHelp.SetInt(PlayerPrefsHelp.MyServerID, self.ServerInfo.ServerId);
            PlayerPrefsHelp.SetOldServerIds(self.ServerInfo.ServerId);
            PlayerPrefsHelp.SetString("MJ_Account", self.View.E_AccountInputField.text);
            PlayerPrefsHelp.SetString("MJ_Password", self.View.E_PasswordInputField.text);

            await LoginHelper.Login(self.Root(), self.View.E_AccountInputField.text, self.View.E_PasswordInputField.text, 0, GlobalHelp.GetVersionMode());
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
