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
            self.View.E_RoleXiLianNumRewardItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRoleXiLianNumRewardItemsRefresh);
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

            self.AddUIScrollItems(ref self.ScrollItemRoleXiLianNumRewardItems, self.ShowInfo.Count);
            self.View.E_RoleXiLianNumRewardItemsLoopVerticalScrollRect.SetVisible(true, self.ShowInfo.Count);
        }

        private static void OnRoleXiLianNumRewardItemsRefresh(this DlgRoleXiLianNumReward self, Transform transform, int index)
        {
            Scroll_Item_RoleXiLianNumRewardItem scrollItemRoleXiLianNumRewardItem = self.ScrollItemRoleXiLianNumRewardItems[index].BindTrans(transform);
            scrollItemRoleXiLianNumRewardItem.OnUpdateUI(self.ShowInfo[index]);
        }

        private static void OnClose(this DlgRoleXiLianNumReward self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_RoleXiLianNumReward);
        }
    }
}