using System.Linq;
using UnityEngine;

namespace ET.Client
{
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
            Scroll_Item_ActivitySingleRechargeItem scrollItemActivitySingleRechargeItem =
                    self.ScrollItemActivitySingleRechargeItems[index].BindTrans(transform);
            scrollItemActivitySingleRechargeItem.OnUpdateData(self.ShowItem[index]);
        }

        public static void InitInfo(this ES_ActivitySingleRecharge self)
        {
            self.ShowItem = ConfigData.SingleRechargeReward.Keys.ToList();

            self.AddUIScrollItems(ref self.ScrollItemActivitySingleRechargeItems, self.ShowItem.Count);
            self.E_ActivitySingleRechargeItemsLoopVerticalScrollRect.SetVisible(true, self.ShowItem.Count);
        }
    }
}
