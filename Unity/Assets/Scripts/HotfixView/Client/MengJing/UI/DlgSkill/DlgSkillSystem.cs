using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_SkillLearn))]
    [FriendOf(typeof (ES_SkillSet))]
    [FriendOf(typeof (ES_SkillMake))]
    [FriendOf(typeof (ES_SkillTianFu))]
    [FriendOf(typeof (ES_SkillLifeShield))]
    [FriendOf(typeof (DlgSkill))]
    public static class DlgSkillSystem
    {
        public static void RegisterUIEvent(this DlgSkill self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgSkill self, Entity contextData = null)
        {
            self.View.E_Button_0Toggle.IsSelected(true);

            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.ShowWindow(WindowID.WindowID_HuoBiSet);
            uiComponent.GetDlgLogic<DlgHuoBiSet>().AddCloseEvent(self.OnCloseButton);
        }

        private static void OnFunctionSetBtn(this DlgSkill self, int index)
        {
            UICommonHelper.SetToggleShow(self.View.E_Button_0Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_Button_1Toggle.gameObject, index == 1);
            UICommonHelper.SetToggleShow(self.View.E_Button_2Toggle.gameObject, index == 2);
            UICommonHelper.SetToggleShow(self.View.E_Button_3Toggle.gameObject, index == 3);
            UICommonHelper.SetToggleShow(self.View.E_Button_4Toggle.gameObject, index == 4);

            UICommonHelper.HideChildren(self.View.EG_SubViewNodeRectTransform);

            switch (index)
            {
                case 0:
                    self.View.ES_SkillLearn.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_SkillSet.uiTransform.gameObject.SetActive(true);
                    break;
                case 2:
                    self.View.ES_SkillTianFu.uiTransform.gameObject.SetActive(true);
                    break;
                case 3:
                    self.View.ES_SkillMake.uiTransform.gameObject.SetActive(true);
                    break;
                case 4:
                    self.View.ES_SkillLifeShield.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }

        private static void OnCloseButton(this DlgSkill self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

            uiComponent.CloseWindow(WindowID.WindowID_Skill);
        }
    }
}