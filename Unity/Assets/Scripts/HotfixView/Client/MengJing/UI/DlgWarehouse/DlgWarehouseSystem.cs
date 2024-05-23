using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_WarehouseRole))]
    [FriendOf(typeof (ES_WarehouseAccount))]
    [FriendOf(typeof (ES_WarehouseGem))]
    [FriendOf(typeof (DlgWarehouse))]
    public static class DlgWarehouseSystem
    {
        public static void RegisterUIEvent(this DlgWarehouse self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgWarehouse self, Entity contextData = null)
        {
            self.View.E_1Toggle.IsSelected(true);

            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.ShowWindow(WindowID.WindowID_HuoBiSet);
            uiComponent.GetDlgLogic<DlgHuoBiSet>().AddCloseEvent(self.OnCloseButton);
        }

        private static void OnFunctionSetBtn(this DlgWarehouse self, int index)
        {
            UICommonHelper.SetToggleShow(self.View.E_1Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_2Toggle.gameObject, index == 1);
            UICommonHelper.SetToggleShow(self.View.E_3Toggle.gameObject, index == 2);

            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_WarehouseRole.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_WarehouseAccount.uiTransform.gameObject.SetActive(true);
                    break;
                case 2:
                    self.View.ES_WarehouseGem.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }

        private static void OnCloseButton(this DlgWarehouse self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

            uiComponent.CloseWindow(WindowID.WindowID_Warehouse);
            uiComponent.CloseWindow(WindowID.WindowID_RoleZodiac);
        }
    }
}