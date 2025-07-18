using System;
using System.Collections.Generic;
using System.Numerics;

namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof (UserInfoComponentS))]
    [FriendOf(typeof (BagComponentS))]
    public class C2M_ItemOperateHandler: MessageLocationHandler<Unit, C2M_ItemOperateRequest, M2C_ItemOperateResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemOperateRequest request, M2C_ItemOperateResponse response)
        {
            //获取UserID及User数据
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            UserInfo useInfo = userInfoComponent.UserInfo;
            long bagInfoID = request.OperateBagID;

            int locType = ItemLocType.ItemLocBag;
            if (request.OperateType == 2)
            {
                ItemConfig config = ItemConfigCategory.Instance.Get(int.Parse(request.OperatePar.Split('_')[0]));
                locType = config.ItemType == (int) ItemTypeEnum.PetHeXin? ItemLocType.ItemPetHeXinBag : locType;
            }

            if (request.OperateType == 4)
            {
                locType = ItemLocType.ItemLocEquip;
            }

            if (request.OperateType == 7)
            {
                locType = int.Parse(request.OperatePar);
            }

            int weizhi = -1;
            ItemConfig itemConfig = null;
            ItemInfo useBagInfo = bagComponent.GetItemByLoc(locType, bagInfoID);
            if (useBagInfo == null && request.OperateType != 8)
            {
                return;
            }

            if (useBagInfo != null)
            {
                itemConfig = ItemConfigCategory.Instance.Get(useBagInfo.ItemID);
                weizhi = itemConfig.ItemSubType;
            }

            //通知客户端背包刷新
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();
            //使用道具
            if (request.OperateType == 1 && itemConfig != null)
            {
                if (itemConfig.Id == 10000156)
                {
                    return;
                }

                if (itemConfig.DayUseNum > 0 && userInfoComponent.GetDayItemUse(itemConfig.Id) >= itemConfig.DayUseNum)
                {
                    response.Error = ErrorCode.ERR_ItemNoUseTime;
                    return;
                }

                //获取背包数据
                int costNumber = 1;
                bool bagIsFull = false;
                List<RewardItem> droplist = new List<RewardItem>();
                if (itemConfig.ItemSubType == 8) //碎片兑换
                {
                    string[] duihuanparams = itemConfig.ItemUsePar.Split(';');
                    int neednum = int.Parse(duihuanparams[0]);
                    if (bagComponent.GetItemNumber(itemConfig.Id) < neednum)
                    {
                        response.Error = ErrorCode.ERR_ItemNotEnoughError;
                        return;
                    }
                }

                if (itemConfig.ItemSubType == 9) //充值达到一定额度开启宝箱获得道具
                {
                    string[] itemPar = itemConfig.ItemUsePar.Split(';');
                    if (unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.RechargeNumber) < long.Parse(itemPar[0]))
                    {
                        response.Error = ErrorCode.ERR_NoPayValueError;
                        return;
                    }

                    string[] rewardInfos = itemConfig.ItemUsePar.Split(';');
                    DropHelper.DropIDToDropItem(int.Parse(rewardInfos[1]), droplist);

                    if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < ItemHelper.GetNeedCell(droplist))
                    {
                        bagIsFull = true;
                    }
                }

                if (itemConfig.ItemSubType == 102 || (itemConfig.ItemSubType == 103)) //宠物蛋(点击使用直接获得1个宠物)
                {
                    if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
                    {
                        bagIsFull = true;
                    }
                }

                if (itemConfig.ItemSubType == 104) //随机道具盒子
                {
                    int dropid = int.Parse(itemConfig.ItemUsePar);
                    droplist = new List<RewardItem>();
                    DropHelper.DropIDToDropItem(dropid, droplist);
                    if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < droplist.Count)
                    {
                        bagIsFull = true;
                    }
                }

                MapComponent mapComponent = unit.Scene().GetComponent<MapComponent>();
                if (itemConfig.ItemSubType == 110 && mapComponent.SceneId != 2000001) // 领主怪物召唤
                {
                    response.Error = ErrorCode.ERR_ItemOnlyUseMiJing;
                    return;
                }

                if (itemConfig.ItemSubType == 111 && ConfigData.BatchUseItemList.Contains(itemConfig.Id))
                {
                    //目前只有111类型支持批量使用
                    if (!string.IsNullOrEmpty(request.OperatePar))
                    {
                        costNumber = int.Parse(request.OperatePar);
                    }
                }

                if (itemConfig.ItemSubType == 14 //召唤卷轴
                    || itemConfig.ItemSubType == 114) //宝石
                {
                    costNumber = 0;
                }

                if (itemConfig.ItemSubType == 112) //经验木桩
                {
                    int openDay = ServerHelper.GetServeOpenDay( unit.Zone());
                    if (openDay <= 1)
                    {
                        response.Error = ErrorCode.ERR_ItemNoUseTime;
                        return;
                    }
                }

                if (itemConfig.ItemSubType == 127)
                {
                    if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
                    {
                        bagIsFull = true;
                    }
                }

                if (itemConfig.ItemSubType == 137)
                {
                    //检测要附灵的宠物蛋是否存在
                    long chongwudanId = long.Parse(request.OperatePar);
                    ItemInfo chongwudan = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, chongwudanId);
                    if (chongwudan == null)
                    {
                        response.Error = ErrorCode.ERR_ItemNotExist;
                        return;
                    }
                }

                if (itemConfig.ItemSubType == 138)
                {
                    // int totalTimes = int.Parse(GlobalValueConfigCategory.Instance.Get(19).Value);
                    if (unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.TeamDungeonTimes) <= 0)
                    {
                        response.Error = ErrorCode.ERR_TeamDungeonTimesMax;
                        return;
                    }
                }


                if (bagIsFull)
                {
                    response.Error = ErrorCode.ERR_BagIsFull;
                    return;
                }

                if (itemConfig.ItemType != 1
                    && itemConfig.ItemType != 2)
                {
                    return;
                }

                if (bagComponent.OnCostItemData(useBagInfo, ItemLocType.ItemLocBag, costNumber))
                {
                    bool costItemStatus = true;
                    //根据道具子类分发不同的功能
                    switch (itemConfig.ItemSubType)
                    {
                        //增加金币
                        case 1:
                            userInfoComponent.UpdateRoleMoneyAdd(UserDataType.Gold, itemConfig.ItemUsePar, true, ItemGetWay.CostItem);
                            break;
                        //增加经验
                        case 2:
                            userInfoComponent.UpdateRoleData(UserDataType.Exp, itemConfig.ItemUsePar);
                            break;
                        //回城卷轴[返回另外一个副本场景]
                        case 4:
                            if (mapComponent.MapType == (int) MapTypeEnum.LocalDungeon)
                            {
                                //LocalDungeonComponent localDungeon = unit.DomainScene().GetComponent<LocalDungeonComponent>();
                                //TransferHelper.LocalDungeonTransfer(unit, 0, int.Parse(itemConfig.ItemUsePar), localDungeon.FubenDifficulty).Coroutine();
                            }
                            break;
                        //图纸制造
                        case 5:
                            break;
                        //随机宝箱
                        case 6:
                            int dropId = 0;
                            try
                            {
                                dropId = int.Parse(itemConfig.ItemUsePar);
                            }
                            catch (Exception ex)
                            {
                                Log.Error(ex.ToString() + $"{itemConfig.Id}   dropId ==0");

                            }

                            if (dropId > 0)
                            {
                                DropHelper.DropIDToDropItem_2(dropId, droplist);
                                bagComponent.OnAddItemData(droplist, string.Empty,
                                    $"{ItemGetWay.ItemBox_6}_{TimeHelper.ServerNow()}_{itemConfig.Id}");
                            }

                            response.RewardList = droplist;
                            break;
                        //兑换：
                        case 8:
                            string[] duihuanparams = itemConfig.ItemUsePar.Split(';');
                            int neednum = int.Parse(duihuanparams[0]);
                            int newItem = int.Parse(duihuanparams[1]);

                            bagComponent.OnCostItemData($"{itemConfig.Id};{neednum - 1}");
                            bagComponent.OnAddItemData($"{newItem};1", $"{ItemGetWay.ItemBox_8}_{TimeHelper.ServerNow()}");
                            break;
                        case 9:
                            bagComponent.OnAddItemData(droplist, string.Empty, $"{ItemGetWay.ActivityHongBao}_{TimeHelper.ServerNow()}");
                            break;
                        //冷却时间清空卷轴"
                        case 12:
                            userInfoComponent.OnCleanBossCD();
                            
                            if (mapComponent.MapType == (int) MapTypeEnum.LocalDungeon)
                            {
                                unit.Scene().GetComponent<LocalDungeonComponent>().OnCleanBossCD();
                            }

                            break;
                        //召唤卷轴
                        case 14:
                            if (mapComponent.MapType == (int) MapTypeEnum.LocalDungeon)
                            {
                                //UnitFactory.CreateTempFollower(unit, int.Parse(itemConfig.ItemUsePar));
                            }

                            break;
                        case 15: //附魔道具
                            List<HideProList> hideProLists = XiLianHelper.GetItemFumoPro(itemConfig.Id);
                            bagComponent.OnEquipFuMo(itemConfig.Id, hideProLists, int.Parse(request.OperatePar));
                            unit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.FoMoNumber_213, 0, 1);
                            break;
                        case 16: //附魔技能
                            userInfoComponent.UserInfo.MakeList.Add(int.Parse(itemConfig.ItemUsePar));
                            break;
                        //使用技能
                        case 101:
                            break;
                        //宠物蛋
                        case 102:
                            string[] getway = useBagInfo.GetWay.Split('_');
                            unit.GetComponent<PetComponentS>().OnAddPet(int.Parse(getway[0]), int.Parse(itemConfig.ItemUsePar), 0, useBagInfo.FuLing);
                            break;
                        //随机宠物蛋
                        case 103:
                            getway = useBagInfo.GetWay.Split('_');
                            int petId = int.Parse(itemConfig.ItemUsePar);
                            int skinId = 0;
                            if (!string.IsNullOrEmpty(useBagInfo.ItemPar))
                            {
                                skinId = int.Parse(useBagInfo.ItemPar);
                            }

                            unit.GetComponent<PetComponentS>().OnAddPet(int.Parse(getway[0]), petId, skinId, useBagInfo.FuLing);
                            break;
                        //随机盒子
                        case 104:
                            bagComponent.OnAddItemData(droplist, string.Empty, $"{ItemGetWay.ItemBox_104}_{TimeHelper.ServerNow()}");
                            break;
                        //指定道具
                        case 106:
                            bagComponent.OnAddItemData(itemConfig.ItemUsePar, $"{ItemGetWay.ItemBox_106}_{TimeHelper.ServerNow()}");
                            break;
                        //永久技能
                        case 107:
                            //判定职业是否符合
                            if (itemConfig.ItemUsePar != "0")
                            {
                                if (itemConfig.ItemUsePar == userInfoComponent.UserInfo.Occ.ToString()
                                    || itemConfig.ItemUsePar == userInfoComponent.UserInfo.OccTwo.ToString())
                                {
                                    //符合条件
                                }
                                else
                                {
                                    //不符合条件
                                    costItemStatus = false;
                                    response.Error = ErrorCode.ERR_ItemUseError;
                                    break;
                                }
                            }

                            unit.GetComponent<SkillSetComponentS>().OnAddkillId(int.Parse(itemConfig.SkillID), 0, SkillSetEnum.Skill, SkillSourceEnum.Book, true);
                            break;
                        case 108: //宠物经验骨头
                        case 109: //宠物经验牛奶
                            break;
                        case 110:
                            //1;20;70010101,70010102@21;70;70020101,70020102
                            int createMonsterID = 0;
                            int lv = userInfoComponent.UserInfo.Lv;
                            string[] monsters = itemConfig.ItemUsePar.Split('@');

                            if (monsters.Length > 100)
                            {
                                Log.Error($"monsters.Length > 100:  {itemConfig.ItemUsePar}");
                                return;
                            }

                            for (int c = 0; c < monsters.Length; c++)
                            {
                                //1;20;70010101,70010102
                                string[] lelveparams = monsters[c].Split(";");
                                int level_1 = int.Parse(lelveparams[0]);
                                int level_2 = int.Parse(lelveparams[1]);
                                if (lv < level_1 || lv > level_2)
                                {
                                    continue;
                                }

                                string[] ids = lelveparams[2].Split(',');
                                int r_number = RandomHelper.RandomNumber(0, ids.Length);
                                Vector3 vector3 = new Vector3(unit.Position.x + RandomHelper.RandFloat01() * 1, unit.Position.y,
                                    unit.Position.z + RandomHelper.RandFloat01() * 1);
                                // Unit monster = UnitFactory.CreateMonster(unit.DomainScene(), int.Parse(ids[r_number]), vector3, new CreateMonsterInfo()
                                // {
                                //     Camp = CampEnum.CampMonster1
                                // });
                                createMonsterID = int.Parse(ids[r_number]);
                            }

                            //发送广播信息
                            if (createMonsterID != 0)
                            {
                                // MonsterConfig monsterCof = MonsterConfigCategory.Instance.Get(createMonsterID);
                                //ServerMessageHelper.SendServerMessage(DBHelper.GetChatServerId(unit.DomainZone()),
                                //     NoticeType.Notice, "玩家" + unit.GetComponent<UserInfoComponent>().UserInfo.Name + "在宝藏之地召唤出领主怪物:<color=#FF75F0>" + monsterCof.MonsterName + "</color>").Coroutine();
                            }

                            break;
                        //金币袋子
                        case 111:
                            string[] jinbiInfos = itemConfig.ItemUsePar.Split(';');
                            int userLv = userInfoComponent.UserInfo.Lv;
                            ExpConfig expConfig = ExpConfigCategory.Instance.Get(userLv);
                            long addCoin = (int) RandomHelper.RandomNumberFloat(float.Parse(jinbiInfos[0]) * expConfig.RoseGoldPro,
                                float.Parse(jinbiInfos[1]) * expConfig.RoseGoldPro);
                            addCoin *= costNumber;
                            userInfoComponent.UpdateRoleMoneyAdd(UserDataType.Gold, addCoin.ToString(), true, ItemGetWay.Sell);
                            break;
                        //经验木桩
                        case 112:
                            string[] expInfos = itemConfig.ItemUsePar.Split('@');
                            int needZuanshi = request.OperatePar == "1"? int.Parse(expInfos[0]) : 0;
                            string[] paramInfo = expInfos[int.Parse(request.OperatePar)].Split(';');
                            userLv = userInfoComponent.UserInfo.Lv;

                            //如果当前钻石不足返回错误
                            if (userInfoComponent.UserInfo.Diamond < needZuanshi)
                            {
                                response.Error = ErrorCode.ERR_DiamondNotEnoughError;
                                break;
                            }

                            expConfig = ExpConfigCategory.Instance.Get(userLv);
                            int addExp = (int) RandomHelper.RandomNumberFloat(float.Parse(paramInfo[0]) * expConfig.RoseExpPro,
                                float.Parse(paramInfo[1]) * expConfig.RoseExpPro);
                            userInfoComponent.UpdateRoleData(UserDataType.Exp, addExp.ToString());
                            userInfoComponent.UpdateRoleMoneySub(UserDataType.Diamond, (needZuanshi * -1).ToString(), true, ItemGetWay.DuiHuan);
                            response.OperatePar = addExp.ToString();
                            break;
                        //藏宝图
                        case 113:
                            int dropid = int.Parse(useBagInfo.ItemPar.Split('@')[2]);
                            //UnitFactory.CreateDropItems(unit, unit, 0, dropid, request.OperatePar);
                            break;
                        case 114: //宝石
                            break;
                        case 115: //宠物皮肤激活道具
                            unit.GetComponent<PetComponentS>().OnUnlockSkin(itemConfig.ItemUsePar);
                            break;
                        case 116: //角色洗点
                            //unit.GetComponent<HeroDataComponent>().OnResetPoint();
                            break;
                        case 117: //宠物洗点
                        case 118: //宠物资质
                        case 119: //宠物成长
                            break;
                        case 120: //120 冒险积分
                            unit.GetComponent<NumericComponentS>().ApplyValue( NumericType.MaoXianExp, int.Parse(itemConfig.ItemUsePar), true);
                            break;
                        case 121: //鉴定符
                            break;
                        case 122: //宠物技能书
                            break;
                        case 123: //宠物扩展工具
                            int petnumer = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetExtendNumber);
                            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.PetExtendNumber, petnumer + 1, true);
                            break;
                        case 124: //仓库扩展工具
                            int cangkuNumber = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.CangKuNumber);
                            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.CangKuNumber, cangkuNumber + 1, true);
                            break;
                        case 125: //坐骑获取
                            userInfoComponent.OnHorseActive(int.Parse(itemConfig.ItemUsePar), true);
                            int hourseId = int.Parse(itemConfig.ItemUsePar);
                            bool canhorse = hourseId == 10001? userInfoComponent.UserInfo.Lv >= 25 : true;
                            if (canhorse && userInfoComponent.UserInfo.HorseIds.Count == 1)
                            {
                                unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.HorseFightID, hourseId, true);
                            }

                            Function_Fight.UnitUpdateProperty_Base(unit, true, true);
                            break;
                        case 126: //集字
                            break;
                        case 127: //藏宝图
                            string rewardItem = useBagInfo.ItemPar.Split('@')[2];
                            bagComponent.OnAddItemData(rewardItem, $"{ItemGetWay.TreasureMap}_{TimeHelper.ServerNow()}");
                            //unit.GetComponent<ChengJiuComponent>().TriggerEvent(ChengJiuTargetEnum.TreasureMapNumber_210, 0, 1);

                            //普通
                            if (itemConfig.ItemQuality == 4)
                            {
                                //unit.GetComponent<TaskComponent>().TriggerTaskEvent(TaskTargetType.TreasureMapNormal_26, 0, 1);
                                //unit.GetComponent<TaskComponent>().TriggerTaskCountryEvent(TaskTargetType.TreasureMapNormal_26, 0, 1);
                            }

                            if (itemConfig.ItemQuality == 5)
                            {
                                //unit.GetComponent<TaskComponent>().TriggerTaskEvent(TaskTargetType.TreasureMapHigh_27, 0, 1);
                                //unit.GetComponent<TaskComponent>().TriggerTaskCountryEvent(TaskTargetType.TreasureMapHigh_27, 0, 1);
                            }   

                            break;
                        case 128: //激活称号
                            unit.GetComponent<TitleComponentS>().OnActiveTile(int.Parse(itemConfig.ItemUsePar));
                            break;
                        case 129: //激活精灵
                            unit.GetComponent<ChengJiuComponentS>().OnAddJingLingProgess(int.Parse(itemConfig.ItemUsePar));
                            Function_Fight.UnitUpdateProperty_Base(unit, true, true);
                            break;
                        case 131: //增加饱食度
                            string[] baoshipas = itemConfig.ItemUsePar.Split(';')[0].Split(',');
                            int baoshiadd = RandomHelper.RandomNumber(int.Parse(baoshipas[0]), int.Parse(baoshipas[1]) + 1);
                            userInfoComponent.UpdateRoleData(UserDataType.BaoShiDu, baoshiadd.ToString());
                            break;
                        case 132:
                            long reduceTime = long.Parse(itemConfig.ItemUsePar);
                            unit.GetComponent<NumericComponentS>().ApplyValue( NumericType.SeasonBossRefreshTime, -1 * reduceTime, true);
                            break;
                        case 133:
                        case 134:
                            break;
                        case 135:
                            // C2M_SkillCmd cmd = new C2M_SkillCmd();
                            // cmd.SkillID = int.Parse(itemConfig.ItemUsePar);
                            // cmd.TargetID = unit.Id;
                            // cmd.TargetAngle = (int)Quaternion.QuaternionToEuler(unit.Rotation).y;
                            // cmd.TargetDistance = 0f;
                            // unit.GetComponent<SkillManagerComponent>().OnUseSkill(cmd);
                            break;
                        case 136:
                            break;
                        case 137:
                            //宠物蛋附灵
                            long chongwudanId = long.Parse(request.OperatePar);
                            ItemInfo chongwudan = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, chongwudanId);
                            chongwudan.FuLing = 1;
                            m2c_bagUpdate.BagInfoUpdate.Add(chongwudan.ToMessage());
                            break;
                        case 138:
                            // 增加副本次数
                            int teamTime = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.TeamDungeonTimes);
                            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.TeamDungeonTimes, teamTime - 1, true);
                            break;
                        case 139:
                            //增加背包格子
                            bagComponent.BagAddCellNumber[ItemLocType.ItemLocBag]++;
                            break;
                        case 140:
                            bagComponent.BagAddCellNumber[ItemLocType.ItemWareHouse1]++;
                            bagComponent.BagAddCellNumber[ItemLocType.ItemWareHouse2]++;
                            bagComponent.BagAddCellNumber[ItemLocType.ItemWareHouse3]++;
                            bagComponent.BagAddCellNumber[ItemLocType.ItemWareHouse4]++;
                            //增加仓库格子
                            break;
                    }

                    //扣除道具
                    if (costItemStatus)
                    {
                        if (useBagInfo.ItemNum <= 0)
                        {
                            m2c_bagUpdate.BagInfoDelete.Add(useBagInfo.ToMessage());
                        }
                        else
                        {
                            m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());
                        }
                    }

                    if (itemConfig.DayUseNum > 0)
                    {
                        userInfoComponent.OnDayItemUse(itemConfig.Id);
                    }
                }
            }

            //出售道具
            if (request.OperateType == 2 && locType == ItemLocType.ItemLocBag)
            {
                //默认出售全部
                //给与对应金币或货币奖励
                string[] sellinfo = request.OperatePar.Split('_');
                if (sellinfo.Length < 2)
                {
                    response.Error = ErrorCode.ERR_VersionNoMatch;
                    return;
                }

                if (CommonHelp.IfNull(sellinfo[1]))
                {
                    response.Error = ErrorCode.ERR_VersionNoMatch;
                    return;
                }

                int sellNum = int.Parse(sellinfo[1]);
                if (sellNum <= 0 || sellNum > useBagInfo.ItemNum)
                {
                    response.Error = ErrorCode.ERR_ModifyData;
                    return;
                }

                string[] gemids = useBagInfo.GemIDNew.Split('_');
                ItemConfig itemConf = null;
                for (int i = 0; i < gemids.Length; i++)
                {
                    if (gemids[i] == "0")
                    {
                        continue;
                    }

                    itemConf = ItemConfigCategory.Instance.Get(int.Parse(gemids[i]));
                    userInfoComponent.UpdateRoleData((int) itemConf.SellMoneyType, (itemConf.SellMoneyValue).ToString());
                }

                //珍宝属性价格提升
                int sellValue = itemConfig.SellMoneyValue;
                if (useBagInfo.HideSkillLists.Contains(68000102))
                {
                    sellValue = itemConfig.SellMoneyValue * 20;
                }

                itemConf = ItemConfigCategory.Instance.Get(useBagInfo.ItemID);
                userInfoComponent.UpdateRoleMoneyAdd((int) itemConf.SellMoneyType, (sellNum * sellValue).ToString(), true, ItemGetWay.Sell);
                bagComponent.OnCostItemData(useBagInfo, locType, sellNum);
                if (useBagInfo.ItemNum <= 0)
                {
                    m2c_bagUpdate.BagInfoDelete.Add(useBagInfo.ToMessage());
                }
                else
                {
                    m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());
                }
            }

            if (request.OperateType == 2 && locType == ItemLocType.ItemPetHeXinBag)
            {
                //默认出售全部
                //给与对应金币或货币奖励
                int sellNum = int.Parse(request.OperatePar.Split('_')[1]);
                if (sellNum <= 0 || sellNum > useBagInfo.ItemNum)
                {
                    response.Error = ErrorCode.ERR_ModifyData;
                    return;
                }

                userInfoComponent.UpdateRoleData(itemConfig.SellMoneyType, (sellNum * itemConfig.SellMoneyValue).ToString());
                bagComponent.OnCostItemData(useBagInfo, locType, sellNum);
                if (useBagInfo.ItemNum == 0)
                {
                    m2c_bagUpdate.BagInfoDelete.Add(useBagInfo.ToMessage());
                }
                else
                {
                    m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());
                }
            }

            //穿戴装备
            if (request.OperateType == 3)
            {
                //宝石
                if (itemConfig.ItemType == 4)
                {
                    response.Error = ErrorCode.ERR_EquipLvLimit;
                    return;
                }

                int error = ItemHelper.CanEquip(useBagInfo, useInfo);
                if (error != 0)
                {
                    response.Error = error;
                    return;
                }

                //获取之前的位置是否有装备
                ItemInfo beforeequip = null;
                if (weizhi == (int) ItemSubTypeEnum.Shiping)  // && !CommonHelp.IsBanHaoZone(unit.Zone()))
                {
                    List<ItemInfo> equipList = bagComponent.GetEquipListByWeizhi(ItemLocType.ItemLocEquip, weizhi);
                    beforeequip = equipList.Count < ConfigData.EquipShiPingMax? null : equipList[0];
                }
                else
                {
                    beforeequip = bagComponent.GetEquipBySubType(ItemLocType.ItemLocEquip, weizhi);
                }

                if (beforeequip != null)
                {
                    bagComponent.OnChangeItemLoc(beforeequip, ItemLocType.ItemLocBag, ItemLocType.ItemLocEquip);
                    bagComponent.OnChangeItemLoc(useBagInfo, ItemLocType.ItemLocEquip, ItemLocType.ItemLocBag);

                    unit.GetComponent<SkillSetComponentS>().OnTakeOffEquip(ItemLocType.ItemLocEquip, beforeequip);
                    unit.GetComponent<SkillSetComponentS>().OnWearEquip(useBagInfo);
                    m2c_bagUpdate.BagInfoUpdate.Add(beforeequip.ToMessage());
                }
                else
                {
                    bagComponent.OnChangeItemLoc(useBagInfo, ItemLocType.ItemLocEquip, ItemLocType.ItemLocBag);
                    unit.GetComponent<SkillSetComponentS>().OnWearEquip(useBagInfo);
                }

                int zodiacnumber = bagComponent.GetZodiacnumber();
                unit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.ZodiacEquipNumber_215, 0, zodiacnumber);
                Function_Fight.UnitUpdateProperty_Base(unit, true, true);
                useBagInfo.isBinging = true;
                m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());

                if (weizhi == (int) ItemSubTypeEnum.Wuqi)
                {
                    unit.GetComponent<SkillPassiveComponent>().OnTrigegerPassiveSkill(SkillPassiveTypeEnum.WandBuff_8, useBagInfo.ItemID);
                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.Now_Weapon, useBagInfo.ItemID, true);
                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.WearWeaponFisrt, 1, true);
                }
            }

            //卸下装备
            if (request.OperateType == 4)
            {
                //判断背包格子是否足够
                bool full = bagComponent.IsBagFullByLoc(ItemLocType.ItemLocBag);
                if (full)
                {
                    response.Error = ErrorCode.ERR_BagIsFull;
                    return;
                }

                if (itemConfig.ItemType == ItemTypeEnum.Equipment && itemConfig.ItemSubType == 201)
                {
                    return;
                }

                bagComponent.OnChangeItemLoc(useBagInfo, ItemLocType.ItemLocBag, ItemLocType.ItemLocEquip);
                unit.GetComponent<SkillSetComponentS>().OnTakeOffEquip(ItemLocType.ItemLocEquip, useBagInfo);
                Function_Fight.UnitUpdateProperty_Base(unit, true, true);
                m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());
                if (weizhi == (int) ItemSubTypeEnum.Wuqi)
                {
                    unit.GetComponent<SkillPassiveComponent>().OnTrigegerPassiveSkill(SkillPassiveTypeEnum.WandBuff_8, 0);
                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.Now_Weapon, 0, true);
                }
            }

            //鉴定装备
            if (request.OperateType == 5)
            {
                //判定材料消耗
                bool ifSell = false; //默认出售全部
                long baginfoId = long.Parse(request.OperatePar);
                int rolelv = useInfo.Lv;
                string qulitylv = "";
                bool ifItem = false;
                if (baginfoId == 0 && itemConfig != null)
                {
                    //金币鉴定，扣除金币
                    qulitylv = itemConfig.UseLv.ToString();
                    ifSell = bagComponent.OnCostItemData($"1;{ItemHelper.GetJianDingCoin(itemConfig.UseLv)}");
                }
                else
                {
                    ItemInfo baginfoCost = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, baginfoId);
                    if (baginfoCost != null)
                    {
                        //道具鉴定，扣除道具
                        qulitylv = baginfoCost.ItemPar;
                        qulitylv = string.IsNullOrEmpty(qulitylv)? "0" : qulitylv;
                        ItemConfig costitemconfig = ItemConfigCategory.Instance.Get(baginfoCost.ItemID);

                        unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.JianDingQulity_42, int.Parse(qulitylv), 1);
                        unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.JianDing_1017, 0, 1);

                        ifSell = bagComponent.OnCostItemData(baginfoId, 1);
                        ifItem = true;
                    }
                    else
                    {
                        ifSell = false;
                    }
                }

                if (ifSell)
                {
                    //未鉴定才可以
                    useBagInfo.IfJianDing = false;

                    if (itemConfig.EquipType != 101)
                    {
                        useBagInfo.HideProLists =XiLianHelper.GetEquipZhuanJingHidePro(itemConfig.ItemEquipID, itemConfig.Id, int.Parse(qulitylv), unit, ifItem);
                    }

                    m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());
                    //如果当前有隐藏技能一起飘出
                    if (useBagInfo.HideSkillLists.Count > 0)
                    {
                        string skillName = "";
                        for (int i = 0; i < useBagInfo.HideSkillLists.Count; i++)
                        {
                            skillName = skillName + $" {SkillConfigCategory.Instance.Get(useBagInfo.HideSkillLists[0]).SkillName}";
                            //unit.GetComponent<ChengJiuComponent>().TriggerEvent(ChengJiuTargetEnum.EquipActiveSkillId_222, useBagInfo.HideSkillLists[i], 1);
                        }

                        string noticeContent = $"恭喜玩家<color=#B6FF00>{userInfoComponent.UserName}</color>在拾取装备时，意外在装备上发现了隐藏技能:<color=#FFA313>{skillName}</color>。";
                        BroadCastHelper.SendBroadMessage(unit.Root(), NoticeType.Notice, noticeContent);
                    }

                    long totalValue = 0;
                    if (useBagInfo.HideProLists != null && useBagInfo.HideProLists.Count > 0)
                    {
                        unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.JianDingAttrNumber_43, useBagInfo.HideProLists.Count, 1);

                        for (int pro = 0; pro < useBagInfo.HideProLists.Count; pro++)
                        {
                            totalValue += useBagInfo.HideProLists[pro].HideValue;
                        }
                    }

                    unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.JianDingValue_140, (int)totalValue, 1);
                    unit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.JianDingEqipNumber_212, int.Parse(qulitylv), 1);
                }
                else
                {
                    response.Error = ErrorCode.ERR_ItemNotEnoughError;
                    return;
                }
            }

            //放入仓库
            if (request.OperateType == 6)
            {
                int hourseId = int.Parse(request.OperatePar);
                if (bagComponent.IsBagFullByLoc(hourseId))
                {
                    response.Error = ErrorCode.ERR_BagIsFull; //错误码:仓库已满
                    return;
                }

                if (useBagInfo.Loc != (int) ItemLocType.ItemLocBag)
                {
                    response.Error = ErrorCode.ERR_ModifyData;
                    return;
                }

                bagComponent.OnChangeItemLoc(useBagInfo, hourseId, ItemLocType.ItemLocBag);
                m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());
            }

            //放回背包
            if (request.OperateType == 7)
            {
                int hourseId = useBagInfo.Loc;
                if (bagComponent.IsBagFullByLoc(ItemLocType.ItemLocBag))
                {
                    response.Error = ErrorCode.ERR_BagIsFull; //错误码:仓库已满
                    return;
                }

                if (useBagInfo.Loc != hourseId)
                {
                    response.Error = ErrorCode.ERR_ModifyData;
                    return;
                }

                bagComponent.OnChangeItemLoc(useBagInfo, ItemLocType.ItemLocBag, hourseId);
                unit.GetComponent<TaskComponentS>().OnGetItemForWarehouse(useBagInfo.ItemID);
                m2c_bagUpdate.BagInfoUpdate.Add(useBagInfo.ToMessage());
            }

            //整理背包
            if (request.OperateType == 8)
            {
                bagComponent.OnRecvItemSort(int.Parse(request.OperatePar));
            }
            bool isRobot = unit.GetComponent<UserInfoComponentS>().UserInfo.RobotId > 0;
            if (isRobot)
            {
                UnitCacheHelper.SaveComponentCache(unit.Root(), bagComponent).Coroutine();
            }

            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            //通知客户端属性刷新
            await ETTask.CompletedTask;
        }
    }
}
