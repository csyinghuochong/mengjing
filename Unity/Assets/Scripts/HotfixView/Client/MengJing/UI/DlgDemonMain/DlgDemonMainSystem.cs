using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgDemonMain))]
    public static class DlgDemonMainSystem
    {
        public static void RegisterUIEvent(this DlgDemonMain self)
        {
        }

        public static void ShowWindow(this DlgDemonMain self, Entity contextData = null)
        {
        }
    }
}