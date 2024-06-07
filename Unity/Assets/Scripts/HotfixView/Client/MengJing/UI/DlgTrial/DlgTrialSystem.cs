using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_TrialDungeon))]
    [FriendOf(typeof (ES_TrialRank))]
    [FriendOf(typeof (DlgTrial))]
    public static class DlgTrialSystem
    {
        public static void RegisterUIEvent(this DlgTrial self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgTrial self, Entity contextData = null)
        {
            self.View.E_0Toggle.IsSelected(true);
        }

        private static void OnFunctionSetBtn(this DlgTrial self, int index)
        {
            UICommonHelper.SetToggleShow(self.View.E_0Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_1Toggle.gameObject, index == 1);

            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_TrialDungeon.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_TrialRank.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }
    }
}