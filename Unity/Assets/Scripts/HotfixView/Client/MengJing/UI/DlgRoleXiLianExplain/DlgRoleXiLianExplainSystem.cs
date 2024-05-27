using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgRoleXiLianExplain))]
    public static class DlgRoleXiLianExplainSystem
    {
        public static void RegisterUIEvent(this DlgRoleXiLianExplain self)
        {
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_Close);
        }

        public static void ShowWindow(this DlgRoleXiLianExplain self, Entity contextData = null)
        {
        }

        public static void OnBtn_Close(this DlgRoleXiLianExplain self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_RoleXiLianExplain);
        }
    }
}