using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgTowerOfSealMain))]
    public static class DlgTowerOfSealMainSystem
    {
        public static void RegisterUIEvent(this DlgTowerOfSealMain self)
        {
        }

        public static void ShowWindow(this DlgTowerOfSealMain self, Entity contextData = null)
        {
        }
    }
}