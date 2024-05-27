using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgRoleXiLianNumReward))]
    public static class DlgRoleXiLianNumRewardSystem
    {
        public static void RegisterUIEvent(this DlgRoleXiLianNumReward self)
        {
            self.View.E_ChouKaRewardItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnChouKaRewardItemsRefresh);
            self.View.E_Btn_CloseButton.AddListener(self.OnClose);
        }

        public static void ShowWindow(this DlgRoleXiLianNumReward self, Entity contextData = null)
        {
            self.OnInitUI();
        }

        private static void OnInitUI(this DlgRoleXiLianNumReward self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            self.View.E_TextTitleText.text = $"今日洗练次数:{unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.ItemXiLianNumber)}";

            self.ShowInfo.Clear();
            foreach (KeyValuePair<int, string> keyValuePair in ConfigData.ItemXiLianNumReward)
            {
                self.ShowInfo.Add(keyValuePair.Key);
            }

            self.AddUIScrollItems(ref self.ScrollItemChouKaRewardItems, self.ShowInfo.Count);
            self.View.E_ChouKaRewardItemsLoopVerticalScrollRect.SetVisible(true, self.ShowInfo.Count);
        }

        private static void OnChouKaRewardItemsRefresh(this DlgRoleXiLianNumReward self, Transform transform, int index)
        {
            Scroll_Item_ChouKaRewardItem scrollItemChouKaRewardItem = self.ScrollItemChouKaRewardItems[index].BindTrans(transform);
            scrollItemChouKaRewardItem.OnUpdateUI(self.ShowInfo[index]);
        }

        private static void OnClose(this DlgRoleXiLianNumReward self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_RoleXiLianNumReward);
        }
    }
}