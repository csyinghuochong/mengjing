using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgBattleRecruit))]
    public static class DlgBattleRecruitSystem
    {
        public static void RegisterUIEvent(this DlgBattleRecruit self)
        {
        }

        public static void ShowWindow(this DlgBattleRecruit self, Entity contextData = null)
        {
        }
    }
}