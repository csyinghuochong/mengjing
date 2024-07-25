using System.Collections.Generic;

namespace ET.Client
{
    public static class RobotHelper
    {
        public static async ETTask JianDing(Scene root)
        {
            //可以鉴定的装备
            List<BagInfo> bagInfos = root.GetComponent<BagComponentC>().GetCanJianDing();

            //鉴定装备
            foreach (BagInfo bagInfo in bagInfos)
            {
                await BagClientNetHelper.RequestAppraisalItem(root, bagInfo);
            }
        }

        public static async ETTask WearEquip(Scene root)
        {
            //可以穿戴的装备
            List<BagInfo> bagInfos = root.GetComponent<BagComponentC>().GetCanEquipList();

            //穿戴装备
            foreach (BagInfo bagInfo in bagInfos)
            {
                await BagClientNetHelper.RequestTakeoffEquip(root, bagInfo);
            }
        }

        public static async ETTask XiangQianGem(Scene root)
        {
            List<BagInfo> gemstones = root.GetComponent<BagComponentC>().GetItemsByType((int)ItemTypeEnum.Gemstone);
            List<BagInfo> equips = root.GetComponent<BagComponentC>().GetEquipList();

            foreach (BagInfo equip in equips)
            {
                string[] gemHoles = equip.GemHole.Split('_');
                string[] gemIDNews = equip.GemIDNew.Split('_');

                for (int j = 0; j < gemHoles.Length; j++)
                {
                    string gemHole = gemHoles[j];
                    string gemIDNew = gemIDNews[j];

                    for (int i = gemstones.Count - 1; i >= 0; i--)
                    {
                        BagInfo gemstone = gemstones[i];
                        ItemConfig itemConfig = ItemConfigCategory.Instance.Get(gemstone.ItemID);
                        if (gemHole != itemConfig.ItemSubType.ToString() && itemConfig.ItemSubType != 110 && itemConfig.ItemSubType != 111)
                        {
                            // 宝石与孔位不符！
                            continue;
                        }

                        if (gemIDNew != "0")
                        {
                            // 该孔位存在宝石
                            ItemConfig beforeItemConfig = ItemConfigCategory.Instance.Get(int.Parse(gemIDNew));

                            if (itemConfig.SellMoneyValue <= beforeItemConfig.SellMoneyValue)
                            {
                                continue;
                            }
                        }

                        string usrPar = string.Format("{0}_{1}", equip.BagInfoID, j);

                        await BagClientNetHelper.RequestXiangQianGem(root, gemstone, usrPar);

                        gemstones.RemoveAt(i);
                    }
                }
            }
        }

        public static async ETTask AddPoint(Scene root)
        {
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            int occ = userInfoComponent.UserInfo.Occ;
            int occTwo = userInfoComponent.UserInfo.OccTwo;

            // 按比例推荐加点
            string recommendAddPoint = string.Empty;
            if (ConfigData.RecommendAddPoint.ContainsKey(occTwo))
            {
                recommendAddPoint = ConfigData.RecommendAddPoint[occTwo];
            }
            else if (ConfigData.RecommendAddPoint.ContainsKey(occ))
            {
                recommendAddPoint = ConfigData.RecommendAddPoint[occ];
            }
            else
            {
                return;
            }

            string[] str = recommendAddPoint.Split('@');
            int all = 0;
            List<int> points = new List<int>();
            foreach (string s in str)
            {
                all += int.Parse(s);
                points.Add(int.Parse(s));
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();
            List<int> PointList = new List<int>();
            PointList.Add(numericComponentC.GetAsInt(NumericType.PointLiLiang));
            PointList.Add(numericComponentC.GetAsInt(NumericType.PointZhiLi));
            PointList.Add(numericComponentC.GetAsInt(NumericType.PointTiZhi));
            PointList.Add(numericComponentC.GetAsInt(NumericType.PointNaiLi));
            PointList.Add(numericComponentC.GetAsInt(NumericType.PointMinJie));

            int PointRemain = numericComponentC.GetAsInt(NumericType.PointRemain);

            int red = 0;
            for (int i = 0; i < 5; i++)
            {
                int add = PointRemain / all * points[i];
                red += add;
                PointList[i] += add;
            }

            PointRemain -= red;

            await BagClientNetHelper.RoleAddPoint(root, PointList);
        }

        public static async ETTask GemHeCheng(Scene root)
        {
            BagComponentC bagComponent = root.GetComponent<BagComponentC>();
            if (bagComponent.GetBagLeftCell() < 1)
            {
                // 请至少预留一个格子
                return;
            }

            List<BagInfo> bagItemList = bagComponent.GetBagList();
            List<BagInfo> gemList = new List<BagInfo>();
            for (int i = 0; i < bagItemList.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagItemList[i].ItemID);
                if (itemConfig.ItemType != ItemTypeEnum.Gemstone)
                {
                    continue;
                }

                if (!EquipMakeConfigCategory.Instance.GetHeChengList.ContainsKey(itemConfig.Id))
                {
                    continue;
                }

                gemList.Add(bagItemList[i]);
            }

            long costgold = 0;
            long costvitality = 0;
            for (int i = gemList.Count - 1; i >= 0; i--)
            {
                KeyValuePairInt keyValuePair = EquipMakeConfigCategory.Instance.GetHeChengList[gemList[i].ItemID];
                int neednumber = (int)keyValuePair.Value;
                int newmakeid = keyValuePair.KeyId;
                int newnumber = gemList[i].ItemNum / neednumber;
                EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(newmakeid);
                costgold += (equipMakeConfig.MakeNeedGold * newnumber);
                costvitality += (equipMakeConfig.CostVitality * newnumber);
            }

            if (costgold <= 0)
            {
                // 当前背包暂无可合成宝石
                return;
            }

            await BagClientNetHelper.RquestGemHeCheng(root, 0);
        }

        public static async ETTask HuiShou(Scene root)
        {
            BagComponentC bagComponentC = root.GetComponent<BagComponentC>();
            UserInfo userInfo = root.GetComponent<UserInfoComponentC>().UserInfo;

            List<BagInfo> bagInfos = new List<BagInfo>();

            bagInfos.AddRange(bagComponentC.GetItemsByType(ItemTypeEnum.Equipment));
            bagInfos.AddRange(bagComponentC.GetItemsByType(ItemTypeEnum.Gemstone));
            bagInfos.AddRange(bagComponentC.GetItemsByLoc(ItemLocType.ItemPetHeXinBag));
            bagInfos.AddRange(bagComponentC.GetItemsByTypeAndSubType(ItemTypeEnum.Consume, 5));

            List<long> huishouList = new List<long>();
            foreach (BagInfo bagInfo in bagInfos)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);

                // 回收绿色及其以下品质的道具
                if (itemConfig.ItemQuality <= 2)
                {
                    huishouList.Add(bagInfo.BagInfoID);
                }
            }

            await BagClientNetHelper.RequestHuiShou(root, huishouList);
        }

        public static async ETTask QiangHua(Scene root)
        {
            BagComponentC bagComponent = root.GetComponent<BagComponentC>();
            for (int itemSubType = 1; itemSubType <= 11; itemSubType++)
            {
                int qianghuaLevel = bagComponent.QiangHuaLevel[itemSubType];
                int maxLevel = QiangHuaHelper.GetQiangHuaMaxLevel(itemSubType);
                if (qianghuaLevel >= maxLevel - 1)
                {
                    // 已经强化到最大等级！
                    continue;
                }

                EquipQiangHuaConfig equipQiangHuaConfig = QiangHuaHelper.GetQiangHuaConfig(itemSubType, qianghuaLevel);
                string costItems = equipQiangHuaConfig.CostItem;

                costItems += string.Format("@1;{0}", equipQiangHuaConfig.CostGold);

                if (!bagComponent.CheckNeedItem(costItems))
                {
                    // 道具不足！
                    continue;
                }

                await BagClientNetHelper.RequestItemQiangHua(root, itemSubType);
            }

            await ETTask.CompletedTask;
        }

        public static async ETTask PetFight(Scene root)
        {
            PetComponentC petComponent = root.GetComponent<PetComponentC>();
            RolePetInfo rolePetInfo = null;

            foreach (RolePetInfo petInfo in petComponent.RolePetInfos)
            {
                if (petInfo.PetStatus == 2)
                {
                    // 先停止散步！
                    continue;
                }

                if (rolePetInfo == null)
                {
                    rolePetInfo = petInfo;
                    continue;
                }

                // 选一只评分最高的
                if (PetHelper.PetPingJia(petInfo) > PetHelper.PetPingJia(rolePetInfo))
                {
                    rolePetInfo = petInfo;
                }
            }

            if (rolePetInfo == null)
            {
                return;
            }

            if (rolePetInfo.PetStatus == 1)
            {
                return;
            }

            await PetNetHelper.RequestPetFight(root, rolePetInfo.Id, rolePetInfo.PetStatus == 0 ? 1 : 0);
        }

        public static async ETTask RolePetHeXin(Scene root, int score)
        {
            PetComponentC petComponent = root.GetComponent<PetComponentC>();
            List<RolePetInfo> rolePetInfos = new List<RolePetInfo>();

            foreach (RolePetInfo petInfo in petComponent.RolePetInfos)
            {
                if (PetHelper.PetPingJia(petInfo) > score)
                {
                    rolePetInfos.Add(petInfo);
                }
            }

            if (rolePetInfos.Count == 0)
            {
                return;
            }

            foreach (RolePetInfo rolePetInfo in rolePetInfos)
            {
                for (int position = 0; position < 3; position++)
                {
                    List<BagInfo> bagInfos = new List<BagInfo>();

                    foreach (BagInfo item in root.GetComponent<BagComponentC>().GetItemsByLoc(ItemLocType.ItemPetHeXinBag))
                    {
                        ItemConfig itemConfig = ItemConfigCategory.Instance.Get(item.ItemID);

                        if (itemConfig.ItemSubType - 1 != position)
                        {
                            continue;
                        }

                        bagInfos.Add(item);
                    }

                    if (bagInfos.Count == 0)
                    {
                        continue;
                    }

                    bagInfos.Sort((bagInfo1, bagInfo2) =>
                    {
                        ItemConfig itemConfig1 = ItemConfigCategory.Instance.Get(bagInfo1.ItemID);
                        ItemConfig itemConfig2 = ItemConfigCategory.Instance.Get(bagInfo2.ItemID);
                        return itemConfig2.UseLv - itemConfig1.UseLv;
                    });

                    List<BagInfo> eqipInfos = root.GetComponent<BagComponentC>().GetItemsByLoc(ItemLocType.ItemPetHeXinEquip);

                    long baginfoId = rolePetInfo.PetHeXinList[position];
                    BagInfo bagInfo = null;
                    for (int i = 0; i < eqipInfos.Count; i++)
                    {
                        if (eqipInfos[i].BagInfoID == baginfoId)
                        {
                            bagInfo = eqipInfos[i];
                        }
                    }

                    if (bagInfo == null)
                    {
                        await PetNetHelper.RequestRolePetHeXin(root, 1, bagInfos[0].BagInfoID, rolePetInfo.Id, position);
                    }
                    else
                    {
                        ItemConfig beforeItemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                        ItemConfig afterItemConfig = ItemConfigCategory.Instance.Get(bagInfos[0].ItemID);
                        if (beforeItemConfig.UseLv < afterItemConfig.UseLv)
                        {
                            await PetNetHelper.RequestRolePetHeXin(root, 1, bagInfos[0].BagInfoID, rolePetInfo.Id, position);
                        }
                    }
                }
            }
        }
    }
}