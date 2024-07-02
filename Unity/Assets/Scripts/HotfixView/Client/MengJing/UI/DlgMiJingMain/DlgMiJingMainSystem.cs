using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_MainTeamItem))]
    [FriendOf(typeof (DlgMiJingMain))]
    public static class DlgMiJingMainSystem
    {
        public static void RegisterUIEvent(this DlgMiJingMain self)
        {
            for (int i = 0; i < self.View.EG_DamageListNodeRectTransform.childCount; i++)
            {
                GameObject gameObject = self.View.EG_DamageListNodeRectTransform.GetChild(i).gameObject;
                Scroll_Item_MainTeamItem scrollItemMainTeamItem = self.AddChild<Scroll_Item_MainTeamItem>();
                scrollItemMainTeamItem.uiTransform = gameObject.transform;
                self.TeamUIList.Add(scrollItemMainTeamItem);
                self.TeamUIList[i].uiTransform.gameObject.SetActive(false);
            }
        }

        public static void ShowWindow(this DlgMiJingMain self, Entity contextData = null)
        {
        }

        public static void OnUpdateDamage(this DlgMiJingMain self, M2C_SyncMiJingDamage message)
        {
            for (int i = 0; i < message.DamageList.Count; i++)
            {
                self.TeamUIList[i].OnUpdateItem(message.DamageList[i]);
            }
        }
    }
}