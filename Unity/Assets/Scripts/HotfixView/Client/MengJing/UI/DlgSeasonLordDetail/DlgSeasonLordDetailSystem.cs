using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgSeasonLordDetail))]
    public static class DlgSeasonLordDetailSystem
    {
        public static void RegisterUIEvent(this DlgSeasonLordDetail self)
        {
        }

        public static void ShowWindow(this DlgSeasonLordDetail self, Entity contextData = null)
        {
        }
    }
}