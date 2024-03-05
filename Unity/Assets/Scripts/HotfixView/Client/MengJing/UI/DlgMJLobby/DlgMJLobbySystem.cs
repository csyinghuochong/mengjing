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
            self.View.E_DeleteRoleButton.AddListenerAsync(self.OnDeleteRoleButton);
            self.View.E_PrevButton.AddListener(self.OnPrevButton);
            self.View.E_NextButton.AddListener(self.OnNextButton);
            self.View.E_CreateRoleItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCreateRoleItemsRefresh);
        }

        public static void ShowWindow(this DlgMJLobby self, Entity contextData = null)
        {
            self.Refresh();
        }

        private static void OnCreateRoleItemsRefresh(this DlgMJLobby self, Transform transform, int index)
        {
            Scroll_Item_CreateRoleItem scrollItemCreateRoleItem = self.ScrollItemCreateRoleItems[index].BindTrans(transform);
            scrollItemCreateRoleItem.Refresh(self.ShowCreateRoleInfos[index], self.UpdateSelect);
        }

        private static void Refresh(this DlgMJLobby self)
        {
            self.RefreshCreateRoleItems();
            self.UpdateSelect(self.ShowCreateRoleInfos[0]);
        }

        public static void SelectNewCreateRole(this DlgMJLobby self)
        {
            self.RefreshCreateRoleItems();
            for (int i = self.ShowCreateRoleInfos.Count - 1; i >= 0; i--)
            {
                if (self.ShowCreateRoleInfos[i] != null)
                {
                    self.UpdateSelect(self.ShowCreateRoleInfos[i]);
                    break;
                }
            }
        }

        private static void RefreshCreateRoleItems(this DlgMJLobby self)
        {
            PlayerComponent playerComponent = self.Root().GetComponent<PlayerComponent>();
            if (self.SeletRoleInfo == null)
            {
                if (playerComponent.CreateRoleList.Count > 0)
                {
                    self.SeletRoleInfo = playerComponent.CreateRoleList[0];
                }

                self.PageIndex = 0;
            }

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

            int roleNumber = playerComponent.CreateRoleList.Count;
            roleNumber = Mathf.Max(roleNumber, 8);

            int pagetotal = roleNumber / 4;
            pagetotal += ((roleNumber % 4 > 0)? 1 : 0);

            self.View.E_PrevButton.gameObject.SetActive(self.PageIndex > 0);
            self.View.E_NextButton.gameObject.SetActive(self.PageIndex < pagetotal - 1);
        }

        public static void UpdateSelect(this DlgMJLobby self, CreateRoleInfo createRoleInfo)
        {
            self.SeletRoleInfo = createRoleInfo;
            // EUIModelViewHelper.AddUIScrollItems 添加时用的<=,会多一个,不知道为什么
            for (int i = 0; i < self.ScrollItemCreateRoleItems.Keys.Count - 1; i++)
            {
                self.ScrollItemCreateRoleItems[i].UpdateSelectStatus(self.SeletRoleInfo);
            }

            if (self.SeletRoleInfo != null)
            {
                self.View.E_NameText.text = self.SeletRoleInfo.PlayerName;
                self.View.E_LvText.text = $"{self.SeletRoleInfo.PlayerLv}级";
                self.View.ES_ModelShow.SetPosition(Vector3.zero, new Vector3(0f, 70f, 150f));
                self.View.ES_ModelShow.ShowPlayerModel(new BagInfo(), createRoleInfo.PlayerOcc, 0);
                self.View.ES_ModelShow.SetShow(true);
            }
            else
            {
                self.View.ES_ModelShow.SetShow(false);
            }
        }

        private static async ETTask OnEnterMapButton(this DlgMJLobby self)
        {
            PlayerComponent accountInfoComponentClient = self.Root().GetComponent<PlayerComponent>();
            if (accountInfoComponentClient.CreateRoleList.Count == 0)
            {
                Log.Debug("需要先创建角色！");
                return;
            }

            if (self.SeletRoleInfo == null)
            {
                Log.Debug("未选择角色！");
                return;
            }

            accountInfoComponentClient.CurrentRoleId = self.SeletRoleInfo.UnitId;
            await EnterMapHelper.EnterMapAsync(self.Root());
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_MJLobby);
        }

        private static async ETTask OnDeleteRoleButton(this DlgMJLobby self)
        {
            if (self.SeletRoleInfo == null)
            {
                Log.Error("请选择要删除的角色!");
                return;
            }

            PlayerComponent playerComponent = self.Root().GetComponent<PlayerComponent>();
            await EnterMapHelper.RequestDeleteRole(self.Root(), playerComponent.AccountId, self.SeletRoleInfo.UnitId, self.SeletRoleInfo);
            self.Refresh();
        }

        private static void OnPrevButton(this DlgMJLobby self)
        {
            if (self.PageIndex < 1)
            {
                return;
            }

            self.PageIndex--;

            self.Refresh();
        }

        private static void OnNextButton(this DlgMJLobby self)
        {
            int roleNumber = self.Root().GetComponent<PlayerComponent>().CreateRoleList.Count;
            roleNumber = Mathf.Max(roleNumber, 8);

            int pagetotal = roleNumber / 4;
            pagetotal += ((roleNumber % 4 > 0)? 1 : 0);
            if (self.PageIndex >= pagetotal - 1)
            {
                return;
            }

            self.PageIndex++;

            self.Refresh();
        }
    }
}