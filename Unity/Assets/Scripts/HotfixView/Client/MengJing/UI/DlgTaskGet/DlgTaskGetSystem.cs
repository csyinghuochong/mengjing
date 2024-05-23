using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgTaskGet))]
    public static class DlgTaskGetSystem
    {
        public static void RegisterUIEvent(this DlgTaskGet self)
        {
        }

        public static void ShowWindow(this DlgTaskGet self, Entity contextData = null)
        {
        }
    }
}