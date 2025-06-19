using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgFunction))]
    public static class DlgFunctionSystem
    {
        public static void RegisterUIEvent(this DlgFunction self)
        {
            self.View.E_CloseButton.AddListener(self.OnClose);

            self.View.E_PetMeleeButton.AddListener(self.OnPetMelee);
            self.View.E_DragonDungeonButton.AddListener(self.OnDragonDungeonButton);

            self.View.E_TaskButton.AddListener(self.OnTask);
            self.View.E_RoseEquipButton.AddListener(self.OnRoseEquip);
            self.View.E_PetButton.AddListener(self.OnPet);
            self.View.E_RoseSkillButton.AddListener(self.OnRoseSkill);
            self.View.E_FriendButton.AddListener(self.OnFriend);
            self.View.E_ChengJiuButton.AddListener(self.OnChengJiu);
            self.View.E_PetBarButton.AddListener(self.OnPetBar);
            self.View.E_SettingButton.AddListener(self.OnSetting);
            self.View.E_UnionButton.AddListener(self.OnUnion);
            self.View.E_SingleHappyButton.AddListenerAsync(self.OnSingleHappy);

            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.RegisterReddot(ReddotType.Friend, self.Reddot_Frined);
            redPointComponent.RegisterReddot(ReddotType.RolePoint, self.Reddot_RolePoint);
            redPointComponent.RegisterReddot(ReddotType.SkillUp, self.Reddot_SkillUp);

            ReddotComponentC reddotComponent = self.Root().GetComponent<ReddotComponentC>();
            reddotComponent.UpdateReddont(ReddotType.FriendApply);
            reddotComponent.UpdateReddont(ReddotType.FriendChat);
            reddotComponent.UpdateReddont(ReddotType.RolePoint);
            reddotComponent.UpdateReddont(ReddotType.SkillUp);
        }

        public static void ShowWindow(this DlgFunction self, Entity contextData = null)
        {
            self.ExitCamera = true;
            
            self.ShowGuide().Coroutine();
        }

        private static async ETTask ShowGuide(this DlgFunction self)
        {
            await self.Root().GetComponent<TimerComponent>().WaitAsync(10);
            self.Root().GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.OpenUI, "UIFunction");
        }
        
        public static void BeforeUnload(this DlgFunction self)
        {
            if (self.ExitCamera)
            {
                self.Root().CurrentScene().GetComponent<MJCameraComponent>().SetBuildExit();
            }

            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.UnRegisterReddot(ReddotType.Friend, self.Reddot_Frined);
            redPointComponent.UnRegisterReddot(ReddotType.RolePoint, self.Reddot_RolePoint);
            redPointComponent.UnRegisterReddot(ReddotType.SkillUp, self.Reddot_SkillUp);
        }

        private static void Reddot_Frined(this DlgFunction self, int num)
        {
            self.View.E_FriendButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        private static void Reddot_RolePoint(this DlgFunction self, int num)
        {
            self.View.E_RoseEquipButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        private static void Reddot_SkillUp(this DlgFunction self, int num)
        {
            self.View.E_RoseSkillButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        private static void OnClose(this DlgFunction self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Function);
        }

        private static void OnTask(this DlgFunction self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Task).Coroutine();
            self.OnClose();
        }

        private static void OnRoseEquip(this DlgFunction self)
        {
            Scene root = self.Root();
            if (SettingData.ModelShow == 0)
            {
                root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Role).Coroutine();
            }
            else
            {
                self.ExitCamera = false;
                MJCameraComponent cameraComponent = root.CurrentScene().GetComponent<MJCameraComponent>();
                UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
                uiComponent.HideWindow(WindowID.WindowID_Main);
                //GlobalComponent globalComponent = self.Root().GetComponent<GlobalComponent>();
                //globalComponent.BloodRoot.gameObject.SetActive(false);
                cameraComponent.SetBuildEnter(UnitHelper.GetMyUnitFromClientScene(root), CameraBuildType.Type_4,
                    () =>
                    {
                        uiComponent.ShowWindow(WindowID.WindowID_Role);
                        uiComponent.ShowWindow(WindowID.WindowID_Main);
                        //globalComponent.BloodRoot.gameObject.SetActive(true);
                    });
            }

            self.OnClose();
        }

        private static void OnPetMelee(this DlgFunction self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetMeleeLevel).Coroutine();
            self.OnClose();
        }

        private static void OnDragonDungeonButton(this DlgFunction self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_DragonDungeon).Coroutine();
            self.OnClose();
        }

        private static async ETTask OnSingleHappy(this DlgFunction self)
        {
            int sceneId = BattleHelper.GetSceneIdByType(MapTypeEnum.SingleHappy);
            int errorCode = await  EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.SingleHappy, sceneId);
            if (errorCode == ErrorCode.ERR_Success)
            {
                self.ExitCamera = false;
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Function, false);
                return;
            }

            HintHelp.ShowErrorHint(self.Root(), errorCode);
        }

        private static void OnPet(this DlgFunction self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Pet).Coroutine();
            self.OnClose();
        }

        private static void OnRoseSkill(this DlgFunction self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Skill).Coroutine();
            self.OnClose();
        }

        private static void OnFriend(this DlgFunction self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Friend).Coroutine();
            self.OnClose();
        }

        private static void OnChengJiu(this DlgFunction self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_ChengJiu).Coroutine();
            self.OnClose();
        }

        private static void OnPetBar(this DlgFunction self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetBar).Coroutine();
            self.OnClose();
        }

        private static void OnSetting(this DlgFunction self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Setting).Coroutine();
            self.OnClose();
        }

        private static void OnUnion(this DlgFunction self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Union).Coroutine();
            self.OnClose();
        }
    }
}