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
            self.View.E_CloseButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Function); });

            self.View.E_TaskButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Task).Coroutine();
            });
            self.View.E_RoseEquipButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Role).Coroutine();
            });
            self.View.E_PetButton.AddListener(() => { self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Pet).Coroutine(); });
            self.View.E_RoseSkillButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Skill).Coroutine();
            });
            self.View.E_FriendButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Friend).Coroutine();
            });
            self.View.E_ChengJiuButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_ChengJiu).Coroutine();
            });

            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.RegisterReddot(ReddotType.Friend, self.Reddot_Frined);
            redPointComponent.RegisterReddot(ReddotType.RolePoint, self.Reddot_RolePoint);
            redPointComponent.RegisterReddot(ReddotType.SkillUp, self.Reddot_SkillUp);
        }

        public static void ShowWindow(this DlgFunction self, Entity contextData = null)
        {
            ReddotComponentC reddotComponent = self.Root().GetComponent<ReddotComponentC>();
            reddotComponent.UpdateReddont(ReddotType.FriendApply);
            reddotComponent.UpdateReddont(ReddotType.FriendChat);
            reddotComponent.UpdateReddont(ReddotType.RolePoint);
            reddotComponent.UpdateReddont(ReddotType.SkillUp);
        }

        public static void BeforeUnload(this DlgFunction self)
        {
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
    }
}