using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_JiaYuanPetWalk))]
    [FriendOf(typeof (DlgJiaYuanPet))]
    public static class DlgJiaYuanPetSystem
    {
        public static void RegisterUIEvent(this DlgJiaYuanPet self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgJiaYuanPet self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgJiaYuanPet self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    
                    break;
                case 1:

                    break;
            }
        }
    }
}