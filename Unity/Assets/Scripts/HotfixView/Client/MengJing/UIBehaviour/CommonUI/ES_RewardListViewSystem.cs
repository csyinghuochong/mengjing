using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_RewardList))]
    [FriendOf(typeof (ES_RewardList))]
    public static partial class ES_RewardListSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RewardList self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
        }

        [EntitySystem]
        private static void Destroy(this ES_RewardList self)
        {
            self.DestroyWidget();
        }

        private static void OnBagItemsRefresh(this ES_RewardList self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.None);
        }

        public static void Refresh(this ES_RewardList self, List<RewardItem> rewardItems)
        {
            self.ShowBagInfos.Clear();
            foreach (RewardItem item in rewardItems)
            {
                self.ShowBagInfos.Add(new BagInfo() { ItemID = item.ItemID, ItemNum = item.ItemNum });
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }

        public static void Refresh(this ES_RewardList self, string rewarfItems)
        {
        }
    }
}