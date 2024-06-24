using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgPetMiningChallenge))]
    public static class DlgPetMiningChallengeSystem
    {
        public static void RegisterUIEvent(this DlgPetMiningChallenge self)
        {
        }

        public static void ShowWindow(this DlgPetMiningChallenge self, Entity contextData = null)
        {
        }

        public static void OnInitUI(this DlgPetMiningChallenge self, int mineType, int position, PetMingPlayerInfo petMingPlayerInfo)
        {
        }
    }
}