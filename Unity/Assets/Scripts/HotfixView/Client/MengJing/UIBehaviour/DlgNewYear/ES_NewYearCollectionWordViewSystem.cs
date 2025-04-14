using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_NewYearCollectionWordItem))]
    [EntitySystemOf(typeof (ES_NewYearCollectionWord))]
    [FriendOfAttribute(typeof (ES_NewYearCollectionWord))]
    public static partial class ES_NewYearCollectionWordSystem
    {
        [EntitySystem]
        private static void Awake(this ES_NewYearCollectionWord self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_NewYearCollectionWordItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnNewYearCollectionWordItemsRefresh);

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_NewYearCollectionWord self)
        {
            self.DestroyWidget();
        }

        private static void OnNewYearCollectionWordItemsRefresh(this ES_NewYearCollectionWord self, Transform transform, int index)
        {
            foreach (Scroll_Item_NewYearCollectionWordItem item in self.ScrollItemNewYearCollectionWordItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_NewYearCollectionWordItem scrollItemNewYearCollectionWordItem =
                    self.ScrollItemNewYearCollectionWordItems[index].BindTrans(transform);

            scrollItemNewYearCollectionWordItem.OnInitUI(self.ShowActivityConfigs[index]);
            scrollItemNewYearCollectionWordItem.SetAction(self.OnRecived);
        }

        public static void OnInitUI(this ES_NewYearCollectionWord self)
        {
            self.ShowActivityConfigs.Clear();
            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < activityConfigs.Count; i++)
            {
                if (activityConfigs[i].ActivityType != 32)
                {
                    continue;
                }

                self.ShowActivityConfigs.Add(activityConfigs[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemNewYearCollectionWordItems, self.ShowActivityConfigs.Count);
            self.E_NewYearCollectionWordItemsLoopVerticalScrollRect.SetVisible(true, self.ShowActivityConfigs.Count);
        }

        public static void OnRecived(this ES_NewYearCollectionWord self)
        {
            self.OnUpdateUI();
        }

        public static void OnUpdateUI(this ES_NewYearCollectionWord self)
        {
            if (self.ScrollItemNewYearCollectionWordItems != null)
            {
                foreach (Scroll_Item_NewYearCollectionWordItem item in self.ScrollItemNewYearCollectionWordItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.OnUpdateUI();
                }
            }
        }
    }
}
