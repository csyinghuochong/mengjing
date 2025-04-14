using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonCostItem))]
    [EntitySystemOf(typeof(ES_CostList))]
    [FriendOfAttribute(typeof(ES_CostList))]
    public static partial class ES_CostListSystem
    {
        [EntitySystem]
        private static void Awake(this ES_CostList self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_CostItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
        }

        [EntitySystem]
        private static void Destroy(this ES_CostList self)
        {
            self.DestroyWidget();
        }

        private static void OnBagItemsRefresh(this ES_CostList self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonCostItem item in self.ScrollItemCommonCostItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonCostItem scrollItemCommonCostItem = self.ScrollItemCommonCostItems[index].BindTrans(transform);
            scrollItemCommonCostItem.UpdateItem(self.ShowBagInfos[index].ItemID, self.ShowBagInfos[index].ItemNum);
        }

        public static void Refresh(this ES_CostList self, List<RewardItem> rewardItems)
        {
            self.ShowBagInfos.Clear();
            foreach (RewardItem item in rewardItems)
            {
                BagInfo bagInfo = BagInfo.Create();
                bagInfo.ItemID = item.ItemID;
                bagInfo.ItemNum = item.ItemNum;
                self.ShowBagInfos.Add(bagInfo);
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonCostItems, self.ShowBagInfos.Count);
            self.E_CostItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }

        public static void Refresh(this ES_CostList self, string rewarfItems)
        {
            self.ShowBagInfos.Clear();
            if (!CommonHelp.IfNull(rewarfItems))
            {
                string[] items = rewarfItems.Split('@');
                foreach (string item in items)
                {
                    if (CommonHelp.IfNull(item))
                    {
                        continue;
                    }

                    string[] it = item.Split(';');
                    BagInfo bagInfo = BagInfo.Create();
                    bagInfo.ItemID = int.Parse(it[0]);
                    bagInfo.ItemNum = int.Parse(it[1]);
                    self.ShowBagInfos.Add(bagInfo);
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonCostItems, self.ShowBagInfos.Count);
            self.E_CostItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }
    }
}