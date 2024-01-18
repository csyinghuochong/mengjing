using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgMain))]
    public static class DlgMainSystem
    {
        public static void RegisterUIEvent(this DlgMain self)
        {
            self.View.E_ShrinkButton.AddListener(self.OnShrinkButton);
            self.View.E_RoseEquipButton.AddListener(self.OnRoseEquipButton);
            self.View.E_PetButton.AddListener(self.OnPetButton);
            self.View.E_RoseSkillButton.AddListener(self.OnRoseSkillButton);
            self.View.E_TaskButton.AddListener(self.OnTaskButton);
            self.View.E_FriendButton.AddListener(self.OnFriendButton);
            self.View.E_ChengJiuButton.AddListener(self.OnChengJiuButton);
        }

        public static void ShowWindow(this DlgMain self, Entity contextData = null)
        {
        }

        private static void OnShrinkButton(this DlgMain self)
        {
            bool isShow = !self.View.EG_LeftBottomBtnsRectTransform.gameObject.activeSelf;
            self.View.EG_LeftBottomBtnsRectTransform.gameObject.SetActive(isShow);
        }

        private static void OnRoseEquipButton(this DlgMain self)
        {
            Log.Debug("打开背包界面！！！");
        }

        private static void OnPetButton(this DlgMain self)
        {
            Log.Debug("打开宠物界面！！！");
        }

        private static void OnRoseSkillButton(this DlgMain self)
        {
            Log.Debug("打开技能界面！！！");
        }

        private static void OnTaskButton(this DlgMain self)
        {
            Log.Debug("打开任务界面！！！");
        }

        private static void OnFriendButton(this DlgMain self)
        {
            Log.Debug("打开社交界面！！！");
        }

        private static void OnChengJiuButton(this DlgMain self)
        {
            Log.Debug("打开成就界面！！！");
        }
    }
}