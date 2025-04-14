using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetEggChouKaRewardItem))]
    [FriendOf(typeof(DlgPetEggChouKaReward))]
    public static class DlgPetEggChouKaRewardSystem
    {
        public static void RegisterUIEvent(this DlgPetEggChouKaReward self)
        {
            self.View.E_PetEggChouKaRewardItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetEggChouKaRewardItemsRefresh);
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_CloseButton);
            
            self.OnInitUI();
        }

        public static void ShowWindow(this DlgPetEggChouKaReward self, Entity contextData = null)
        {
        }

        private static void OnInitUI(this DlgPetEggChouKaReward self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            using (zstring.Block())
            {
                self.View.E_TextTitleText.text =
                        zstring.Format("今日探索次数:{0}", unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetExploreNumber));
            }

            self.ShowInfo.Clear();
            foreach (KeyValuePair<int, string> keyValuePair in ConfigData.PetExploreReward)
            {
                self.ShowInfo.Add(keyValuePair.Key);
            }

            self.AddUIScrollItems(ref self.ScrollItemPetEggChouKaRewardItems, self.ShowInfo.Count);
            self.View.E_PetEggChouKaRewardItemsLoopVerticalScrollRect.SetVisible(true, self.ShowInfo.Count);
        }

        private static void OnPetEggChouKaRewardItemsRefresh(this DlgPetEggChouKaReward self, Transform transform, int index)
        {
            foreach (Scroll_Item_PetEggChouKaRewardItem item in self.ScrollItemPetEggChouKaRewardItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_PetEggChouKaRewardItem scrollItemPetEggChouKaRewardItem = self.ScrollItemPetEggChouKaRewardItems[index].BindTrans(transform);
            scrollItemPetEggChouKaRewardItem.OnUpdateUI(self.ShowInfo[index]);
        }

        private static void OnBtn_CloseButton(this DlgPetEggChouKaReward self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetEggChouKaReward);
        }
    }
}
