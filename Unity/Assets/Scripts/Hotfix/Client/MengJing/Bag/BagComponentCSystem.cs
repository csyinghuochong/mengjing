using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof(UserInfoComponentC))]
    [FriendOf(typeof(BagComponentC))]
    [EntitySystemOf(typeof(BagComponentC))]
    public static partial class BagComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this BagComponentC self)
        {
            self.AllItemList = new Dictionary<int, List<ItemInfo>>();
            for (int i = 0; i < (int)ItemLocType.ItemLocMax; i++)
            {
                self.AllItemList[i] = new List<ItemInfo>();
            }

            self.RealAddItem = 0;
        }

        [EntitySystem]
        private static void Destroy(this BagComponentC self)
        {
        }

        public static bool CheckAddItemData(this BagComponentC self, string rewardItems)
        {
            int cellNumber = 0;
            string[] needList = rewardItems.Split('@');
            for (int i = 0; i < needList.Length; i++)
            {
                string[] itemInfo = needList[i].Split(';');
                if (itemInfo.Length < 2)
                {
                    continue;
                }

                int itemId = int.Parse(itemInfo[0]);
                int itemNum = int.Parse(itemInfo[1]);

                if (itemId <= (int)UserDataType.Max)
                {
                    continue;
                }

                int ItemPileSum = ItemConfigCategory.Instance.Get(itemId).ItemPileSum;
                if (ItemPileSum == 1)
                {
                    cellNumber += itemNum;
                }
                else
                {
                    cellNumber += (int)(1f * itemNum / ItemPileSum);
                    cellNumber += (itemNum % ItemPileSum > 0 ? 1 : 0);
                }
            }

            return self.GetBagLeftCell(ItemLocType.ItemLocBag) >= cellNumber;
        }

        public static List<ItemInfo> GetCurJingHeList(this BagComponentC self)
        {
            List<ItemInfo> bagInfos = new List<ItemInfo>();
            List<ItemInfo> jingheList = self.GetItemsByLoc(ItemLocType.SeasonJingHe);
            for (int i = 0; i < jingheList.Count; i++)
            {
                if (jingheList[i].EquipPlan == self.SeasonJingHePlan)
                {
                    bagInfos.Add(jingheList[i]);
                }
            }

            return bagInfos;
        }

        public static ItemInfo GetJingHeByWeiZhi(this BagComponentC self, int subType)
        {
            List<ItemInfo> bagInfos = self.GetCurJingHeList();
            for (int i = 0; i < bagInfos.Count; i++)
            {
                if (bagInfos[i].EquipIndex == subType)
                {
                    return bagInfos[i];
                }
            }

            return null;
        }

        public static void OnRecvItemSort(this BagComponentC self, int itemEquipType)
        {
            List<ItemInfo> ItemTypeList = self.GetItemsByLoc(itemEquipType);
            ItemHelper.ItemLitSort(ItemTypeList);
            EventSystem.Instance.Publish(self.Root(), new BagItemUpdate());
        }

        public static void OnRecvBagUpdate(this BagComponentC self, M2C_RoleBagUpdate message)
        {
            var bagUpdate = message.BagInfoUpdate;
            var bagAdd = message.BagInfoAdd;
            var bagDelete = message.BagInfoDelete;

            if (bagUpdate != null && bagUpdate.Count > 0)
            {
                for (int i = 0; i < bagUpdate.Count; i++)
                {
                    ItemInfo newInfo = self.AddChild<ItemInfo>();
                    newInfo.FromMessage(bagUpdate[i]);
                    ItemInfo oldInfo = self.GetBagInfo(bagUpdate[i].BagInfoID);
                    if (oldInfo == null)
                    {
                        continue;
                    }

                    if (newInfo.Loc == (int)ItemLocType.ItemLocBag && newInfo.ItemNum > oldInfo.ItemNum)
                    {
                        self.ShowGetItemTip(newInfo, newInfo.ItemNum - oldInfo.ItemNum);
                    }

                    if (newInfo.Loc == (int)ItemLocType.ChouKaWarehouse)
                    {
                        EventSystem.Instance.Publish(self.Root(), new ChouKaWarehouseAddItem());
                    }

                    if (oldInfo.Loc != newInfo.Loc)
                    {
                        List<ItemInfo> oldTemp = self.GetItemsByLoc(oldInfo.Loc);
                        for (int k = oldTemp.Count - 1; k >= 0; k--)
                        {
                            if (oldTemp[k].BagInfoID == newInfo.BagInfoID)
                            {
                                oldTemp[k].Dispose();
                                oldTemp.RemoveAt(k);
                                break;
                            }
                        }

                        List<ItemInfo> temp = self.GetItemsByLoc(newInfo.Loc);
                        temp.Add(newInfo);
                    }
                    else
                    {
                        List<ItemInfo> temp = self.GetItemsByLoc(newInfo.Loc);
                        for (int k = 0; k < temp.Count; k++)
                        {
                            if (temp[k].BagInfoID == newInfo.BagInfoID)
                            {
                                temp[k].Dispose();
                                temp[k] = newInfo;
                                break;
                            }
                        }
                    }
                }
            }

            if (bagAdd != null && bagAdd.Count > 0)
            {
                for (int i = 0; i < bagAdd.Count; i++)
                {
                    ItemInfo bagInfo = self.AddChild<ItemInfo>();
                    bagInfo.FromMessage(bagAdd[i]);
                    if (bagInfo.Loc == (int)ItemLocType.ItemLocBag)
                    {
                        self.ShowGetItemTip(bagInfo, bagInfo.ItemNum);
                    }

                    if (bagInfo.Loc == (int)ItemLocType.ChouKaWarehouse)
                    {
                        EventSystem.Instance.Publish(self.Root(), new ChouKaWarehouseAddItem());
                    }

                    List<ItemInfo> temp = self.GetItemsByLoc(bagInfo.Loc);
                    temp.Add(bagInfo);
                }
            }

            if (bagDelete != null && bagDelete.Count > 0)
            {
                for (int i = 0; i < bagDelete.Count; i++)
                {
                    List<ItemInfo> temp = self.GetItemsByLoc(bagDelete[i].Loc);
                    for (int k = temp.Count - 1; k >= 0; k--)
                    {
                        if (temp[k].BagInfoID == bagDelete[i].BagInfoID)
                        {
                            temp[k].Dispose();
                            temp.RemoveAt(k);
                            break;
                        }
                    }
                }
            }

            EventSystem.Instance.Publish(self.Root(), new BagItemUpdate());
        }

        private static void ShowGetItemTip(this BagComponentC self, ItemInfo bagInfo, int addNum)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            if (itemConfig.IfAutoUse == 1)
            {
                BagClientNetHelper.RequestUseItem(self.Root(), bagInfo).Coroutine();
                return;
            }

            if (self.RealAddItem >= 0)
            {
                // self.Root().GetComponent<ShoujiComponentC>().OnGetItem(bagInfo.ItemID);
                HintHelp.ShowHint(self.Root(), $"获得 {itemConfig.ItemName} {addNum}");
            }
            
            EventSystem.Instance.Publish(self.Root(), new BagItemItemAdd() { ItemId = bagInfo.ItemID , Num = addNum});
        }

        //检测
        public static bool CheckNeedItem(this BagComponentC self, string needitems)
        {
            if (string.IsNullOrEmpty(needitems))
            {
                return true;
            }

            string[] needList = needitems.Split('@');

            List<RewardItem> costItems = new List<RewardItem>();
            for (int i = 0; i < needList.Length; i++)
            {
                string[] itemInfo = needList[i].Split(';');
                int itemId = int.Parse(itemInfo[0]);
                int itemNum = int.Parse(itemInfo[1]);
                costItems.Add(new RewardItem() { ItemID = itemId, ItemNum = itemNum });
            }

            return self.CheckNeedItem(costItems);
        }

        public static bool CheckNeedItem(this BagComponentC self, List<RewardItem> costItems)
        {
            for (int i = costItems.Count - 1; i >= 0; i--)
            {
                int itemID = costItems[i].ItemID;
                long itemNum = costItems[i].ItemNum;
                //获取背包内的道具是否足够
                if (self.GetItemNumber(itemID) < itemNum)
                {
                    return false;
                }
            }

            return true;
        }

        public static long GetItemNumber(this BagComponentC self, int itemId)
        {
            int userDataType = ItemHelper.GetItemToUserDataType(itemId);
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            long number = 0;
            switch (userDataType)
            {
                case UserDataType.None:
                    List<ItemInfo> bagInfos = self.GetBagList();
                    for (int i = 0; i < bagInfos.Count; i++)
                    {
                        if (bagInfos[i].ItemID == itemId)
                        {
                            number += bagInfos[i].ItemNum;
                        }
                    }

                    break;
                case UserDataType.Gold:
                    number = userInfo.Gold;
                    break;
                case UserDataType.Diamond:
                    number = userInfo.Diamond;
                    break;
                case UserDataType.JiaYuanFund:
                    number = userInfo.JiaYuanFund;
                    break;
                case UserDataType.UnionContri:
                    number = userInfo.UnionZiJin;
                    break;
                case UserDataType.SeasonCoin:
                    number = userInfo.SeasonCoin;
                    break;
                default:
                    number = 0;
                    break;
            }

            return number;
        }

        public static List<ItemInfo> GetItemsByLoc(this BagComponentC self, int loc)
        {
            return self.AllItemList[loc];
        }

        public static List<ItemInfo> GetItemsByType(this BagComponentC self, int itemType)
        {
            List<ItemInfo> bagInfos = self.GetItemsByLoc((int)ItemLocType.ItemLocBag);
            if (itemType == ItemTypeEnum.ALL)
                return bagInfos;

            List<ItemInfo> typeList = new List<ItemInfo>();
            for (int i = 0; i < bagInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                if (itemConfig.ItemType == (int)itemType)
                {
                    typeList.Add(bagInfos[i]);
                }
            }

            return typeList;
        }

        public static List<ItemInfo> GetItemsByTypeAndSubType(this BagComponentC self, int itemType, int itemSubType)
        {
            List<ItemInfo> bagInfos = self.GetBagList();
            if (itemType == ItemTypeEnum.ALL)
                return bagInfos;

            List<ItemInfo> typeList = new List<ItemInfo>();
            for (int i = 0; i < bagInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                if (itemConfig.ItemType == (int)itemType && itemConfig.ItemSubType == itemSubType)
                {
                    typeList.Add(bagInfos[i]);
                }
            }

            return typeList;
        }

        public static ItemInfo GetBagInfoByConfigId(this BagComponentC self, int itemId)
        {
            for (int i = 0; i < self.AllItemList.Count; i++)
            {
                List<ItemInfo> baglist = self.AllItemList[i];
                for (int k = 0; k < baglist.Count; k++)
                {
                    if (baglist[k].ItemID == itemId)
                    {
                        return baglist[k];
                    }
                }
            }

            return null;
        }

        public static ItemInfo GetBagInfo(this BagComponentC self, long id)
        {
            for (int i = 0; i < self.AllItemList.Count; i++)
            {
                List<ItemInfo> baglist = self.AllItemList[i];
                for (int k = 0; k < baglist.Count; k++)
                {
                    if (baglist[k].BagInfoID == id)
                    {
                        return baglist[k];
                    }
                }
            }

            return null;
        }

        public static List<ItemInfo> GetAllItems(this BagComponentC self)
        {
            List<ItemInfo> bagInfos = new List<ItemInfo>();
            foreach (List<ItemInfo> list in self.AllItemList.Values)
            {
                bagInfos.AddRange(list);
            }

            return bagInfos;
        }

        public static ItemInfo GetEquipBySubType(this BagComponentC self, int itemLocType, int subType)
        {
            List<ItemInfo> bagInfos = self.GetItemsByLoc(itemLocType);
            for (int i = 0; i < bagInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                if (itemConfig.ItemSubType == subType)
                {
                    return bagInfos[i];
                }
            }

            return null;
        }

        public static List<ItemInfo> GetBagList(this BagComponentC self)
        {
            return self.AllItemList[(int)ItemLocType.ItemLocBag];
        }

        public static List<ItemInfo> GetEquipListByWeizhi(this BagComponentC self, int position)
        {
            List<ItemInfo> bagInfos = new List<ItemInfo>();
            List<ItemInfo> equipList = self.GetEquipList();
            for (int i = 0; i < equipList.Count; i++)
            {
                ItemConfig itemCof = ItemConfigCategory.Instance.Get(equipList[i].ItemID);
                if (itemCof.ItemSubType == position)
                {
                    bagInfos.Add(equipList[i]);
                }
            }

            return bagInfos;
        }

        public static List<ItemInfo> GetEquipList(this BagComponentC self)
        {
            return self.AllItemList[(int)ItemLocType.ItemLocEquip];
        }

        public static int GetBagLeftCell(this BagComponentC self, int hourseId)
        {
            List<ItemInfo> ItemTypeList = self.AllItemList[hourseId];
            return self.GetBagTotalCell(hourseId) - ItemTypeList.Count;
        }

        public static int GetBagTotalCell(this BagComponentC self, int hourseId)
        {
            int storeCapacity = GlobalValueConfigCategory.Instance.HourseInitCapacity; //仓库
            if (hourseId == (int)ItemLocType.GemWareHouse1)
            {
                storeCapacity = GlobalValueConfigCategory.Instance.GemStoreInitCapacity; //宝石仓库
            }

            if (hourseId == (int)ItemLocType.ItemLocBag)
            {
                storeCapacity = GlobalValueConfigCategory.Instance.BagInitCapacity; //背包
            }

            if (hourseId == (int)ItemLocType.ItemPetHeXinBag)
            {
                storeCapacity = GlobalValueConfigCategory.Instance.PetHeXinMax; //宠物之核背包
            }

            return storeCapacity + self.BagBuyCellNumber[hourseId] + self.BagAddCellNumber[hourseId];
        }

        public static int GetBagShowCell(this BagComponentC self, int houseId)
        {
            if (houseId == ItemLocType.ItemLocBag)
            {
                return self.BagAddCellNumber[0] + GlobalValueConfigCategory.Instance.BagInitCapacity + GlobalValueConfigCategory.Instance.BuyBagCellMaxNum;
            }

            return self.BagAddCellNumber[houseId] + GlobalValueConfigCategory.Instance.HourseInitCapacity + GlobalValueConfigCategory.Instance.BuyHourseCellMaxNum;
        }

        public static List<ItemInfo> GetCanJianDing(this BagComponentC self)
        {
            List<ItemInfo> bagInfos = new List<ItemInfo>();
            List<ItemInfo> equipList = self.GetItemsByType((int)ItemTypeEnum.Equipment);
            for (int i = 0; i < equipList.Count; i++)
            {
                ItemConfig itemconf = ItemConfigCategory.Instance.Get(equipList[i].ItemID);
                // 赛季晶核除外
                if (itemconf.ItemType == 3 && itemconf.EquipType == 201)
                {
                    continue;
                }

                if (equipList[i].IfJianDing == false)
                {
                    bagInfos.Add(equipList[i]);
                }
            }

            return bagInfos;
        }

        public static List<ItemInfo> GetCanEquipList(this BagComponentC self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            UserInfo useInfo = userInfoComponent.UserInfo;

            List<ItemInfo> canEquipList = new List<ItemInfo>();

            // 检测是否有可以穿戴的装备
            List<ItemInfo> bagInfos = self.GetItemsByLoc(ItemLocType.ItemLocBag);
            for (int i = bagInfos.Count - 1; i >= 0; i--)
            {
                if (bagInfos.Count <= i)
                {
                    continue;
                }

                ItemInfo baginfo1 = bagInfos[i];
                if (baginfo1 == null)
                {
                    continue;
                }

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(baginfo1.ItemID);

                int error = ItemHelper.CanEquip(baginfo1, useInfo);
                if (error != 0)
                {
                    continue;
                }

                // 猎人武器特殊处理 。。。
                // 。。。。。。。。

                int weizhi = itemConfig.ItemSubType;
                //获取之前的位置是否有装备
                ItemInfo beforeequip = null;
                if (weizhi == (int)ItemSubTypeEnum.Shiping)
                {
                    List<ItemInfo> equipList = self.GetEquipListByWeizhi(weizhi);
                    beforeequip = equipList.Count < ConfigData.EquipShiPingMax ? null : equipList[0];
                }
                else
                {
                    beforeequip = self.GetEquipBySubType(ItemLocType.ItemLocEquip, weizhi);
                }

                if (beforeequip == null)
                {
                    canEquipList.Add(baginfo1);
                }
                else
                {
                    ItemConfig nowItemConfig = ItemConfigCategory.Instance.Get(beforeequip.ItemID);
                    if (itemConfig.UseLv > nowItemConfig.UseLv && itemConfig.ItemQuality > nowItemConfig.ItemQuality)
                    {
                        canEquipList.Add(baginfo1);
                    }
                }
            }

            return canEquipList;
        }

        public static void OnResetSeason(this BagComponentC self, bool notice)
        {
            self.SeasonJingHePlan = 0;

            self.ClearJingHeItem(self.AllItemList[(int)ItemLocType.ItemLocBag]);
            self.ClearJingHeItem(self.AllItemList[(int)ItemLocType.ItemWareHouse1]);
            self.ClearJingHeItem(self.AllItemList[(int)ItemLocType.ItemWareHouse2]);
            self.ClearJingHeItem(self.AllItemList[(int)ItemLocType.ItemWareHouse3]);
            self.ClearJingHeItem(self.AllItemList[(int)ItemLocType.ItemWareHouse4]);
            self.ClearJingHeItem(self.AllItemList[(int)ItemLocType.SeasonJingHe]);
        }

        public static void ClearJingHeItem(this BagComponentC self, List<ItemInfo> bagInfos)
        {
            for (int i = bagInfos.Count - 1; i >= 0; i--)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                if (itemConfig.EquipType == 201)
                {
                    bagInfos[i].Dispose();
                    bagInfos.RemoveAt(i);
                }
            }
        }
    }
}