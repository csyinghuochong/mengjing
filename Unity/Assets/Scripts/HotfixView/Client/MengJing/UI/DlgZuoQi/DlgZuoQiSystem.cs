using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_ZuoQiShow))]
    [FriendOf(typeof (DlgZuoQi))]
    public static class DlgZuoQiSystem
    {
        public static void RegisterUIEvent(this DlgZuoQi self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgZuoQi self, Entity contextData = null)
        {
            self.View.E_1Toggle.IsSelected(true);
        }

        private static void OnFunctionSetBtn(this DlgZuoQi self, int index)
        {
            UICommonHelper.SetToggleShow(self.View.E_1Toggle.gameObject, index == 1);

            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_ZuoQiShow.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }
    }
}