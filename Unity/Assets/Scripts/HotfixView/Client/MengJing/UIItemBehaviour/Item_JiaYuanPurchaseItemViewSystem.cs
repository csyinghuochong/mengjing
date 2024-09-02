using System;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_JiaYuanPurchaseItem))]
    [EntitySystemOf(typeof(Scroll_Item_JiaYuanPurchaseItem))]
    public static partial class Scroll_Item_JiaYuanPurchaseItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_JiaYuanPurchaseItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_JiaYuanPurchaseItem self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButton_Sell(this Scroll_Item_JiaYuanPurchaseItem self)
        {
            int itemid = self.JiaYuanPurchaseItem.ItemID;

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (bagComponent.GetItemNumber(itemid) < 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("道具不足！");
                return;
            }

            M2C_JiaYuanPurchaseResponse response =
                    await JiaYuanNetHelper.JiaYuanPurchaseRequest(self.Root(), itemid, self.JiaYuanPurchaseItem.PurchaseId);
            if (self.IsDisposed)
            {
                return;
            }

            self.Root().GetComponent<JiaYuanComponentC>().PurchaseItemList_7 = response.PurchaseItemList;

            self.Action_Buy.Invoke();
        }

        public static bool UpdateLeftTime(this Scroll_Item_JiaYuanPurchaseItem self)
        {
            long serverTime = TimeHelper.ServerNow();
            long endTime = self.JiaYuanPurchaseItem.EndTime;
            if (endTime < serverTime)
            {
                self.E_Text_TimeText.text = "已过期";
                return false;
            }
            else
            {
                using (zstring.Block())
                {
                    self.E_Text_TimeText.text = zstring.Format("剩余时间:{0}", TimeHelper.ShowLeftTime(endTime - serverTime));
                }

                return true;
            }
        }

        public static void OnUpdateUI(this Scroll_Item_JiaYuanPurchaseItem self, JiaYuanPurchaseItem jiaYuanPurchaseItem, Action action)
        {
            self.E_Button_SellButton.AddListenerAsync(self.OnButton_Sell);

            self.Action_Buy = action;
            self.JiaYuanPurchaseItem = jiaYuanPurchaseItem;
            int itemid = jiaYuanPurchaseItem.ItemID;
            int makeid = EquipMakeConfigCategory.Instance.GetMakeId(itemid);
            EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(makeid);
            ItemInfo bagInfo = new ItemInfo();
            bagInfo.ItemID = itemid;
            bagInfo.ItemNum = jiaYuanPurchaseItem.LeftNum;
            self.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
            self.ES_RewardList.Refresh(equipMakeConfig.NeedItems);

            using (zstring.Block())
            {
                self.E_Text_PriceText.text = zstring.Format("资金:{0}", jiaYuanPurchaseItem.BuyZiJin.ToString());
            }

            self.UpdateLeftTime();
        }
    }
}