using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgDungeonMapLevel))]
    public static class DlgDungeonMapLevelSystem
    {
        public static void RegisterUIEvent(this DlgDungeonMapLevel self)
        {
            self.View.E_ReturnButton.AddListener(self.OnReturnButtonClick);
        }

        public static void ShowWindow(this DlgDungeonMapLevel self, Entity contextData = null)
        {
        }

        private static void OnReturnButtonClick(this DlgDungeonMapLevel self)
        {
            DlgDungeonMap dungeonMap = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgDungeonMap>();
            dungeonMap.ReEnlarge();

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_DungeonMapLevel);
        }
    }
}