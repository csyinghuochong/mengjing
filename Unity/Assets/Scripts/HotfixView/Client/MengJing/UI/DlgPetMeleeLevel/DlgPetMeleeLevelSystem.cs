using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgPetMeleeLevel))]
    public static class DlgPetMeleeLevelSystem
    {
        public static void RegisterUIEvent(this DlgPetMeleeLevel self)
        {
            self.View.E_CloseButton.AddListener(self.OnClose);
            self.View.E_PetMeleeButton.AddListener(self.OnPetMelee);

            self.View.E_Level_1Button.AddListener(() => self.OnLevel(2700001));
            self.View.E_Level_2Button.AddListener(() => self.OnLevel(2700002));

            
            
            self.View.E_EnterMapButton.AddListener(self.OnEnterMap);
        }

        public static void ShowWindow(this DlgPetMeleeLevel self, Entity contextData = null)
        {
            self.View.E_RightBGImage.gameObject.SetActive(false);
        }

        private static void OnClose(this DlgPetMeleeLevel self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetMeleeLevel);
        }

        private static void OnPetMelee(this DlgPetMeleeLevel self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetMelee).Coroutine();
        }

        private static void OnLevel(this DlgPetMeleeLevel self, int sceneId)
        {
            self.SceneId = sceneId;
            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneId);
            self.View.E_LevelNameText.text = sceneConfig.Name;
            self.View.ES_RewardList.Refresh(sceneConfig.RewardShow);

            // 判断是否通关、领取奖励
            self.View.E_EnterMapButton.gameObject.SetActive(true);
            self.View.E_ReceiveButton.gameObject.SetActive(false);
            self.View.E_ReceivedText.gameObject.SetActive(false);

            self.View.E_RightBGImage.gameObject.SetActive(true);
        }

        private static void OnEnterMap(this DlgPetMeleeLevel self)
        {
            EnterMapHelper.RequestTransfer(self.Root(), SceneTypeEnum.PetMelee, self.SceneId, FubenDifficulty.Normal, "0").Coroutine();
            self.OnClose();
        }
    }
}