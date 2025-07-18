using System;
using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof(UserInfoComponentS))]
    [EntitySystemOf(typeof(BagComponentS))]
    [FriendOf(typeof(BagComponentS))]
    public static partial class BagComponentSSystem
    {
        [EntitySystem]
        private static void Awake(this BagComponentS self)
        {
            self.CheckAllItemList();

            self.OnAddItemData(GlobalValueConfigCategory.Instance.Get(9).Value, $"{ItemGetWay.System}_{TimeHelper.ServerNow()}", false);
        }

        [EntitySystem]
        private static void Destroy(this BagComponentS self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this BagComponentS self)
        {
            if (self.AllItemList == null)
            {
                self.AllItemList = new();
            }

            for (int i = 0; i < ItemLocType.ItemLocMax; i++)
            {
                if (!self.AllItemList.ContainsKey(i))
                {
                    self.AllItemList.Add(i, new());
                }
            }

            foreach (Entity entity in self.Children.Values)
            {
                ItemInfo itemInfo = entity as ItemInfo;

                self.AllItemList[itemInfo.Loc].Add(itemInfo);
            }
        }
        
        public static void DeserializeDB(this BagComponentS self)
        {
            if (self.AllItemList == null)
            {
                self.AllItemList = new();
            }

            for (int i = 0; i < ItemLocType.ItemLocMax; i++)
            {
                if (!self.AllItemList.ContainsKey(i))
                {
                    self.AllItemList.Add(i, new());
                }
            }

            foreach (Entity entity in self.ChildrenDB)
            {
                ItemInfo itemInfo = entity as ItemInfo;

                self.AllItemList[itemInfo.Loc].Add(itemInfo);
            }
        }

        public static void CheckAllItemList(this BagComponentS self)
        {
            if (self.AllItemList == null)
            {
                self.AllItemList = new();
            }

            for (int i = 0; i < (int)ItemLocType.ItemLocMax; i++)
            {
                if (!self.AllItemList.ContainsKey(i))
                {
                    self.AllItemList.Add(i, new());
                }
            }

            for (int i = self.BagBuyCellNumber.Count; i < (int)ItemLocType.ItemLocMax; i++)
            {
                self.BagBuyCellNumber.Add(0);
            }

            for (int i = self.BagAddCellNumber.Count; i < (int)ItemLocType.ItemLocMax; i++)
            {
                self.BagAddCellNumber.Add(0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool HaveOccEquip(this BagComponentS self)
        {
            List<ItemInfo> allequiplist = new List<ItemInfo>();
            allequiplist.AddRange(self.AllItemList[ItemLocType.ItemLocEquip]);
            allequiplist.AddRange(self.AllItemList[ItemLocType.ItemLocEquip_2]);

            for (int i = 0; i < allequiplist.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(allequiplist[i].ItemID);
                if (itemConfig.ItemType == 3
                    && itemConfig.EquipType >= 0 && itemConfig.EquipType <= 100
                    && itemConfig.ItemSubType >= 0 && itemConfig.ItemSubType <= 12)
                {
                    return true;
                }
            }

            return false;
        }
        
        public static List<PropertyValue> GetGemProLists(this BagComponentS self)
        {
            List<PropertyValue> list = new List<PropertyValue>();
            for (int i = 0; i < self.GetItemByLoc(ItemLocType.ItemLocGem).Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.GetItemByLoc(ItemLocType.ItemLocGem)[i].ItemID);
                string itemUsePar = itemConfig.ItemUsePar;
                if (string.IsNullOrEmpty(itemUsePar) || itemUsePar == "0")
                {
                    continue;
                }

                string[] attributes = itemUsePar.Split('@');
                for (int a = 0; a < attributes.Length; a++)
                {
                    string[] attributeItem = attributes[a].Split(';');
                    int hideId = int.Parse(attributeItem[0]);
                    long hide_value = 0;
                    if (NumericHelp.GetNumericValueType(hideId) == 2)
                    {
                        hide_value = (long)(float.Parse(attributeItem[1]) * 10000);
                    }
                    else
                    {
                        hide_value = long.Parse(attributeItem[1]);
                    }

                    list.Add(new PropertyValue() { HideID = hideId, HideValue = hide_value });
                }
            }

            return list;
        }

        public static List<ItemInfo> GetItemByLoc(this BagComponentS self, int itemEquipType)
        {
            if (self.AllItemList.ContainsKey(itemEquipType))
            {
                return self.AllItemList[itemEquipType];
            }
            else
            {
                Log.Error($"BagComponent 不存在 itemEquipType == {itemEquipType} 空间");
                return null;
            }
        }

        public static void ZhengLiItemList(this BagComponentS self, Dictionary<int, List<ItemInfo>> ItemSameList, M2C_RoleBagUpdate m2c_bagUpdate)
        {
            foreach (var item in ItemSameList)
            {
                List<ItemInfo> bagInfos = item.Value;
                if (bagInfos.Count == 1)
                {
                    continue;
                }

                ItemConfig itemCof = ItemConfigCategory.Instance.Get(bagInfos[0].ItemID);

                int totalNum = 0;
                int needGrid = 0;
                int finalNum = 0;
                for (int i = 0; i < bagInfos.Count; i++)
                {
                    totalNum += bagInfos[i].ItemNum;
                }

                needGrid = totalNum / itemCof.ItemPileSum;
                needGrid += (totalNum % itemCof.ItemPileSum > 0 ? 1 : 0);
                finalNum = totalNum - (needGrid - 1) * itemCof.ItemPileSum;

                if (needGrid <= 0 || needGrid > bagInfos.Count)
                {
                    Log.Debug($"RecvItemSortError: {self.GetParent<Unit>().Id} {bagInfos[0].ItemID}   {totalNum}   {needGrid}  {bagInfos.Count}");
                    continue;
                }

                bagInfos[needGrid - 1].ItemNum = finalNum;
                m2c_bagUpdate.BagInfoUpdate.Add(bagInfos[needGrid - 1].ToMessage());
                for (int i = 0; i < needGrid - 1; i++)
                {
                    bagInfos[i].ItemNum = itemCof.ItemPileSum;
                    m2c_bagUpdate.BagInfoUpdate.Add(bagInfos[i].ToMessage());
                }

                //删除后面的空格子
                for (int i = needGrid; i < bagInfos.Count; i++)
                {
                    bagInfos[i].ItemNum = 0;
                    m2c_bagUpdate.BagInfoDelete.Add(bagInfos[i].ToMessage());
                }
            }
        }

        public static void OnRecvItemSort(this BagComponentS self, int itemEquipType)
        {
            List<ItemInfo> ItemTypeList = self.GetItemByLoc(itemEquipType);

            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();

            Dictionary<int, List<ItemInfo>> ItemSameList_1 = new Dictionary<int, List<ItemInfo>>();
            Dictionary<int, List<ItemInfo>> ItemSameList_2 = new Dictionary<int, List<ItemInfo>>();
            //找出可以堆叠并且格子未放满的道具
            for (int i = 0; i < ItemTypeList.Count; i++)
            {
                ItemInfo bagInfo = ItemTypeList[i];

                //最大堆叠数量
                ItemConfig itemCof = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                if (bagInfo.ItemNum >= itemCof.ItemPileSum)
                {
                    continue;
                }

                if (bagInfo.isBinging)
                {
                    if (!ItemSameList_1.ContainsKey(bagInfo.ItemID))
                    {
                        ItemSameList_1[bagInfo.ItemID] = new List<ItemInfo>();
                    }

                    ItemSameList_1[bagInfo.ItemID].Add(bagInfo);
                }
                else
                {
                    if (!ItemSameList_2.ContainsKey(bagInfo.ItemID))
                    {
                        ItemSameList_2[bagInfo.ItemID] = new List<ItemInfo>();
                    }

                    ItemSameList_2[bagInfo.ItemID].Add(bagInfo);
                }
            }

            self.ZhengLiItemList(ItemSameList_1, m2c_bagUpdate);
            self.ZhengLiItemList(ItemSameList_2, m2c_bagUpdate);

            for (int i = ItemTypeList.Count - 1; i >= 0; i--)
            {
                if (ItemTypeList[i].ItemNum == 0)
                {
                    ItemTypeList[i].Dispose();
                    ItemTypeList.RemoveAt(i);
                }
            }

            //通知客户端背包道具发生改变
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2c_bagUpdate);

            ItemHelper.ItemLitSort(ItemTypeList);
        }

        public static void CheckValiedItem(this BagComponentS self, List<ItemInfo> bagInfos)
        {
            Unit unit = self.GetParent<Unit>();
            int occ = unit.GetComponent<UserInfoComponentS>().GetOcc();
            int occTwo = unit.GetComponent<UserInfoComponentS>().GetOccTwo();
            for (int i = bagInfos.Count - 1; i >= 0; i--)
            {
                if (!ItemConfigCategory.Instance.Contain(bagInfos[i].ItemID))
                {
                    bagInfos[i].Dispose();
                    bagInfos.RemoveAt(i);
                    continue;
                }

                if (bagInfos[i].ItemNum <= 0)
                {
                    bagInfos[i].ItemNum = 1;
                }

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                if (itemConfig.EquipType != 101 && itemConfig.ItemType == ItemTypeEnum.Equipment && bagInfos[i].InheritSkills.Count == 0 &&
                    itemConfig.ItemQuality >= 5 && itemConfig.UseLv >= 60)
                {
                    int skillid = 0; //XiLianHelper.XiLianChuanChengJianDing(itemConfig, occ, occTwo);
                    if (skillid != 0)
                    {
                        bagInfos[i].InheritSkills.Add(skillid);
                    }
                }

                if (itemConfig.ItemType == ItemTypeEnum.Equipment && itemConfig.ItemQuality <= 4)
                {
                    bagInfos[i].InheritSkills.Clear();
                }

                if (itemConfig.ItemType == ItemTypeEnum.Equipment && itemConfig.ItemQuality >= 5 && itemConfig.UseLv < 60)
                {
                    bagInfos[i].InheritSkills.Clear();
                }

                if (itemConfig.EquipType == 101 && bagInfos[i].HideProLists != null)
                {
                    bagInfos[i].HideProLists.Clear();
                }

                if (itemConfig.EquipType == 101 && bagInfos[i].InheritSkills != null)
                {
                    bagInfos[i].InheritSkills.Clear();
                }

                if ((itemConfig.EquipType == 113 || itemConfig.EquipType == 127) && string.IsNullOrEmpty((bagInfos[i].ItemPar)))
                {
                    ItemAddHelper.TreasureItem(unit, bagInfos[i]);
                }
            }
        }

        //获取自身所有的道具
        public static List<ItemInfo> GetAllItems(this BagComponentS self)
        {
            List<ItemInfo> bagList = new List<ItemInfo>();

            self.CheckValiedItem(self.GetItemByLoc(ItemLocType.ItemLocGem));
            self.CheckValiedItem(self.GetItemByLoc(ItemLocType.ItemLocBag));
            self.CheckValiedItem(self.GetItemByLoc(ItemLocType.ItemLocEquip));
            self.CheckValiedItem(self.GetItemByLoc(ItemLocType.ItemPetHeXinBag));
            self.CheckValiedItem(self.GetItemByLoc(ItemLocType.ItemWareHouse1));
            self.CheckValiedItem(self.GetItemByLoc(ItemLocType.ItemWareHouse2));
            self.CheckValiedItem(self.GetItemByLoc(ItemLocType.ItemWareHouse3));
            self.CheckValiedItem(self.GetItemByLoc(ItemLocType.ItemWareHouse4));

            for (int i = self.GetItemByLoc(ItemLocType.ItemLocEquip).Count - 1; i >= 0; i--)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.GetItemByLoc(ItemLocType.ItemLocEquip)[i].ItemID);
                if (itemConfig.ItemType == ItemTypeEnum.Gemstone)
                {
                    Log.Warning($"误穿宝石！！  {itemConfig.ItemName}");
                    self.GetItemByLoc(ItemLocType.ItemLocEquip)[i].Dispose();
                    self.GetItemByLoc(ItemLocType.ItemLocEquip).RemoveAt(i);
                    break;
                }
            }

            bagList.AddRange(self.GetItemByLoc(ItemLocType.ItemLocGem));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.ItemLocBag));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.ItemPetHeXinBag));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.ItemLocEquip));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.ItemPetHeXinEquip));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.ItemWareHouse1));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.ItemWareHouse2));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.ItemWareHouse3));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.ItemWareHouse4));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.JianYuanWareHouse1));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.JianYuanWareHouse2));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.JianYuanWareHouse3));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.JianYuanWareHouse4));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.JianYuanTreasureMapStorage1));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.JianYuanTreasureMapStorage2));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.ChouKaWarehouse));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.ItemLocEquip_2));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.SeasonJingHe));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.PetLocEquip));
            bagList.AddRange(self.GetItemByLoc(ItemLocType.GemWareHouse1));

            return bagList;
        }

        public static List<ItemInfo> GetIdItemList(this BagComponentS self, int itemId)
        {
            List<ItemInfo> baginfo = new List<ItemInfo>();
            for (int i = 0; i < self.GetItemByLoc(ItemLocType.ItemLocBag).Count; i++)
            {
                if (self.GetItemByLoc(ItemLocType.ItemLocBag)[i].ItemID == itemId)
                {
                    baginfo.Add(self.GetItemByLoc(ItemLocType.ItemLocBag)[i]);
                }
            }

            return baginfo;
        }

        public static int GetNeedCell(this BagComponentS self, List<RewardItem> itemids, int itemLocType)
        {
            int needcell = 0;
            for  ( int i =0; i < itemids.Count; i++ )
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemids[i].ItemID);
                long curNumber = self.GetItemNumber(itemids[i].ItemID, itemLocType);

                if (curNumber > 0 && curNumber + itemids[i].ItemNum < itemConfig.ItemPileSum)
                {
                    needcell = 0;
                }
                else
                {
                    int temp = 0;
                    temp += (int)(1f * itemids[i].ItemNum / itemConfig.ItemPileSum);
                    temp += (itemids[i].ItemNum % itemConfig.ItemPileSum > 0 ? 1 : 0);

                    needcell += temp;

                    if (temp != 1)
                    {
                        Console.WriteLine($"needcell:{needcell}  ItemNum:{itemids[i].ItemNum}   ItemPileSum:{itemConfig.ItemPileSum}");
                    }
                }
            }

            return needcell;
        }
        
        //获取某个道具的数量
        public static long GetItemNumber(this BagComponentS self, int itemId, int itemLocType = ItemLocType.ItemLocBag)
        {
            int userDataType = ItemHelper.GetItemToUserDataType(itemId);
            long number = 0;
            switch (userDataType)
            {
                case UserDataType.None:
                    List<ItemInfo> bagInfos = self.GetItemByLoc(itemLocType);
                    for (int i = 0; i < bagInfos.Count; i++)
                    {
                        if (bagInfos[i].ItemID == itemId)
                        {
                            number += bagInfos[i].ItemNum;
                        }
                    }

                    break;
                case UserDataType.Gold:
                    number = self.GetParent<Unit>().GetComponent<UserInfoComponentS>().GetGold();
                    break;
                case UserDataType.Diamond:
                    number = self.GetParent<Unit>().GetComponent<UserInfoComponentS>().UserInfo.Diamond;
                    break;
                case UserDataType.RongYu:
                    number = self.GetParent<Unit>().GetComponent<UserInfoComponentS>().UserInfo.RongYu;
                    break;
                case UserDataType.JiaYuanFund:
                    number = self.GetParent<Unit>().GetComponent<UserInfoComponentS>().UserInfo.JiaYuanFund;
                    break;
                case UserDataType.UnionContri:
                    number = self.GetParent<Unit>().GetComponent<UserInfoComponentS>().UserInfo.UnionZiJin;
                    break;
                case UserDataType.SeasonCoin:
                    number = self.GetParent<Unit>().GetComponent<UserInfoComponentS>().UserInfo.SeasonCoin;
                    break;
                default:
                    break;
            }

            return number;
        }

        //根据ID获取对应的背包数据
        public static ItemInfo GetItemByLoc(this BagComponentS self, int itemLocType, long bagId)
        {
            if (bagId == 0)
                return null;
            List<ItemInfo> ItemTypeList = self.GetItemByLoc(itemLocType);
            for (int i = 0; i < ItemTypeList.Count; i++)
            {
                if (ItemTypeList[i].BagInfoID == bagId)
                {
                    return ItemTypeList[i];
                }
            }

            return null;
        }

        public static bool IsBagFullByLoc(this BagComponentS self, int hourseId)
        {
            List<ItemInfo> ItemTypeList = self.GetItemByLoc(hourseId);
            return ItemTypeList.Count >= self.GetBagTotalCell(hourseId);
        }

        public static int GetBagLeftCell(this BagComponentS self, int hourseId)
        {
            List<ItemInfo> ItemTypeList = self.GetItemByLoc(hourseId);
            return self.GetBagTotalCell(hourseId) - ItemTypeList.Count;
        }

        public static int GetBagTotalCell(this BagComponentS self, int hourseId)
        {
            int storeCapacity = GlobalValueConfigCategory.Instance.HourseInitCapacity;  //仓库
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

        /// <summary>
        /// 获取抽卡仓库剩余的格数，上限100
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static int GetChouKaLeftSpace(this BagComponentS self)
        {
            return 100 - self.GetItemByLoc(ItemLocType.ChouKaWarehouse).Count;
        }

        public static void OnChangeItemLoc(this BagComponentS self, ItemInfo bagInfo, int itemLocTypeTo, int itemLocTypeFrom)
        {
            List<ItemInfo> ItemTypeListSour = self.GetItemByLoc(itemLocTypeFrom);
            for (int i = ItemTypeListSour.Count - 1; i >= 0; i--)
            {
                if (ItemTypeListSour[i].BagInfoID == bagInfo.BagInfoID)
                {
                    ItemTypeListSour.RemoveAt(i);
                }
            }

            List<ItemInfo> ItemTypeListDest = self.GetItemByLoc(itemLocTypeTo);
            bagInfo.Loc = (int)itemLocTypeTo;
            ItemTypeListDest.Add(bagInfo);
        }

        /// <summary>
        /// 是否有装备技能
        /// </summary>
        /// <param name="self"></param>
        /// <param name="skillId"></param>
        /// <returns></returns>
        public static bool IsHaveEquipSkill(this BagComponentS self, int skillId, long xilianequip)
        {
            if (xilianequip == 0)
            {
                return false;
            }

            for (int i = 0; i < self.GetItemByLoc(ItemLocType.ItemLocEquip).Count; i++)
            {
                if (self.GetItemByLoc(ItemLocType.ItemLocEquip)[i].BagInfoID == xilianequip)
                {
                    continue;
                }

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.GetItemByLoc(ItemLocType.ItemLocEquip)[i].ItemID);
                if (itemConfig.SkillID.Contains(skillId.ToString()))
                {
                    return true;
                }

                if (self.GetItemByLoc(ItemLocType.ItemLocEquip)[i].HideSkillLists.Contains(skillId))
                {
                    return true;
                }

                if (self.GetItemByLoc(ItemLocType.ItemLocEquip)[i].InheritSkills.Contains(skillId))
                {
                    return true;
                }
            }

            return false;
        }

        public static void OnResetSeason(this BagComponentS self, bool notice)
        { 
            self.SeasonJingHePlan = 0;
       
            self.ClearJingHeItem(self.GetItemByLoc(ItemLocType.ItemLocBag));
            self.ClearJingHeItem(self.GetItemByLoc(ItemLocType.ItemWareHouse1));
            self.ClearJingHeItem(self.GetItemByLoc(ItemLocType.ItemWareHouse2));
            self.ClearJingHeItem(self.GetItemByLoc(ItemLocType.ItemWareHouse3));
            self.ClearJingHeItem(self.GetItemByLoc(ItemLocType.ItemWareHouse4));
            self.ClearJingHeItem(self.GetItemByLoc(ItemLocType.SeasonJingHe));
        }

        public static void ClearJingHeItem(this BagComponentS self, List<ItemInfo> bagInfos)
        {
            for (int i = bagInfos.Count - 1; i >= 0; i--)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                if (itemConfig.EquipType == 201)
                {
                    bagInfos.RemoveAt(i);
                }
            }
        }
        
        public static List<ItemInfo> GetCurJingHeList(this BagComponentS self)
        {
            List<ItemInfo> bagInfos = new List<ItemInfo>();
            for (int i = 0; i < self.GetItemByLoc(ItemLocType.SeasonJingHe).Count; i++)
            {
                if (self.GetItemByLoc(ItemLocType.SeasonJingHe)[i].EquipPlan == self.SeasonJingHePlan)
                {
                    bagInfos.Add(self.GetItemByLoc(ItemLocType.SeasonJingHe)[i]);
                }
            }

            return bagInfos;
        }

        public static bool IsEquipJingHe(this BagComponentS self, int itemId)
        {
            List<ItemInfo> bagInfos = self.GetCurJingHeList();
            for (int i = 0; i < bagInfos.Count; i++)
            {
                if (bagInfos[i].ItemID == itemId)
                {
                    return true;
                }
            }

            return false;
        }

        public static List<int> GetEquipTianFuIds(this BagComponentS self)
        {
            List<int> equiptianfuids = new List<int>(); 
            List<ItemInfo> equiplist = new List<ItemInfo>();
            equiplist.AddRange(self.AllItemList[ItemLocType.ItemLocEquip] );
            equiplist.AddRange(self.AllItemList[ItemLocType.ItemLocEquip_2]);
            equiplist.AddRange(self.AllItemList[ItemLocType.SeasonJingHe]);

            
            for (int i = 0; i < equiplist.Count; i++)
            {
                if (!ItemConfigCategory.Instance.Contain(equiplist[i].ItemID))
                {
                    continue;
                }

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(equiplist[i].ItemID);

                if (!EquipConfigCategory.Instance.Contain(itemConfig.ItemEquipID))
                {
                    continue;
                }
                EquipConfig equipConfig = EquipConfigCategory.Instance.Get(itemConfig.ItemEquipID);
                

                if (equipConfig.TianFuId != 0)
                {
                    equiptianfuids.Add(equipConfig.TianFuId);
                }
            }

            return equiptianfuids;
        }
        
        public static ItemInfo GetJingHeByWeiZhi(this BagComponentS self, int subType)
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

        public static List<ItemInfo> GetEquipListByWeizhi(this BagComponentS self, int equipIndex, int position)
        {
            List<ItemInfo> bagInfos = new List<ItemInfo>();
            List<ItemInfo> equipList = self.GetItemByLoc(equipIndex);
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

        public static int GetMaxQiangHuaLevel(this BagComponentS self)
        {
            int maxLevel = 0;
            for (int i = 0; i < self.QiangHuaLevel.Count; i++)
            {
                if (self.QiangHuaLevel[i] > maxLevel)
                {
                    maxLevel = self.QiangHuaLevel[i];
                }
            }

            return maxLevel;
        }

        //获取某个装备位置的道具数据
        public static ItemInfo GetEquipBySubType(this BagComponentS self, int equipIndex, int subType)
        {
            List<ItemInfo> equipList = self.GetItemByLoc(equipIndex);
            for (int i = 0; i < equipList.Count; i++)
            {
                ItemConfig itemCof = ItemConfigCategory.Instance.Get(equipList[i].ItemID);
                if (itemCof.ItemSubType == subType)
                {
                    return equipList[i];
                }
            }

            return null;
        }

        public static void OnLogin(this BagComponentS self, int robotId)
        {
            self.CheckAllItemList();
            Unit unit = self.GetParent<Unit>();
            int zodiacnumber = self.GetZodiacnumber();
            //unit.GetComponent<ChengJiuComponent>().TriggerEvent(ChengJiuTargetEnum.ZodiacEquipNumber_215, 0, zodiacnumber);

            ///old
            //int warehourseNumber = (int)ItemLocType.ItemLocMax - 5;
            //if (self.WarehouseAddedCell.Count < warehourseNumber)  // 11)
            //{
            //    for (int i = self.WarehouseAddedCell.Count; i < warehourseNumber; i++)
            //    {
            //        self.WarehouseAddedCell.Add(0);
            //    }
            //}

            if (self.QiangHuaLevel.Count == 0)
            {
                for (int i = 0; i <= 11; i++)
                {
                    self.QiangHuaLevel.Add(0);
                    self.QiangHuaFails.Add(0);
                }
            }
            else
            {
                for (int i = 0; i <= 11; i++)
                {
                    int maxLevel = QiangHuaHelper.GetQiangHuaMaxLevel(i);
                    if (self.QiangHuaLevel[i] >= maxLevel)
                    {
                        self.QiangHuaLevel[i] = maxLevel - 1;

                        if (i != 0)
                        {
                            Log.Error($"self.QiangHuaLevel[i] >= maxLevel： {unit.Id}   {i}  {self.QiangHuaLevel[i]}");
                        }
                    }
                }
            }

            if (robotId != 0)
            {
                int[] equipList = new int[0];
                UserInfoComponentS userInfoComponentS = unit.GetComponent<UserInfoComponentS>();
                RobotConfig robotConfig = RobotConfigCategory.Instance.Get(robotId);

                if (robotConfig.Behaviour != 1 && robotConfig.Level > userInfoComponentS.GetUserLv())
                {
                    userInfoComponentS.SetUserLv(robotConfig.Level);
                }

                if (robotConfig.EquipList != null)
                {
                    equipList = robotConfig.EquipList != null ? robotConfig.EquipList : equipList;
                }
                else
                {
                    equipList = ItemConfigCategory.Instance.GetRandomEquipList(userInfoComponentS.GetOcc(), userInfoComponentS.GetUserLv());
                }

                for (int i = 0; i < equipList.Length; i++)
                {
                    if (equipList[i] == 0)
                    {
                        continue;
                    }

                    ItemConfig itemconfig = ItemConfigCategory.Instance.Get(equipList[i]);
                    if (self.GetEquipBySubType(ItemLocType.ItemLocEquip, itemconfig.ItemSubType) != null)
                    {
                        continue;
                    }

                    if (self.GetIdItemList(equipList[i]).Count > 0)
                    {
                        continue;
                    }

                    self.OnAddItemData($"{equipList[i]};1", $"{ItemGetWay.System}_0", false);
                    List<ItemInfo> bagInfo = self.GetIdItemList(equipList[i]);
                    if (bagInfo.Count == 0)
                    {
                        Log.Warning("机器人装备 bagInfo.Count == 0");
                        continue;
                    }

                    self.OnChangeItemLoc(bagInfo[0], ItemLocType.ItemLocEquip, ItemLocType.ItemLocBag);
                }
            }
        }

        public static int GetZodiacnumber(this BagComponentS self)
        {
            int number = 0;
            for (int i = 0; i < self.GetItemByLoc(ItemLocType.ItemLocEquip).Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.GetItemByLoc(ItemLocType.ItemLocEquip)[i].ItemID);
                if (itemConfig.EquipType == 101)
                {
                    number++;
                }
            }

            return number;
        }

        public static int GetWuqiItemId(this BagComponentS self)
        {
            ItemInfo bagInfo = self.GetEquipBySubType(ItemLocType.ItemLocEquip, (int)ItemSubTypeEnum.Wuqi);
            return bagInfo != null ? bagInfo.ItemID : 0;
        }

        //字符串添加道具 
        public static bool OnAddItemData(this BagComponentS self, string rewardItems, string getType, bool notice = true)
        {
            List<RewardItem> costItems = new List<RewardItem>();
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
                costItems.Add(new RewardItem() { ItemID = itemId, ItemNum = itemNum });
            }

            return self.OnAddItemData(costItems, string.Empty, getType, notice);
        }

        public static void OnAddItemData(this BagComponentS self, List<ItemInfoProto> bagInfos, string getType)
        {
            for (int i = 0; i < bagInfos.Count; i++)
            {
                self.OnAddItemData(bagInfos[i], getType);
            }
        }

        public static void OnAddItemData(this BagComponentS self, ItemInfoProto bagInfo, string getType)
        {
            ItemConfig itemCof = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            int maxPileSum = itemCof.ItemPileSum;

            if (maxPileSum > 1 || bagInfo.BagInfoID == 0)
            {
                self.OnAddItemData($"{bagInfo.ItemID};{bagInfo.ItemNum}", string.IsNullOrEmpty(bagInfo.GetWay) ? getType : bagInfo.GetWay);
            }
            else
            {
                ItemInfo itemInfo = self.AddChild<ItemInfo>();
                itemInfo.FromMessage(bagInfo);
                self.GetItemByLoc(ItemLocType.ItemLocBag).Add(itemInfo);

                M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
                m2c_bagUpdate.BagInfoAdd.Add(bagInfo);
                //通知客户端背包道具发生改变
                MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2c_bagUpdate);

                //检测任务需求道具
                self.GetParent<Unit>().OnGetItem(int.Parse(getType.Split('_')[0]), bagInfo.ItemID, bagInfo.ItemNum);
            }
        }
        
        public static void OnAddItemData(this BagComponentS self, ItemInfo bagInfo, string getType)
        {
            ItemConfig itemCof = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            int maxPileSum = itemCof.ItemPileSum;

            if (maxPileSum > 1 || bagInfo.BagInfoID == 0)
            {
                self.OnAddItemData($"{bagInfo.ItemID};{bagInfo.ItemNum}", string.IsNullOrEmpty(bagInfo.GetWay) ? getType : bagInfo.GetWay);
            }
            else
            {
                // self.AddChild(bagInfo);目前只是仓库之间存放用到，item都在BagComponentS下，所以不用再AddChild
                self.GetItemByLoc(ItemLocType.ItemLocBag).Add(bagInfo);

                M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
                m2c_bagUpdate.BagInfoAdd.Add(bagInfo.ToMessage());
                //通知客户端背包道具发生改变
                MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2c_bagUpdate);

                //检测任务需求道具
                self.GetParent<Unit>().OnGetItem(int.Parse(getType.Split('_')[0]), bagInfo.ItemID, bagInfo.ItemNum);
            }
        }

        public static void OnAddItemToStore(this BagComponentS self, int itemlockType, int itemid, int itemnumber, string getType)
        {
            ItemInfo useBagInfo = self.AddChild<ItemInfo>();
            useBagInfo.ItemID = itemid;
            useBagInfo.ItemNum = itemnumber;
            useBagInfo.Loc = itemlockType;
            useBagInfo.BagInfoID = IdGenerater.Instance.GenerateId();
            useBagInfo.GemHole = "0_0_0_0";
            useBagInfo.GemIDNew = "0_0_0_0";
            useBagInfo.GetWay = getType;
            self.GetItemByLoc(useBagInfo.Loc).Add(useBagInfo);

            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
            m2c_bagUpdate.BagInfoAdd.Add(useBagInfo.ToMessage());
            //通知客户端背包道具发生改变
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2c_bagUpdate);
        }

        public static void OnAddItemDataNewCell(this BagComponentS self, ItemInfo bagInfo, int itemnumber)
        {
            int itemid = bagInfo.ItemID;
            ItemInfo useBagInfo = self.AddChild<ItemInfo>();
            useBagInfo.ItemID = itemid;
            useBagInfo.ItemNum = itemnumber;
            ItemConfig itemCof = ItemConfigCategory.Instance.Get(itemid);
            useBagInfo.Loc = itemCof.ItemType == (int)ItemTypeEnum.PetHeXin ? (int)ItemLocType.ItemPetHeXinBag : (int)ItemLocType.ItemLocBag;
            useBagInfo.BagInfoID = IdGenerater.Instance.GenerateId();
            useBagInfo.GemHole = "0_0_0_0";
            useBagInfo.GemIDNew = "0_0_0_0";
            useBagInfo.GetWay = bagInfo.GetWay;
            useBagInfo.isBinging = bagInfo.isBinging;
            self.GetItemByLoc(useBagInfo.Loc).Add(useBagInfo);

            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
            m2c_bagUpdate.BagInfoAdd.Add(useBagInfo.ToMessage());
            //通知客户端背包道具发生改变
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2c_bagUpdate);
        }

        /// <summary>
        /// 暂时只有宝石仓库用到
        /// </summary>
        /// <param name="self"></param>
        /// <param name="itemId"></param>
        /// <param name="itemNumber"></param>
        /// <param name="itemLocType"></param>
        /// <returns></returns>
        public static bool CheckCanAddItem(this BagComponentS self, int itemId, int itemNumber, int itemLocType)
        {
            if (itemLocType == ItemLocType.GemWareHouse1)
            {
                if (self.IsBagFullByLoc((int)itemLocType))
                {
                    List<ItemInfo> bagInfoList = self.GetItemByLoc(itemLocType);
                    for (int i = 0; i < bagInfoList.Count; i++)
                    {
                        if (bagInfoList[i].ItemID != itemId)
                        {
                            continue;
                        }

                        ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemId);
                        if (bagInfoList[i].ItemNum + itemNumber <= itemConfig.ItemPileSum)
                        {
                            return true;
                        }
                    }

                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public static int GetRealNeedCell(this BagComponentS self, RewardItem itemids, int itemLocType)
        {
            int needcell = 0;

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemids.ItemID);
            long curNumber = self.GetItemNumber(itemids.ItemID, itemLocType);

            if (curNumber > 0 && curNumber + itemids.ItemNum <= itemConfig.ItemPileSum)
            {
                return 0;
            }

            needcell += (int)(1f * itemids.ItemNum / itemConfig.ItemPileSum);
            needcell += (itemids.ItemNum % itemConfig.ItemPileSum > 0 ? 1 : 0);

            return needcell;
        }

        //添加背包道具道具[支持同时添加多个]
        public static bool OnAddItemData(this BagComponentS self, List<RewardItem> rewardItems_init, string makeUserID, string getWay,
        bool notice = true, bool gm = false, int UseLocType = ItemLocType.ItemLocBag)
        {
            int needCellNumber = 0;
            int petHeXinNumber = 0;
            string[] getWayInfo = getWay.Split('_');
            int getType = int.Parse(getWayInfo[0]);
            Unit unit = self.GetParent<Unit>();
            bool isRobot = unit.GetComponent<UserInfoComponentS>().IsRobot();
            if (isRobot && getType == ItemGetWay.PickItem)
            {
                return true;
            }

            List<RewardItem> rewardItems = new List<RewardItem>();
            for (int i = rewardItems_init.Count - 1; i >= 0; i--)
            {
                if (rewardItems_init[i].ItemID == 0 || !ItemConfigCategory.Instance.Contain(rewardItems_init[i].ItemID))
                {
                    continue;
                }

                bool have = false;
                for (int bb = rewardItems.Count - 1; bb >= 0; bb--)
                {
                    if (rewardItems[bb].ItemID == rewardItems_init[i].ItemID)
                    {
                        rewardItems[bb].ItemNum += rewardItems_init[i].ItemNum;
                        have = true;
                        break;
                    }
                }

                if (!have)
                {
                    RewardItem item = new RewardItem();
                    item.ItemID = rewardItems_init[i].ItemID;
                    item.ItemNum = rewardItems_init[i].ItemNum;
                    rewardItems.Add(item);
                }
            }

            for (int i = rewardItems.Count - 1; i >= 0; i--)
            {
                ItemConfig itemCof = ItemConfigCategory.Instance.Get(rewardItems[i].ItemID);
                int userDataType = ItemHelper.GetItemToUserDataType(rewardItems[i].ItemID);
                if (userDataType != UserDataType.None)
                {
                    continue;
                }

                int ItemPileSum = (gm && itemCof.ItemPileSum > 1) ? 1000000 : itemCof.ItemPileSum;
                if (UseLocType >= ItemLocType.ItemWareHouse1)
                {
                    continue;
                }

                if (itemCof.ItemType == ItemTypeEnum.PetHeXin)
                {
                    petHeXinNumber += rewardItems[i].ItemNum;
                    continue;
                }

                ItemPileSum = itemCof.ItemPileSum;
                if (ItemPileSum == 1)
                {
                    needCellNumber +=  ( gm?1 :rewardItems[i].ItemNum);
                }
                else
                {
                    needCellNumber +=  ( gm?1 : self.GetRealNeedCell(rewardItems[i], UseLocType) );
                }
            }

            if (rewardItems.Count == 0)
            {
                return true;
            }

            if (getType != ItemGetWay.GemHeCheng) //宝石合成在对应的协议有判断
            {
                //宠物之核都是通过ItemLocType.ItemLocBag进入背包的
                if (petHeXinNumber > 0 && (petHeXinNumber + self.GetItemByLoc(ItemLocType.ItemPetHeXinBag).Count > GlobalValueConfigCategory.Instance.PetHeXinMax) &&
                    UseLocType == ItemLocType.ItemLocBag)
                {
                    return false;
                }
                if (needCellNumber > self.GetBagLeftCell(ItemLocType.ItemLocBag) && UseLocType == ItemLocType.ItemLocBag)
                {
                    return false;
                }
            }
            
            //通知客户端背包刷新
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
            m2c_bagUpdate.BagInfoAdd.Clear();
            m2c_bagUpdate.BagInfoUpdate.Clear();
            m2c_bagUpdate.BagInfoDelete.Clear();
            for (int i = rewardItems.Count - 1; i >= 0; i--)
            {
                int itemID = rewardItems[i].ItemID;
                if (itemID == 0 || !ItemConfigCategory.Instance.Contain(itemID))
                {
                    continue;
                }

                ServerLogHelper.GetItemInfo( self.Id, itemID, rewardItems[i].ItemNum, getType );
                
                int leftNum = rewardItems[i].ItemNum;
                int userDataType = ItemHelper.GetItemToUserDataType(itemID);
                if (userDataType == UserDataType.Gold && rewardItems[i].ItemNum > 1000000)
                {
                    Log.Warning(
                        $"[获取金币]UserDataType.Gold  {unit.Id} {getType} {unit.GetComponent<UserInfoComponentS>().GetName()} {rewardItems[i].ItemNum}");
                }

                if (userDataType == UserDataType.Diamond)
                {
                    Log.Warning(
                        $"[获取钻石]UserDataType.Diamond  {unit.Id} {getType} {unit.GetComponent<UserInfoComponentS>().GetName()} {rewardItems[i].ItemNum}");
                }

                if (userDataType == UserDataType.PiLao)
                {
                    //Log.Warning($"[增加疲劳] {unit.DomainZone()}  {unit.Id}   {getType}  {rewardItems[i].ItemNum}");
                }

                if (userDataType != UserDataType.None)
                {
                    //检测任务需求道具
                    unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneyAdd(userDataType, leftNum.ToString(), true, getType);
                    ItemAddHelper.OnGetItem(unit, getType, itemID, leftNum);
                    continue;
                }

                //最大堆叠数量
                ItemConfig itemCof = ItemConfigCategory.Instance.Get(itemID);
                if (itemCof.EquipType == 101 || itemCof.ItemQuality >= 4 || (itemCof.Id >= 16000101 && itemCof.Id <= 16000312) ||
                    (itemCof.Id >= 10030011 && itemCof.Id <= 10030019))
                {
                    Log.Warning($"[获取道具] {unit.Id} {getType} {itemID} {rewardItems[i].ItemNum}");
                }

                if (leftNum >= 99)
                {
                    Log.Warning($"[获取道具]leftNum >= 99  {unit.Id} {getType} {itemID} {rewardItems[i].ItemNum}");
                }

                int maxPileSum = (gm && itemCof.ItemPileSum > 1) ? 10000000 : itemCof.ItemPileSum;
                int itemLockType = ItemLocType.ItemLocBag;
                List<ItemInfo> itemlist = null;
                if (itemCof.ItemType == ItemTypeEnum.Equipment)
                {
                    maxPileSum = itemCof.ItemPileSum;
                }

                if (itemCof.ItemType == ItemTypeEnum.PetHeXin)
                {
                    maxPileSum = itemCof.ItemPileSum;
                    itemLockType = ItemLocType.ItemPetHeXinBag;
                    itemlist = self.GetItemByLoc(itemLockType);
                }
                else if (getType == ItemGetWay.PickItem && itemCof.ItemType == ItemTypeEnum.Gemstone && itemCof.ItemQuality > 3)
                {
                    NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
                    if (numericComponent.GetAsInt(NumericType.GemWarehouseOpen) >= 1 &&
                        self.CheckCanAddItem(itemID, leftNum, ItemLocType.GemWareHouse1))
                    {
                        itemLockType = ItemLocType.GemWareHouse1;
                        itemlist = self.GetItemByLoc(itemLockType);
                    }
                    else
                    {
                        itemLockType = UseLocType;
                        itemlist = self.GetItemByLoc(itemLockType);
                    }
                }
                else
                {
                    itemLockType = UseLocType;
                    itemlist = self.GetItemByLoc(itemLockType);
                }

                for (int k = 0; k < itemlist.Count; k++)
                {
                    ItemInfo userBagInfo = itemlist[k];
                    if (userBagInfo.ItemID != itemID)
                    {
                        continue;
                    }

                    if (userBagInfo.ItemNum >= maxPileSum)
                    {
                        continue;
                    }

                    int newNum = leftNum + userBagInfo.ItemNum;
                    if (newNum > maxPileSum)
                    {
                        leftNum = newNum - maxPileSum;
                        newNum = maxPileSum;
                    }
                    else
                    {
                        leftNum = 0;
                    }

                    userBagInfo.ItemNum = newNum;
                    m2c_bagUpdate.BagInfoUpdate.Add(userBagInfo.ToMessage());

                    if (leftNum == 0)
                    {
                        //跳出循环
                        break;
                    }
                }

                //还没有插入完，需要开启新格子
                while (leftNum > 0)
                {
                    ItemInfo useBagInfo = self.AddChild<ItemInfo>();
                    useBagInfo.ItemID = itemID;
                    useBagInfo.ItemNum = (leftNum > maxPileSum) ? maxPileSum : leftNum;
                    useBagInfo.Loc = (int)itemLockType;
                    useBagInfo.BagInfoID = IdGenerater.Instance.GenerateId();
                    useBagInfo.GemHole = "0_0_0_0";
                    useBagInfo.GemIDNew = "0_0_0_0";
                    useBagInfo.GetWay = getWay;
                    leftNum -= useBagInfo.ItemNum;

                    //记录制造的玩家
                    useBagInfo.MakePlayer = makeUserID;
                    //蓝色品质的装备需要进行鉴定
                    //if (!ItemHelper.IsBuyItem(getType) && itemCof.ItemType == 3)
                    if (itemCof.ItemType == 3)
                    {
                        if (itemCof.ItemQuality >= 4)
                        {
                            useBagInfo.IfJianDing = true;
                        }
                        else
                        {
                            //白色和绿色品质都是100% 紫色概率出鉴定
                            float jianDingPro = 0f;

                            if (itemCof.ItemQuality == 1)
                            {
                                jianDingPro = 0f;
                            }

                            if (itemCof.ItemQuality == 2)
                            {
                                jianDingPro = 0f;
                            }

                            if (itemCof.ItemQuality == 3)
                            {
                                jianDingPro = 0f;
                            }

                            if (itemCof.ItemQuality == 4)
                            {
                                jianDingPro = 0.75f;
                            }

                            if (RandomHelper.RandFloat() <= jianDingPro)
                            {
                                useBagInfo.IfJianDing = true;
                            }
                        }

                        //特殊处理不坚定
                        if (useBagInfo.ItemID == 14100021 || useBagInfo.ItemID == 14100022 || useBagInfo.ItemID == 14100121 ||
                            useBagInfo.ItemID == 14100122 || useBagInfo.ItemID == 14100221 || useBagInfo.ItemID == 14060006)
                        {
                            useBagInfo.IfJianDing = false;
                        }

                        int equipId = itemCof.ItemEquipID;
                        if (equipId != 0 && EquipConfigCategory.Instance.Get(equipId).AppraisalItem == 0)
                        {
                            useBagInfo.IfJianDing = false;
                        }

                        if (itemCof.EquipType == 101)
                        {
                            useBagInfo.IfJianDing = itemCof.ItemQuality >= 5;
                        }
                    }

                    // 默认洗练
                    if (!ItemHelper.IsBuyItem(getType) && itemCof.ItemEquipID != 0)
                    {
                        int xilianLevel = XiLianHelper.GetXiLianId(unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.ItemXiLianDu));
                        xilianLevel = xilianLevel != 0 ? EquipXiLianConfigCategory.Instance.Get(xilianLevel).XiLianLevel : 0;

                        int xilianType = 0;
                        if (getType == ItemGetWay.SkillMake || getType == ItemGetWay.TreasureMap)
                        {
                            xilianType = 2;
                        }

                        ItemXiLianResult itemXiLian = ItemXiLianResult.Create();
                        if (itemCof.EquipType < 101) //装备洗炼
                        {
                            itemXiLian = XiLianHelper.XiLianItem(unit, useBagInfo, xilianType, xilianLevel, 0, 0,
                                unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.ItemXiLianDu),
                                unit.GetComponent<UserInfoComponentS>().UserInfo.Name);
                        }
                        else if (itemCof.EquipType == 101) //生肖洗炼
                        {
                            itemXiLian = XiLianHelper.XiLianShengXiao(useBagInfo);
                        }

                        useBagInfo.XiLianHideProLists = itemXiLian.XiLianHideProLists; //基础属性洗炼
                        useBagInfo.HideSkillLists = itemXiLian.HideSkillLists; //隐藏技能
                        useBagInfo.XiLianHideTeShuProLists = itemXiLian.XiLianHideTeShuProLists; //特殊属性洗炼
                    }

                    if (ItemGetWay.ItemGetBing.Contains(getType))
                    {
                        useBagInfo.isBinging = true;
                    }

                    //掉落的橙色装备默认为绑定的物品
                    if (((getType == ItemGetWay.PickItem
                                || getType == ItemGetWay.ChouKa)
                            && itemCof.ItemQuality >= 5) || itemCof.IfLock == 1)
                    {
                        useBagInfo.isBinging = true;
                    }

                    if (getType == ItemGetWay.System)
                    {
                        useBagInfo.IfJianDing = false;
                    }

                    //藏宝图
                    if (itemCof.ItemSubType == 113 || itemCof.ItemSubType == 127)
                    {
                        ItemAddHelper.TreasureItem(unit, useBagInfo);
                    }

                    //鉴定符
                    if (itemCof.ItemSubType == 121)
                    {
                        int makePlan = 1;
                        if (getType == ItemGetWay.SkillMake && getWayInfo.Length >= 3)
                        {
                            makePlan = int.Parse(getWayInfo[1]);
                        }

                        if (makePlan != 1 && makePlan != 2)
                        {
                            makePlan = 1;
                        }

                        int shulianduNumeric = makePlan == 1 ? NumericType.MakeShuLianDu_1 : NumericType.MakeShuLianDu_2;
                        int shuliandu = unit.GetComponent<NumericComponentS>().GetAsInt(shulianduNumeric);
                        ItemAddHelper.JianDingFuItem(useBagInfo, shuliandu, getType);
                    }

                    //食物
                    if (itemCof.ItemType == 1 && itemCof.ItemSubType == 131)
                    {
                        useBagInfo.ItemPar = RandomHelper.RandomNumber(1, 100).ToString();
                    }

                    //家园烹饪
                    if (getType == ItemGetWay.JiaYuanCook)
                    {
                        useBagInfo.ItemPar = RandomHelper.RandomNumber(1, 100).ToString();
                    }

                    //拾取到橙色装备
                    if (itemCof.ItemType == 3 && itemCof.ItemQuality >= 5 && getType == ItemGetWay.PickItem)
                    {
                        string name = unit.GetComponent<UserInfoComponentS>().GetName();
                        string noticeContent = $"恭喜玩家 {name} 获得装备: <color=#{CommonHelp.QualityReturnColor(5)}>{itemCof.ItemName}</color>";
                        BroadCastHelper.SendBroadMessage(self.Root(), NoticeType.Notice, noticeContent);
                    }

                    //刷新传承属性
                    // if (itemCof.ItemType == ItemTypeEnum.Equipment && itemCof.EquipType != 101
                    //     && itemCof.ItemQuality >= 5 && itemCof.UseLv >= 60)
                    // {
                    //     int occ = unit.GetComponent<UserInfoComponentS>().GetOcc();
                    //     int occTwo = unit.GetComponent<UserInfoComponentS>().GetOccTwo();
                    //     int skillid = XiLianHelper.XiLianChuanChengJianDing(itemCof, occ, occTwo);
                    //     if (skillid != 0)
                    //     {
                    //         useBagInfo.InheritSkills.Add(skillid);
                    //     }
                    // }

                    // 振幅卷轴
                    if (itemCof.ItemType == ItemTypeEnum.Consume && itemCof.ItemSubType == 17)
                    {
                        // 属性
                        useBagInfo.IncreaseProLists.AddRange(XiLianHelper.GetHidePro(useBagInfo.ItemID));
                        // 技能
                        useBagInfo.IncreaseSkillLists.AddRange(XiLianHelper.GetHideSkill(useBagInfo.ItemID));
                    }

                    // 赛季晶核
                    if (itemCof.ItemType == ItemTypeEnum.Equipment && itemCof.EquipType == 201)
                    {
                        useBagInfo.ItemPar = ItemHelper.GetJingHeInitQulity(useBagInfo.ItemID).ToString();

                        //增加技能的晶核无须鉴定
                        int jingheSkill = ItemHelper.GetJingHeSkillId(useBagInfo.ItemID);
                        if (jingheSkill > 0)
                        {
                            useBagInfo.IfJianDing = false;
                            useBagInfo.HideSkillLists.Add(jingheSkill);
                        }
                        else
                        {
                            useBagInfo.IfJianDing = true;
                        }
                    }

                    self.GetItemByLoc(useBagInfo.Loc).Add(useBagInfo);
                    m2c_bagUpdate.BagInfoAdd.Add(useBagInfo.ToMessage());
                }

                //检测任务需求道具
                ItemAddHelper.OnGetItem(unit, getType, itemID, leftNum);
            }

            //通知客户端背包道具发生改变
            if (notice)
            {
                MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            }

            return true;
        }

        public static bool CheckCostItem(this BagComponentS self, string rewardItems)
        {
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
                if (self.GetItemNumber(itemId) < itemNum)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CheckCostItem(this BagComponentS self, List<RewardItem> rewardItems)
        {
            for (int i = 0; i < rewardItems.Count; i++)
            {
                RewardItem itemInfo = rewardItems[i];
                if (self.GetItemNumber(itemInfo.ItemID) < itemInfo.ItemNum)
                {
                    return false;
                }
            }

            return true;
        }

        //字符串删除道具
        public static bool OnCostItemData(this BagComponentS self, string rewardItems, int itemLocType = ItemLocType.ItemLocBag)
        {
            List<RewardItem> costItems = new List<RewardItem>();
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
                costItems.Add(new RewardItem() { ItemID = itemId, ItemNum = itemNum });
            }

            return self.OnCostItemData(costItems, itemLocType);
        }

        //删除背包道具道具[支持同时添加多个]
        public static bool OnCostItemData(this BagComponentS self, List<long> costItems, int itemLocType = ItemLocType.ItemLocBag)
        {
            //通知客户端背包刷新
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();

            List<ItemInfo> ItemTypeList = self.GetItemByLoc(itemLocType);

            for (int i = 0; i < costItems.Count; i++)
            {
                for (int k = ItemTypeList.Count - 1; k >= 0; k--)
                {
                    if (ItemTypeList[k].BagInfoID == costItems[i])
                    {
                        m2c_bagUpdate.BagInfoDelete.Add(ItemTypeList[k].ToMessage());
                        ItemTypeList[k].Dispose();
                        ItemTypeList.RemoveAt(k);
                        break;
                    }
                }
            }

            //通知客户端背包道具发生改变
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2c_bagUpdate);
            return true;
        }

        //指定某一个格子的ID
        public static bool OnCostItemData(this BagComponentS self, long uid, int number)
        {
            //通知客户端背包刷新
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();

            List<ItemInfo> ItemTypeList = self.GetItemByLoc(ItemLocType.ItemLocBag);
            for (int k = ItemTypeList.Count - 1; k >= 0; k--)
            {
                if (ItemTypeList[k].BagInfoID == uid)
                {
                    ItemTypeList[k].ItemNum -= number;

                    if (ItemTypeList[k].ItemNum <= 0)
                    {
                        m2c_bagUpdate.BagInfoDelete.Add(ItemTypeList[k].ToMessage());
                        ItemTypeList[k].Dispose();
                        ItemTypeList.RemoveAt(k);
                    }
                    else
                    {
                        m2c_bagUpdate.BagInfoUpdate.Add(ItemTypeList[k].ToMessage());
                    }

                    break;
                }
            }

            //通知客户端背包道具发生改变
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2c_bagUpdate);
            return true;
        }

        //删除背包道具道具[支持同时添加多个]
        public static bool OnCostItemData(this BagComponentS self, List<RewardItem> costItems, int itemLocType = ItemLocType.ItemLocBag)
        {
            for (int i = costItems.Count - 1; i >= 0; i--)
            {
                int itemID = costItems[i].ItemID;
                long itemNum = costItems[i].ItemNum;

                //获取背包内的道具是否足够
                if (self.GetItemNumber(itemID, itemLocType) < itemNum)
                {
                    return false;
                }
            }

            //通知客户端背包刷新
            Unit unit = self.GetParent<Unit>();
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
            m2c_bagUpdate.BagInfoAdd = new List<ItemInfoProto>();

            for (int i = costItems.Count - 1; i >= 0; i--)
            {
                int itemID = costItems[i].ItemID;
                int itemNum = costItems[i].ItemNum;

                //扣除金币
                if (itemID == (int)UserDataType.Gold)
                {
                    itemNum = -1 * itemNum;
                    unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneySub(UserDataType.Gold, itemNum.ToString(), true, ItemGetWay.CostItem);
                    continue;
                }

                if (itemID == (int)UserDataType.Diamond)
                {
                    itemNum = -1 * itemNum;
                    unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneySub(UserDataType.Diamond, itemNum.ToString(), true, ItemGetWay.CostItem);
                    continue;
                }

                if (itemID == (int)UserDataType.RongYu)
                {
                    itemNum = -1 * itemNum;
                    unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.RongYu, itemNum.ToString());
                    continue;
                }

                if (itemID == (int)UserDataType.JiaYuanFund)
                {
                    itemNum = -1 * itemNum;
                    unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.JiaYuanFund, itemNum.ToString());
                    continue;
                }

                if (itemID == (int)UserDataType.SeasonCoin)
                {
                    itemNum = -1 * itemNum;
                    unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.SeasonCoin, itemNum.ToString());
                    continue;
                }

                if (itemID == (int)UserDataType.UnionContri)
                {
                    itemNum = -1 * itemNum;
                    unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.UnionContri, itemNum.ToString());
                    continue;
                }

                Log.Warning($"消耗道具: {unit.Id} {itemID} {itemNum}");
                List<ItemInfo> bagInfos = self.GetItemByLoc(itemLocType);
                for (int k = bagInfos.Count - 1; k >= 0; k--)
                {
                    ItemInfo userBagInfo = bagInfos[k];
                    if (userBagInfo.ItemID == itemID)
                    {
                        if (userBagInfo.ItemNum >= itemNum)
                        {
                            //满足扣除数
                            int costNum = itemNum;
                            itemNum -= userBagInfo.ItemNum;
                            userBagInfo.ItemNum -= costNum;
                            if (userBagInfo.ItemNum <= 0)
                            {
                                m2c_bagUpdate.BagInfoDelete.Add(userBagInfo.ToMessage());
                                userBagInfo.Dispose();
                                bagInfos.RemoveAt(k);
                            }
                            else
                            {
                                m2c_bagUpdate.BagInfoUpdate.Add(userBagInfo.ToMessage());
                            }
                        }
                        else
                        {
                            itemNum -= userBagInfo.ItemNum;
                            //完全删除道具
                            userBagInfo.ItemNum = 0;
                            m2c_bagUpdate.BagInfoDelete.Add(userBagInfo.ToMessage());
                            userBagInfo.Dispose();
                            bagInfos.RemoveAt(k);
                        }

                        //扣除完道具直接跳出当前循环
                        if (itemNum <= 0)
                        {
                            break;
                        }
                    }
                }
                //ItemAddHelper.OnCostItem(unit, itemID);
            }

            //通知客户端背包道具发生改变
            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            return true;
        }

        public static int GetQiangHuaLevel(this BagComponentS self, int subType)
        {
            if (subType > 1000)
            {
                return 0;
            }

            if (self.QiangHuaLevel.Count == 0)
            {
                Console.WriteLine("self.QiangHuaLevel.Count == 0");
                return 0;
            }

            return self.QiangHuaLevel[subType];
        }

        public static bool OnCostItemData(this BagComponentS self, ItemInfo bagInfo, int locType, int number)
        {
            List<ItemInfo> bagInfos = self.GetItemByLoc(locType);

            if (bagInfo.ItemNum >= number)
            {
                bagInfo.ItemNum -= number;

                if (bagInfo.ItemNum <= 0)
                {
                    bagInfos.Remove(bagInfo);
                    bagInfo.Dispose();
                }

                Log.Warning($"消耗道具: {self.GetParent<Unit>().Id} {bagInfo.ItemID} {number}");
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void OnEquipFuMo(this BagComponentS self, int itemid, List<HideProList> hideProLists, int index)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemid);
            string[] itemparams = itemConfig.ItemUsePar.Split('@');
            int weizhi = int.Parse(itemparams[0]);
            List<ItemInfo> bagInfos = self.GetEquipListByWeizhi(ItemLocType.ItemLocEquip, weizhi);
            if (bagInfos.Count <= index)
            {
                return;
            }

            //通知客户端背包刷新
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
            m2c_bagUpdate.BagInfoUpdate.Add(bagInfos[index].ToMessage());

            //9@200103; 0.03; 0.03
            bagInfos[index].FumoProLists.Clear();
            bagInfos[index].FumoProLists.AddRange(hideProLists);
            //bagInfos[index].FumoProLists.AddRange( ItemHelper.GetItemFumoPro(itemid) );

            //通知客户端背包道具发生改变
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2c_bagUpdate);
            //Function_Fight.GetInstance().UnitUpdateProperty_Base(self.GetParent<Unit>(), true, true);
        }
       
    }
}