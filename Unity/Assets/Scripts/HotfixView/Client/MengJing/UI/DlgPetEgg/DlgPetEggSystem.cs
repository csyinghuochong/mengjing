using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_PetEggList))]
    [FriendOf(typeof (ES_PetEggDuiHuan))]
    [FriendOf(typeof (ES_PetEggChouKa))]
    [FriendOf(typeof (ES_PetHeXinChouKa))]
    [FriendOf(typeof (DlgPetEgg))]
    public static class DlgPetEggSystem
    {
        public static void RegisterUIEvent(this DlgPetEgg self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgPetEgg self, Entity contextData = null)
        {
            self.View.E_1Toggle.IsSelected(true);

            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.ShowWindow(WindowID.WindowID_HuoBiSet);
            uiComponent.GetDlgLogic<DlgHuoBiSet>().AddCloseEvent(self.OnCloseButton);
        }

        private static void OnFunctionSetBtn(this DlgPetEgg self, int index)
        {
            UICommonHelper.SetToggleShow(self.View.E_1Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_2Toggle.gameObject, index == 1);
            UICommonHelper.SetToggleShow(self.View.E_3Toggle.gameObject, index == 2);
            UICommonHelper.SetToggleShow(self.View.E_4Toggle.gameObject, index == 3);

            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_PetEggList.uiTransform.gameObject.SetActive(true);
                    self.View.ES_PetEggList.OnUpdateUI();
                    break;
                case 1:
                    self.View.ES_PetEggDuiHuan.uiTransform.gameObject.SetActive(true);
                    self.View.ES_PetEggDuiHuan.OnUpdateUI();
                    break;
                case 2:
                    self.View.ES_PetEggChouKa.uiTransform.gameObject.SetActive(true);
                    break;
                case 3:
                    self.View.ES_PetHeXinChouKa.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }

        private static void OnCloseButton(this DlgPetEgg self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

            uiComponent.CloseWindow(WindowID.WindowID_PetEgg);
        }

        public static void OnRolePetEggOpen(this DlgPetEgg self)
        {
            self.View.ES_PetEggList.UpdatePetEggUI();
        }
    }
}