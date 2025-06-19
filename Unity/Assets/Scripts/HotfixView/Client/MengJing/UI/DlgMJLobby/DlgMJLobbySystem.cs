using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CreateRoleItem))]
    [FriendOf(typeof(DlgMJLobby))]
    [FriendOf(typeof(PlayerInfoComponent))]
    public static class DlgMJLobbySystem
    {
        public static void RegisterUIEvent(this DlgMJLobby self)
        {
            self.View.E_EnterMapButton.AddListenerAsync(self.OnEnterMapButton);
            self.View.E_DeleteRoleButton.AddListener(self.OnDeleteRoleButton);
            self.View.E_PrevButton.AddListener(self.OnPrevButton);
            self.View.E_NextButton.AddListener(self.OnNextButton);
            self.View.E_CreateRoleItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCreateRoleItemsRefresh);
            
            self.Refresh();
        }

        public static void ShowWindow(this DlgMJLobby self, Entity contextData = null)
        {
        }

        private static void OnCreateRoleItemsRefresh(this DlgMJLobby self, Transform transform, int index)
        {
            foreach (Scroll_Item_CreateRoleItem item in self.ScrollItemCreateRoleItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CreateRoleItem scrollItemCreateRoleItem = self.ScrollItemCreateRoleItems[index].BindTrans(transform);
            scrollItemCreateRoleItem.Refresh(self.ShowCreateRoleInfos[index], self.UpdateSelect);
        }

        private static void Refresh(this DlgMJLobby self)
        {
            self.RefreshCreateRoleItems();
            
            string lastUserID = PlayerPrefsHelp.GetString(PlayerPrefsHelp.LastUserID);
            PlayerInfoComponent playerInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();
            if (!string.IsNullOrEmpty(lastUserID))
            {
                long useid = long.Parse(lastUserID);
                for (int i = 0; i < playerInfoComponent.CreateRoleList.Count; i++)
                {
                    if (playerInfoComponent.CreateRoleList[i].UnitId == useid)
                    {
                        self.SeletRoleInfo = playerInfoComponent.CreateRoleList[i];
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
            PlayerInfoComponent playerInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();
            if (self.SeletRoleInfo == null)
            {
                if (playerInfoComponent.CreateRoleList.Count > 0)
                {
                    self.SeletRoleInfo = playerInfoComponent.CreateRoleList[0];
                }

                self.PageIndex = 0;
            }

            int starIndex = self.PageIndex * self.PageCount;

            int num = playerInfoComponent.CreateRoleList.Count - starIndex + 1;
            num = Mathf.Min(self.PageCount, num);

            self.ShowCreateRoleInfos.Clear();

            for (int i = 0; i < num; i++)
            {
                if (i < playerInfoComponent.CreateRoleList.Count - starIndex)
                {
                    self.ShowCreateRoleInfos.Add(playerInfoComponent.CreateRoleList[starIndex + i]);
                }
            }

            if (self.ShowCreateRoleInfos.Count < self.PageCount)
            {
                self.ShowCreateRoleInfos.Add(null);
            }

            self.AddUIScrollItems(ref self.ScrollItemCreateRoleItems, self.ShowCreateRoleInfos.Count);
            self.View.E_CreateRoleItemsLoopVerticalScrollRect.SetVisible(true, self.ShowCreateRoleInfos.Count);

            int roleNumber = playerInfoComponent.CreateRoleList.Count;
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

                self.View.ES_ModelShow.SetCameraPosition(new Vector3(0f, 70f, 150f));
                self.View.ES_ModelShow.SetShow(true);
                self.View.ES_ModelShow.ShowPlayerModel(new ItemInfo(), createRoleInfo.PlayerOcc, 0, new List<int>());
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
            
            PlayerInfoComponent playerInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();
            if (playerInfoComponent.CreateRoleList.Count == 0)
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
            playerInfoComponent.CurrentRoleId = self.SeletRoleInfo.UnitId;
            self.Root().GetComponent<MapComponent>().MapType = MapTypeEnum.LoginScene;
            int errorCode = await LoginHelper.LoginGameAsync(self.Root(), 0);
            
            if (errorCode == ErrorCode.ERR_SessionDisconnect)
            {
                FlyTipComponent.Instance.ShowFlyTip("网络断线，请重新登陆！");
            }
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
            PlayerInfoComponent playerInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();
            await LoginHelper.RequestDeleteRole(self.Root(), playerInfoComponent.AccountId, self.SeletRoleInfo.UnitId, self.SeletRoleInfo);
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
            int roleNumber = self.Root().GetComponent<PlayerInfoComponent>().CreateRoleList.Count;
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
