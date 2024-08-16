using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgTowerOfSealJump))]
    public static class DlgTowerOfSealJumpSystem
    {
        public static void RegisterUIEvent(this DlgTowerOfSealJump self)
        {
        }

        public static void ShowWindow(this DlgTowerOfSealJump self, Entity contextData = null)
        {
        }
    }
}