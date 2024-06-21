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
            if (self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgRecharge>() != null)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Recharge).Coroutine();
        }

        private static void OnAddZuanShiButton(this DlgHuoBiSet self)
        {
            if (self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPaiMai>() != null)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Recharge).Coroutine();
        }

        public static void Refresh(this DlgHuoBiSet self)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            self.View.E_GoldText.text = userInfo.Gold.ToString();
            self.View.E_ZuanShiText.text = userInfo.Diamond.ToString();
        }

        private static void OnClose(this DlgHuoBiSet self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

            uiComponent.CloseWindow(WindowID.WindowID_ItemTips);
            uiComponent.CloseWindow(WindowID.WindowID_EquipDuiBiTips);

            if (uiComponent.OpenUIList.Count > 0)
            {
                if (uiComponent.OpenUIList[0] == WindowID.WindowID_Setting)
                {
                    DlgSetting dlgSetting = uiComponent.GetDlgLogic<DlgSetting>();
                    dlgSetting.OnBeforeClose();
                }

                if (uiComponent.OpenUIList[0] == WindowID.WindowID_Role)
                {
                    uiComponent.CloseWindow(WindowID.WindowID_RoleZodiac);
                }

                uiComponent.CloseWindow(uiComponent.OpenUIList[0]);
            }
        }

        public static void OnUpdateTitle(this DlgHuoBiSet self, WindowID windowID)
        {
            // string[] paths = uiType.Split('/');
            // string titlePath = paths[paths.Length - 1];
            // if (uiType.Contains("UITeamDungeon"))
            // {
            //     titlePath = "UITeamDungeon";
            // }
            //
            // string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.TiTleIcon, "Img_" + titlePath);
            // Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAsset<Sprite>(path);
            // if (!self.AssetPath.Contains(path))
            // {
            //     self.AssetPath.Add(path);
            // }
            //
            // self.Img_Back_Title.GetComponent<Image>().sprite = sp;
        }
    }
}