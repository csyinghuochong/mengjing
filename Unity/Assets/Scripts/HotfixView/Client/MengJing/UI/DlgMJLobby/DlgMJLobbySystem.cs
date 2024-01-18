using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgMJLobby))]
    public static class DlgMJLobbySystem
    {
        public static void RegisterUIEvent(this DlgMJLobby self)
        {
            self.View.E_EnterMapButton.AddListenerAsync(self.OnEnterMapButton);
        }

        public static void ShowWindow(this DlgMJLobby self, Entity contextData = null)
        {
        }

        private static async ETTask OnEnterMapButton(this DlgMJLobby self)
        {
            // 测试。。。
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Main);
            
            await EnterMapHelper.EnterMapAsync(self.Root());
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Lobby);
        }
    }
}