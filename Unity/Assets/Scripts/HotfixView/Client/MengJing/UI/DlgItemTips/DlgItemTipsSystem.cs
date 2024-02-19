using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgItemTipsViewComponent))]
    [FriendOf(typeof (DlgItemTips))]
    public static class DlgItemTipsSystem
    {
        public static void RegisterUIEvent(this DlgItemTips self)
        {
        }

        public static void ShowWindow(this DlgItemTips self, Entity contextData = null)
        {
        }

        public static void SetPosition(this DlgItemTips self, Vector2 vector2)
        {
            self.View.uiTransform.GetComponent<RectTransform>().anchoredPosition = vector2;
        }

        public static void RefreshInfo(this DlgItemTips self, BagInfo bagInfo, ItemOperateEnum itemOperateEnum)
        {
        }
    }
}