using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_TowerDungeon))]
    [FriendOf(typeof (DlgTower))]
    public static class DlgTowerSystem
    {
        public static void RegisterUIEvent(this DlgTower self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgTower self, Entity contextData = null)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.ShowWindow(WindowID.WindowID_HuoBiSet);
            uiComponent.GetDlgLogic<DlgHuoBiSet>().AddCloseEvent(self.OnCloseButton);

            self.View.E_Type_1Toggle.IsSelected(true);
        }

        private static void OnCloseButton(this DlgTower self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

            uiComponent.CloseWindow(WindowID.WindowID_Tower);
        }

        private static void OnFunctionSetBtn(this DlgTower self, int index)
        {
            UICommonHelper.SetToggleShow(self.View.E_Type_1Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_Type_2Toggle.gameObject, index == 1);

            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_TowerDungeon.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    break;
            }
        }
    }
}