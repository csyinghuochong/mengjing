using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_ProtectEquip))]
    [FriendOf(typeof (ES_ProtectPet))]
    [FriendOf(typeof (DlgProtect))]
    public static class DlgProtectSystem
    {
        public static void RegisterUIEvent(this DlgProtect self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgProtect self, Entity contextData = null)
        {
            self.View.E_0Toggle.IsSelected(true);
        }

        private static void OnFunctionSetBtn(this DlgProtect self, int index)
        {
            UICommonHelper.SetToggleShow(self.View.E_0Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_1Toggle.gameObject, index == 1);

            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_ProtectEquip.uiTransform.gameObject.SetActive(true);
                    self.View.ES_ProtectEquip.OnUpdateUI();
                    break;
                case 1:
                    self.View.ES_ProtectPet.uiTransform.gameObject.SetActive(true);
                    self.View.ES_ProtectPet.OnUpdateUI();
                    break;
            }
        }
    }
}