using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class UserDataTypeUpdate_Gold_HuoBiSetRefresh: AEvent<Scene, UserDataTypeUpdate_Gold>
    {
        protected override async ETTask Run(Scene root, UserDataTypeUpdate_Gold args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgHuoBiSet>()?.Refresh();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class UserDataTypeUpdate_Diamond_HuoBiSetRefresh: AEvent<Scene, UserDataTypeUpdate_Diamond>
    {
        protected override async ETTask Run(Scene root, UserDataTypeUpdate_Diamond args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgHuoBiSet>()?.Refresh();
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof (UserInfoComponentC))]
    [FriendOf(typeof (DlgHuoBiSet))]
    public static class DlgHuoBiSetSystem
    {
        public static void RegisterUIEvent(this DlgHuoBiSet self)
        {
            self.View.E_AddGoldButton.AddListener(self.OnAddGoldButton);
            self.View.E_AddZuanShiButton.AddListener(self.OnAddZuanShiButton);

            self.View.E_CloseButton.AddListener(self.OnClose);
            self.View.E_Close2Button.AddListener(self.OnClose);
        }

        public static void ShowWindow(this DlgHuoBiSet self, Entity contextData = null)
        {
            self.Refresh();
        }

        private static void OnAddGoldButton(this DlgHuoBiSet self)
        {
            FlyTipComponent.Instance.SpawnFlyTipDi("氪金界面暂未开放");
        }

        private static void OnAddZuanShiButton(this DlgHuoBiSet self)
        {
            FlyTipComponent.Instance.SpawnFlyTipDi("氪金界面暂未开放");
        }

        public static void Refresh(this DlgHuoBiSet self)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            self.View.E_GoldText.text = userInfo.Gold.ToString();
            self.View.E_ZuanShiText.text = userInfo.Diamond.ToString();
        }

        public static void AddCloseEvent(this DlgHuoBiSet self, Action closeAction)
        {
            self.CloseActions.Add(closeAction);
        }

        public static void OnClose(this DlgHuoBiSet self)
        {
            if (self.CloseActions.Count > 0)
            {
                Action lastCallback = self.CloseActions[^1];

                lastCallback.Invoke();

                self.CloseActions.RemoveAt(self.CloseActions.Count - 1);
            }

            if (self.CloseActions.Count == 0)
            {
                self.Root().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_HuoBiSet);
            }
        }
    }
}