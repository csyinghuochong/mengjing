using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_JiaYuanPastureItem_A))]
    [EntitySystemOf(typeof(ES_JiaYuanPasture_A))]
    [FriendOfAttribute(typeof(ES_JiaYuanPasture_A))]
    public static partial class ES_JiaYuanPasture_ASystem
    {
        [EntitySystem]
        private static void Awake(this ES_JiaYuanPasture_A self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_JiaYuanPastureItem_AsLoopVerticalScrollRect.AddItemRefreshListener(self.OnJJiaYuanPastureItemsRefresh);
        }

        [EntitySystem]
        private static void Destroy(this ES_JiaYuanPasture_A self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this ES_JiaYuanPasture_A self)
        {
            self.UpdateMysteryItem();
        }

        public static List<int> GetMysteryList(this ES_JiaYuanPasture_A self, int mysteryStartId)
        {
            List<int> itemList = new List<int>();

            while (mysteryStartId != 0)
            {
                itemList.Add(mysteryStartId);

                MysteryConfig mysteryConfig = MysteryConfigCategory.Instance.Get(mysteryStartId);
                mysteryStartId = mysteryConfig.NextId;
            }

            return itemList;
        }

        private static void OnJJiaYuanPastureItemsRefresh(this ES_JiaYuanPasture_A self, Transform transform, int index)
        {
            foreach (Scroll_Item_JiaYuanPastureItem_A item in self.ScrollItemJiaYuanPastureItemAs.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_JiaYuanPastureItem_A scrollItemCommonItem = self.ScrollItemJiaYuanPastureItemAs[index].BindTrans(transform);
            scrollItemCommonItem.OnUpdateUI(self.ShowMysteryItemInfos[index], index);
        }

        public static void UpdateMysteryItem(this ES_JiaYuanPasture_A self)
        {
            List<JiaYuanPastureConfig> jiaYuanPastureConfigs = new List<JiaYuanPastureConfig>();
            foreach (JiaYuanPastureConfig jiaYuanPastureConfig in JiaYuanPastureConfigCategory.Instance.GetAll().Values)
            {
                jiaYuanPastureConfigs.Add(jiaYuanPastureConfig);
            }

            self.ShowMysteryItemInfos.Clear();

            for (int i = 0; i < jiaYuanPastureConfigs.Count; i++)
            {
                MysteryItemInfo mysteryItemInfos = MysteryItemInfo.Create();
                mysteryItemInfos.ItemID = jiaYuanPastureConfigs[i].GetItemID;
                mysteryItemInfos.ItemNumber = 1;
                mysteryItemInfos.MysteryId = jiaYuanPastureConfigs[i].Id;
                mysteryItemInfos.ProductId = -1;

                self.ShowMysteryItemInfos.Add(mysteryItemInfos);
            }

            self.AddUIScrollItems(ref self.ScrollItemJiaYuanPastureItemAs, self.ShowMysteryItemInfos.Count);
            self.E_JiaYuanPastureItem_AsLoopVerticalScrollRect.SetVisible(true, self.ShowMysteryItemInfos.Count);
        }
    }
}
