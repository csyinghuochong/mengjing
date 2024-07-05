using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_JiaYuanMystery_A))]
    [FriendOf(typeof (DlgJiaYuanMystery))]
    public static class DlgJiaYuanMysterySystem
    {
        public static void RegisterUIEvent(this DlgJiaYuanMystery self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgJiaYuanMystery self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgJiaYuanMystery self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_JiaYuanMystery_A.uiTransform.gameObject.SetActive(true);
                    self.View.ES_JiaYuanMystery_A.OnUpdateUI();
                    break;
                case 1:
                    break;
            }
        }
    }
}