using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgMJLobby))]
    [FriendOf(typeof(PlayerComponent))]
    public static class DlgMJLobbySystem
    {
        public static void RegisterUIEvent(this DlgMJLobby self)
        {
            self.View.E_EnterMapButton.AddListenerAsync(self.OnEnterMapButton);
            self.View.E_DeleteRoleButton.AddListener(self.OnDeleteRoleButton);
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
            
            string lastUserID = PlayerPrefsHelp.GetString(PlayerPrefsHelp.LastUserID);
            PlayerComponent playerComponent = self.Root().GetComponent<PlayerComponent>();
            if (!string.IsNullOrEmpty(lastUserID))
            {
                long useid = long.Parse(lastUserID);
                for (int i = 0; i < playerComponent.CreateRoleList.Count; i++)
                {
                    if (playerComponent.CreateRoleList[i].UnitId == useid)
                    {
                        self.SeletRoleInfo = playerComponent.CreateRoleList[i];
                        self.PageIndex = i / self.PageCount;
                        break;
                    }
                }
            }
            
            self.UpdateSelect(self.SeletRoleInfo ?? self.ShowCreateRoleInfos[0]);

            if (self.PageIndex == 0 && self.ShowCreateRoleInfos.Count == 1)
            {
                UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
                uiComponent.ShowWindow(WindowID.WindowID_CreateRole);
                uiComponent.HideWindow(WindowID.WindowID_MJLobby);
                return;
            }
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
            pagetotal += ((roleNumber % 4 > 0) ? 1 : 0);

            self.View.E_PrevButton.gameObject.SetActive(self.PageIndex > 0);
            self.View.E_NextButton.gameObject.SetActive(self.PageIndex < pagetotal - 1);
        }

        public static void UpdateSelect(this DlgMJLobby self, CreateRoleInfo createRoleInfo)
        {
            self.SeletRoleInfo = createRoleInfo;
            // EUIModelViewHelper.AddUIScrollItems 添加时用的<=,会多一个,不知道为什么
            for (int i = 0; i < self.ScrollItemCreateRoleItems.Keys.Count - 1; i++)
            {
                Scroll_Item_CreateRoleItem scrollItemCreateRoleItem = self.ScrollItemCreateRoleItems[i];
                scrollItemCreateRoleItem.UpdateSelectStatus(self.SeletRoleInfo);
            }

            if (self.SeletRoleInfo != null)
            {
                self.View.E_NameText.text = self.SeletRoleInfo.PlayerName;
                self.View.E_NameText.gameObject.SetActive(true);
                using (zstring.Block())
                {
                    self.View.E_LvText.text = zstring.Format("{0}级", self.SeletRoleInfo.PlayerLv);
                }
                self.View.E_LvText.gameObject.SetActive(true);

                self.View.ES_ModelShow.SetPosition(Vector3.zero, new Vector3(0f, 70f, 150f));
                self.View.ES_ModelShow.ShowPlayerModel(new ItemInfo(), createRoleInfo.PlayerOcc, 0, new List<int>());
                self.View.ES_ModelShow.SetShow(true);
            }
            else
            {
                self.View.E_NameText.gameObject.SetActive(false);
                self.View.E_LvText.gameObject.SetActive(false);
                self.View.ES_ModelShow.SetShow(false);
            }
        }

        private static async ETTask OnEnterMapButton(this DlgMJLobby self)
        {
            if (Time.time - self.LastLoginTime < 4f)
            {
                return;
            }
            
            PlayerComponent playerComponent = self.Root().GetComponent<PlayerComponent>();
            if (playerComponent.CreateRoleList.Count == 0)
            {
                Log.Debug("需要先创建角色！");
                return;
            }

            if (self.SeletRoleInfo == null)
            {
                Log.Debug("未选择角色！");
                return;
            }

            self.LastLoginTime = Time.time;
            PlayerPrefsHelp.SetString(PlayerPrefsHelp.LastUserID, self.SeletRoleInfo.UnitId.ToString());
            playerComponent.CurrentRoleId = self.SeletRoleInfo.UnitId;
            await LoginHelper.LoginGameAsync(self.Root(), 0);
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_MJLobby);
        }

        private static void OnDeleteRoleButton(this DlgMJLobby self)
        {
            if (self.SeletRoleInfo == null)
            {
                FlyTipComponent.Instance.ShowFlyTip("请选择要删除的角色!");
                return;
            }

            PopupTipHelp.OpenPopupTip(self.Root(),
                        "删除角色",
                        "是否删除当前角色？",
                        () => { self.RequestDeleteRole().Coroutine(); })
                    .Coroutine();
        }

        private static async ETTask RequestDeleteRole(this DlgMJLobby self)
        {
            PlayerComponent playerComponent = self.Root().GetComponent<PlayerComponent>();
            await LoginHelper.RequestDeleteRole(self.Root(), playerComponent.AccountId, self.SeletRoleInfo.UnitId, self.SeletRoleInfo);
            self.SeletRoleInfo = null;
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
            pagetotal += ((roleNumber % 4 > 0) ? 1 : 0);
            if (self.PageIndex >= pagetotal - 1)
            {
                return;
            }

            self.PageIndex++;

            self.Refresh();
        }
    }
}
