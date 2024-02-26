using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgRole))]
    public static class DlgRoleSystem
    {
        public static void RegisterUIEvent(this DlgRole self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgRole self, Entity contextData = null)
        {
            self.View.E_BagToggle.IsSelected(true);

            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.ShowWindow(WindowID.WindowID_HuoBiSet);
            uiComponent.GetDlgLogic<DlgHuoBiSet>().AddCloseEvent(self.OnCloseButton);

            self.RefreshPlayerInfo();
        }

        private static void OnFunctionSetBtn(this DlgRole self, int index)
        {
            Log.Debug($"按下Toggle：{index}");
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

            UICommonHelper.SetToggleShow(self.View.E_BagToggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_PropertyToggle.gameObject, index == 1);

            switch (index)
            {
                case 0:
                    uiComponent.ShowWindowAsync(WindowID.WindowID_RoleBag).Coroutine();
                    Log.Debug($"打开 Bag");
                    break;
                case 1:
                    Log.Debug($"打开 Property");
                    break;
            }

            if (index != 0)
            {
                uiComponent.HideWindow(WindowID.WindowID_RoleBag);
            }

            if (index != 1)
            {
            }
        }

        public static void OnCloseButton(this DlgRole self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.CloseWindow(WindowID.WindowID_RoleBag);

            uiComponent.CloseWindow(WindowID.WindowID_Role);
        }

        private static void RefreshPlayerInfo(this DlgRole self)
        {
            // 假数据
            UserInfo userInfo = new UserInfo() { Lv = 10, Name = "玩家1号", Occ = 1 };
            BagInfo bagInfo = new BagInfo();

            self.View.E_RoseLvText.text = userInfo.Lv.ToString();
            self.View.E_RoseNameText.text = userInfo.Name;

            self.View.ES_ModelShow.SetPosition(Vector3.zero, new Vector3(0f, 70f, 150f));
            self.View.ES_ModelShow.ShowPlayerModel(bagInfo, userInfo.Occ, 0);
        }
    }
}