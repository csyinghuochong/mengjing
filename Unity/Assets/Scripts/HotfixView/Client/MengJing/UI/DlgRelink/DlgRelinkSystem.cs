using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgRelink))]
    public static class DlgRelinkSystem
    {
        public static void RegisterUIEvent(this DlgRelink self)
        {
        }

        public static void ShowWindow(this DlgRelink self, Entity contextData = null)
        {
        }
    }
}