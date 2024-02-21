using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgMJLobby))]
    [FriendOf(typeof(PlayerComponent))]
    public static class DlgMJLobbySystem
    {
        public static void RegisterUIEvent(this DlgMJLobby self)
        {
            self.View.E_EnterMapButton.AddListenerAsync(self.OnEnterMapButton);
            self.View.E_BtnSelectRole.AddListenerAsync(self.OnBtnSelectRole);
        }

        public static void ShowWindow(this DlgMJLobby self, Entity contextData = null)
        {
            
        }

        private static async ETTask OnBtnSelectRole(this DlgMJLobby self)
        {
            PlayerComponent accountInfoComponentClient = self.Root().GetComponent<PlayerComponent>();
            if (accountInfoComponentClient.CreateRoleList.Count > 0)
            {
                Log.Debug("暂时只能创建一个角色！");
                return;
            }

            await EnterMapHelper.RequestCreateRole(self.Root(), accountInfoComponentClient.AccountId ,1, "ttt");
        }

        private static async ETTask OnEnterMapButton(this DlgMJLobby self)
        {
            PlayerComponent accountInfoComponentClient = self.Root().GetComponent<PlayerComponent>();
            if (accountInfoComponentClient.CreateRoleList.Count == 0)
            {
                Log.Debug("需要先创建角色！");
                return;
            }

            accountInfoComponentClient.CurrentRoleId = accountInfoComponentClient.CreateRoleList[0].UnitId;
            await EnterMapHelper.EnterMapAsync(self.Root());
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_MJLobby);
        }
    }
}