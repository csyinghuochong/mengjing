using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_SeasonHome))]
    [FriendOf(typeof (ES_SeasonTask))]
    [FriendOf(typeof (DlgSeason))]
    public static class DlgSeasonSystem
    {
        public static void RegisterUIEvent(this DlgSeason self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgSeason self, Entity contextData = null)
        {
            self.View.E_HomeToggle.IsSelected(true);
        }

        private static void OnFunctionSetBtn(this DlgSeason self, int index)
        {
            UICommonHelper.SetToggleShow(self.View.E_HomeToggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_TaskToggle.gameObject, index == 1);
            UICommonHelper.SetToggleShow(self.View.E_JingHeToggle.gameObject, index == 2);
            UICommonHelper.SetToggleShow(self.View.E_ShopToggle.gameObject, index == 3);
            UICommonHelper.SetToggleShow(self.View.E_TowerToggle.gameObject, index == 4);

            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_SeasonHome.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_SeasonTask.uiTransform.gameObject.SetActive(true);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }
    }
}