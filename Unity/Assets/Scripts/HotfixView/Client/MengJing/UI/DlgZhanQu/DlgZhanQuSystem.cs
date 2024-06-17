using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_ZhanQuLevel))]
    [FriendOf(typeof (ES_ZhanQuCombat))]
    [FriendOf(typeof (DlgZhanQu))]
    public static class DlgZhanQuSystem
    {
        public static void RegisterUIEvent(this DlgZhanQu self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgZhanQu self, Entity contextData = null)
        {
            self.View.E_1Toggle.IsSelected(true);
        }

        private static void OnFunctionSetBtn(this DlgZhanQu self, int index)
        {
            UICommonHelper.SetToggleShow(self.View.E_1Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_2Toggle.gameObject, index == 1);

            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_ZhanQuLevel.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_ZhanQuCombat.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }
    }
}