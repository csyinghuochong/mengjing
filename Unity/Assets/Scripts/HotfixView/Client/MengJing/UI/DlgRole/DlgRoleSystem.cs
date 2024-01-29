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
        }

        private static void OnFunctionSetBtn(this DlgRole self, int index)
        {
            Log.Debug($"按下Toggle：{index}");
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

            self.SetToggleShow(self.View.E_BagToggle.gameObject, index == 0);
            self.SetToggleShow(self.View.E_PropertyToggle.gameObject, index == 1);

            switch (index)
            {
                case 0:
                    uiComponent.ShowWindowAsync(WindowID.WindowID_RoleBag).Coroutine();
                    Log.Debug($"打开 Bag");
                    break;
                case 1:
                    // uiComponent.ShowWindowAsync(WindowID.WindowID_Role).Coroutine();
                    Log.Debug($"打开 Property");
                    break;
            }

            if (index != 0)
            {
                uiComponent.HideWindow(WindowID.WindowID_RoleBag);
                Log.Debug($"关闭 Bag");
            }

            if (index != 1)
            {
                // uiComponent.HideWindow(WindowID.WindowID_Main);
                Log.Debug($"关闭 Property");
            }
        }

        private static void SetToggleShow(this DlgRole self, GameObject gameObject, bool isShow)
        {
            gameObject.transform.Find("Background/XuanZhong").gameObject.SetActive(isShow);
            gameObject.transform.Find("Background/WeiXuanZhong").gameObject.SetActive(!isShow);
        }
    }
}