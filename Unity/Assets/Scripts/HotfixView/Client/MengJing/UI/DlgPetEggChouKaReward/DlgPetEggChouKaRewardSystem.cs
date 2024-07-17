using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (DlgPetEggChouKaReward))]
    public static class DlgPetEggChouKaRewardSystem
    {
        public static void RegisterUIEvent(this DlgPetEggChouKaReward self)
        {
            self.View.E_PetEggChouKaRewardItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetEggChouKaRewardItemsRefresh);
            self.View.E_Btn_CloseButton.AddListener(self.OnClose);
        }

        public static void ShowWindow(this DlgPetEggChouKaReward self, Entity contextData = null)
        {
            self.OnInitUI();
        }

        private static void OnInitUI(this DlgPetEggChouKaReward self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            self.View.E_TextTitleText.text = $"今日探索次数:{unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetExploreNumber)}";

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
            Scroll_Item_PetEggChouKaRewardItem scrollItemPetEggChouKaRewardItem = self.ScrollItemPetEggChouKaRewardItems[index].BindTrans(transform);
            scrollItemPetEggChouKaRewardItem.OnUpdateUI(self.ShowInfo[index]);
        }

        private static void OnClose(this DlgPetEggChouKaReward self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetEggChouKaReward);
        }
    }
}