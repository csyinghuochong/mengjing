using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgPetEggChouKaProbExplain))]
    public static class DlgPetEggChouKaProbExplainSystem
    {
        public static void RegisterUIEvent(this DlgPetEggChouKaProbExplain self)
        {
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_Close);
        }

        public static void ShowWindow(this DlgPetEggChouKaProbExplain self, Entity contextData = null)
        {
        }

        public static void OnBtn_Close(this DlgPetEggChouKaProbExplain self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetEggChouKaProbExplain);
        }
    }
}