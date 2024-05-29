using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof (UserInfoComponentC))]
    [FriendOf(typeof (BagComponentC))]
    [EntitySystemOf(typeof (BagComponentC))]
    public static partial class BagComponent_CSystem
    {
        [EntitySystem]
        private static void Awake(this BagComponentC self)
        {
            self.AllItemList = new List<BagInfo>[(int)ItemLocType.ItemLocMax];
            for (int i = 0; i < (int)ItemLocType.ItemLocMax; i++)
            {
                self.AllItemList[i] = new List<BagInfo>();
            }

            self.RealAddItem = true;
        }

        [EntitySystem]
        private static void Destroy(this BagComponentC self)
        {
        }

        public static void OnRecvItemSort(this BagComponentC self, ItemLocType itemEquipType)
        {
            List<BagInfo> ItemTypeList = self.GetItemsByLoc(itemEquipType);
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
                    BagInfo newInfo = bagUpdate[i];
                    BagInfo oldInfo = self.GetBagInfo(bagUpdate[i].BagInfoID);
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
                        // HintHelp.GetInstance().DataUpdate(DataType.ChouKaWarehouseAddItem);
                    }

                    if (oldInfo.Loc != newInfo.Loc)
                    {
                        List<BagInfo> oldTemp = self.GetItemsByLoc(oldInfo.Loc);
                        for (int k = oldTemp.Count - 1; k >= 0; k--)
                        {
                            if (oldTemp[k].BagInfoID == newInfo.BagInfoID)
                            {
                                oldTemp.RemoveAt(k);
                                break;
                            }
                        }

                        List<BagInfo> temp = self.GetItemsByLoc(newInfo.Loc);
                        temp.Add(bagUpdate[i]);
                    }
                    else
                    {
                        List<BagInfo> temp = self.GetItemsByLoc(newInfo.Loc);
                        for (int k = 0; k < temp.Count; k++)
                        {
                            if (temp[k].BagInfoID == newInfo.BagInfoID)
                            {
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
                    BagInfo bagInfo = bagAdd[i];
                    if (bagInfo.Loc == (int)ItemLocType.ItemLocBag)
                    {
                        self.ShowGetItemTip(bagInfo, bagInfo.ItemNum);
                    }

                    if (bagInfo.Loc == (int)ItemLocType.ChouKaWarehouse)
                    {
                        // HintHelp.GetInstance().DataUpdate(DataType.ChouKaWarehouseAddItem);
                    }

                    List<BagInfo> temp = self.GetItemsByLoc(bagInfo.Loc);
                    temp.Add(bagInfo);
                }
            }

            if (bagDelete != null && bagDelete.Count > 0)
            {
                for (int i = 0; i < bagDelete.Count; i++)
                {
                    List<BagInfo> temp = self.GetItemsByLoc(bagDelete[i].Loc);
                    for (int k = temp.Count - 1; k >= 0; k--)
                    {
                        if (temp[k].BagInfoID == bagDelete[i].BagInfoID)
                        {
                            temp.RemoveAt(k);
                            break;
                        }
                    }
                }
            }

            EventSystem.Instance.Publish(self.Root(), new BagItemUpdate());
            // HintHelp.GetInstance().DataUpdate(DataType.BagItemUpdate);
        }

        private static void ShowGetItemTip(this BagComponentC self, BagInfo bagInfo, int addNum)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            if (itemConfig.IfAutoUse == 1)
            {
                // self.SendUseItem( bagInfo).Coroutine();
                return;
            }

            if (self.RealAddItem)
            {
                // self.ZoneScene().GetComponent<ShoujiComponent>().OnGetItem(bagInfo.ItemID);
                // HintHelp.GetInstance().DataUpdate(DataType.BagItemAdd, $"{bagInfo.ItemID}_{addNum}");
                EventSystem.Instance.Publish(self.Root(), new ShowFlyTip() { Type = 1, Str = $"获得 {itemConfig.ItemName} {addNum}" });
            }
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
                    List<BagInfo> bagInfos = self.GetBagList();
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

        public static List<BagInfo> GetItemsByLoc(this BagComponentC self, ItemLocType itemLocType)
        {
            return self.AllItemList[(int)itemLocType];
        }

        private static List<BagInfo> GetItemsByLoc(this BagComponentC self, int loc)
        {
            return self.AllItemList[loc];
        }

        public static List<BagInfo> GetItemsByType(this BagComponentC self, int itemType)
        {
            List<BagInfo> bagInfos = self.GetItemsByLoc((int)ItemLocType.ItemLocBag);
            if (itemType == ItemTypeEnum.ALL)
                return bagInfos;

            List<BagInfo> typeList = new List<BagInfo>();
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

        public static List<BagInfo> GetItemsByTypeAndSubType(this BagComponentC self, int itemType, int itemSubType)
        {
            List<BagInfo> bagInfos = self.GetBagList();
            if (itemType == ItemTypeEnum.ALL)
                return bagInfos;

            List<BagInfo> typeList = new List<BagInfo>();
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

        public static BagInfo GetBagInfo(this BagComponentC self, long id)
        {
            for (int i = 0; i < self.AllItemList.Length; i++)
            {
                List<BagInfo> baglist = self.AllItemList[i];
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

        public static List<BagInfo> GetAllItems(this BagComponentC self)
        {
            List<BagInfo> bagInfos = new List<BagInfo>();
            foreach (List<BagInfo> list in self.AllItemList)
            {
                bagInfos.AddRange(list);
            }

            return bagInfos;
        }

        public static BagInfo GetEquipBySubType(this BagComponentC self, ItemLocType itemLocType, int subType)
        {
            List<BagInfo> bagInfos = self.GetItemsByLoc(itemLocType);
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

        public static List<BagInfo> GetBagList(this BagComponentC self)
        {
            return self.AllItemList[(int)ItemLocType.ItemLocBag];
        }

        public static int GetBagLeftCell(this BagComponentC self)
        {
            return self.GetBagTotalCell() - self.GetBagList().Count;
        }

        public static int GetBagTotalCell(this BagComponentC self)
        {
            if (self.WarehouseAddedCell.Count == 0 || self.AdditionalCellNum.Count == 0)
            {
                return GlobalValueConfigCategory.Instance.BagInitCapacity;
            }

            return self.WarehouseAddedCell[0] + self.AdditionalCellNum[0] + GlobalValueConfigCategory.Instance.BagInitCapacity;
        }

        public static int GetBagShowCell(this BagComponentC self)
        {
            return self.AdditionalCellNum[0] + GlobalValueConfigCategory.Instance.BagInitCapacity + GlobalValueConfigCategory.Instance.Get(84).Value2;
        }

        public static List<BagInfo> GetEquipListByWeizhi(this BagComponentC self, int position)
        {
            List<BagInfo> bagInfos = new List<BagInfo>();
            List<BagInfo> equipList = self.GetEquipList();
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

        public static List<BagInfo> GetEquipList(this BagComponentC self)
        {
            return self.AllItemList[(int)ItemLocType.ItemLocEquip];
        }

        public static int GetHouseTotalCell(this BagComponentC self, int houseId)
        {
            return self.WarehouseAddedCell[houseId] + self.AdditionalCellNum[houseId] + GlobalValueConfigCategory.Instance.HourseInitCapacity;
        }

        public static int GetHouseShowCell(this BagComponentC self, int houseId)
        {
            return self.AdditionalCellNum[houseId] + GlobalValueConfigCategory.Instance.HourseInitCapacity +
                    GlobalValueConfigCategory.Instance.Get(85).Value2;
        }

        public static int GetPetHeXinLeftSpace(this BagComponentC self)
        {
            return ComHelp.PetHeXinMax - self.GetItemsByLoc(ItemLocType.ItemPetHeXinBag).Count;
        }
    }
}