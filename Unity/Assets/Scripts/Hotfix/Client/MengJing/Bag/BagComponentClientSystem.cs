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
        }

        [EntitySystem]
        private static void Destroy(this BagComponentClient self)
        {
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
                        // self.ShowGetItemTip(newInfo, newInfo.ItemNum - oldInfo.ItemNum);
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
                        // self.ShowGetItemTip(bagInfo, bagInfo.ItemNum);
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

            // HintHelp.GetInstance().DataUpdate(DataType.BagItemUpdate);
        }

        public static List<BagInfo> GetItemsByLoc(this BagComponentClient self, int loc)
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
    }
}