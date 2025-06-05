using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class DataUpdate_SkillReset_Refresh : AEvent<Scene, SkillReset>
    {
        protected override async ETTask Run(Scene scene, SkillReset args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgSkill>()?.OnSkillReset();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_SkillUpgrade_Refresh : AEvent<Scene, SkillUpgrade>
    {
        protected override async ETTask Run(Scene scene, SkillUpgrade args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgSkill>()?.OnSkillUpgrade(args.DataParamString);
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_SkillSetting_Refresh : AEvent<Scene, SkillSetting>
    {
        protected override async ETTask Run(Scene scene, SkillSetting args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgSkill>()?.OnSkillSetUpdate();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_OnActiveTianFu_Refresh : AEvent<Scene, OnActiveTianFu>
    {
        protected override async ETTask Run(Scene scene, OnActiveTianFu args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgSkill>()?.OnActiveTianFu();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_HuiShouSelect_Refresh : AEvent<Scene, HuiShouSelect>
    {
        protected override async ETTask Run(Scene scene, HuiShouSelect args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgSkill>()?.OnHuiShouSelect(args.DataParamString);
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(ES_SkillLearn))]
    [FriendOf(typeof(ES_SkillSet))]
    [FriendOf(typeof(ES_SkillMake))]
    [FriendOf(typeof(ES_SkillTianFu))]
    [FriendOf(typeof(ES_SkillLifeShield))]
    [FriendOf(typeof(DlgSkill))]
    public static class DlgSkillSystem
    {
        public static void RegisterUIEvent(this DlgSkill self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.RegisterReddot(ReddotType.SkillUp, self.Reddot_SkillUp);
            
            IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0f));
        }

        public static void ShowWindow(this DlgSkill self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgSkill self)
        {
            ReddotViewComponent redPointComponent = self.Root()?.GetComponent<ReddotViewComponent>();
            redPointComponent?.UnRegisterReddot(ReddotType.SkillUp, self.Reddot_SkillUp);
        }

        private static void OnFunctionSetBtn(this DlgSkill self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewNodeRectTransform);

            switch (index)
            {
                case 0:
                    self.View.ES_SkillLearn.uiTransform.gameObject.SetActive(true);
                    self.View.ES_SkillLearn.E_BtnItemTypeSetToggleGroup.OnSelectIndex(0);
                    break;
                case 1:
                    self.View.ES_SkillSet.uiTransform.gameObject.SetActive(true);
                    self.View.ES_SkillSet.UpdateSkillListUI();
                    break;
                case 2:
                    self.View.ES_SkillTianFu.uiTransform.gameObject.SetActive(true);
                    break;
                case 3:
                    self.View.ES_SkillLifeShield.uiTransform.gameObject.SetActive(true);
                    self.View.ES_SkillLifeShield.OnUpdateUI();
                    break;
                case 4:
                    self.View.ES_SkillMake.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }

        public static void Reddot_SkillUp(this DlgSkill self, int num)
        {
            self.View.E_Type_0Toggle.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void OnActiveTianFu(this DlgSkill self)
        {
            if (self.View.ES_SkillTianFu.uiTransform.gameObject.activeSelf)
            {
                self.View.ES_SkillTianFu.RefreshTianFuList();
            }
        }

        public static void OnSkillReset(this DlgSkill self)
        {
            if (self.View.ES_SkillLearn.uiTransform.gameObject.activeSelf)
            {
                self.View.ES_SkillLearn.E_BtnItemTypeSetToggleGroup.OnSelectIndex(0);
            }
        }

        public static void OnSkillUpgrade(this DlgSkill self, string DataParams)
        {
            if (self.View.ES_SkillLearn.uiTransform.gameObject.activeSelf)
            {
                self.View.ES_SkillLearn.OnSkillUpgrade(DataParams);
            }

            self.Root().GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.SkillUp, "0");
        }

        public static void OnSkillSetUpdate(this DlgSkill self)
        {
            if (self.View.ES_SkillLearn.uiTransform.gameObject.activeSelf)
            {
                self.View.ES_SkillLearn.E_BtnItemTypeSetToggleGroup.OnSelectIndex(0);
            }

            if (self.View.ES_SkillSet.uiTransform.gameObject.activeSelf)
            {
                self.View.ES_SkillSet.OnSkillSetting();
            }
        }

        public static void OnHuiShouSelect(this DlgSkill self, string dataParams)
        {
            if (self.View.ES_SkillMake.uiTransform.gameObject.activeSelf)
            {
                self.View.ES_SkillMake.OnHuiShouSelect(dataParams);
            }
        }
    }
}