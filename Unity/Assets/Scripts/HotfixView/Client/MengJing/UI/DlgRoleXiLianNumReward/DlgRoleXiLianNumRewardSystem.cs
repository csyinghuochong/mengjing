using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_RoleXiLianNumRewardItem))]
    [FriendOf(typeof(DlgRoleXiLianNumReward))]
    public static class DlgRoleXiLianNumRewardSystem
    {
        public static void RegisterUIEvent(this DlgRoleXiLianNumReward self)
        {
            self.View.E_RoleXiLianNumRewardItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRoleXiLianNumRewardItemsRefresh);
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_CloseButton);
            
            self.OnInitUI();
        }

        public static void ShowWindow(this DlgRoleXiLianNumReward self, Entity contextData = null)
        {
        }

        private static void OnInitUI(this DlgRoleXiLianNumReward self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            using (zstring.Block())
            {
                self.View.E_TextTitleText.text =
                        zstring.Format("今日洗练次数:{0}", unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.ItemXiLianNumber));
            }

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
            foreach (Scroll_Item_RoleXiLianNumRewardItem item in self.ScrollItemRoleXiLianNumRewardItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_RoleXiLianNumRewardItem scrollItemRoleXiLianNumRewardItem = self.ScrollItemRoleXiLianNumRewardItems[index].BindTrans(transform);
            scrollItemRoleXiLianNumRewardItem.OnUpdateUI(self.ShowInfo[index]);
        }

        private static void OnBtn_CloseButton(this DlgRoleXiLianNumReward self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_RoleXiLianNumReward);
        }
    }
}
