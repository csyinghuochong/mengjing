using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ChouKaRewardItem))]
    [FriendOf(typeof(DlgChouKaReward))]
    public static class DlgChouKaRewardSystem
    {
        public static void RegisterUIEvent(this DlgChouKaReward self)
        {
            self.View.E_ChouKaRewardItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnChouKaRewardItemsRefresh);
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_CloseButton);
            self.OnInitUI();
        }

        public static void ShowWindow(this DlgChouKaReward self, Entity contextData = null)
        {
        }

        public static void OnInitUI(this DlgChouKaReward self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            using (zstring.Block())
            {
                self.View.E_TextTitleText.text = zstring.Format("今日探宝次数:{0}", unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.ChouKa));
            }

            self.TakeCardRewardConfigs = TakeCardRewardConfigCategory.Instance.GetAll().Values.ToList();

            self.AddUIScrollItems(ref self.ScrollItemChouKaRewardItems, self.TakeCardRewardConfigs.Count);
            self.View.E_ChouKaRewardItemsLoopVerticalScrollRect.SetVisible(true, self.TakeCardRewardConfigs.Count);
        }

        private static void OnChouKaRewardItemsRefresh(this DlgChouKaReward self, Transform transform, int index)
        {
            foreach (Scroll_Item_ChouKaRewardItem item in self.ScrollItemChouKaRewardItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_ChouKaRewardItem scrollItemRoleXiLianNumRewardItem = self.ScrollItemChouKaRewardItems[index].BindTrans(transform);
            scrollItemRoleXiLianNumRewardItem.OnUpdateUI(self.TakeCardRewardConfigs[index]);
        }

        private static void OnBtn_CloseButton(this DlgChouKaReward self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ChouKaReward);
        }
    }
}
