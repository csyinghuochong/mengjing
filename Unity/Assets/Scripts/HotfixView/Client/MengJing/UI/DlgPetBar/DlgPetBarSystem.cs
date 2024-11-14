﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(ES_PetBarSet))]
    [FriendOf(typeof(ES_PetBarUpgrade))]
    [FriendOf(typeof(DlgPetBar))]
    public static class DlgPetBarSystem
    {
        public static void RegisterUIEvent(this DlgPetBar self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgPetBar self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgPetBar self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.ES_PetBarSet.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.ES_PetBarUpgrade.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }
    }
}