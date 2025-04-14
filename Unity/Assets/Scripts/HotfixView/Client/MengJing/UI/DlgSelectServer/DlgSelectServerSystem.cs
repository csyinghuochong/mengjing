using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_SelectServerItem))]
    [FriendOf(typeof(DlgSelectServer))]
    public static class DlgSelectServerSystem
    {
        public static void RegisterUIEvent(this DlgSelectServer self)
        {
            self.View.E_SelectServerItem1LoopVerticalScrollRect.AddItemRefreshListener(self.OnSelectServerItems1Refresh);
            self.View.E_SelectServerItem2LoopVerticalScrollRect.AddItemRefreshListener(self.OnSelectServerItems2Refresh);

            self.View.E_ButtonCloseButton.AddListener(self.OnButtonCloseButton);
            
            self.OnUpdateServerList();
        }

        public static void ShowWindow(this DlgSelectServer self, Entity contextData = null)
        {
        }

        private static void OnSelectServerItems1Refresh(this DlgSelectServer self, Transform transform, int index)
        {
            foreach (Scroll_Item_SelectServerItem item in self.ScrollItemSelectServerItems1.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_SelectServerItem scrollItemSelectServerItem = self.ScrollItemSelectServerItems1[index].BindTrans(transform);
            scrollItemSelectServerItem.SetClickHandler((ServerItem serverId) => { self.OnClickServerItem(serverId); });
            scrollItemSelectServerItem.OnUpdateData(self.AllserverList[index], index);
        }

        private static void OnSelectServerItems2Refresh(this DlgSelectServer self, Transform transform, int index)
        {
            foreach (Scroll_Item_SelectServerItem item in self.ScrollItemSelectServerItems2.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_SelectServerItem scrollItemSelectServerItem = self.ScrollItemSelectServerItems2[index].BindTrans(transform);
            scrollItemSelectServerItem.SetClickHandler((ServerItem serverId) => { self.OnClickServerItem(serverId); });
            scrollItemSelectServerItem.OnUpdateData(self.MyServers[index], -1);
        }

        public static void OnUpdateServerList(this DlgSelectServer self)
        {
            PlayerInfoComponent playerInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();

            List<ServerItem> allserverList = playerInfoComponent.AllServerList;

            // 暂时不区分平台
            // int platform = GlobalHelp.GetPlatform();
            // string lastAccount = string.Empty;
            // string lastloginType = PlayerPrefsHelp.GetString(PlayerPrefsHelp.LastLoginType);
            // if (!string.IsNullOrEmpty(lastloginType))
            // {
            //     lastAccount = PlayerPrefsHelp.GetString(PlayerPrefsHelp.LastAccount(lastloginType));
            // }
            //
            // for (int i = allserverList.Count - 1; i >= 0; i--)
            // {
            //     if (!allserverList[i].PlatformList.Contains(platform))
            //     {
            //         allserverList.RemoveAt(i);
            //         continue;
            //     }
            // }

            List<int> myserverids = new List<int>();
            int myserver = PlayerPrefsHelp.GetInt(PlayerPrefsHelp.MyServerID);
            myserver = playerInfoComponent.GetNewServerId(myserver);
            myserverids.Add(myserver);

            List<int> myoldserveids = PlayerPrefsHelp.GetOldServerIds();
            for (int i = 0; i < myoldserveids.Count; i++)
            {
                int newids = playerInfoComponent.GetNewServerId(myoldserveids[i]);
                if (!myserverids.Contains(newids))
                {
                    myserverids.Add(newids);
                }
            }

            List<ServerItem> myServers = new List<ServerItem>();
            List<int> newmyServer = new List<int>();
            for (int i = 0; i < allserverList.Count; i++)
            {
                if (myserverids.Contains(allserverList[i].ServerId))
                {
                    myServers.Add(allserverList[i]);
                    newmyServer.Add(allserverList[i].ServerId);
                }
            }

            self.UpdateLatelyServer(myServers);
            self.UpdateAllServerList(allserverList);
        }

        public static void UpdateLatelyServer(this DlgSelectServer self, List<ServerItem> ids)
        {
            self.MyServers = ids;

            self.AddUIScrollItems(ref self.ScrollItemSelectServerItems2, self.MyServers.Count);
            self.View.E_SelectServerItem2LoopVerticalScrollRect.SetVisible(true, self.MyServers.Count);
        }

        public static void UpdateAllServerList(this DlgSelectServer self, List<ServerItem> allserverList)
        {
            allserverList.Sort(delegate(ServerItem a, ServerItem b) { return b.ServerId - a.ServerId; });
            self.AllserverList = allserverList;

            self.AddUIScrollItems(ref self.ScrollItemSelectServerItems1, self.AllserverList.Count);
            self.View.E_SelectServerItem1LoopVerticalScrollRect.SetVisible(true, self.AllserverList.Count);
        }

        public static void OnClickServerItem(this DlgSelectServer self, ServerItem serverId)
        {
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMJLogin>().OnSelectServer(serverId);

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_SelectServer);
        }

        public static void OnButtonCloseButton(this DlgSelectServer self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_SelectServer);
        }
    }
}
