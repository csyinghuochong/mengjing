﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_SeasonHome))]
    [FriendOf(typeof (ES_SeasonTask))]
    [FriendOf(typeof (ES_SeasonJingHe))]
    [FriendOf(typeof (ES_SeasonStore))]
    [FriendOf(typeof (ES_SeasonTower))]
    [FriendOf(typeof (DlgSeason))]
    public static class DlgSeasonSystem
    {
        public static void RegisterUIEvent(this DlgSeason self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgSeason self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgSeason self, int index)
        {
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
                    self.View.ES_SeasonJingHe.uiTransform.gameObject.SetActive(true);
                    break;
                case 3:
                    self.View.ES_SeasonStore.uiTransform.gameObject.SetActive(true);
                    break;
                case 4:
                    self.View.ES_SeasonTower.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }
    }
}