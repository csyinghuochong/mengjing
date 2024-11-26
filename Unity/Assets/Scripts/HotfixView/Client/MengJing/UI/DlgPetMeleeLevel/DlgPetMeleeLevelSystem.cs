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

            self.View.E_Level_1Button.AddListener(self.OnLevel);

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

        private static void OnLevel(this DlgPetMeleeLevel self)
        {
            self.View.E_RightBGImage.gameObject.SetActive(true);
        }

        private static void OnEnterMap(this DlgPetMeleeLevel self)
        {
            EnterMapHelper.RequestTransfer(self.Root(), SceneTypeEnum.PetMelee, 2700001, FubenDifficulty.Normal, "0").Coroutine();
            self.OnClose();
        }
    }
}