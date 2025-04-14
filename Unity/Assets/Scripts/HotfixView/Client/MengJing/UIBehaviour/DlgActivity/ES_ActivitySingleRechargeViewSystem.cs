using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ActivitySingleRechargeItem))]
    [EntitySystemOf(typeof (ES_ActivitySingleRecharge))]
    [FriendOfAttribute(typeof (ES_ActivitySingleRecharge))]
    public static partial class ES_ActivitySingleRechargeSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ActivitySingleRecharge self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ActivitySingleRechargeItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnActivitySingleRechargeItemsRefresh);

            self.GetInfo();
        }

        [EntitySystem]
        private static void Destroy(this ES_ActivitySingleRecharge self)
        {
            self.DestroyWidget();
        }

        public static void GetInfo(this ES_ActivitySingleRecharge self)
        {
            self.InitInfo();
        }

        private static void OnActivitySingleRechargeItemsRefresh(this ES_ActivitySingleRecharge self, Transform transform, int index)
        {
            foreach (Scroll_Item_ActivitySingleRechargeItem item in self.ScrollItemActivitySingleRechargeItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_ActivitySingleRechargeItem scrollItemActivitySingleRechargeItem =
                    self.ScrollItemActivitySingleRechargeItems[index].BindTrans(transform);
            scrollItemActivitySingleRechargeItem.OnUpdateData(self.ShowItem[index]);
        }

        public static void InitInfo(this ES_ActivitySingleRecharge self)
        {
            self.ShowItem.Clear();
            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < activityConfigs.Count; i++)
            {
                if (activityConfigs[i].ActivityType != ActivityEnum.Type_35)
                {
                    continue;
                }

                self.ShowItem.Add(activityConfigs[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemActivitySingleRechargeItems, self.ShowItem.Count);
            self.E_ActivitySingleRechargeItemsLoopVerticalScrollRect.SetVisible(true, self.ShowItem.Count);
        }
    }
}
