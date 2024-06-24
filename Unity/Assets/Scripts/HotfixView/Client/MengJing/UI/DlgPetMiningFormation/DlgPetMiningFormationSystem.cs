using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgPetMiningFormation))]
    public static class DlgPetMiningFormationSystem
    {
        public static void RegisterUIEvent(this DlgPetMiningFormation self)
        {
        }

        public static void ShowWindow(this DlgPetMiningFormation self, Entity contextData = null)
        {
        }

        public static void OnInitUI(this DlgPetMiningFormation self, int sceneType, int teamid, Action action)
        {
        }
    }
}