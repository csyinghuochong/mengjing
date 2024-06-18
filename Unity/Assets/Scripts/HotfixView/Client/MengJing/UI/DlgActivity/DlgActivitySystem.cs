using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_ActivityYueKa))]
    [FriendOf(typeof (ES_ActivityMaoXian))]
    [FriendOf(typeof (ES_ActivityToken))]
    [FriendOf(typeof (DlgActivity))]
    public static class DlgActivitySystem
    {
        public static void RegisterUIEvent(this DlgActivity self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgActivity self, Entity contextData = null)
        {
            self.View.E_1Toggle.IsSelected(true);
        }

        private static void OnFunctionSetBtn(this DlgActivity self, int index)
        {
            UICommonHelper.SetToggleShow(self.View.E_1Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_2Toggle.gameObject, index == 1);
            UICommonHelper.SetToggleShow(self.View.E_3Toggle.gameObject, index == 2);
            UICommonHelper.SetToggleShow(self.View.E_4Toggle.gameObject, index == 3);
            UICommonHelper.SetToggleShow(self.View.E_5Toggle.gameObject, index == 4);

            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_ActivityYueKa.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_ActivityMaoXian.uiTransform.gameObject.SetActive(true);
                    break;
                case 2:
                    self.View.ES_ActivityToken.uiTransform.gameObject.SetActive(true);
                    break;
                case 3:

                    break;
                case 4:

                    break;
            }
        }
    }
}