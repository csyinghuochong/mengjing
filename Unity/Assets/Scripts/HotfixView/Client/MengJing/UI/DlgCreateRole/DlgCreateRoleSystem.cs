using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgCreateRole))]
    [FriendOf(typeof (PlayerComponent))]
    public static class DlgCreateRoleSystem
    {
        public static void RegisterUIEvent(this DlgCreateRole self)
        {
            self.View.E_CreateRoleButton.AddListenerAsync(self.OnCreateRoleButton);
        }

        public static void ShowWindow(this DlgCreateRole self, Entity contextData = null)
        {
        }

        private static async ETTask OnCreateRoleButton(this DlgCreateRole self)
        {
            //參考危境，有角色则显示角色列表，点击空角色跳转到创建角色界面。
            PlayerComponent playerComponent = self.Root().GetComponent<PlayerComponent>();
            if (playerComponent.CreateRoleList.Count > 0)
            {
                Log.Debug("暂时只能创建一个角色！");
                return;
            }

            await EnterMapHelper.RequestCreateRole(self.Root(), playerComponent.AccountId, 1, "ttt");
        }
    }
}