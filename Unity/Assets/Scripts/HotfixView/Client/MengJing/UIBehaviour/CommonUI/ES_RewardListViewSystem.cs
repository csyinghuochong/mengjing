using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [EntitySystemOf(typeof(ES_RewardList))]
    [FriendOf(typeof(ES_RewardList))]
    public static partial class ES_RewardListSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RewardList self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_RewardList self)
        {
            // ！！！
            self.E_BagItemsLoopVerticalScrollRect.dataSource.scrollMoveEvent = null;

            self.DestroyWidget();
        }

        private static void OnBagItemsRefresh(this ES_RewardList self, Transform transform, int index)
        {
            if (index < 0 || index >= self.ShowBagInfos.Count)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("index超了 {0} {1}", index, self.ShowBagInfos.Count));
                }

                return;
            }
            
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }

            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.None);

            scrollItemCommonItem.E_ItemNumText.gameObject.SetActive(self.ShowNum);
            scrollItemCommonItem.E_ItemNameText.gameObject.SetActive(self.ShowName);
            scrollItemCommonItem.E_ItemNameText.GetComponent<Outline>().enabled = self.ShowNameOutline;
            scrollItemCommonItem.uiTransform.localScale = Vector3.one * self.Scale;
            scrollItemCommonItem.E_BindingImage.gameObject.SetActive(self.GetWay == ItemGetWay.Activity_DayTeHui ||
                self.GetWay == ItemGetWay.ActivityNewYear);
        }

        public static void Refresh(this ES_RewardList self, List<RewardItem> rewardItems, float scale = 1f, bool showNumber = true,
        bool showName = false, int getWay = 0, bool showNameOutline = true)
        {
            self.Scale = scale;
            self.ShowNum = showNumber;
            self.ShowName = showName;
            self.ShowNameOutline = showNameOutline;
            self.GetWay = getWay;

            self.ShowBagInfos.Clear();
            foreach (RewardItem item in rewardItems)
            {
                ItemInfo bagInfo = new ItemInfo();
                bagInfo.ItemID = item.ItemID;
                bagInfo.ItemNum = item.ItemNum;
                self.ShowBagInfos.Add(bagInfo);
            }

            self.ShowBagInfos = self.ShowBagInfos
                    .OrderByDescending(t => ItemConfigCategory.Instance.Get(t.ItemID).ItemQuality)
                    .ThenBy(t => ItemConfigCategory.Instance.Get(t.ItemID).ItemType == 3 ? 0 : 1)
                    .ToList();

            self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }

        //40000001
        public static void ShowUIEffect(this ES_RewardList self, int effectid)
        {
            foreach (var commonitem in self.ScrollItemCommonItems)
            {
                Scroll_Item_CommonItem itemCommonItem = commonitem.Value;
                if (itemCommonItem == null || itemCommonItem.uiTransform == null)
                {
                    continue;
                }

                itemCommonItem.ShowUIEffect(effectid);
            }
        }

        public static void ShowReceived(this ES_RewardList self, bool recv)
        {
            foreach (var commonitem in self.ScrollItemCommonItems)
            {
                Scroll_Item_CommonItem itemCommonItem = commonitem.Value;
                if (itemCommonItem == null || itemCommonItem.uiTransform == null)
                {
                    continue;
                }

                itemCommonItem.E_ImageReceivedImage.gameObject.SetActive(recv);
            }
        }

        public static void Refresh(this ES_RewardList self, string rewarfItems, float scale = 1f, bool showNumber = true, bool showName = false,
        int getWay = 0)
        {
            self.Scale = scale;
            self.ShowNum = showNumber;
            self.ShowName = showName;
            self.GetWay = getWay;

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
                    ItemInfo bagInfo = new ItemInfo();
                    bagInfo.ItemID = int.Parse(it[0]);
                    bagInfo.ItemNum = int.Parse(it[1]);
                    self.ShowBagInfos.Add(bagInfo);
                }
            }
            self.ShowBagInfos = self.ShowBagInfos
                    .OrderByDescending(t => ItemConfigCategory.Instance.Get(t.ItemID).ItemQuality)
                    .ThenBy(t => ItemConfigCategory.Instance.Get(t.ItemID).ItemType == 3 ? 0 : 1)
                    .ToList();
            
            self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }
    }
}