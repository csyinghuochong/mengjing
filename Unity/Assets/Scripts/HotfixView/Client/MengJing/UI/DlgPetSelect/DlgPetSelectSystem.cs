using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgPetSelect))]
    public static class DlgPetSelectSystem
    {
        public static void RegisterUIEvent(this DlgPetSelect self)
        {
        }

        public static void ShowWindow(this DlgPetSelect self, Entity contextData = null)
        {
        }

        public static void OnSetType(this DlgPetSelect self, PetOperationType bagOperationType)
        {
            // self.OperationType = bagOperationType;
            // self.OnInitData();
        }
    }
}