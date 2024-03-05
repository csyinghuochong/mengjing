using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_ItemAppraisalTips))]
    [FriendOf(typeof (DlgEquipDuiBiTips))]
    public static class DlgEquipDuiBiTipsSystem
    {
        public static void RegisterUIEvent(this DlgEquipDuiBiTips self)
        {
            self.View.E_CloseButton.AddListener(self.OnCloseButton);
        }

        public static void ShowWindow(this DlgEquipDuiBiTips self, Entity contextData = null)
        {
        }

        private static void OnCloseButton(this DlgEquipDuiBiTips self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
        }

        public static void OnUpdateDuiBiUI(this DlgEquipDuiBiTips self, BagInfo bagInfo_1, ShowItemTips args, int weight,
        ItemOperateEnum itemOperateEnum)
        {
            
        }

        public static void OnUpdateAppraisalUI(this DlgEquipDuiBiTips self, ShowItemTips args)
        {
            self.View.ES_ItemAppraisalTips.uiTransform.gameObject.SetActive(true);
            self.View.ES_ItemAppraisalTips.RefreshInfo(args.BagInfo, args.ItemOperateEnum);
        }

        public static async ETTask OnUpdateEquipUI(this DlgEquipDuiBiTips self, ShowItemTips args)
        {
            await ETTask.CompletedTask;
        }
    }
}