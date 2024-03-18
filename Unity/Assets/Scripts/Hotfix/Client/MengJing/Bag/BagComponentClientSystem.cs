using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof (BagComponentClient))]
    [EntitySystemOf(typeof (BagComponentClient))]
    public static partial class BagComponentClientSystem
    {
        [EntitySystem]
        private static void Awake(this BagComponentClient self)
        {
            self.AllItemList = new List<BagInfo>[(int)ItemLocType.ItemLocMax];
            for (int i = 0; i < (int)ItemLocType.ItemLocMax; i++)
            {
                self.AllItemList[i] = new List<BagInfo>();
            }

            self.RealAddItem = true;
        }

        [EntitySystem]
        private static void Destroy(this BagComponentClient self)
        {
        }

        public static void OnRecvItemSort(this BagComponentClient self, ItemLocType itemEquipType)
        {
            List<BagInfo> ItemTypeList = self.GetItemsByLoc(itemEquipType);
            ItemHelper.ItemLitSort(ItemTypeList);
            EventSystem.Instance.Publish(self.Root(), new BagItemUpdate());
        }

        public static void OnRecvBagUpdate(this BagComponentClient self, M2C_RoleBagUpdate message)
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

        private static void ShowGetItemTip(this BagComponentClient self, BagInfo bagInfo, int addNum)
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

        public static List<BagInfo> GetItemsByLoc(this BagComponentClient self, ItemLocType itemLocType)
        {
            return self.AllItemList[(int)itemLocType];
        }

        private static List<BagInfo> GetItemsByLoc(this BagComponentClient self, int loc)
        {
            return self.AllItemList[loc];
        }

        public static List<BagInfo> GetItemsByType(this BagComponentClient self, int itemType)
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

        public static BagInfo GetBagInfo(this BagComponentClient self, long id)
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

        public static List<BagInfo> GetAllItems(this BagComponentClient self)
        {
            List<BagInfo> bagInfos = new List<BagInfo>();
            foreach (List<BagInfo> list in self.AllItemList)
            {
                bagInfos.AddRange(list);
            }

            return bagInfos;
        }

        public static BagInfo GetEquipBySubType(this BagComponentClient self, ItemLocType itemLocType, int subType)
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
        
        public static List<BagInfo> GetBagList(this BagComponentClient self)
        {
            return self.AllItemList[(int)ItemLocType.ItemLocBag];
        }
        
        public static int GetBagLeftCell(this BagComponentClient self)
        {
            return self.GetBagTotalCell() - self.GetBagList().Count;
        }
        
        public static int GetBagTotalCell(this BagComponentClient self)
        {
            if (self.WarehouseAddedCell.Count == 0 || self.AdditionalCellNum.Count == 0)
            {
                return  GlobalValueConfigCategory.Instance.BagInitCapacity;
            }
            return self.WarehouseAddedCell[0] + self.AdditionalCellNum[0] + GlobalValueConfigCategory.Instance.BagInitCapacity;
        }
    }
}