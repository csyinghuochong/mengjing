using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class BagItemUpdate_DlgRoleAndBagRefresh: AEvent<Scene, BagItemUpdate>
    {
        protected override async ETTask Run(Scene scene, BagItemUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgRole>()?.Refresh();
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgRole>()?.View.ES_RoleBag?.Refresh();
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgRole>()?.View.ES_RoleGem?.Refresh();
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof (ES_EquipSet))]
    [FriendOf(typeof (ES_RoleGem))]
    [FriendOf(typeof (ES_RoleProperty))]
    [FriendOf(typeof (ES_RoleBag))]
    [FriendOf(typeof (UserInfoComponentClient))]
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
        }

        private static void OnFunctionSetBtn(this DlgRole self, int index)
        {
            UICommonHelper.SetToggleShow(self.View.E_BagToggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_PropertyToggle.gameObject, index == 1);
            UICommonHelper.SetToggleShow(self.View.E_GemToggle.gameObject, index == 2);

            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_RoleBag.uiTransform.gameObject.SetActive(true);
                    self.View.E_ZodiacButton.gameObject.SetActive(true);
                    self.View.ES_EquipSet.uiTransform.gameObject.SetActive(true);
                    self.View.ES_EquipSet.PlayShowIdelAnimate(null);
                    self.View.ES_EquipSet.EquipSetHide(true);
                    break;
                case 1:
                    self.View.ES_RoleProperty.uiTransform.gameObject.SetActive(true);
                    self.View.E_ZodiacButton.gameObject.SetActive(true);
                    self.View.ES_EquipSet.uiTransform.gameObject.SetActive(true);
                    self.View.ES_EquipSet.PlayShowIdelAnimate(null);
                    self.View.ES_EquipSet.EquipSetHide(true);
                    break;
                case 2:
                    self.View.ES_RoleGem.uiTransform.gameObject.SetActive(true);
                    self.View.E_ZodiacButton.gameObject.SetActive(false);
                    self.View.ES_EquipSet.uiTransform.gameObject.SetActive(true);
                    self.View.ES_EquipSet.PlayShowIdelAnimate(null);
                    self.View.ES_EquipSet.EquipSetHide(false);
                    break;
                case 3:
                    self.View.E_ZodiacButton.gameObject.SetActive(false);
                    self.View.ES_EquipSet.uiTransform.gameObject.SetActive(false);
                    self.View.ES_EquipSet.EquipSetHide(true);
                    break;
            }

            self.Refresh();
        }

        public static void Refresh(this DlgRole self)
        {
            self.View.ES_EquipSet.RefreshPlayerInfo();
            self.View.ES_EquipSet.RefreshEquip();
        }

        private static void OnCloseButton(this DlgRole self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

            uiComponent.CloseWindow(WindowID.WindowID_Role);
        }
    }
}