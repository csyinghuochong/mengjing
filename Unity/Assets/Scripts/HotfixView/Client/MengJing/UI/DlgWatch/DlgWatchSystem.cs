using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_WatchEquip))]
    [FriendOf(typeof (ES_PetList))]
    [FriendOf(typeof (DlgWatch))]
    public static class DlgWatchSystem
    {
        public static void RegisterUIEvent(this DlgWatch self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgWatch self, Entity contextData = null)
        {
        }

        private static void OnFunctionSetBtn(this DlgWatch self, int index)
        {
            if (!self.CanClick)
            {
                return;
            }

            UICommonHelper.SetToggleShow(self.View.E_1Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_2Toggle.gameObject, index == 1);

            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_WatchEquip.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_PetList.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }

        public static void OnUpdateUI(this DlgWatch self, F2C_WatchPlayerResponse m2C_WatchPlayerResponse)
        {
            self.F2C_WatchPlayerResponse = m2C_WatchPlayerResponse;
            self.CanClick = true;
            self.View.E_1Toggle.IsSelected(true);
        }
    }
}