using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgMJLogin))]
    public static class DlgMJLoginSystem
    {
        public static void RegisterUIEvent(this DlgMJLogin self)
        {
            self.View.E_LoginButton.AddListener(self.OnLogin);
            self.View.E_SelectBtnButton.AddListener(self.OnSelectServerList);
        }

        public static void ShowWindow(this DlgMJLogin self, Entity contextData = null)
        {
            Application.targetFrameRate = 60;
            GameObject.Find("Global").GetComponent<Init>().HidePatchWindow();

            self.AddUIScrollItems(ref self.Dictionary, 100);
            self.View.E_AccountInputField.text = PlayerPrefsHelp.GetString("MJ_Account");
            self.View.E_PasswordInputField.text = PlayerPrefsHelp.GetString("MJ_Password");

            self.RequestServerList().Coroutine();
        }

        public static async ETTask RequestServerList(this DlgMJLogin self)
        {
            //获取服务器列表
            R2C_ServerList r2CServerList = await LoginHelper.GetServerList(self.Root(), GlobalHelp.GetVersionMode());

            Debug.Log($"RequestServerList:  {r2CServerList}");

            ServerItem serverItem = r2CServerList.ServerItems[r2CServerList.ServerItems.Count - 1];

            Debug.Log($"RequestServerList2:  {serverItem}");

            int myserver = PlayerPrefsHelp.GetInt(PlayerPrefsHelp.MyServerID);
            myserver = ServerHelper.GetNewServerId(myserver);

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
            PlayerComponent playerComponent = self.Root().GetComponent<PlayerComponent>();
            playerComponent.ServerItem = serverItem;
            playerComponent.AllServerList = r2CServerList.ServerItems;
        }

        public static void OnLoop(this DlgMJLogin self, Transform transform, int index)
        {
            Scroll_Item_test test = self.Dictionary[index].BindTrans(transform);
            test.ELabel_ContentText.text = index.ToString();
        }

        public static void OnLogin(this DlgMJLogin self)
        {
            PlayerComponent playerComponent = self.Root().GetComponent<PlayerComponent>();
            playerComponent.ServerItem.ServerId = self.ServerInfo.ServerId;

            LoginHelper.Login(self.Root(),
                self.View.E_AccountInputField.text,
                self.View.E_PasswordInputField.text).Coroutine();

            PlayerPrefsHelp.SetInt(PlayerPrefsHelp.MyServerID, self.ServerInfo.ServerId);
            PlayerPrefsHelp.SetString("MJ_Account", self.View.E_AccountInputField.text);
            PlayerPrefsHelp.SetString("MJ_Password", self.View.E_PasswordInputField.text);
        }

        public static void OnSelectServer(this DlgMJLogin self, ServerItem serverId)
        {
            self.ServerInfo = serverId;
            self.View.E_SelectServerNameText.text = serverId.ServerName;
        }

        private static void OnSelectServerList(this DlgMJLogin self)
        {
            Log.Info("点击显示服务器列表...");
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_SelectServer).Coroutine();
        }
    }
}