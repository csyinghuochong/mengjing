using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgRechargeReward))]
    public static class DlgRechargeRewardSystem
    {
        public static void RegisterUIEvent(this DlgRechargeReward self)
        {
        }

        public static void ShowWindow(this DlgRechargeReward self, Entity contextData = null)
        {
        }
    }
}