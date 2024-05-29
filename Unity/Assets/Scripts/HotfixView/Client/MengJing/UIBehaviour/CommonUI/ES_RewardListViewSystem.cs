using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_CommonItem))]
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

            scrollItemCommonItem.ES_CommonItem.E_ItemNumText.gameObject.SetActive(self.ShowNum);
            scrollItemCommonItem.ES_CommonItem.E_ItemNameText.gameObject.SetActive(self.ShowName);
            scrollItemCommonItem.uiTransform.localScale = Vector3.one * self.Scale;
        }

        public static void Refresh(this ES_RewardList self, List<RewardItem> rewardItems, float scale = 1f, bool showNumber = true,
        bool showName = false)
        {
            self.Scale = scale;
            self.ShowNum = showNumber;
            self.ShowName = showName;

            self.ShowBagInfos.Clear();
            foreach (RewardItem item in rewardItems)
            {
                self.ShowBagInfos.Add(new BagInfo() { ItemID = item.ItemID, ItemNum = item.ItemNum });
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }

        public static void Refresh(this ES_RewardList self, string rewarfItems, float scale = 1f, bool showNumber = true, bool showName = false)
        {
            self.Scale = scale;
            self.ShowNum = showNumber;
            self.ShowName = showName;

            self.ShowBagInfos.Clear();
            string[] items = rewarfItems.Split('@');
            foreach (string item in items)
            {
                string[] it = item.Split(';');
                self.ShowBagInfos.Add(new BagInfo() { ItemID = int.Parse(it[0]), ItemNum = int.Parse(it[1]) });
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }
    }
}