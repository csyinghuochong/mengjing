using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_RoleXiLianShow))]
    [FriendOf(typeof (ES_RoleXiLianLevel))]
    [FriendOf(typeof (DlgRoleXiLian))]
    public static class DlgRoleXiLianSystem
    {
        public static void RegisterUIEvent(this DlgRoleXiLian self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgRoleXiLian self, Entity contextData = null)
        {
            self.View.E_XiLianToggle.IsSelected(true);

            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.ShowWindow(WindowID.WindowID_HuoBiSet);
            uiComponent.GetDlgLogic<DlgHuoBiSet>().AddCloseEvent(self.OnCloseButton);
        }

        private static void OnFunctionSetBtn(this DlgRoleXiLian self, int index)
        {
            UICommonHelper.SetToggleShow(self.View.E_XiLianToggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_DaShiToggle.gameObject, index == 1);
            UICommonHelper.SetToggleShow(self.View.E_SkillToggle.gameObject, index == 2);
            UICommonHelper.SetToggleShow(self.View.E_TransferToggle.gameObject, index == 3);
            UICommonHelper.SetToggleShow(self.View.E_InheritToggle.gameObject, index == 4);

            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_RoleXiLianShow.uiTransform.gameObject.SetActive(true);
                    self.View.ES_RoleXiLianShow.OnUpdateUI();
                    break;
                case 1:
                    self.View.ES_RoleXiLianLevel.uiTransform.gameObject.SetActive(true);
                    self.View.ES_RoleXiLianLevel.OnUpdateUI();
                    break;
                case 2:
                    
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }

        private static void OnCloseButton(this DlgRoleXiLian self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

            uiComponent.CloseWindow(WindowID.WindowID_RoleXiLian);
        }

        public static void OnXiLianReturn(this DlgRoleXiLian self)
        {
            self.View.ES_RoleXiLianShow.OnXiLianReturn();
        }
    }
}