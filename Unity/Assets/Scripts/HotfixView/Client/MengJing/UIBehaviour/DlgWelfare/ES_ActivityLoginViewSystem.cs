using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_ActivityLogin))]
    [FriendOfAttribute(typeof (ES_ActivityLogin))]
    public static partial class ES_ActivityLoginSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ActivityLogin self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_ActivityLoginItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnActivityLoginItemsRefresh);
        }

        [EntitySystem]
        private static void Destroy(this ES_ActivityLogin self)
        {
            self.DestroyWidget();
        }

        private static void OnActivityLoginItemsRefresh(this ES_ActivityLogin self, Transform transform, int index)
        {
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            Scroll_Item_ActivityLoginItem scrollItemActivityLoginItem = self.ScrollItemActivityLoginItems[index].BindTrans(transform);
            scrollItemActivityLoginItem.OnUpdateUI(self.ShowActivityConfigs[index]);
            scrollItemActivityLoginItem.SetReceived(activityComponent.ActivityReceiveIds.Contains(self.ShowActivityConfigs[index].Id));
        }

        public static void OnUpdateUI(this ES_ActivityLogin self)
        {
            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();

            self.ShowActivityConfigs.Clear();
            for (int i = 0; i < activityConfigs.Count; i++)
            {
                if (activityConfigs[i].ActivityType != 31)
                {
                    continue;
                }

                self.ShowActivityConfigs.Add(activityConfigs[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemActivityLoginItems, self.ShowActivityConfigs.Count);
            self.E_ActivityLoginItemsLoopVerticalScrollRect.SetVisible(true, self.ShowActivityConfigs.Count);
        }
    }
}