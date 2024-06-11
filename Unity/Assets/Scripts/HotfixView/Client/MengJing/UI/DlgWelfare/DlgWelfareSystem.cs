using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_ActivityLogin))]
    [FriendOf(typeof (ES_WelfareTask))]
    [FriendOf(typeof (DlgWelfare))]
    public static class DlgWelfareSystem
    {
        public static void RegisterUIEvent(this DlgWelfare self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgWelfare self, Entity contextData = null)
        {
            self.View.E_0Toggle.IsSelected(true);
        }

        private static void OnFunctionSetBtn(this DlgWelfare self, int index)
        {
            UICommonHelper.SetToggleShow(self.View.E_0Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_1Toggle.gameObject, index == 1);
            UICommonHelper.SetToggleShow(self.View.E_2Toggle.gameObject, index == 2);
            UICommonHelper.SetToggleShow(self.View.E_3Toggle.gameObject, index == 3);
            UICommonHelper.SetToggleShow(self.View.E_4Toggle.gameObject, index == 4);

            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_ActivityLogin.uiTransform.gameObject.SetActive(true);
                    self.View.ES_ActivityLogin.OnUpdateUI();
                    break;
                case 1:
                    self.View.ES_WelfareTask.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }
    }
}