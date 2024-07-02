using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgRunRaceMain))]
    public static class DlgRunRaceMainSystem
    {
        public static void RegisterUIEvent(this DlgRunRaceMain self)
        {
        }

        public static void ShowWindow(this DlgRunRaceMain self, Entity contextData = null)
        {
        }
    }
}