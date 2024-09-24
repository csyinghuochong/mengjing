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
            self.View.E_CloseButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Function);
            });
            
            self.View.E_TaskButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Task).Coroutine();
            });
            self.View.E_RoseEquipButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Role).Coroutine();
            });
            self.View.E_PetButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Pet).Coroutine();
            });
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
        }

        public static void ShowWindow(this DlgFunction self, Entity contextData = null)
        {
        }
    }
}