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
            self.View.E_CloseButton.AddListener(self.OnCloseButton);
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgCreateRole self, Entity contextData = null)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            self.View.E_Icon_1_1Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "1"));
            self.View.E_Icon_1_2Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "1"));
            self.View.E_Icon_2_1Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "2"));
            self.View.E_Icon_2_2Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "2"));
            self.View.E_Icon_3_1Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "3"));
            self.View.E_Icon_3_2Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "3"));

            self.View.E_Occ1Toggle.IsSelected(true);
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

        private static void OnFunctionSetBtn(this DlgCreateRole self, int index)
        {
            Log.Debug($"按下Toggle：{index}");

            UICommonHelper.SetToggleShow(self.View.E_Occ1Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_Occ2Toggle.gameObject, index == 1);
            UICommonHelper.SetToggleShow(self.View.E_Occ3Toggle.gameObject, index == 2);

            switch (index)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }

            self.OnSelectOcc(index + 1);
        }

        private static void OnSelectOcc(this DlgCreateRole self, int occ)
        {
            self.Occ = occ;
            self.View.ES_ModelShow.SetPosition(Vector3.zero, new Vector3(0f, 70f, 150f));
            self.View.ES_ModelShow.ShowPlayerModel(new BagInfo(), occ, 0);
        }

        private static void OnCloseButton(this DlgCreateRole self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.ShowWindow(WindowID.WindowID_MJLobby);
            uiComponent.CloseWindow(WindowID.WindowID_CreateRole);
        }
    }
}