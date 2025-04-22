using System.Collections.Generic;

namespace ET
{
    [FriendOf(typeof(RewardItem))]
    public static class ItemHelper
    {
        public static List<ItemInfoProto> GetRewardItems_2(string needitems)
        {
            List<ItemInfoProto> costItems = new List<ItemInfoProto>();
            if (CommonHelp.IfNull(needitems))
            {
                return costItems;
            }
            string[] needList = needitems.Split('@');
            for (int i = 0; i < needList.Length; i++)
            {
                string[] itemInfo = needList[i].Split(';');
                int itemId = int.Parse(itemInfo[0]);
                int itemNum = int.Parse(itemInfo[1]);
                ItemInfoProto ItemInfoProto = ItemInfoProto.Create();
                ItemInfoProto.ItemID = itemId;
                ItemInfoProto.ItemNum = itemNum;      
                costItems.Add(ItemInfoProto);
            }
            return costItems;
        }
        
        public static int CanEquip(ItemInfo bagInfo, UserInfo userInfo)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);

            //判断等级
            int roleLv = userInfo.Lv;
            int equipLv = itemConfig.UseLv;
            //简易
            if (bagInfo.HideSkillLists.Contains(68000103))
            {
                equipLv = equipLv - 5;
            }

            //无级别
            if (bagInfo.HideSkillLists.Contains(68000106))
            {
                equipLv = 1;
            }

            if (roleLv < equipLv)
            {
                return ErrorCode.ERR_EquipLvLimit;
            }

            //对应部位是否符合
            if (itemConfig.ItemType == 3 && itemConfig.EquipType != 0)
            {
                //查看自身是否是二转
                if (userInfo.OccTwo > 0)
                {
                    OccupationTwoConfig occtwoCof = OccupationTwoConfigCategory.Instance.Get(userInfo.OccTwo);
                    if (occtwoCof.ArmorMastery == itemConfig.EquipType || itemConfig.EquipType == 99 || itemConfig.EquipType == 101)
                    {
                        //可以穿戴
                    }
                    else
                    {
                        bool ifWear = false;
                        if (userInfo.Occ == 1 && (itemConfig.EquipType == 1 || itemConfig.EquipType == 2))
                        {
                            ifWear = true;
                        }

                        if (userInfo.Occ == 2 && (itemConfig.EquipType == 3 || itemConfig.EquipType == 4))
                        {
                            ifWear = true;
                        }

                        if (userInfo.Occ == 3 && (itemConfig.EquipType == 1 || itemConfig.EquipType == 5))
                        {
                            ifWear = true;
                        }

                        //佩戴部位不符
                        if (ifWear == false)
                        {
                            return ErrorCode.ERR_EquipType; //错误码:穿戴类型不符
                        }
                    }
                }
            }

            return 0;
        }

        /// <summary>
        /// 是否有传承增幅属性
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static bool IsHaveMovePro(ItemInfo info)
        {
            bool canTrans = false;
            foreach (HideProList hideProList in info.IncreaseProLists)
            {
                HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(hideProList.HideID);
                if (hideProListConfig.IfMove == 1)
                {
                    canTrans = true;
                    break;
                }
            }

            foreach (int increaseSkillList in info.IncreaseSkillLists)
            {
                HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(increaseSkillList);
                if (hideProListConfig.IfMove == 1)
                {
                    canTrans = true;
                    break;
                }
            }

            return canTrans;
        }

        public static ItemInfoProto GetBagInfo(int itemId, int itemNum, int getWay)
        {
            ItemInfoProto bagInfo = ItemInfoProto.Create();
            bagInfo.ItemID = itemId;
            bagInfo.ItemNum = itemNum;
            bagInfo.GetWay = $"{getWay}_{TimeHelper.ServerNow()}";
            return bagInfo;
        }

        public static string GetInheritCost(int number)
        {
            string[] costitem = GlobalValueConfigCategory.Instance.Get(88).Value.Split('@');
            if (number >= costitem.Length)
            {
                return costitem[costitem.Length - 1];
            }

            return costitem[number];
        }

        /// <summary>
        /// 晶核增加品质
        /// </summary>
        /// <param name="qulitylv">传入消耗晶核的品质。 baginfo.itempar</param>
        /// <returns>返回一个本次预计增加品质范围(客户端显示用， 服务器随机取值)</returns>
        public static List<int> GetJingHeAddQulity(List<int> qulitylv)
        {
            //int addValue = (int)(qulitylv / 10f);
            int min = 10;
            int max = 20;
            return new List<int>() { min, max };
        }

        //晶核初始品质
        public static int GetJingHeInitQulity(int itemid)
        {
            //1,30@1;202103,0.01,0.03
            //初始品质最小值,初始品质最大值;属性类型;属性值
            //下面时属性类型
            //1; 属性ID,属性最大值,属性最小值
            //2;附带技能
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemid);
            string[] parmainfos = itemConfig.ItemUsePar.Split('@');
            string[] qulityinfo = parmainfos[0].Split(',');
            int lowlevel = int.Parse(qulityinfo[0]);
            int highlevel = int.Parse((qulityinfo[1]));

            return RandomHelper.RandomNumber(lowlevel, highlevel + 1);
        }

        //晶核属性类型
        public static int GetJingHeProType(int itemid)
        {
            //1,30@1;202103,0.01,0.03   增加属性
            //1,30@2;62000001           增加技能
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemid);
            string[] parmainfos = itemConfig.ItemUsePar.Split('@');
            string[] attriinfos = parmainfos[1].Split(';');
            int addType = int.Parse(attriinfos[0]);
            return addType;
        }

        //晶核属性类型
        public static int GetJingHeSkillId(int itemid)
        {
            //1,30@1;202103,0.01,0.03   增加属性
            //1,30@2;62000001           增加技能
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemid);
            string[] parmainfos = itemConfig.ItemUsePar.Split('@');
            string[] attriinfos = parmainfos[1].Split(';');
            int addType = int.Parse(attriinfos[0]);
            if (addType != 2)
            {
                return 0;
            }

            return int.Parse(attriinfos[1]);
        }

        //生成晶核属性. 
        public static HideProList GetJingHeHidePro(int itemid, int qulity)
        {
            //1,30@1;202103,0.01,0.03   增加属性
            //1,30@2;62000001           增加技能

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemid);
            string[] parmainfos = itemConfig.ItemUsePar.Split('@');
            string[] attriinfos = parmainfos[1].Split(';');

            int addType = int.Parse(attriinfos[0]);
            if (addType != 1)
            {
                return null;
            }

            string[] hidevalueinfo = attriinfos[1].Split(',');
            int hideid = int.Parse(hidevalueinfo[0]);
            int showType = NumericHelp.GetNumericValueType(hideid);
            if (showType == 2)
            {
                float hidevaluemin = float.Parse(hidevalueinfo[1]);
                float hidevaluemax = float.Parse(hidevalueinfo[2]);
                (hidevaluemin, hidevaluemax) = GetJingHeHideProRange(hidevaluemin, hidevaluemax, qulity);
                float hidevalue = RandomHelper.RandomNumberFloat(hidevaluemin, hidevaluemax);
                // float hidevalue = RandomHelper.RandomNumberFloat(hidevaluemin, hidevalueman - hidevaluemin);
                // if (qulity < 90) {
                //     hidevalue = hidevaluemin +  hidevalue * (0.4f + qulity / 100 * 0.6f);
                // }
                //保底
                return new HideProList() { HideID = hideid, HideValue = (long)(hidevalue * 10000) };
            }
            else
            {
                int hidevaluemin = int.Parse(hidevalueinfo[1]);
                int hidevaluemax = int.Parse(hidevalueinfo[2]);
                (hidevaluemin, hidevaluemax) = GetJingHeHideProRange(hidevaluemin, hidevaluemax, qulity);
                int hidevalue = RandomHelper.RandomNumber(hidevaluemin, hidevaluemax);
                // int hidevalue = RandomHelper.RandomNumber(hidevaluemin, hidevaluemax - hidevaluemin);
                // if (qulity < 90)
                // {
                //     hidevalue = hidevaluemin + (int)((float)hidevalue * (0.4f + qulity / 100 * 0.6f));
                // }

                return new HideProList() { HideID = hideid, HideValue = hidevalue };
            }
        }

        public static (float, float) GetJingHeHideProRange(float min, float max, int qulity)
        {
            float med = min + (max - min) * qulity / 100f;
            float activatedMinValue = 0;
            float activatedMaxValue = 0;
            if (med - 0.005f < min)
            {
                activatedMinValue = min;
            }
            else
            {
                activatedMinValue = med - 0.005f;
            }

            if (med + 0.005f > max)
            {
                activatedMaxValue = max;
            }
            else
            {
                activatedMaxValue = med + 0.005f;
            }

            return (activatedMinValue, activatedMaxValue);
        }

        public static (int, int) GetJingHeHideProRange(int min, int max, int qulity)
        {
            int med = min + (int)((max - min) * qulity / 100f);
            int activatedMinValue = 0;
            int activatedMaxValue = 0;
            if (med - 10 < min)
            {
                activatedMinValue = min;
            }
            else
            {
                activatedMinValue = med - 10;
            }

            if (med + 10 > max)
            {
                activatedMaxValue = max;
            }
            else
            {
                activatedMaxValue = med + 10;
            }

            return (activatedMinValue, activatedMaxValue);
        }

        /// <summary>
        /// 套装属性
        /// </summary>
        /// <param name="bagInfos"></param>
        /// <param name="occ"></param>
        /// <returns></returns>
        public static List<PropertyValue> GetSuiPros(List<BagInfo> bagComponent, int occ)
        {
            return new List<PropertyValue>();
        }

        /// <summary>
        /// //5 橙装
        /// </summary>
        /// <param name="bagInfos"></param>
        /// <param name="qulity"></param>
        /// <returns></returns>
        public static int GetNumberByQulity(List<ItemInfo> bagInfos, int qulity)
        {
            int number = 0;
            for (int i = 0; i < bagInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                if (itemConfig.ItemQuality >= qulity)
                {
                    number++;
                }
            }

            return number;
        }

        public static List<ItemInfo> GetSeedList(List<ItemInfo> bagInfos)
        {
            List<ItemInfo> seedlist = new List<ItemInfo>();
            for (int i = 0; i < bagInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                if (itemConfig.ItemType == 2 &&
                    (itemConfig.ItemSubType == 101 || itemConfig.ItemSubType == 131 || itemConfig.ItemSubType == 201 ||
                        itemConfig.ItemSubType == 301))
                {
                    seedlist.Add(bagInfos[i]);
                }

                if (itemConfig.ItemType == 1 && itemConfig.ItemSubType == 131)
                {
                    seedlist.Add(bagInfos[i]);
                }
            }

            return seedlist;
        }

        /// <summary>
        /// 从背包中获取所有藏宝图
        /// </summary>
        /// <param name="bagInfos"></param>
        /// <returns></returns>
        public static List<ItemInfo> GetTreasureMapList(List<ItemInfo> bagInfos)
        {
            List<ItemInfo> treasureMapList = new List<ItemInfo>();
            for (int i = 0; i < bagInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);

                if (itemConfig.ItemType == 1 && itemConfig.ItemSubType == 127)
                {
                    treasureMapList.Add(bagInfos[i]);
                }
            }

            return treasureMapList;
        }

        /// <summary>
        /// 从背包中获取生活材料,用于家园藏宝图的第二页分页
        /// </summary>
        /// <param name="bagInfos"></param>
        /// <returns></returns>
        public static List<ItemInfo> GetTreasureMapList2(List<ItemInfo> bagInfos)
        {
            List<ItemInfo> treasureMapList = new List<ItemInfo>();
            for (int i = 0; i < bagInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);

                if ((itemConfig.ItemType == 2 && (itemConfig.ItemSubType == 121)) ||
                    (itemConfig.ItemType == 1 && (itemConfig.ItemSubType == 15 || itemConfig.ItemSubType == 101)))
                {
                    treasureMapList.Add(bagInfos[i]);
                }
            }

            return treasureMapList;
        }

        public static int GetItemToUserDataType(int itemid)
        {
            int userDataType = UserDataType.None;
            ConfigData.ItemToUserDataType.TryGetValue(itemid, out userDataType);
            return userDataType;
        }

        public static int GetEquipType(int occ, int itemId)
        {
            if (itemId == 0)
            {
                if (occ == 1)
                {
                    return ItemEquipType.Sword;
                }

                if (occ == 2)
                {
                    return ItemEquipType.Wand;
                }

                if (occ == 3)
                {
                    return ItemEquipType.Bow;
                }

                Log.Error($"{occ} 没有配置此职业的默认武器！");
                return ItemEquipType.Sword;
            }
            else
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemId);
                return itemConfig.EquipType;
            }
        }

        public static int GetNeedCell(string needitems)
        {
            List<RewardItem> rewards = GetRewardItems(needitems);
            return GetNeedCell(rewards);
        }

        public static int GetNeedCell(List<RewardItem> rewardItems_1)
        {
            Dictionary<int, int> rewardItems = new Dictionary<int, int>();
            for (int i = 0; i < rewardItems_1.Count; i++)
            {
                if (!rewardItems.ContainsKey(rewardItems_1[i].ItemID))
                {
                    rewardItems.Add(rewardItems_1[i].ItemID, 0);
                }

                rewardItems[rewardItems_1[i].ItemID] += rewardItems_1[i].ItemNum;
            }

            int bagCellNumber = 1;
            foreach (var item in rewardItems)
            {
                int itemId = item.Key;
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemId);
                if (itemConfig.ItemPileSum == 999999)
                {
                    bagCellNumber += 1;
                    continue;
                }

                int ItemPileSum = itemConfig.ItemPileSum;
                if (item.Value <= ItemPileSum)
                {
                    bagCellNumber += 1;
                }
                else
                {
                    bagCellNumber += (int)(1f * item.Value / ItemPileSum);
                    bagCellNumber += (item.Value % ItemPileSum > 0 ? 1 : 0);
                }
                //needcell += Mathf.CeilToInt(rewards[i].ItemNum * 1f / itemConfig.ItemPileSum);
            }

            return bagCellNumber;
        }

        public static List<RewardItem> GetRewardItems(string needitems)
        {
            List<RewardItem> costItems = new List<RewardItem>();
            if (CommonHelp.IfNull(needitems))
            {
                return costItems;
            }

            string[] needList = needitems.Split('@');
            for (int i = 0; i < needList.Length; i++)
            {
                string[] itemInfo = needList[i].Split(';');
                int itemId = int.Parse(itemInfo[0]);
                int itemNum = int.Parse(itemInfo[1]);
                if (itemNum == 0)
                {
                    continue;
                }
                costItems.Add(new RewardItem() { ItemID = itemId, ItemNum = itemNum });
            }

            return costItems;
        }

        public static List<int> GetGemIdList(ItemInfo bagInfo)
        {
            string[] gemIdInfos = bagInfo.GemIDNew.Split('_');
            List<int> getIds = new List<int>();
            for (int i = 0; i < gemIdInfos.Length; i++)
            {
                int getItemId = int.Parse(gemIdInfos[i]);
                if (getItemId > 0)
                {
                    getIds.Add(getItemId);
                }
            }

            return getIds;
        }

        //金币鉴定消费
        public static int GetJianDingCoin(int level)
        {
            int gold = 25000;
            bool ifStatus = false;

            if (level <= 18)
            {
                gold = 25000;
                ifStatus = true;
            }

            if (level <= 29 && ifStatus == false)
            {
                gold = 30000;
            }

            if (level <= 39 && ifStatus == false)
            {
                gold = 35000;
            }

            if (level <= 49 && ifStatus == false)
            {
                gold = 40000;
            }

            if (level <= 100 && ifStatus == false)
            {
                gold = 50000;
            }

            return gold;
        }

        public static bool IsBuyItem(int getType)
        {
            return getType == ItemGetWay.StoreBuy || getType == ItemGetWay.MysteryBuy || getType == ItemGetWay.PaiMaiShop;
        }

        public static ItemInfo GetEquipByWeizhi(List<ItemInfo> bagInfos, int pos)
        {
            for (int i = 0; i < bagInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                if (itemConfig.ItemSubType == pos)
                {
                    return bagInfos[i];
                }
            }

            return null;
        }

        //客户端线条用的
        public static bool IfShengXiaoActiveLine(string shengXiaoItemID, List<ItemInfo> equipList)
        {
            List<int> idList = new List<int>();
            for (int i = 0; i < equipList.Count; i++)
            {
                idList.Add(equipList[i].ItemID);
            }

            switch (shengXiaoItemID)
            {
                case "16000104a":
                    if (idList.Contains(16000102) && idList.Contains(16000103))
                    {
                        return true;
                    }

                    return false;

                case "16000104b":
                    if (idList.Contains(16000101))
                    {
                        return true;
                    }

                    return false;

                case "16000111a":
                    if (idList.Contains(16000109) && idList.Contains(16000110))
                    {
                        return true;
                    }

                    return false;

                case "16000111b":
                    if (idList.Contains(16000112))
                    {
                        return true;
                    }

                    return false;

                case "16000204a":
                    if (idList.Contains(16000202) && idList.Contains(16000203))
                    {
                        return true;
                    }

                    return false;

                case "16000204b":
                    if (idList.Contains(16000201))
                    {
                        return true;
                    }

                    return false;

                case "16000211a":
                    if (idList.Contains(16000209) && idList.Contains(16000210))
                    {
                        return true;
                    }

                    return false;

                case "16000211b":
                    if (idList.Contains(16000212))
                    {
                        return true;
                    }

                    return false;

                case "16000304a":
                    if (idList.Contains(16000302) && idList.Contains(16000303))
                    {
                        return true;
                    }

                    return false;

                case "16000304b":
                    if (idList.Contains(16000301))
                    {
                        return true;
                    }

                    return false;

                case "16000311a":
                    if (idList.Contains(16000309) && idList.Contains(16000310))
                    {
                        return true;
                    }

                    return false;

                case "16000311b":
                    if (idList.Contains(16000312))
                    {
                        return true;
                    }

                    return false;
            }

            return IfShengXiaoActive(int.Parse(shengXiaoItemID), equipList);
        }

        //生肖激活前缀
        public static bool IfShengXiaoActive(int shengXiaoItemID, List<ItemInfo> equipList)
        {
            List<int> idList = new List<int>();
            for (int i = 0; i < equipList.Count; i++)
            {
                idList.Add(equipList[i].ItemID);
            }

            switch (shengXiaoItemID)
            {
                case 16000101:
                    return true;

                case 16000102:
                    return true;

                case 16000103:
                    if (idList.Contains(16000102))
                    {
                        return true;
                    }

                    break;

                case 16000104:
                    if (idList.Contains(16000102) && idList.Contains(16000103) || idList.Contains(16000101))
                    {
                        return true;
                    }

                    break;
                case 16000105:
                    return true;

                case 16000106:
                    if (idList.Contains(16000105))
                    {
                        return true;
                    }

                    break;

                case 16000107:
                    if (idList.Contains(16000105) && idList.Contains(16000106))
                    {
                        return true;
                    }

                    break;

                case 16000108:
                    if (idList.Contains(16000105) && idList.Contains(16000106) && idList.Contains(16000108))
                    {
                        return true;
                    }

                    break;

                case 16000109:
                    return true;

                case 16000110:
                    if (idList.Contains(16000109))
                    {
                        return true;
                    }

                    break;

                case 16000111:
                    if (idList.Contains(16000109) && idList.Contains(16000110) || idList.Contains(16000112))
                    {
                        return true;
                    }

                    break;

                case 16000112:
                    return true;

                case 16000201:
                    return true;

                case 16000202:
                    return true;

                case 16000203:
                    if (idList.Contains(16000202))
                    {
                        return true;
                    }

                    break;

                case 16000204:
                    if (idList.Contains(16000202) && idList.Contains(16000203) || idList.Contains(16000201))
                    {
                        return true;
                    }

                    break;
                case 16000205:
                    return true;

                case 16000206:
                    if (idList.Contains(16000205))
                    {
                        return true;
                    }

                    break;

                case 16000207:
                    if (idList.Contains(16000205) && idList.Contains(16000206))
                    {
                        return true;
                    }

                    break;

                case 16000208:
                    if (idList.Contains(16000205) && idList.Contains(16000206) && idList.Contains(16000208))
                    {
                        return true;
                    }

                    break;

                case 16000209:
                    return true;

                case 16000210:
                    if (idList.Contains(16000209))
                    {
                        return true;
                    }

                    break;

                case 16000211:
                    if (idList.Contains(16000209) && idList.Contains(16000210) || idList.Contains(16000212))
                    {
                        return true;
                    }

                    break;

                case 16000212:
                    return true;

                case 16000301:
                    return true;

                case 16000302:
                    return true;

                case 16000303:
                    if (idList.Contains(16000302))
                    {
                        return true;
                    }

                    break;

                case 16000304:
                    if (idList.Contains(16000302) && idList.Contains(16000303) || idList.Contains(16000301))
                    {
                        return true;
                    }

                    break;
                case 16000305:
                    return true;

                case 16000306:
                    if (idList.Contains(16000305))
                    {
                        return true;
                    }

                    break;

                case 16000307:
                    if (idList.Contains(16000305) && idList.Contains(16000306))
                    {
                        return true;
                    }

                    break;

                case 16000308:
                    if (idList.Contains(16000305) && idList.Contains(16000306) && idList.Contains(16000308))
                    {
                        return true;
                    }

                    break;

                case 16000309:
                    return true;

                case 16000310:
                    if (idList.Contains(16000309))
                    {
                        return true;
                    }

                    break;

                case 16000311:
                    if (idList.Contains(16000309) && idList.Contains(16000310) || idList.Contains(16000312))
                    {
                        return true;
                    }

                    break;

                case 16000312:
                    return true;
                case 16000401:
                    return true;

                case 16000402:
                    return true;

                case 16000403:
                    if (idList.Contains(16000402))
                    {
                        return true;
                    }

                    break;

                case 16000404:
                    if (idList.Contains(16000402) && idList.Contains(16000403) || idList.Contains(16000401))
                    {
                        return true;
                    }

                    break;
                case 16000405:
                    return true;

                case 16000406:
                    if (idList.Contains(16000405))
                    {
                        return true;
                    }

                    break;

                case 16000407:
                    if (idList.Contains(16000405) && idList.Contains(16000406))
                    {
                        return true;
                    }

                    break;

                case 16000408:
                    if (idList.Contains(16000405) && idList.Contains(16000406) && idList.Contains(16000408))
                    {
                        return true;
                    }

                    break;

                case 16000409:
                    return true;

                case 16000410:
                    if (idList.Contains(16000409))
                    {
                        return true;
                    }

                    break;

                case 16000411:
                    if (idList.Contains(16000409) && idList.Contains(16000410) || idList.Contains(16000412))
                    {
                        return true;
                    }

                    break;

                case 16000412:
                    return true;
            }

            return false;
        }

        public static string ItemGetWayName(int itemgetWay)
        {
            string getname = string.Empty;
            ConfigData.ItemGetWayNameList.TryGetValue(itemgetWay, out getname);
            return getname;
        }

        public static void ItemLitSort(List<ItemInfo> ItemTypeList)
        {
            ItemTypeList.Sort(delegate(ItemInfo a, ItemInfo b)
            {
                int itemIda = a.ItemID;
                int itemIdb = b.ItemID;
                int isBinginga = a.isBinging ? 1 : 0;
                int isBingingb = b.isBinging ? 1 : 0;
                ItemConfig itemConfig_a = ItemConfigCategory.Instance.Get(itemIda);
                ItemConfig itemConfig_b = ItemConfigCategory.Instance.Get(itemIdb);
                int quliatya = itemConfig_a.ItemQuality;
                int quliatyb = itemConfig_b.ItemQuality;
                int jianDingLva = itemConfig_a.ItemSubType == 121 && !string.IsNullOrEmpty(a.ItemPar) ? int.Parse(a.ItemPar) : 0;
                int jianDingLvb = itemConfig_b.ItemSubType == 121 && !string.IsNullOrEmpty(b.ItemPar) ? int.Parse(b.ItemPar) : 0;
                int dungeonida = (itemConfig_a.ItemSubType == 113 || itemConfig_a.ItemSubType == 127) ? int.Parse(a.ItemPar.Split('@')[0]) : 0;
                int dungeonidb = (itemConfig_b.ItemSubType == 113 || itemConfig_b.ItemSubType == 127) ? int.Parse(b.ItemPar.Split('@')[0]) : 0;
                //bagInfo.ItemPar = $"{dungeonid}@{"TaskMove_6"}@{rewardList[0].ItemID + ";" + rewardList[0].ItemNum}";

                if (isBinginga == isBingingb)
                {
                    if (quliatya == quliatyb)
                    {
                        if (jianDingLva == jianDingLvb)
                        {
                            if (dungeonida == dungeonidb)
                            {
                                if (itemIda == itemIdb)
                                {
                                    return b.ItemNum - a.ItemNum;
                                }
                                else
                                {
                                    return itemIda - itemIdb;
                                }
                            }
                            else
                            {
                                return dungeonidb - dungeonida;
                            }
                        }
                        else
                        {
                            return jianDingLvb - jianDingLva;
                        }
                    }
                    else
                    {
                        return quliatyb - quliatya;
                    }
                }
                else
                {
                    return isBinginga - isBingingb;
                }
            });
        }

        public static List<int> GetItemSkill(string skillpar)
        {
            ////69000013;69000017
            List<int> skillids = new List<int>();
            if (CommonHelp.IfNull(skillpar))
            {
                return skillids;
            }

            string[] skillinfos = skillpar.Split(';');
            for (int i = 0; i < skillinfos.Length; i++)
            {
                int skillid = int.Parse(skillinfos[i]);
                if (skillid != 0)
                {
                    skillids.Add(skillid);
                }
            }

            return skillids;
        }

        //获取装备的鉴定属性
        public static JianDingDate GetEquipZhuanJingPro(int equipID, int itemID, int jianDingPinZhi, bool ifItem)
        {
            //获取最大值
            EquipConfig equipCof = EquipConfigCategory.Instance.Get(equipID);

            //获取当前鉴定系数
            ItemConfig itemCof = ItemConfigCategory.Instance.Get(itemID);

            //最低系数是20
            int pro = itemCof.UseLv;
            if (pro <= 20)
            {
                pro = 20;
            }

            if (ifItem == true && itemCof.UseLv < 30)
            {
                jianDingPinZhi = jianDingPinZhi + 5;
            }

            //鉴定符和当前装备的等级差
            float JianDingPro = (float)jianDingPinZhi / (float)pro;
            float addJianDingPro = 0;

            if (JianDingPro >= 1.5f)
            {
                JianDingPro = 1.5f;
                addJianDingPro += 0.2f;
            }
            else if (JianDingPro >= 1f)
            {
                addJianDingPro += 0.2f * (JianDingPro - 0.5f);
            }

            if (JianDingPro <= 0.5f)
            {
                JianDingPro = 0.5f;
            }

            //随机值(高品质保底属性)
            int minNum = 1;
            if (JianDingPro > 1f)
            {
                minNum = (int)((float)equipCof.OneProRandomValue * (JianDingPro - 1f) * 0.8f);
            }

            int maxNum = (int)((float)equipCof.OneProRandomValue * JianDingPro * 0.8f);
            if (minNum > maxNum)
            {
                maxNum = minNum;
            }

            if (maxNum > equipCof.OneProRandomValue)
            {
                maxNum = equipCof.OneProRandomValue;
            }

            JianDingDate data = new JianDingDate();
            data.MinNum = minNum;
            data.MaxNum = maxNum;
            return data;
        }
    }
}