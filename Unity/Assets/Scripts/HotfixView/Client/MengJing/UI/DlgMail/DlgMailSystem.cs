using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgMail))]
    public static class DlgMailSystem
    {
        public static void RegisterUIEvent(this DlgMail self)
        {
        }

        public static void ShowWindow(this DlgMail self, Entity contextData = null)
        {
        }
    }
}