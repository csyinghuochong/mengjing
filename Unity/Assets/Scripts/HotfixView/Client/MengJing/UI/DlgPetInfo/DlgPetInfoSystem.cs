using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgPetInfo))]
    public static class DlgPetInfoSystem
    {
        public static void RegisterUIEvent(this DlgPetInfo self)
        {
            self.View.E_ButtonCloseButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetInfo); });
        }

        public static void ShowWindow(this DlgPetInfo self, Entity contextData = null)
        {
        }
    }
}