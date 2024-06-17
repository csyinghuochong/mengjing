using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_NewYearCollectionWord))]
    [FriendOf(typeof (ES_NewYearMonster))]
    [FriendOf(typeof (DlgNewYear))]
    public static class DlgNewYearSystem
    {
        public static void RegisterUIEvent(this DlgNewYear self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgNewYear self, Entity contextData = null)
        {
            self.View.E_Type1Toggle.IsSelected(true);
        }

        private static void OnFunctionSetBtn(this DlgNewYear self, int index)
        {
            UICommonHelper.SetToggleShow(self.View.E_Type1Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_Type2Toggle.gameObject, index == 1);

            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_NewYearCollectionWord.uiTransform.gameObject.SetActive(true);
                    self.View.ES_NewYearCollectionWord.OnUpdateUI();
                    break;
                case 1:
                    self.View.ES_NewYearMonster.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }
    }
}