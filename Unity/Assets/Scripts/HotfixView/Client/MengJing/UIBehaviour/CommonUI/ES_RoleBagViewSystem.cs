using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_CommonItem))]
    [FriendOf(typeof (Scroll_Item_CommonItem))]
    [EntitySystemOf(typeof (ES_RoleBag))]
    [FriendOfAttribute(typeof (ES_RoleBag))]
    public static partial class ES_RoleBagSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleBag self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.E_ZhengLiButton.AddListenerAsync(self.OnZhengLiButton);
            self.E_OneSellButton.AddListener(self.OnOneSellButton);
            self.E_AllToggle.IsSelected(true);
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleBag self)
        {
            self.DestroyWidget();
        }

        private static void OnBagItemsRefresh(this ES_RoleBag self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            int openell = bagComponent.GetBagTotalCell();
            if (index < openell)
            {
                scrollItemCommonItem.ES_CommonItem.UpdateUnLock(true);
                scrollItemCommonItem.Refresh(index < self.ShowBagInfos.Count? self.ShowBagInfos[index] : null, ItemOperateEnum.Bag,
                    self.UpdateSelect);
            }
            else
            {
                int addcell = bagComponent.WarehouseAddedCell[0] + (index - openell);
                BuyCellCost buyCellCost = ConfigData.BuyBagCellCosts[addcell];
                int itemid = int.Parse(buyCellCost.Get.Split(';')[0]);
                int itemnum = int.Parse(buyCellCost.Get.Split(';')[1]);
                scrollItemCommonItem.Refresh(new BagInfo() { ItemID = itemid, BagInfoID = index, ItemNum = itemnum }, ItemOperateEnum.None);
                scrollItemCommonItem.ES_CommonItem.E_LockButton.AddListener(self.OnClickImage_Lock);
                scrollItemCommonItem.ES_CommonItem.UpdateUnLock(false);
            }

            BagInfo bagInfo = scrollItemCommonItem.ES_CommonItem.Baginfo;
            if (bagInfo == null)
            {
                return;
            }

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            if (itemConfig.ItemType != 3)
            {
                return;
            }

            int curQulity = 0;
            int curLevel = 0;
            List<BagInfo> curEquiplist = bagComponent.GetEquipListByWeizhi(itemConfig.ItemSubType);
            for (int e = 0; e < curEquiplist.Count; e++)
            {
                ItemConfig curEquipConfig = ItemConfigCategory.Instance.Get(curEquiplist[e].ItemID);
                if (curEquipConfig.UseLv < curLevel || curLevel == 0)
                {
                    curLevel = curEquipConfig.UseLv;
                }

                if (curEquipConfig.ItemQuality < curQulity || curQulity == 0)
                {
                    curQulity = curEquipConfig.ItemQuality;
                }
            }

            if (curEquiplist.Count < 3 && itemConfig.ItemSubType == 5)
            {
                curQulity = 0;
                curLevel = 0;
            }

            if (itemConfig.EquipType != 0 && itemConfig.EquipType != 99 && itemConfig.EquipType != 101 && itemConfig.EquipType != 201)
            {
                //武器类型
                switch (userInfoComponent.UserInfo.Occ)
                {
                    //战士
                    case 1:
                        if (itemConfig.EquipType < 10 && itemConfig.EquipType != 1 && itemConfig.EquipType != 2)
                        {
                            return;
                        }

                        break;

                    //法师
                    case 2:
                        if (itemConfig.EquipType < 10 && itemConfig.EquipType != 3 && itemConfig.EquipType != 4)
                        {
                            return;
                        }

                        break;
                    //猎人
                    case 3:
                        if (itemConfig.EquipType < 10 && itemConfig.EquipType != 1 && itemConfig.EquipType != 5)
                        {
                            return;
                        }

                        break;
                }

                if (userInfoComponent.UserInfo.OccTwo > 100)
                {
                    OccupationTwoConfig occTwoCof = OccupationTwoConfigCategory.Instance.Get(userInfoComponent.UserInfo.OccTwo);
                    //护甲类型
                    if (itemConfig.EquipType > 10 && itemConfig.EquipType != occTwoCof.ArmorMastery)
                    {
                        return;
                    }
                }
            }

            scrollItemCommonItem.ES_CommonItem.E_UpTipImage.gameObject.SetActive(userInfoComponent.UserInfo.Lv >= itemConfig.UseLv
                && itemConfig.UseLv > curLevel && itemConfig.ItemQuality > curQulity && itemConfig.EquipType != 201); // 晶核不显示箭头
        }

        public static void OnClickImage_Lock(this ES_RoleBag self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            BuyCellCost buyCellCost = ConfigData.BuyBagCellCosts[bagComponent.WarehouseAddedCell[0]];

            PopupTipHelp.OpenPopupTip(self.Root(), "购买格子",
                $"是否花费{UICommonHelper.GetNeedItemDesc(buyCellCost.Cost)}购买一个背包格子?",
                () => { BagClientNetHelper.RequestBuyBagCell(self.Root(), 0).Coroutine(); }, null).Coroutine();
            return;
        }

        private static void OnItemTypeSet(this ES_RoleBag self, int index)
        {
            UICommonHelper.SetToggleShow(self.E_AllToggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.E_EquipToggle.gameObject, index == 1);
            UICommonHelper.SetToggleShow(self.E_CaiLiaoToggle.gameObject, index == 2);
            UICommonHelper.SetToggleShow(self.E_XiaoHaoToggle.gameObject, index == 3);

            self.CurrentItemType = index;
            self.RefreshBagItems();
        }

        public static void RefreshBagItems(this ES_RoleBag self)
        {
            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();

            self.ShowBagInfos.Clear();

            int itemTypeEnum = ItemTypeEnum.ALL;
            switch (self.CurrentItemType)
            {
                case 0:
                    itemTypeEnum = ItemTypeEnum.ALL;
                    break;
                case 1:
                    itemTypeEnum = ItemTypeEnum.Equipment;
                    break;
                case 2:
                    itemTypeEnum = ItemTypeEnum.Material;
                    break;
                case 3:
                    itemTypeEnum = ItemTypeEnum.Consume;
                    break;
            }

            int allNumber = bagComponentC.GetBagShowCell();
            // int maxCount = GlobalValueConfigCategory.Instance.BagMaxCapacity;
            self.ShowBagInfos.AddRange(bagComponentC.GetItemsByType(itemTypeEnum));
            self.AddUIScrollItems(ref self.ScrollItemCommonItems, allNumber);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, allNumber);
        }

        private static void UpdateSelect(this ES_RoleBag self, BagInfo bagInfo)
        {
            for (int i = 0; i < self.ScrollItemCommonItems.Keys.Count - 1; i++)
            {
                // 滚动组件的子物体是动态从对象池里拿的，只引用看的到的
                if (self.ScrollItemCommonItems[i].uiTransform != null)
                {
                    self.ScrollItemCommonItems[i].UpdateSelectStatus(bagInfo);
                }
            }
        }

        private static async ETTask OnZhengLiButton(this ES_RoleBag self)
        {
            FlyTipComponent flyTipComponent = self.Root().GetComponent<FlyTipComponent>();
            int errorCode = await BagClientNetHelper.RequestSortByLoc(self.Root(), ItemLocType.ItemLocBag);
            if (errorCode == ErrorCode.ERR_Success)
            {
                flyTipComponent.SpawnFlyTipDi("整理完成!");
            }
        }

        private static void OnOneSellButton(this ES_RoleBag self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "一键出售", "是否一键出售低品质装备和宝石,出售品质可以在设置中进行选择",
                        () => { BagClientNetHelper.RequestOneSell(self.Root(), ItemLocType.ItemLocBag).Coroutine(); }, null)
                    .Coroutine();
        }
    }
}