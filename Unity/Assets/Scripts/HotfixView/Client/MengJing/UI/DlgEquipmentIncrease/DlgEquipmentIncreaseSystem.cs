using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(ES_EquipmentIncreaseShow))]
    [FriendOf(typeof(DlgEquipmentIncrease))]
    public static class DlgEquipmentIncreaseSystem
    {
        public static void RegisterUIEvent(this DlgEquipmentIncrease self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgEquipmentIncrease self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgEquipmentIncrease self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_EquipmentIncreaseShow.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:

                    break;
            }
        }
    }
}