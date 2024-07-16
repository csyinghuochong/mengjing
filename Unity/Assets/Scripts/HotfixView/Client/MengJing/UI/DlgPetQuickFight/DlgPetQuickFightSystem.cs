using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgPetQuickFight))]
    public static class DlgPetQuickFightSystem
    {
        public static void RegisterUIEvent(this DlgPetQuickFight self)
        {
        }

        public static void ShowWindow(this DlgPetQuickFight self, Entity contextData = null)
        {
        }
    }
}