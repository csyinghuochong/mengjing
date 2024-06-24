using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgLoading))]
    public static class DlgLoadingSystem
    {
        public static void RegisterUIEvent(this DlgLoading self)
        {
        }

        public static void ShowWindow(this DlgLoading self, Entity contextData = null)
        {
        }
    }
}