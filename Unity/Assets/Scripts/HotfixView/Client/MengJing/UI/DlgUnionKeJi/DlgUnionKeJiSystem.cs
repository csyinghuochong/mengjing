using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_UnionKeJiResearch))]
    [FriendOf(typeof (DlgUnionKeJi))]
    public static class DlgUnionKeJiSystem
    {
        public static void RegisterUIEvent(this DlgUnionKeJi self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgUnionKeJi self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgUnionKeJi self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_UnionKeJiResearch.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    break;
            }
        }
    }
}