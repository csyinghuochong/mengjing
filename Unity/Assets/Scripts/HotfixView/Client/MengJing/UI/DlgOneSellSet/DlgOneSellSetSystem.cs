using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgOneSellSet))]
    public static class DlgOneSellSetSystem
    {
        public static void RegisterUIEvent(this DlgOneSellSet self)
        {
        }

        public static void ShowWindow(this DlgOneSellSet self, Entity contextData = null)
        {
        }
    }
}