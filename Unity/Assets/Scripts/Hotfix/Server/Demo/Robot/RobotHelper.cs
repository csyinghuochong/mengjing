using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;

namespace ET.Client
{
    public static class RobotHelper
    {
        public static async ETTask JianDing(Scene root)
        {
            //可以鉴定的装备
            List<ItemInfo> bagInfos = root.GetComponent<BagComponentC>().GetCanJianDing();

            //鉴定装备
            foreach (ItemInfo bagInfo in bagInfos)
            {
                await BagClientNetHelper.RequestAppraisalItem(root, bagInfo);
            }
        }

        public static async ETTask WearEquip(Scene root)
        {
            //可以穿戴的装备
            List<ItemInfo> bagInfos = root.GetComponent<BagComponentC>().GetCanEquipList();

            //穿戴装备
            foreach (ItemInfo bagInfo in bagInfos)
            {
                await BagClientNetHelper.RequestTakeoffEquip(root, bagInfo);
            }
        }

        public static async ETTask XiangQianGem(Scene root)
        {
            List<ItemInfo> gemstones = root.GetComponent<BagComponentC>().GetItemsByType((int)ItemTypeEnum.Gemstone);
            List<ItemInfo> equips = root.GetComponent<BagComponentC>().GetEquipList();

            foreach (ItemInfo equip in equips)
            {
                string[] gemHoles = equip.GemHole.Split('_');
                string[] gemIDNews = equip.GemIDNew.Split('_');

                for (int j = 0; j < gemHoles.Length; j++)
                {
                    string gemHole = gemHoles[j];
                    string gemIDNew = gemIDNews[j];

                    for (int i = gemstones.Count - 1; i >= 0; i--)
                    {
                        ItemInfo gemstone = gemstones[i];
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
            if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                // 请至少预留一个格子
                return;
            }

            List<ItemInfo> bagItemList = bagComponent.GetBagList();
            List<ItemInfo> gemList = new List<ItemInfo>();
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

            List<ItemInfo> bagInfos = new List<ItemInfo>();

            bagInfos.AddRange(bagComponentC.GetItemsByType(ItemTypeEnum.Equipment));
            bagInfos.AddRange(bagComponentC.GetItemsByType(ItemTypeEnum.Gemstone));
            bagInfos.AddRange(bagComponentC.GetItemsByLoc(ItemLocType.ItemPetHeXinBag));
            bagInfos.AddRange(bagComponentC.GetItemsByTypeAndSubType(ItemTypeEnum.Consume, 5));

            List<long> huishouList = new List<long>();
            foreach (ItemInfo bagInfo in bagInfos)
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

                await BagClientNetHelper.RequestItemQiangHua(root, itemSubType, false);
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
                if (PetHelper.GetPetCombat(petInfo) > PetHelper.GetPetCombat(rolePetInfo))
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

            await ETTask.CompletedTask;
        }

        public static async ETTask RolePetHeXin(Scene root, int score)
        {
            PetComponentC petComponent = root.GetComponent<PetComponentC>();
            List<RolePetInfo> rolePetInfos = new List<RolePetInfo>();

            foreach (RolePetInfo petInfo in petComponent.RolePetInfos)
            {
                if (PetHelper.GetPetCombat(petInfo) > score)
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
                    List<ItemInfo> bagInfos = new List<ItemInfo>();

                    foreach (ItemInfo item in root.GetComponent<BagComponentC>().GetItemsByLoc(ItemLocType.ItemPetHeXinBag))
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

                    List<ItemInfo> eqipInfos = root.GetComponent<BagComponentC>().GetItemsByLoc(ItemLocType.ItemPetHeXinEquip);

                    long baginfoId = rolePetInfo.PetHeXinList[position];
                    ItemInfo bagInfo = null;
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

                if (PetHelper.GetPetCombat(rolePetInfo) < score && rolePetInfo.PetSkill.Count < skillNum)
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
            List<ItemInfo> ShowBagInfos = new List<ItemInfo>();

            List<ItemInfo> bagList = root.GetComponent<BagComponentC>().GetBagList();
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
                if (PetHelper.GetPetCombat(petInfo) > PetHelper.GetPetCombat(rolePetInfo))
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
                        if (PetHelper.GetPetCombat(rolePetInfo) > PetHelper.GetPetCombat(rolePetInfo1))
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
                        if (PetHelper.GetPetCombat(rolePetInfo) > PetHelper.GetPetCombat(rolePetInfo2))
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
                        if (PetHelper.GetPetCombat(rolePetInfo) > PetHelper.GetPetCombat(rolePetInfo3))
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
                        if (PetHelper.GetPetCombat(rolePetInfo) > PetHelper.GetPetCombat(rolePetInfo4))
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

                if (PetHelper.GetPetCombat(rolePetInfo) > PetHelper.GetPetCombat(maxPetInfo))
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
            int tianFuId = TalentHelpter.GetFirstTalent( occTwo, 1 );
            await SkillNetHelper.ActiveTianFu(root, tianFuId);
        }

        public static async ETTask LifeShieldCost(Scene root)
        {
            List<ItemInfo> allInfos = new List<ItemInfo>();
            BagComponentC bagComponent = root.GetComponent<BagComponentC>();
            allInfos.AddRange(bagComponent.GetItemsByType(ItemTypeEnum.Material));
            allInfos.AddRange(bagComponent.GetItemsByType(ItemTypeEnum.Equipment));

            List<ItemInfo> showBagInfos = new List<ItemInfo>();
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
            List<ItemInfo> bagInfos = bagComponent.GetItemsByType(ItemTypeEnum.Equipment);
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
                // $"{tip} 后才能加入公会！"
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

        public static async ETTask JingLingUse(Scene root)
        {
            ChengJiuComponentC chengJiuComponent = root.GetComponent<ChengJiuComponentC>();
            // if (chengJiuComponent.JingLingList.Count == 0)
            // {
            //     return;
            // }
            //
            // if (chengJiuComponent.JingLingList[^1] == chengJiuComponent.JingLingId)
            // {
            //     return;
            // }
            //
            // await JingLingNetHelper.RequestJingLingUse(root, chengJiuComponent.JingLingList[^1], 1);
            await ETTask.CompletedTask;
        }

        public static async ETTask MoveToNpc(Scene root, int npcConfigId)
        {
            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(npcConfigId);
            float3 newTarget = new(npcConfig.Position[0] * 0.01f, npcConfig.Position[1] * 0.01f, npcConfig.Position[2] * 0.01f);
            await UnitHelper.GetMyUnitFromClientScene(root).MoveToAsync(newTarget);
        }

        public static async ETTask Warehous(Scene root)
        {
            await RobotHelper.MoveToNpc(root, 20000003);
            BagComponentC bagComponent = root.GetComponent<BagComponentC>();
            // 存普通仓库
            List<ItemInfo> bagInfos = bagComponent.GetItemsByType(ItemLocType.ItemLocBag);
            if (bagInfos.Count > 0)
            {
                await BagClientNetHelper.RquestPutStoreHouse(root, bagInfos[0], ItemLocType.ItemWareHouse1);
            }

            // 存账号仓库
            bagInfos.Clear();
            foreach (ItemInfo bagInfo in bagComponent.GetItemsByType(ItemLocType.ItemLocBag))
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                if (itemConfig.ItemType == 3 && itemConfig.EquipType < 100 && !bagInfo.isBinging)
                {
                    bagInfos.Add(bagInfo);
                }
            }

            if (bagInfos.Count > 0)
            {
                await BagClientNetHelper.RequestAccountWarehousOperate(root, 1, bagInfos[0].BagInfoID);
            }

            // 宝石合成
            await BagClientNetHelper.RquestGemHeCheng(root, 19);
            // 存宝石仓库
            bagInfos.Clear();
            foreach (ItemInfo bagInfo in bagComponent.GetItemsByType(ItemLocType.ItemLocBag))
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                if (itemConfig.ItemType == ItemTypeEnum.Gemstone)
                {
                    bagInfos.Add(bagInfo);
                }
            }

            if (bagInfos.Count > 0)
            {
                await BagClientNetHelper.RquestPutStoreHouse(root, bagInfos[0], ItemLocType.GemWareHouse1);
            }
        }

        public static async ETTask GetMail(Scene root)
        {
            await RobotHelper.MoveToNpc(root, 20000006);
            await MailNetHelper.SendGetMailList(root);
            TimerComponent timerComponent = root.GetComponent<TimerComponent>();
            MailComponentC mailComponent = root.GetComponent<MailComponentC>();
            while (mailComponent.MailInfoList.Count > 0)
            {
                int errorCode = await MailNetHelper.SendReceiveMail(root);
                if (errorCode != 0)
                {
                    break;
                }

                await timerComponent.WaitAsync(200);
            }
        }

        public static async ETTask JoinTeam(Scene root)
        {
            await TeamNetHelper.RequestTeamDungeonList(root, MapTypeEnum.TeamDungeon);
            TeamComponentC teamComponent = root.GetComponent<TeamComponentC>();
            TeamInfo teamInfo = teamComponent.GetSelfTeam();
            if (teamInfo == null || teamInfo.SceneId == 0)
            {
                //无副本队伍
                int error = -1;
                List<TeamInfo> teamList = teamComponent.TeamList;
                for (int i = 0; i < teamList.Count; i++)
                {
                    if (teamList[i].SceneId == 0)
                    {
                        continue;
                    }

                    error = await TeamNetHelper.TeamDungeonApplyRequest(root, teamList[i].TeamId, teamList[i].SceneId, teamList[i].FubenType,
                        teamList[i].PlayerList[0].PlayerLv, true,MapTypeEnum.TeamDungeon);

                    if (error == 0)
                    {
                        break;
                    }
                }

                if (error != 0)
                {
                    await TeamNetHelper.RequestTeamDungeonCreate(root, 110001, 1,MapTypeEnum.TeamDungeon);
                }
            }
            else
            {
                // 有副本队伍

                // 同意申请加入队伍
                for (int i = teamComponent.ApplyList.Count - 1; i >= 0; i--)
                {
                    await TeamNetHelper.TeamDungeonAgreeRequest(root, teamComponent.ApplyList[i], 1);
                }

                // 自己是队长，人满了就开
            }
        }

        public static async ETTask Mystery(Scene root)
        {
            int npcid = 20000001;
            await RobotHelper.MoveToNpc(root, npcid);

            A2C_MysteryListResponse response =
                    await BagClientNetHelper.RquestMysteryList(root, root.GetComponent<UserInfoComponentC>().UserInfo.UserId);

            List<int> itemList = new List<int>();

            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(npcid);
            int shopValue = npcConfig.ShopValue;
            while (shopValue != 0)
            {
                itemList.Add(shopValue);

                MysteryConfig mysteryConfig = MysteryConfigCategory.Instance.Get(shopValue);
                shopValue = mysteryConfig.NextId;
            }

            List<MysteryItemInfo> MysteryItemInfos = new List<MysteryItemInfo>();
            for (int i = 0; i < response.MysteryItemInfos.Count; i++)
            {
                if (!itemList.Contains(response.MysteryItemInfos[i].MysteryId))
                {
                    continue;
                }

                MysteryItemInfos.Add(response.MysteryItemInfos[i]);
            }

            if (MysteryItemInfos.Count == 0)
            {
                return;
            }

            int random = RandomHelper.RandomNumber(0, MysteryItemInfos.Count);
            if (MysteryItemInfos[random].ItemNumber == 0)
            {
                return;
            }

            MysteryItemInfo mysteryItemInfo = new() { MysteryId = MysteryItemInfos[random].MysteryId };

            await BagClientNetHelper.RquestMysteryBuy(root, mysteryItemInfo, npcid);
        }

        public static async ETTask Store(Scene root, int npcid)
        {
            await RobotHelper.MoveToNpc(root, npcid);

            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(npcid);
            int shopSellid = npcConfig.ShopValue;

            int playLv = root.GetComponent<UserInfoComponentC>().UserInfo.Lv;

            List<int> ShowStores = new List<int>();
            while (shopSellid != 0)
            {
                StoreSellConfig storeSellConfig = StoreSellConfigCategory.Instance.Get(shopSellid);

                // if (playLv < storeSellConfig.ShowRoleLvMin || playLv > storeSellConfig.ShowRoleLvMax)
                // {
                //     continue;
                // }

                ShowStores.Add(shopSellid);
                shopSellid = storeSellConfig.NextID;
            }

            if (ShowStores.Count == 0)
            {
                return;
            }

            int random = RandomHelper.RandomNumber(0, ShowStores.Count);

            await BagClientNetHelper.RquestStoreBuy(root, ShowStores[random], 1);
        }

        public static async ETTask RoleXiLian(Scene root)
        {
            int npcid = 20000004;
            await RobotHelper.MoveToNpc(root, npcid);

            BagComponentC bagComponent = root.GetComponent<BagComponentC>();

            // 洗练
            List<ItemInfo> equips = bagComponent.GetItemsByLoc(ItemLocType.ItemLocEquip);
            if (equips.Count == 0)
            {
                return;
            }

            int random = RandomHelper.RandomNumber(0, equips.Count);

            await BagClientNetHelper.RquestItemXiLian(root, equips[random].BagInfoID, 1);

            // 传承
            List<ItemInfo> equipInfos = bagComponent.GetItemsByType(ItemTypeEnum.Equipment);

            equips.Clear();
            for (int i = 0; i < equipInfos.Count; i++)
            {
                if (equipInfos[i].IfJianDing)
                {
                    continue;
                }

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(equipInfos[i].ItemID);
                if (itemConfig.EquipType == 101)
                {
                    continue;
                }

                if (itemConfig.UseLv < 60 && itemConfig.ItemQuality <= 5)
                {
                    continue;
                }

                //饰品不显示
                if (itemConfig.ItemSubType == 5)
                {
                    continue;
                }

                equips.Add(equipInfos[i]);
            }

            if (equips.Count == 0)
            {
                return;
            }

            random = RandomHelper.RandomNumber(0, equips.Count);

            int maxInheritTimes =int.Parse( GlobalValueConfigCategory.Instance.Get(117).Value);
            if (equips[random].InheritTimes >= maxInheritTimes)
            {
                // 该装备不可再进行传承鉴定！
                return;
            }

            string costitem = ItemHelper.GetInheritCost(equips[random].InheritTimes);
            if (!bagComponent.CheckNeedItem(costitem))
            {
                // 材料不足！
                return;
            }

            await BagClientNetHelper.ItemInherit(root, equips[random].BagInfoID);
        }

        public static async ETTask PetEgg(Scene root)
        {
            int npcid = 20000010;
            await RobotHelper.MoveToNpc(root, npcid);

            BagComponentC bagComponent = root.GetComponent<BagComponentC>();
            PetComponentC petComponent = root.GetComponent<PetComponentC>();
            // 有宠物蛋孵化完成就领取宠物,有空位和蛋，就把蛋放上去孵化
            for (int index = 0; index < 3; index++)
            {
                if (petComponent.RolePetEggs[index].KeyId > 0)
                {
                    long timeNow = petComponent.RolePetEggs[index].Value - TimeHelper.ServerNow();
                    if (timeNow < 0)
                    {
                        // 孵化结束，取出
                        await PetNetHelper.RequestPetEggOpen(root, index);
                        return;
                    }
                }
                else
                {
                    List<ItemInfo> bagInfos = bagComponent.GetBagList();
                    for (int j = 0; j < bagInfos.Count; j++)
                    {
                        ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[j].ItemID);
                        if (itemConfig.ItemSubType == 102 && itemConfig.ItemType == 1)
                        {
                            // 放蛋
                            await PetNetHelper.RequestPetEggPut(root, index, bagInfos[j].BagInfoID);
                            break;
                        }
                    }
                }
            }

            // 兑换宠物
            for (int index = 1; index < 4; index++)
            {
                PetEggDuiHuanConfig cofig0 = PetEggDuiHuanConfigCategory.Instance.Get(index);
                if (!bagComponent.CheckNeedItem(cofig0.CostItems))
                {
                    // 道具不足!
                    return;
                }

                if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) <= 1)
                {
                    // 背包空间不足！
                    return;
                }

                await PetNetHelper.RequestPetEggDuiHuan(root, index);
            }

            // 抽卡
            int choukaType = 1;
            if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < choukaType)
            {
                // 请预留足够的背包空间！
                return;
            }

            if (bagComponent.GetBagLeftCell(ItemLocType.ItemPetHeXinBag) < choukaType)
            {
                // 请清理一下宠物之核背包！
                return;
            }

            if (petComponent.RolePetBag.Count >= GlobalValueConfigCategory.Instance.RolePetBagNum)
            {
                // 请及时清理探索宠物仓库！
                return;
            }

            string needItems = GlobalValueConfigCategory.Instance.Get(39).Value.Split('@')[0];
            if (choukaType == 1 && !bagComponent.CheckNeedItem(needItems))
            {
                // ErrorCode.ERR_ItemNotEnoughError);
                return;
            }

            int needDimanond = int.Parse(GlobalValueConfigCategory.Instance.Get(40).Value.Split('@')[0]);
            UserInfo userInfo = root.GetComponent<UserInfoComponentC>().UserInfo;
            int exlporeNumber = UnitHelper.GetMyUnitFromClientScene(root).GetComponent<NumericComponentC>()
                    .GetAsInt(NumericType.PetExploreNumber);
            string[] set = GlobalValueConfigCategory.Instance.Get(107).Value.Split(';');
            float discount;
            if (exlporeNumber < int.Parse(set[0])) // 超过300次打8折
            {
                discount = 1;
            }
            else
            {
                discount = float.Parse(set[1]);
            }

            if (choukaType == 10 && userInfo.Diamond < (int)(needDimanond * discount))
            {
                // ErrorCode.ERR_DiamondNotEnoughError);
                return;
            }

            await PetNetHelper.RequestPetEggChouKa(root, choukaType);

            // 核心抽卡
            choukaType = 1;
            if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < choukaType)
            {
                // 请预留足够的背包空间！
                return;
            }

            if (bagComponent.GetBagLeftCell(ItemLocType.ItemPetHeXinBag) < choukaType)
            {
                // 请清理一下宠物之核背包！
                return;
            }

            needItems = GlobalValueConfigCategory.Instance.Get(110).Value.Split('@')[0];
            if (choukaType == 1 && !bagComponent.CheckNeedItem(needItems))
            {
                // ErrorCode.ERR_ItemNotEnoughError
                return;
            }

            string[] itemInfo10 = GlobalValueConfigCategory.Instance.Get(111).Value.Split('@')[0].Split(';');
            exlporeNumber = UnitHelper.GetMyUnitFromClientScene(root).GetComponent<NumericComponentC>()
                    .GetAsInt(NumericType.PetExploreNumber);
            set = GlobalValueConfigCategory.Instance.Get(112).Value.Split(';');

            if (exlporeNumber < int.Parse(set[0]))
            {
                discount = 1;
            }
            else
            {
                discount = float.Parse(set[1]);
            }

            long haveNumber10 = bagComponent.GetItemNumber(int.Parse(itemInfo10[0]));
            if (choukaType == 10 && haveNumber10 < (int)(int.Parse(itemInfo10[1]) * discount))
            {
                // ErrorCode.ERR_ItemNotEnoughError
                return;
            }

            await PetNetHelper.RequestPetHeXinChouKa(root, choukaType);
        }

        public static async ETTask ChouKa(Scene root)
        {
            int npcid = 20000011;
            await RobotHelper.MoveToNpc(root, npcid);

            await BagClientNetHelper.ChouKa(root, 1001, 1);
        }

        public static async ETTask MakeLearn(Scene root, int npcid)
        {
            await RobotHelper.MoveToNpc(root, npcid);

            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            int makeType_1 = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.MakeType_1);
            int makeType_2 = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.MakeType_2);

            int showValue = NpcConfigCategory.Instance.Get(npcid).ShopValue;

            int plan = -1;
            if (makeType_1 == showValue)
            {
                plan = 1;
            }

            if (plan == -1)
            {
                if (makeType_1 != 0)
                {
                    // "重置后自身学习的生活技能将全部遗忘，请谨慎选择!"
                }

                await SkillNetHelper.MakeSelect(root, showValue, plan == -1 ? 1 : plan);
            }

            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            int playeLv = userInfoComponent.UserInfo.Lv;
            Dictionary<int, EquipMakeConfig> keyValuePairs = EquipMakeConfigCategory.Instance.GetAll();
            string initMakeList = GlobalValueConfigCategory.Instance.Get(43).Value;
            List<int> showMakeLearns = new List<int>();
            foreach (var item in keyValuePairs)
            {
                if (userInfoComponent.UserInfo.MakeList.Contains(item.Key))
                {
                    continue;
                }

                if (initMakeList.Contains(item.Key.ToString()))
                {
                    continue;
                }

                if (playeLv < item.Value.LearnLv || item.Value.LearnType != 0)
                {
                    continue;
                }

                if (item.Value.ProficiencyType != showValue)
                {
                    continue;
                }

                showMakeLearns.Add(item.Key);
            }

            for (int i = showMakeLearns.Count - 1; i >= 0; i--)
            {
                await SkillNetHelper.MakeLearn(root, showMakeLearns[i], plan == -1 ? 1 : plan);
            }
        }

        public static async ETTask OccTwo(Scene root)
        {
            await RobotHelper.MoveToNpc(root, 20000015);

            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            int occ = userInfoComponent.UserInfo.Occ;
            OccupationConfig occupationConfig = OccupationConfigCategory.Instance.Get(occ);

            int index = RandomHelper.RandomNumber(0, occupationConfig.OccTwoID.Length);

            int occTwoId = occupationConfig.OccTwoID[index];

            if (userInfoComponent.UserInfo.OccTwo != 0)
            {
                // 不能重复转职!
                return;
            }

            await SkillNetHelper.ChangeOccTwoRequest(root, occTwoId);
        }

        public static async ETTask PaiMaiShop(Scene root)
        {
            List<int> numbers = PaiMaiSellConfigCategory.Instance.GetAll().Keys.ToList();
            int randomIndex = RandomHelper.RandomNumber(0, numbers.Count);
            int paiMaiSellId = numbers[randomIndex];

            UserInfo userInfo = root.GetComponent<UserInfoComponentC>().UserInfo;
            PaiMaiSellConfig paiMaiSellConfig = PaiMaiSellConfigCategory.Instance.Get(paiMaiSellId);
            if (userInfo.Lv < paiMaiSellConfig.BuyLv)
            {
                // "{0}级才能购买！", paiMaiSellConfig.BuyLv));

                return;
            }

            if (root.GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                // "背包已满！"
                return;
            }

            await PaiMaiNetHelper.PaiMaiShop(root, paiMaiSellId, 1);
        }

        public static async ETTask PaiMaiBuy(Scene root)
        {
            int itemType = RandomHelper.RandomNumber(1, 5);
            P2C_PaiMaiListResponse response = await PaiMaiNetHelper.PaiMaiList(root, 1, itemType, UnitHelper.GetMyUnitFromClientScene(root).Id);
            if (response.PaiMaiItemInfos.Count == 0)
            {
                return;
            }

            int index = RandomHelper.RandomNumber(0, response.PaiMaiItemInfos.Count);

            await PaiMaiNetHelper.PaiMaiBuyNew(root, response.PaiMaiItemInfos[index], 0,
                UnitHelper.GetMyUnitFromClientScene(root).GetComponent<NumericComponentC>().GetAsInt(NumericType.RechargeNumber));
        }

        public static async ETTask PaiMaiSell(Scene root)
        {
            List<ItemInfo> equipInfos = root.GetComponent<BagComponentC>().GetBagList();
            List<ItemInfo> showBagInfos = new List<ItemInfo>();

            P2C_PaiMaiListResponse response = await PaiMaiNetHelper.PaiMaiList(root, 0, 0, root.GetComponent<UserInfoComponentC>().UserInfo.UserId);

            for (int i = 0; i < equipInfos.Count; i++)
            {
                if (equipInfos[i].isBinging || equipInfos[i].IsProtect)
                {
                    continue;
                }

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(equipInfos[i].ItemID);
                if (itemConfig.IfStopPaiMai == 1)
                {
                    // 此道具禁止上架！
                    continue;
                }

                if (!CommonHelp.IsShowPaiMai(itemConfig.ItemType, itemConfig.ItemSubType))
                {
                    // 此道具不能上架！
                    continue;
                }

                if (response.PaiMaiItemInfos.Count >= int.Parse( GlobalValueConfigCategory.Instance.Get(50).Value))
                {
                    // 已经达到最大上架数量！
                    continue;
                }

                if (itemConfig.ItemQuality >= 5 && itemConfig.ItemType == 3)
                {
                    // 橙色品质及以上的装备不能上架！
                    continue;
                }

                showBagInfos.Add(equipInfos[i]);
            }

            if (showBagInfos.Count == 0)
            {
                return;
            }

            int index = RandomHelper.RandomNumber(0, showBagInfos.Count);

            //设置价格
            int price = 10000; //临时
            //获取是否是快捷购买的道具列表
            P2C_PaiMaiShopShowListResponse response2 = await PaiMaiNetHelper.PaiMaiShopShowList(root);
            foreach (PaiMaiShopItemInfo info in response2.PaiMaiShopItemInfos)
            {
                if (info.Id == showBagInfos[index].ItemID)
                {
                    price = info.Price;
                }
            }

            int sellNum = showBagInfos[index].ItemNum;

            PaiMaiItemInfo paiMaiItemInfo = new();
            paiMaiItemInfo.BagInfo = CommonHelp.DeepCopy(showBagInfos[index].ToMessage());
            paiMaiItemInfo.BagInfo.ItemNum = sellNum;
            paiMaiItemInfo.Price = price;
            await PaiMaiNetHelper.PaiMaiSell(root, paiMaiItemInfo);
        }

        public static async ETTask PaiMaiDuiHuan(Scene root)
        {
            //初始化兑换值
            R2C_DBServerInfoResponse response = await PaiMaiNetHelper.DBServerInfo(root);

            long diamondsNumber = 100;
            if (root.GetComponent<UserInfoComponentC>().UserInfo.Diamond < diamondsNumber)
            {
                // 钻石不足！
                return;
            }

            await PaiMaiNetHelper.PaiMaiDuiHuan(root, diamondsNumber);
        }

        public static async ETTask GemMake(Scene root)
        {
            await RobotHelper.MoveToNpc(root, 20000018);

            int showValue = NpcConfigCategory.Instance.Get(20000018).ShopValue;

            List<EquipMakeConfig> makeList = EquipMakeConfigCategory.Instance.GetAll().Values.ToList();
            List<int> showMake = new List<int>();
            for (int i = 0; i < makeList.Count; i++)
            {
                EquipMakeConfig equipMakeConfig1 = makeList[i];
                if (equipMakeConfig1.ProficiencyType != showValue)
                {
                    continue;
                }

                showMake.Add(equipMakeConfig1.Id);
            }

            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            BagComponentC bagComponent = root.GetComponent<BagComponentC>();
            foreach (int makeId in showMake)
            {
                long cdEndTime = userInfoComponent.GetMakeTime(makeId);
                if (cdEndTime > TimeHelper.ServerNow())
                {
                    continue;
                }

                EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(makeId);
                if (userInfoComponent.UserInfo.Gold < equipMakeConfig.MakeNeedGold)
                {
                    // 金币不足！
                    continue;
                }

                bool success = bagComponent.CheckNeedItem(equipMakeConfig.NeedItems);
                if (!success)
                {
                    // 材料不足！
                    continue;
                }

                await BagClientNetHelper.RequestEquipMake(root, 0, makeId, 1);
            }
        }

        public static async ETTask ShenMiBuy(Scene root)
        {
            int npcid = 20000022;

            await RobotHelper.MoveToNpc(root, npcid);

            A2C_MysteryListResponse response =
                    await BagClientNetHelper.RquestMysteryList(root, root.GetComponent<UserInfoComponentC>().UserInfo.UserId);

            List<int> itemList = new List<int>();

            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(npcid);
            int shopValue = npcConfig.ShopValue;
            while (shopValue != 0)
            {
                itemList.Add(shopValue);

                MysteryConfig mysteryConfig = MysteryConfigCategory.Instance.Get(shopValue);
                shopValue = mysteryConfig.NextId;
            }

            List<MysteryItemInfo> mysteryItemInfos = new List<MysteryItemInfo>();
            for (int i = 0; i < response.MysteryItemInfos.Count; i++)
            {
                if (!itemList.Contains(response.MysteryItemInfos[i].MysteryId))
                {
                    continue;
                }

                mysteryItemInfos.Add(response.MysteryItemInfos[i]);
            }

            if (mysteryItemInfos.Count == 0)
            {
                return;
            }

            int index = RandomHelper.RandomNumber(0, mysteryItemInfos.Count);

            MysteryItemInfo mysteryItemInfo = new() { MysteryId = mysteryItemInfos[index].MysteryId };

            await BagClientNetHelper.RquestMysteryBuy(root, mysteryItemInfo, npcid);
        }

        public static async ETTask ShenQiMake(Scene root)
        {
            int npcid = 20000023;

            await RobotHelper.MoveToNpc(root, npcid);

            int showValue = NpcConfigCategory.Instance.Get(npcid).ShopValue;

            List<EquipMakeConfig> makeList = EquipMakeConfigCategory.Instance.GetAll().Values.ToList();
            Dictionary<int, List<int>> chapterMakeids = new Dictionary<int, List<int>>();
            chapterMakeids.Add(0, new List<int>()); //消耗性道具
            chapterMakeids.Add(1, new List<int>()); //<=20
            chapterMakeids.Add(2, new List<int>()); //<=30
            chapterMakeids.Add(3, new List<int>()); //<= 40
            chapterMakeids.Add(4, new List<int>()); //<= 50
            chapterMakeids.Add(5, new List<int>()); //<= 100
            chapterMakeids.Add(6, new List<int>()); //其他

            for (int i = 0; i < makeList.Count; i++)
            {
                EquipMakeConfig equipMakeConfig = makeList[i];
                if (equipMakeConfig.ProficiencyType != showValue)
                {
                    continue;
                }

                int chapterindex = -1;
                int itemid = equipMakeConfig.MakeItemID;
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemid);
                if (itemConfig.ItemType == 1 || itemConfig.ItemType == 2)
                {
                    chapterindex = 0;
                }
                else if (equipMakeConfig.LearnLv <= 20)
                {
                    chapterindex = 1;
                }
                else if (equipMakeConfig.LearnLv <= 30)
                {
                    chapterindex = 2;
                }
                else if (equipMakeConfig.LearnLv <= 40)
                {
                    chapterindex = 3;
                }
                else if (equipMakeConfig.LearnLv <= 50)
                {
                    chapterindex = 4;
                }
                else if (equipMakeConfig.LearnLv < 58)
                {
                    chapterindex = 5;
                }
                else
                {
                    chapterindex = 6;
                }

                chapterMakeids[chapterindex].Add(equipMakeConfig.Id);
            }

            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            BagComponentC bagComponent = root.GetComponent<BagComponentC>();
            for (int i = 0; i < 7; i++)
            {
                for (int j = chapterMakeids[i].Count - 1; j >= 0; j--)
                {
                    long cdEndTime = userInfoComponent.GetMakeTime(chapterMakeids[i][j]);
                    if (cdEndTime > TimeHelper.ServerNow())
                    {
                        continue;
                    }

                    EquipMakeConfig equipMakeConfig1 = EquipMakeConfigCategory.Instance.Get(chapterMakeids[i][j]);
                    if (userInfoComponent.UserInfo.Gold < equipMakeConfig1.MakeNeedGold)
                    {
                        // 金币不足！
                        continue;
                    }

                    bool success = bagComponent.CheckNeedItem(equipMakeConfig1.NeedItems);
                    if (!success)
                    {
                        // 材料不足！
                        continue;
                    }

                    await BagClientNetHelper.RequestEquipMake(root, 0, chapterMakeids[i][j], 1);
                }
            }

            await ETTask.CompletedTask;
        }

        public static async ETTask TaskGet(Scene root, int npcid)
        {
            await RobotHelper.MoveToNpc(root, npcid);

            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            TaskComponentC taskComponent = root.GetComponent<TaskComponentC>();
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();

            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(npcid);
            switch (npcConfig.NpcType)
            {
                case 1: //神兽兑换
                case 2: //挑戰之地
                    // self.View.E_TaskFubenItemsLoopVerticalScrollRect.gameObject.SetActive(true);
                    // if (npcConfig.NpcPar != null)
                    // {
                    //     List<int> fubenList = new List<int>(npcConfig.NpcPar);
                    //     self.AddUIScrollItems(ref self.ScrollItemTaskFubenItems, fubenList.Count);
                    //     self.View.E_TaskFubenItemsLoopVerticalScrollRect.SetVisible(true, fubenList.Count);
                    // }

                    break;
                case 3: //循环任务 周任务 支线任务 藏宝图任务

                    # region 任务

                    //获取npc任务
                    List<int> taskids = new List<int>();

                    List<TaskPro> taskProCompleted = taskComponent.GetCompltedTaskByNpc(npcid);
                    for (int i = 0; i < taskProCompleted.Count; i++)
                    {
                        taskids.Add(taskProCompleted[i].taskID);
                    }

                    taskids.AddRange(taskComponent.GetOpenTaskIds(npcid));

                    List<int> addTaskids = new List<int>();
                    if (npcid == 20000024) //任务使者：赛利
                    {
                        int weeklyTask = numericComponent.GetAsInt(NumericType.WeeklyTaskId);
                        if (weeklyTask > 0 && taskComponent.GetTaskTypeList(TaskTypeEnum.Weekly).Count == 0)
                        {
                            addTaskids.Add(weeklyTask);
                        }

                        int dailyTaskId = numericComponent.GetAsInt(NumericType.DailyTaskID);
                        if (dailyTaskId > 0 && taskComponent.GetTaskById(dailyTaskId) == null)
                        {
                            addTaskids.Add(dailyTaskId);
                        }
                    }

                    if (npcid == 20000102) //公会任务
                    {
                        int unionTaskId = numericComponent.GetAsInt(NumericType.UnionTaskId);
                        if (unionTaskId > 0 && taskComponent.GetTaskById(unionTaskId) == null)
                        {
                            addTaskids.Add(unionTaskId);
                        }

                        int ringTaskId = numericComponent.GetAsInt(NumericType.RingTaskId);
                        if (ringTaskId > 0 && taskComponent.GetTaskById(ringTaskId) == null)
                        {
                            addTaskids.Add(ringTaskId);
                        }
                    }

                    taskids.AddRange(addTaskids);

                    //给予任务
                    List<TaskPro> taskPros = taskComponent.RoleTaskList;
                    for (int i = 0; i < taskPros.Count; i++)
                    {
                        if (taskids.Contains(taskPros[i].taskID))
                        {
                            continue;
                        }

                        TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPros[i].taskID);
                        if ((taskConfig.TargetType == (int)TaskTargetType.GiveItem_10 || taskConfig.TargetType == (int)TaskTargetType.GivePet_25)
                            && taskConfig.CompleteNpcID == npcid)
                        {
                            taskids.Add(taskPros[i].taskID);
                        }
                        else if ((taskConfig.TargetType == (int)TaskTargetType.GiveItem_10 ||
                                     taskConfig.TargetType == (int)TaskTargetType.GivePet_25) &&
                                 taskConfig.TaskType == TaskTypeEnum.Ring && npcid == 20000102)
                        {
                            // 公会给予任务可以CompleteNpcID==0，找公会任务NPC提交
                            taskids.Add(taskPros[i].taskID);
                        }
                    }

                    foreach (int taskid in taskids)
                    {
                        TaskPro taskPro = taskComponent.GetTaskById(taskid);
                        TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskid);
                        if (taskConfig.TargetType == TaskTargetType.GiveItem_10 || taskConfig.TargetType == TaskTargetType.GivePet_25)
                        {
                            if (taskPro == null)
                            {
                                await TaskClientNetHelper.RequestGetTask(root, taskid);
                            }
                            else
                            {
                                if (taskConfig.TargetType == TaskTargetType.GivePet_25)
                                {
                                    PetComponentC petComponent = root.GetComponent<PetComponentC>();

                                    List<RolePetInfo> rolePetInfos = petComponent.RolePetInfos;
                                    for (int i = 0; i < rolePetInfos.Count; i++)
                                    {
                                        if (rolePetInfos[i].IsProtect)
                                        {
                                            // 宠物已锁定！
                                            continue;
                                        }

                                        if (rolePetInfos[i].PetStatus == 1)
                                        {
                                            // 出战宠物不能提交！
                                            continue;
                                        }

                                        if (rolePetInfos[i].PetStatus == 2)
                                        {
                                            // 请先停止家园散步！
                                            continue;
                                        }

                                        if (rolePetInfos[i].PetStatus == 3)
                                        {
                                            // 请先从仓库取出！
                                            continue;
                                        }

                                        if (petComponent.TeamPetList.Contains(rolePetInfos[i].Id))
                                        {
                                            // 当前宠物存在于宠物天梯上阵中,不能提交！
                                            continue;
                                        }

                                        if (petComponent.PetFormations.Contains(rolePetInfos[i].Id))
                                        {
                                            // 当前宠物存在于宠物副本上阵中,不能提交！
                                            continue;
                                        }

                                        if (petComponent.PetMingList.Contains(rolePetInfos[i].Id))
                                        {
                                            // 当前宠物存在于宠物矿场队伍中,不能提交！
                                            continue;
                                        }

                                        if (TaskHelper.IsTaskGivePet(taskConfig.TargetType, taskConfig.Target, taskConfig.TargetValue,
                                                rolePetInfos[i]))
                                        {
                                            taskPro.taskStatus = (int)TaskStatuEnum.Completed; // 手动修改

                                            await TaskClientNetHelper.RequestCommitTask(root, taskid, rolePetInfos[i].Id);

                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    BagComponentC bagComponent = root.GetComponent<BagComponentC>();

                                    foreach (ItemInfo bagInfo in bagComponent.GetItemsByType(ItemTypeEnum.Equipment))
                                    {
                                        if (TaskHelper.IsTaskGiveItem(taskConfig.TargetType, taskConfig.Target, taskConfig.TargetValue, bagInfo))
                                        {
                                            taskPro.taskStatus = (int)TaskStatuEnum.Completed;
                                            await TaskClientNetHelper.RequestCommitTask(root, taskid, bagInfo.BagInfoID);
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            bool isCompleted = taskPro != null && taskPro.taskStatus == (int)TaskStatuEnum.Completed;
                            if (isCompleted)
                            {
                                await TaskClientNetHelper.RequestCommitTask(root, taskid, 0);
                            }
                            else
                            {
                                await TaskClientNetHelper.RequestGetTask(root, taskid);
                            }
                        }
                    }

                    # endregion

                    break;
                case 4: //魔能老人
                    // int costItemID = 12000006;
                    // long itemNum = self.Root().GetComponent<BagComponentC>().GetItemNumber(costItemID);
                    // self.View.EG_EnergySkillRectTransform.gameObject.SetActive(true);
                    // //获取
                    // using (zstring.Block())
                    // {
                    //     self.View.E_Lab_MoNnengHintText.text =
                    //             zstring.Format("{0}  {1}/5", ItemConfigCategory.Instance.Get(costItemID).ItemName, itemNum);
                    // }

                    break;
                case 5: //补偿大师
                    // self.View.E_TaskFubenItemsLoopVerticalScrollRect.gameObject.SetActive(true);
                    // PlayerComponent accountInfo = self.Root().GetComponent<PlayerComponent>();
                    // int buchangNumber = BuChangHelper.ShowNewBuChang(accountInfo.PlayerInfo, accountInfo.CurrentRoleId);
                    // GameObject go = self.Root().GetComponent<ResourcesLoaderComponent>()
                    //         .LoadAssetSync<GameObject>("Assets/Bundles/UI/Item/Item_TaskFubenItem.prefab");
                    // if (buchangNumber > 0)
                    // {
                    //     GameObject goitem = UnityEngine.Object.Instantiate(go);
                    //     goitem.SetActive(true);
                    //     CommonViewHelper.SetParent(goitem, self.View.E_TaskFubenItemsLoopVerticalScrollRect.transform.Find("Content").gameObject);
                    //     Scroll_Item_TaskFubenItem uIBuChangItem = self.AddChild<Scroll_Item_TaskFubenItem>();
                    //     uIBuChangItem.uiTransform = goitem.transform;
                    //     uIBuChangItem.OnInitUI_2((long userid) => { self.OnClickBuChangItem(userid); }, buchangNumber);
                    // }
                    // else
                    // {
                    //     for (int i = 0; i < accountInfo.PlayerInfo.DeleteUserList.Count; i++)
                    //     {
                    //         GameObject goitem = UnityEngine.Object.Instantiate(go);
                    //         goitem.SetActive(true);
                    //         CommonViewHelper.SetParent(goitem, self.View.E_TaskFubenItemsLoopVerticalScrollRect.transform.Find("Content").gameObject);
                    //         Scroll_Item_TaskFubenItem uIBuChangItem = self.AddChild<Scroll_Item_TaskFubenItem>();
                    //         uIBuChangItem.uiTransform = goitem.transform;
                    //         uIBuChangItem.OnInitUI((long userid) => { self.OnClickBuChangItem(userid); }, accountInfo.PlayerInfo.DeleteUserList[i]);
                    //     }
                    // }

                    break;
                case 6: //节日使者
                    // int activityId = ActivityHelper.GetJieRiActivityId();
                    // ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
                    // self.View.E_ButtonJieRiRewardButton.gameObject.SetActive(activityId > 0 &&
                    //     !activityComponent.ActivityReceiveIds.Contains(activityId));
                    //
                    // if (activityId == 0)
                    // {
                    //     int nextid = ActivityHelper.GetNextRiActivityId();
                    //     ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(nextid);
                    //     string[] riqi = activityConfig.Par_1.Split(';');
                    //     string speek = self.View.E_Lab_NpcSpeakText.text;
                    //     using (zstring.Block())
                    //     {
                    //         self.View.E_Lab_NpcSpeakText.text =
                    //                 zstring.Format("{0} 下次领取时间:{1}月{2}日 {3}", speek, riqi[0], riqi[1], activityConfig.Par_4);
                    //     }
                    // }

                    break;
                case 8: //经验兑换
                    await UserInfoNetHelper.ExpToGold(root, 1);
                    break;
                case 9:
                    // self.View.E_ButtonPetFragmentButton.gameObject.SetActive(true);
                    break;
                case 10: //神秘之门
                    // self.View.E_ButtonMysteryButton.gameObject.SetActive(true);
                    break;
                default:
                    // self.View.E_TaskGetItemsLoopVerticalScrollRect.gameObject.SetActive(true);
                    // self.UpdataTask();
                    break;
            }

            await ETTask.CompletedTask;
        }

        public static async ETTask ShouJi(Scene root)
        {
            int npcid = 20000025;
            await RobotHelper.MoveToNpc(root, npcid);

            ShoujiComponentC shoujiComponent = root.GetComponent<ShoujiComponentC>();
            BagComponentC bagComponent = root.GetComponent<BagComponentC>();
            // 珍宝
            foreach (ShouJiItemConfig shouJiItemConfig in ShouJiItemConfigCategory.Instance.GetAll().Values.ToList())
            {
                KeyValuePairInt keyValuePairInt = shoujiComponent.GetTreasureInfo(shouJiItemConfig.Id);
                int haveNumber = keyValuePairInt != null ? (int)keyValuePairInt.Value : 0;

                bool actived = haveNumber >= shouJiItemConfig.AcitveNum;
                if (!actived)
                {
                    List<ItemInfo> showBagInfos = new List<ItemInfo>();
                    foreach (ItemInfo bagInfo in bagComponent.GetBagList())
                    {
                        if (bagInfo.ItemID != shouJiItemConfig.ItemID)
                        {
                            continue;
                        }

                        showBagInfos.Add(bagInfo);
                    }

                    if (showBagInfos.Count == 0)
                    {
                        continue;
                    }

                    int count = shouJiItemConfig.AcitveNum - haveNumber;
                    List<long> selects = new List<long>();
                    for (int i = 0; i < count; i++)
                    {
                        selects.Add(showBagInfos[i].BagInfoID);
                    }

                    await ShoujiNetHelper.ShouJiTreasure(root, selects, shouJiItemConfig.Id);
                }
            }
        }

        public static async ETTask ZuoQi(Scene root)
        {
            await RobotHelper.TaskGet(root, 20000031);

            List<ZuoQiShowConfig> showZuoQiShowConfigs = new List<ZuoQiShowConfig>();
            showZuoQiShowConfigs.AddRange(ZuoQiShowConfigCategory.Instance.GetAll().Values.ToList());
            showZuoQiShowConfigs.Sort((a, b) => b.Quality - a.Quality);

            UserInfo userInfo = root.GetComponent<UserInfoComponentC>().UserInfo;

            foreach (ZuoQiShowConfig showZuoQiShowConfig in showZuoQiShowConfigs)
            {
                if (userInfo.HorseIds.Contains(showZuoQiShowConfig.Id))
                {
                    await BagClientNetHelper.HorseFight(root, showZuoQiShowConfig.Id);
                    return;
                }
            }
        }

        public static async ETTask Protect(Scene root)
        {
            await RobotHelper.MoveToNpc(root, 30000011);

            BagComponentC bagComponent = root.GetComponent<BagComponentC>();
            // 橙色装备加锁
            foreach (ItemInfo bagInfo in bagComponent.GetItemsByType(ItemTypeEnum.Equipment))
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                if (itemConfig.EquipType == 101)
                {
                    continue;
                }

                if (itemConfig.ItemQuality < 5)
                {
                    continue;
                }

                if (bagInfo.IsProtect)
                {
                    continue;
                }

                await BagClientNetHelper.ItemProtect(root, bagInfo.BagInfoID, true);
            }

            // 好宠物加锁
            foreach (RolePetInfo rolePetInfo in root.GetComponent<PetComponentC>().RolePetInfos)
            {
                if (rolePetInfo.IsProtect)
                {
                    continue;
                }

                if (rolePetInfo.PetLv < 30)
                {
                    continue;
                }

                if (rolePetInfo.PetSkill.Count < 6)
                {
                    continue;
                }

                await PetNetHelper.RolePetProtect(root, rolePetInfo.Id, true);
            }
        }

        public static async ETTask ZhanQuLevel(Scene root)
        {
            ActivityComponentC activityComponent = root.GetComponent<ActivityComponentC>();

            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            foreach (ActivityConfig activityConfig in activityConfigs)
            {
                if (activityConfig.ActivityType != 21)
                {
                    continue;
                }

                int receiveNum = 0;
                int leftNumber = 0;
                for (int i = 0; i < activityComponent.ZhanQuReceiveNumbers.Count; i++)
                {
                    if (activityComponent.ZhanQuReceiveNumbers[i].ActivityId == activityConfig.Id)
                    {
                        receiveNum = activityComponent.ZhanQuReceiveNumbers[i].ReceiveNum;
                    }
                }

                leftNumber = int.Parse(activityConfig.Par_2) - receiveNum;

                if (!activityComponent.ZhanQuReceiveIds.Contains(activityConfig.Id) && leftNumber > 0)
                {
                    await ActivityNetHelper.ZhanQuReceive(root, activityConfig.ActivityType, activityConfig.Id);
                }
            }
        }

        public static async ETTask ZhanQuCombat(Scene root)
        {
            ActivityComponentC activityComponent = root.GetComponent<ActivityComponentC>();

            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            foreach (ActivityConfig activityConfig in activityConfigs)
            {
                if (activityConfig.ActivityType != 22)
                {
                    continue;
                }

                int receiveNum = 0;
                int leftNumber = 0;
                for (int i = 0; i < activityComponent.ZhanQuReceiveNumbers.Count; i++)
                {
                    if (activityComponent.ZhanQuReceiveNumbers[i].ActivityId == activityConfig.Id)
                    {
                        receiveNum = activityComponent.ZhanQuReceiveNumbers[i].ReceiveNum;
                    }
                }

                leftNumber = int.Parse(activityConfig.Par_2) - receiveNum;

                if (!activityComponent.ZhanQuReceiveIds.Contains(activityConfig.Id) && leftNumber > 0)
                {
                    await ActivityNetHelper.ZhanQuReceive(root, activityConfig.ActivityType, activityConfig.Id);
                }
            }
        }

        public static async ETTask ActivityLogin(Scene root)
        {
            ActivityComponentC activityComponent = root.GetComponent<ActivityComponentC>();

            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            foreach (ActivityConfig activityConfig in activityConfigs)
            {
                if (activityConfig.ActivityType != 31)
                {
                    continue;
                }

                if (activityComponent.ActivityReceiveIds.Contains(activityConfig.Id))
                {
                    await ActivityNetHelper.ActivityReceive(root, activityConfig.ActivityType, activityConfig.Id);
                }
            }
        }

        public static async ETTask ActivityToken(Scene root)
        {
            ActivityComponentC activityComponent = root.GetComponent<ActivityComponentC>();
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);

            if (root.GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                // 背包已满！
                return;
            }

            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            foreach (ActivityConfig activityConfig in activityConfigs)
            {
                if (activityConfig.ActivityType != 24)
                {
                    continue;
                }

                int selfRechage = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.RechargeNumber);

                if (userInfoComponent.UserInfo.Lv < int.Parse(activityConfig.Par_1))
                {
                    // "等级不足！"
                    break;
                }

                List<TokenRecvive> zhanQuTokenRecvives = activityComponent.QuTokenRecvive;

                if (selfRechage >= 298)
                {
                    for (int i = 0; i < zhanQuTokenRecvives.Count; i++)
                    {
                        if (zhanQuTokenRecvives[i].ActivityId == activityConfig.Id && zhanQuTokenRecvives[i].ReceiveIndex == 3)
                        {
                            await ActivityNetHelper.ActivityReceive(root, 24, activityConfig.Id, 3);
                        }
                    }
                }

                if (selfRechage >= 98)
                {
                    for (int i = 0; i < zhanQuTokenRecvives.Count; i++)
                    {
                        if (zhanQuTokenRecvives[i].ActivityId == activityConfig.Id && zhanQuTokenRecvives[i].ReceiveIndex == 2)
                        {
                            await ActivityNetHelper.ActivityReceive(root, 24, activityConfig.Id, 2);
                        }
                    }
                }

                for (int i = 0; i < zhanQuTokenRecvives.Count; i++)
                {
                    if (zhanQuTokenRecvives[i].ActivityId == activityConfig.Id && zhanQuTokenRecvives[i].ReceiveIndex == 1)
                    {
                        await ActivityNetHelper.ActivityReceive(root, 24, activityConfig.Id, 1);
                    }
                }
            }
        }

        public static async ETTask ActivitySingIn(Scene root)
        {
            ActivityComponentC activityComponent = root.GetComponent<ActivityComponentC>();

            List<ActivityConfig> showActivityConfigs = new List<ActivityConfig>();
            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            foreach (ActivityConfig activityConfig in activityConfigs)
            {
                if (activityConfig.ActivityType != 23)
                {
                    continue;
                }

                if (activityComponent.ActivityReceiveIds.Contains(activityConfig.Id))
                {
                    await ActivityNetHelper.ActivityReceive(root, activityConfig.ActivityType, activityConfig.Id);
                }

                showActivityConfigs.Add(activityConfig);
            }

            int curDay = 0;
            long serverNow = TimeHelper.ServerNow();
            bool isSign = CommonHelp.GetDayByTime(serverNow) == CommonHelp.GetDayByTime(activityComponent.LastSignTime);
            curDay = activityComponent.TotalSignNumber;
            if (activityComponent.TotalSignNumber < 30 && !isSign)
            {
                curDay++;
            }

            if (activityComponent.TotalSignNumber == 30)
            {
                // "已领完全部奖励！"
                return;
            }

            if (CommonHelp.GetDayByTime(serverNow) == CommonHelp.GetDayByTime(activityComponent.LastSignTime))
            {
                // "当日奖励已领取！"
                return;
            }

            int ActivityId = showActivityConfigs[curDay - 1].Id;

            if (activityComponent.ActivityReceiveIds.Contains(ActivityId))
            {
                // "当日奖励已领取！"
                return;
            }

            await ActivityNetHelper.ActivityReceive(root, 23, ActivityId);
        }

        public static async ETTask PaiMaiAuction(Scene root)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            P2C_PaiMaiAuctionInfoResponse response = await ActivityNetHelper.PaiMaiAuctionInfo(root, unit.Id);
            if (response.AuctionItem == 0)
            {
                // "已结束";
                return;
            }

            int price = (int)(response.AuctionPrice * 1.1f);
            UserInfo userInfo = root.GetComponent<UserInfoComponentC>().UserInfo;
            if (userInfo.Gold < price)
            {
                // "金币不足！"
                return;
            }

            await ActivityNetHelper.PaiMaiAuctionPrice(root, price);
        }

        public static async ETTask YueKa(Scene root)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            if (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.YueKaRemainTimes) > 0)
            {
                if (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.YueKaAward) == 1)
                {
                    //当天已领取
                    // "当天奖励已领取！"
                    return;
                }

                await ActivityNetHelper.YueKaReward(root);
            }
            else
            {
                await ActivityNetHelper.YueKaOpen(root);
            }
        }

        public static async ETTask ActivityMaoXian(Scene root)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            ActivityComponentC activityComponent = root.GetComponent<ActivityComponentC>();

            int rechargeNum = unit.GetMaoXianExp();
            int curActivityId = activityComponent.GetCurActivityId(rechargeNum);

            ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(curActivityId);
            int needNumber = int.Parse(activityConfig.Par_2);
            if (rechargeNum < needNumber)
            {
                // "冒险家积分不足！"
                return;
            }

            if (activityComponent.ActivityReceiveIds.Contains(curActivityId))
            {
                // "当前奖励已领取！"
                return;
            }

            await ActivityNetHelper.ActivityReceive(root, activityConfig.ActivityType, activityConfig.Id);
        }

        public static async ETTask ActivityTeHui(Scene root)
        {
            ActivityComponentC activityComponent = root.GetComponent<ActivityComponentC>();

            foreach (int activityId in activityComponent.DayTeHui)
            {
                if (!activityComponent.ActivityReceiveIds.Contains(activityId))
                {
                    ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(activityId);
                    await ActivityNetHelper.ActivityReceive(root, activityConfig.ActivityType, activityConfig.Id);
                }
            }
        }

        public static async ETTask NewYearCollectionWord(Scene root)
        {
            ActivityComponentC activityComponent = root.GetComponent<ActivityComponentC>();

            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < activityConfigs.Count; i++)
            {
                if (activityConfigs[i].ActivityType != 32)
                {
                    continue;
                }

                ActivityConfig activityConfig = activityConfigs[i];

                bool receiveMax = ActivityHelper.HaveReceiveTimes(activityComponent.ActivityReceiveIds, activityConfig.Id);
                if (!receiveMax)
                {
                    // "已达到最大领取上限！"
                    continue;
                }

                if (!root.GetComponent<BagComponentC>().CheckNeedItem(activityConfig.Par_2))
                {
                    // "道具不足！"
                    continue;
                }

                await ActivityNetHelper.ActivityReceive(root, activityConfig.ActivityType, activityConfig.Id);
            }
        }

        public static async ETTask RechargeRequest(Scene root)
        {
            List<int> recharge = new List<int>() { 6, 30, 50, 98, 198, 298, 298, 488, 648 };

            int index = RandomHelper.RandomNumber(0, recharge.Count);

            await UserInfoNetHelper.RechargeRequest(root, "", recharge[index], PayTypeEnum.AliPay);
        }
    }
}
