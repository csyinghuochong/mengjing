using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgEquipDuiBiTips))]
    public static class DlgEquipDuiBiTipsSystem
    {
        public static void RegisterUIEvent(this DlgEquipDuiBiTips self)
        {
        }

        public static void ShowWindow(this DlgEquipDuiBiTips self, Entity contextData = null)
        {
        }

        public static async ETTask OnUpdateDuiBiUI(this DlgEquipDuiBiTips self, BagInfo bagInfo_1, ShowItemTips args, int weight,
        ItemOperateEnum itemOperateEnum)
        {
            await ETTask.CompletedTask;
        }

        public static async ETTask OnUpdateAppraisalUI(this DlgEquipDuiBiTips self, ShowItemTips args)
        {
            await ETTask.CompletedTask;
        }

        public static async ETTask OnUpdateEquipUI(this DlgEquipDuiBiTips self, ShowItemTips args)
        {
            await ETTask.CompletedTask;
        }
    }
}