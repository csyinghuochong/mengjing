using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class DataUpdate_SkillReset_Refresh: AEvent<Scene, DataUpdate_SkillReset>
    {
        protected override async ETTask Run(Scene scene, DataUpdate_SkillReset args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgSkill>()?.OnSkillReset();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_SkillUpgrade_Refresh: AEvent<Scene, DataUpdate_SkillUpgrade>
    {
        protected override async ETTask Run(Scene scene, DataUpdate_SkillUpgrade args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgSkill>()?.OnSkillUpgrade(args.DataParamString);
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_SkillSetting_Refresh: AEvent<Scene, DataUpdate_SkillSetting>
    {
        protected override async ETTask Run(Scene scene, DataUpdate_SkillSetting args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgSkill>()?.OnSkillSetUpdate();
            await ETTask.CompletedTask;
        }
    }

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
                    self.View.ES_SkillLearn.OnUpdateUI();
                    break;
                case 1:
                    self.View.ES_SkillSet.uiTransform.gameObject.SetActive(true);
                    self.View.ES_SkillSet.UpdateSkillListUI();
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

        public static void Reddot_SkillUp(this DlgSkill self, int num)
        {
            // self.UIPageButton.SetButtonReddot((int)SkillPageEnum.SkillLearn, num > 0);
        }

        public static void OnSkillReset(this DlgSkill self)
        {
            if (self.View.ES_SkillLearn.uiTransform.gameObject.activeSelf)
            {
                self.View.ES_SkillLearn.UpdateLeftSp();
            }
        }

        public static void OnSkillUpgrade(this DlgSkill self, string DataParams)
        {
            if (self.View.ES_SkillLearn.uiTransform.gameObject.activeSelf)
            {
                self.View.ES_SkillLearn.OnSkillUpgrade(DataParams);
            }

            // self.ZoneScene().GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.SkillUp, "0");
        }

        public static void OnSkillSetUpdate(this DlgSkill self)
        {
            if (self.View.ES_SkillLearn.uiTransform.gameObject.activeSelf)
            {
                self.View.ES_SkillLearn.InitSkillList(0).Coroutine();
            }

            if (self.View.ES_SkillSet.uiTransform.gameObject.activeSelf)
            {
                self.View.ES_SkillSet.OnSkillSetting();
            }
        }
    }
}