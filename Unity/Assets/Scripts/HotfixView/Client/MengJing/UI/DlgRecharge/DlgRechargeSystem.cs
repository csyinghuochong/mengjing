using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgRecharge))]
    public static class DlgRechargeSystem
    {
        public static void RegisterUIEvent(this DlgRecharge self)
        {
        }

        public static void ShowWindow(this DlgRecharge self, Entity contextData = null)
        {
        }
    }
}