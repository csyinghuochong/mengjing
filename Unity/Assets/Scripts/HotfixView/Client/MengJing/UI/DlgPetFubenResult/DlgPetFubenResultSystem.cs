using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgPetFubenResult))]
    public static class DlgPetFubenResultSystem
    {
        public static void RegisterUIEvent(this DlgPetFubenResult self)
        {
        }

        public static void ShowWindow(this DlgPetFubenResult self, Entity contextData = null)
        {
        }

        public static void OnUpdateUI(this DlgPetFubenResult self, M2C_FubenSettlement message)
        {
        }
    }
}