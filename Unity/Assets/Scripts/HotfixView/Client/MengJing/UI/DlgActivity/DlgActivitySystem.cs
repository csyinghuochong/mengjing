using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgActivity))]
    public static class DlgActivitySystem
    {
        public static void RegisterUIEvent(this DlgActivity self)
        {
        }

        public static void ShowWindow(this DlgActivity self, Entity contextData = null)
        {
        }
    }
}