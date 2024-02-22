using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgMJLobby))]
    [FriendOf(typeof (PlayerComponent))]
    public static class DlgMJLobbySystem
    {
        public static void RegisterUIEvent(this DlgMJLobby self)
        {
            self.View.E_EnterMapButton.AddListenerAsync(self.OnEnterMapButton);
            self.View.E_CreateRoleItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCreateRoleItemsRefresh);
            // self.View.E_BtnSelectRole.AddListenerAsync(self.OnBtnSelectRole);
        }

        public static void ShowWindow(this DlgMJLobby self, Entity contextData = null)
        {
            self.Refresh();
        }

        private static void OnCreateRoleItemsRefresh(this DlgMJLobby self, Transform transform, int index)
        {
            Scroll_Item_CreateRoleItem scrollItemCreateRoleItem = self.ScrollItemCreateRoleItems[index].BindTrans(transform);
            scrollItemCreateRoleItem.Refresh(self.ShowCreateRoleInfos[index]);
        }

        private static void Refresh(this DlgMJLobby self)
        {
            self.RefreshCreateRoleItems();
        }

        private static void RefreshCreateRoleItems(this DlgMJLobby self)
        {
            PlayerComponent playerComponent = self.Root().GetComponent<PlayerComponent>();
            if (playerComponent.CreateRoleList.Count > 0)
            {
                self.SeletRoleInfo = playerComponent.CreateRoleList[0];
            }

            self.PageIndex = 0;

            int starIndex = self.PageIndex * self.PageCount;

            int num = playerComponent.CreateRoleList.Count - starIndex + 1;
            num = Mathf.Min(self.PageCount, num);

            self.ShowCreateRoleInfos.Clear();

            for (int i = 0; i < num; i++)
            {
                if (i < playerComponent.CreateRoleList.Count - starIndex)
                {
                    self.ShowCreateRoleInfos.Add(playerComponent.CreateRoleList[starIndex + i]);
                }
            }

            if (self.ShowCreateRoleInfos.Count < self.PageCount)
            {
                self.ShowCreateRoleInfos.Add(null);
            }

            self.AddUIScrollItems(ref self.ScrollItemCreateRoleItems, self.ShowCreateRoleInfos.Count);
            self.View.E_CreateRoleItemsLoopVerticalScrollRect.SetVisible(true, self.ShowCreateRoleInfos.Count);

            // self.UpdateSelectShow().Coroutine();
            // self.Update_Page();
        }

        public static void UpdateSelect(this DlgMJLobby self, CreateRoleInfo createRoleInfo)
        {
            self.SeletRoleInfo = createRoleInfo;
            for (int i = 0; i < self.ScrollItemCreateRoleItems.Keys.Count; i++)
            {
                self.ScrollItemCreateRoleItems[i].UpdateSelectStatus(self.SeletRoleInfo);
            }

            if (self.SeletRoleInfo != null)
            {
                self.View.E_NameText.text = self.SeletRoleInfo.PlayerName;
                self.View.E_LvText.text = $"{self.SeletRoleInfo.PlayerLv}级";

                self.View.ES_ModelShow.ShowPlayerModel(new BagInfo(), 1, 0);
                self.View.ES_ModelShow.SetShow(true);
            }
            else
            {
                self.View.ES_ModelShow.SetShow(false);
            }
        }

        private static async ETTask OnBtnSelectRole(this DlgMJLobby self)
        {
            //參考危境，有角色则显示角色列表，点击空角色跳转到创建角色界面。
            PlayerComponent accountInfoComponentClient = self.Root().GetComponent<PlayerComponent>();
            if (accountInfoComponentClient.CreateRoleList.Count > 0)
            {
                Log.Debug("暂时只能创建一个角色！");
                return;
            }

            await EnterMapHelper.RequestCreateRole(self.Root(), accountInfoComponentClient.AccountId, 1, "ttt");
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

    [Event(SceneType.Demo)]
    public class DlgMJLobby_UpdateSelectHandler: AEvent<Scene, DlgMJLobby_UpdateSelect>
    {
        protected override async ETTask Run(Scene scene, DlgMJLobby_UpdateSelect args)
        {
            scene.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMJLobby>().UpdateSelect(args.CreateRoleInfo);
            await ETTask.CompletedTask;
        }
    }
}