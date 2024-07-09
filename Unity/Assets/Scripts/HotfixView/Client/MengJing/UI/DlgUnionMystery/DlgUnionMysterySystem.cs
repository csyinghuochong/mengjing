using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_UnionMystery_A))]
    [FriendOf(typeof (DlgUnionMystery))]
    public static class DlgUnionMysterySystem
    {
        public static void RegisterUIEvent(this DlgUnionMystery self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgUnionMystery self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);

            self.View.ES_ModelShow.Camera.localPosition = new(0f, 115, 257f);
            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(self.Root().GetComponent<UIComponent>().CurrentNpcId);
            self.View.ES_ModelShow.ShowOtherModel("Npc/" + npcConfig.Asset.ToString()).Coroutine();
        }

        private static void OnFunctionSetBtn(this DlgUnionMystery self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_UnionMystery_A.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:

                    break;
            }
        }
    }
}