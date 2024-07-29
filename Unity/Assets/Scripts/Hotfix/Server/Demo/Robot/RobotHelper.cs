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

        public static async ETTask RolePetJiadian(Scene root)
        {
            PetComponentC petComponent = root.GetComponent<PetComponentC>();

            foreach (RolePetInfo petInfo in petComponent.RolePetInfos)
            {
                List<int> PointList = new List<int>();

                string[] propertyList = petInfo.AddPropretyValue.Split('_');
                PointList.Add(int.Parse(propertyList[0]));
                PointList.Add(int.Parse(propertyList[1]));
                PointList.Add(int.Parse(propertyList[2]));
                PointList.Add(int.Parse(propertyList[3]));

                int PointRemain = petInfo.AddPropretyNum;

                // 平均加点
                int add = PointRemain / 4;
                if (add == 0)
                {
                    continue;
                }

                PointList[0] += add;
                PointList[1] += add;
                PointList[2] += add;
                PointList[3] += add;
                await PetNetHelper.RequestRolePetJiadian(root, petInfo.Id, PointList);
            }
        }

        public static async ETTask RolePetHeCheng(Scene root, int score, int skillNum)
        {
            PetComponentC petComponent = root.GetComponent<PetComponentC>();
            if (petComponent.RolePetInfos.Count < 3)
            {
                // 最少有3个宠物才可以开启合成！
                return;
            }

            RolePetInfo HeChengPet_Left = null;
            RolePetInfo HeChengPet_Right = null;

            foreach (RolePetInfo rolePetInfo in petComponent.RolePetInfos)
            {
                if (rolePetInfo.PetStatus == 1)
                {
                    continue;
                }

                if (PetHelper.PetPingJia(rolePetInfo) < score && rolePetInfo.PetSkill.Count < skillNum)
                {
                    if (HeChengPet_Left == null)
                    {
                        HeChengPet_Left = rolePetInfo;
                        continue;
                    }

                    if (HeChengPet_Right == null)
                    {
                        HeChengPet_Right = rolePetInfo;
                        continue;
                    }
                }
            }

            if (HeChengPet_Left != null && HeChengPet_Right != null)
            {
                await PetNetHelper.RequestRolePetHeCheng(root, HeChengPet_Left.Id, HeChengPet_Right.Id);
            }
        }

        public static async ETTask RolePetXiLian(Scene root)
        {
            PetComponentC petComponent = root.GetComponent<PetComponentC>();
            List<BagInfo> ShowBagInfos = new List<BagInfo>();

            List<BagInfo> bagList = root.GetComponent<BagComponentC>().GetBagList();
            for (int i = 0; i < bagList.Count; i++)
            {
                int itemID = bagList[i].ItemID;
                ItemConfig conf = ItemConfigCategory.Instance.Get(itemID);
                int itemType = conf.ItemType;
                int itemSubType = conf.ItemSubType;

                if (itemSubType != 105 && itemSubType != 108 && itemSubType != 109
                    && itemSubType != 117 && itemSubType != 118 && itemSubType != 119
                    && itemSubType != 122 && itemSubType != 133 && itemSubType != 134
                    && itemSubType != 136)
                {
                    continue;
                }

                ShowBagInfos.Add(bagList[i]);
            }

            if (ShowBagInfos.Count == 0)
            {
                return;
            }

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

            await PetNetHelper.RequestXiLian(root, ShowBagInfos[0].BagInfoID, rolePetInfo.Id);
        }

        public static async ETTask PetShouHu(Scene root)
        {
            PetComponentC petComponent = root.GetComponent<PetComponentC>();
            RolePetInfo rolePetInfo1 = null;
            RolePetInfo rolePetInfo2 = null;
            RolePetInfo rolePetInfo3 = null;
            RolePetInfo rolePetInfo4 = null;

            List<long> shouhulist = petComponent.PetShouHuList;

            foreach (RolePetInfo rolePetInfo in petComponent.RolePetInfos)
            {
                if (shouhulist.Contains(rolePetInfo.Id))
                {
                    continue;
                }

                if (rolePetInfo.ShouHuPos == 1)
                {
                    if (rolePetInfo1 == null)
                    {
                        rolePetInfo1 = rolePetInfo;
                    }
                    else
                    {
                        if (PetHelper.PetPingJia(rolePetInfo) > PetHelper.PetPingJia(rolePetInfo1))
                        {
                            rolePetInfo1 = rolePetInfo;
                        }
                    }
                }

                if (rolePetInfo.ShouHuPos == 2)
                {
                    if (rolePetInfo2 == null)
                    {
                        rolePetInfo2 = rolePetInfo;
                    }
                    else
                    {
                        if (PetHelper.PetPingJia(rolePetInfo) > PetHelper.PetPingJia(rolePetInfo2))
                        {
                            rolePetInfo2 = rolePetInfo;
                        }
                    }
                }

                if (rolePetInfo.ShouHuPos == 3)
                {
                    if (rolePetInfo3 == null)
                    {
                        rolePetInfo3 = rolePetInfo;
                    }
                    else
                    {
                        if (PetHelper.PetPingJia(rolePetInfo) > PetHelper.PetPingJia(rolePetInfo3))
                        {
                            rolePetInfo3 = rolePetInfo;
                        }
                    }
                }

                if (rolePetInfo.ShouHuPos == 4)
                {
                    if (rolePetInfo4 == null)
                    {
                        rolePetInfo4 = rolePetInfo;
                    }
                    else
                    {
                        if (PetHelper.PetPingJia(rolePetInfo) > PetHelper.PetPingJia(rolePetInfo4))
                        {
                            rolePetInfo4 = rolePetInfo;
                        }
                    }
                }
            }

            if (rolePetInfo1 != null)
            {
                await PetNetHelper.RequestPetShouHu(root, rolePetInfo1.Id, 0);
            }

            if (rolePetInfo2 != null)
            {
                await PetNetHelper.RequestPetShouHu(root, rolePetInfo2.Id, 0);
            }

            if (rolePetInfo3 != null)
            {
                await PetNetHelper.RequestPetShouHu(root, rolePetInfo3.Id, 0);
            }

            if (rolePetInfo3 != null)
            {
                await PetNetHelper.RequestPetShouHu(root, rolePetInfo3.Id, 0);
            }
        }

        public static async ETTask PetShouHuActive(Scene root)
        {
            PetComponentC petComponent = root.GetComponent<PetComponentC>();

            int index = -1;
            RolePetInfo maxPetInfo = null;
            for (int i = 0; i < petComponent.PetShouHuList.Count; i++)
            {
                RolePetInfo rolePetInfo = petComponent.GetPetInfoByID(petComponent.PetShouHuList[i]);
                if (rolePetInfo == null)
                {
                    continue;
                }

                if (maxPetInfo == null)
                {
                    maxPetInfo = rolePetInfo;
                    index = i;
                    continue;
                }

                if (PetHelper.PetPingJia(rolePetInfo) > PetHelper.PetPingJia(maxPetInfo))
                {
                    maxPetInfo = rolePetInfo;
                    index = i;
                }
            }

            if (index != -1)
            {
                await PetNetHelper.RequestPetShouHuActive(root, index + 1);
            }
        }

        public static async ETTask SkillUp(Scene root)
        {
            List<SkillPro> skillPros = root.GetComponent<SkillSetComponentC>().SkillList;
            List<SkillPro> showSkillPros = new List<SkillPro>();

            for (int i = 0; i < skillPros.Count; i++)
            {
                SkillPro skillPro = skillPros[i];
                if (skillPro.SkillSetType == (int)SkillSetEnum.Item)
                {
                    continue;
                }

                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillPro.SkillID);
                if (skillConfig.IsShow == 1)
                {
                    continue;
                }

                showSkillPros.Add(skillPro);
            }

            foreach (SkillPro skillPro in showSkillPros)
            {
                UserInfo userInfo = root.GetComponent<UserInfoComponentC>().UserInfo;

                SkillConfig skillConfig_base = SkillConfigCategory.Instance.Get(skillPro.SkillID);

                int playerLv = userInfo.Lv;
                if (userInfo.Sp < skillConfig_base.CostSPValue)
                {
                    // 技能点不足！!
                    return;
                }

                if (playerLv < skillConfig_base.LearnRoseLv)
                {
                    // 等级不足！!
                    return;
                }

                if (userInfo.Gold < skillConfig_base.CostGoldValue)
                {
                    // 金币不足！!
                    return;
                }

                if (skillConfig_base.NextSkillID == 0)
                {
                    // 已满级！!
                    return;
                }

                await SkillNetHelper.ActiveSkillID(root, skillPro.SkillID);
            }
        }

        public static async ETTask SkillSet(Scene root)
        {
            List<SkillPro> skillPros = root.GetComponent<SkillSetComponentC>().SkillList;

            List<SkillPro> ShowSkillPros = new List<SkillPro>();
            for (int i = 0; i < skillPros.Count; i++)
            {
                if (skillPros[i].SkillSetType == (int)SkillSetEnum.Item)
                {
                    continue;
                }

                //没激活的不显示
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillPros[i].SkillID);
                if (skillConfig.SkillLv == 0 || skillConfig.IsShow == 1)
                {
                    continue;
                }

                if (skillConfig.SkillType == (int)SkillTypeEnum.PassiveSkill
                    || skillConfig.SkillType == (int)SkillTypeEnum.PassiveAddProSkill
                    || skillConfig.SkillType == (int)SkillTypeEnum.PassiveAddProSkillNoFight)
                {
                    continue;
                }

                ShowSkillPros.Add(skillPros[i]);
            }

            ShowSkillPros.Sort((skillPro1, skillPro2) =>
            {
                SkillConfig skillConfig1 = SkillConfigCategory.Instance.Get(skillPro1.SkillID);
                SkillConfig skillConfig2 = SkillConfigCategory.Instance.Get(skillPro2.SkillID);

                return skillConfig2.SkillLv - skillConfig1.SkillLv;
            });

            int index = 1;
            foreach (SkillPro skillPro in ShowSkillPros)
            {
                if (index >= 9)
                {
                    break;
                }

                index++;
                await SkillNetHelper.SetSkillIdByPosition(root, skillPro.SkillID, (int)SkillSetEnum.Skill, index);
            }
        }

        public static async ETTask TianFuActive(Scene root)
        {
            UserInfo userInfo = root.GetComponent<UserInfoComponentC>().UserInfo;
            int occTwo = OccupationConfigCategory.Instance.Get(userInfo.Occ).OccTwoID[0];

            Dictionary<int, List<int>> TianFuToLevel = new Dictionary<int, List<int>>();
            int[] TalentList = OccupationTwoConfigCategory.Instance.Get(occTwo).Talent;
            for (int i = 0; i < TalentList.Length; i++)
            {
                int talentId = TalentList[i];
                TalentConfig talentConfig = TalentConfigCategory.Instance.Get(talentId);
                if (!TianFuToLevel.ContainsKey(talentConfig.LearnRoseLv))
                {
                    TianFuToLevel.Add(talentConfig.LearnRoseLv, new List<int>());
                }

                TianFuToLevel[talentConfig.LearnRoseLv].Add(talentId);
            }

            List<List<int>> ShowTianFu = new List<List<int>>();
            foreach (var item in TianFuToLevel)
            {
                ShowTianFu.Add(item.Value);
            }

            int playerLv = userInfo.Lv;
            SkillSetComponentC skillSetComponent = root.GetComponent<SkillSetComponentC>();
            foreach (List<int> list in ShowTianFu)
            {
                // 默认选第一个
                int tianFuId = list[0];

                TalentConfig talentConfig = TalentConfigCategory.Instance.Get(tianFuId);
                if (playerLv < talentConfig.LearnRoseLv)
                {
                    // 等级不足!
                    continue;
                }

                int oldId = skillSetComponent.HaveSameTianFu(tianFuId);
                if (oldId != 0 && oldId != tianFuId)
                {
                    // 选了天赋了
                    continue;
                }

                await SkillNetHelper.ActiveTianFu(root, tianFuId);
            }
        }

        public static async ETTask LifeShieldCost(Scene root)
        {
            List<BagInfo> allInfos = new List<BagInfo>();
            BagComponentC bagComponent = root.GetComponent<BagComponentC>();
            allInfos.AddRange(bagComponent.GetItemsByType(ItemTypeEnum.Material));
            allInfos.AddRange(bagComponent.GetItemsByType(ItemTypeEnum.Equipment));

            List<BagInfo> showBagInfos = new List<BagInfo>();
            for (int i = 0; i < allInfos.Count; i++)
            {
                if (!ConfigData.ItemAddShieldExp.ContainsKey(allInfos[i].ItemID))
                {
                    continue;
                }

                showBagInfos.Add(allInfos[i]);
            }

            if (showBagInfos.Count == 0)
            {
                return;
            }

            SkillSetComponentC skillSetComponent = root.GetComponent<SkillSetComponentC>();
            for (int i = showBagInfos.Count - 1; i >= 0; i--)
            {
                int shieldType = RandomHelper.RandomNumber(1, 7);

                if (shieldType == 6)
                {
                    int hplv = skillSetComponent.GetLifeShieldLevel(shieldType);
                    int otlv = skillSetComponent.GetOtherMinLevel();
                    if (otlv <= hplv)
                    {
                        // 请先升级其他护盾！

                        shieldType--;
                    }
                }

                await SkillNetHelper.LifeShieldCost(root, shieldType, new List<long>() { showBagInfos[i].BagInfoID });
            }
        }

        public static async ETTask ItemMelting(Scene root)
        {
            BagComponentC bagComponent = root.GetComponent<BagComponentC>();

            List<long> huishouList = new List<long>();
            List<BagInfo> bagInfos = bagComponent.GetItemsByType(ItemTypeEnum.Equipment);
            for (int i = 0; i < bagInfos.Count; i++)
            {
                if (bagInfos[i].IsProtect)
                {
                    continue;
                }

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                if (itemConfig.ItemQuality < 4)
                {
                    continue;
                }

                huishouList.Add(bagInfos[i].BagInfoID);
            }

            if (huishouList.Count == 0)
            {
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            int makeId = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.MakeType_1);

            await SkillNetHelper.ItemMelting(root, huishouList, makeId);
        }

        public static async ETTask MakeEquip(Scene root, int makeType)
        {
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            BagComponentC bagComponent = root.GetComponent<BagComponentC>();

            List<int> makeList = userInfoComponent.UserInfo.MakeList;
            for (int i = 0; i < makeList.Count; i++)
            {
                if (!EquipMakeConfigCategory.Instance.Contain(makeList[i]))
                {
                    continue;
                }

                EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(makeList[i]);
                if (equipMakeConfig.ProficiencyType != makeType)
                {
                    continue;
                }

                long cdEndTime = userInfoComponent.GetMakeTime(makeList[i]);
                if (cdEndTime > TimeHelper.ServerNow())
                {
                    // InMakeCD
                    return;
                }

                if (userInfoComponent.UserInfo.Gold < equipMakeConfig.MakeNeedGold)
                {
                    // 金币不足！
                    return;
                }

                bool success = bagComponent.CheckNeedItem(equipMakeConfig.NeedItems);
                if (!success)
                {
                    // 材料不足！
                    return;
                }

                await BagClientNetHelper.RequestEquipMake(root, 0, makeList[i], 1);
            }
        }

        public static async ETTask AddFriend(Scene root)
        {
            List<Unit> units = UnitHelper.GetUnitsByType(root, UnitType.Player);
            List<FriendInfo> friendInfos = root.GetComponent<FriendComponent>().FriendList;

            foreach (Unit unit in units)
            {
                bool isFriend = false;
                foreach (FriendInfo friendInfo in friendInfos)
                {
                    if (friendInfo.UserId == unit.Id)
                    {
                        isFriend = true;
                        break;
                    }
                }

                if (!isFriend)
                {
                    await FriendNetHelper.RequestFriendApply(root, unit.Id);
                }
            }
        }

        public static async ETTask FriendApplyReply(Scene root)
        {
            FriendComponent friendComponent = root.GetComponent<FriendComponent>();
            List<FriendInfo> friendInfos = friendComponent.ApplyList;

            for (int i = friendInfos.Count - 1; i >= 0; i--)
            {
                await FriendNetHelper.RequestFriendApplyReply(root, friendInfos[i], 1);
            }
        }

        public static async ETTask SendFriendChat(Scene root, string str)
        {
            FriendComponent friendComponent = root.GetComponent<FriendComponent>();
            foreach (FriendInfo friendInfo in friendComponent.FriendList)
            {
                await ChatNetHelper.RequestSendChat(root, ChannelEnum.Friend, str, friendInfo.UserId);
            }
        }

        public static async ETTask AddBlack(Scene root)
        {
            FriendComponent friendComponent = root.GetComponent<FriendComponent>();
            foreach (FriendInfo friendInfo in friendComponent.FriendList)
            {
                await FriendNetHelper.RequestAddBlack(root, friendInfo.UserId);
            }
        }

        public static async ETTask RemoveBlack(Scene root)
        {
            FriendComponent friendComponent = root.GetComponent<FriendComponent>();

            for (int i = friendComponent.Blacklist.Count - 1; i >= 0; i--)
            {
                await FriendNetHelper.RequestRemoveBlack(root, friendComponent.Blacklist[i].UserId);
            }
        }

        public static async ETTask FriendDelete(Scene root)
        {
            FriendComponent friendComponent = root.GetComponent<FriendComponent>();

            for (int i = friendComponent.FriendList.Count - 1; i >= 0; i--)
            {
                await FriendNetHelper.RequestRemoveBlack(root, friendComponent.FriendList[i].UserId);
            }
        }

        public static async ETTask UnionApply(Scene root)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            long unionId = numericComponent.GetAsLong(NumericType.UnionId_0);
            if (unionId != 0)
            {
                // 请先退出公会
                return;
            }

            long leaveTime = numericComponent.GetAsLong(NumericType.UnionIdLeaveTime);
            if (TimeHelper.ServerNow() - leaveTime < TimeHelper.Hour * 8)
            {
                string tip = TimeHelper.ShowLeftTime(TimeHelper.Hour * 8 - (TimeHelper.ServerNow() - leaveTime));
                // $"{tip} 后才能加入家族！"
                return;
            }

            U2C_UnionListResponse response = await UnionNetHelper.UnionList(root);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            if (response.UnionList.Count == 0)
            {
                return;
            }

            response.UnionList.Sort(delegate(UnionListItem a, UnionListItem b)
            {
                int unionlevela = a.UnionLevel;
                int unionlevelb = b.UnionLevel;
                int numbera = a.PlayerNumber;
                int numberb = b.PlayerNumber;

                if (numbera == numberb)
                {
                    return unionlevelb - unionlevela;
                }
                else
                {
                    return numberb - numbera;
                }
            });

            await UnionNetHelper.UnionApplyRequest(root, response.UnionList[^1].UnionId, unit.Id);
        }
    }
}