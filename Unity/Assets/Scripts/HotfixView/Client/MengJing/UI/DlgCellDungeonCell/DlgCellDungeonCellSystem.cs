using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgCellDungeonCell))]
    public static class DlgCellDungeonCellSystem
    {
        public static void RegisterUIEvent(this DlgCellDungeonCell self)
        {
            self.View.E_CloseButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CellDungeonCell); });
        }

        public static void ShowWindow(this DlgCellDungeonCell self, Entity contextData = null)
        {
        }
    }
}