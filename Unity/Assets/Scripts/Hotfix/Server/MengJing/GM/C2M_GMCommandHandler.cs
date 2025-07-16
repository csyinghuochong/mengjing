using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;

namespace ET.Server
{
    [FriendOf(typeof(UserInfoComponentS))]
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_GMCommandHandler: MessageLocationHandler<Unit, C2M_GMCommand>
    {
        protected override async ETTask Run(Unit unit, C2M_GMCommand message)
        {
            try
            {
                if (!GMHelp.IsGmAccount(message.Account)
                    && !CommonHelp.IsBanHaoZone(unit.Zone()))
                {
                    return;
                }
                
                string[] commands = message.GMMsg.Split('#');
                if (commands.Length == 0)
                {
                    return;
                }

                if (message.GMMsg == "#completetask")
                {
                    unit.GetComponent<TaskComponentS>().CompletCurrentTask();
                    return;
                }
                
                if (message.GMMsg == "#killall")
                {
                    List<EntityRef<Unit>> units = unit.GetParent<UnitComponent>().GetAll();
                    for(int i = units.Count - 1; i >= 0; i--)
                    {
                        Unit uunit = units[i];
                        if (uunit.Type != UnitType.Monster)
                        {
                            continue;
                        }

                        if (!uunit.IsCanBeAttack())
                        {
                            continue;
                        }

                        uunit.GetComponent<NumericComponentS>().ApplyChange(NumericType.Now_Hp, -1000000000, attackid: unit.Id);
                    }
                    return;
                }
                
                if (message.GMMsg == "#hightest")
                {
                    // 提升等级
                    int level = 70 - unit.GetComponent<UserInfoComponentS>().UserInfo.Lv;
                    unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.Lv, level.ToString());
                    
                    // 添加道具
                    string items = "10;100000@1;100000000@3;100000000@35;100000000@16;1000000@1000001;999@1000002;999@1000003;999@1000004;999@1000005;99@1000010;999@1000013;999@1000014;999@1000016;99@1000017;999@1000018;9999@1000019;9999@1000021;9999@1000022;9999@1000023;9999@1000025;9999@1000026;999@1000027;9999@1000028;9999@1000029;9999@1000030;9999@1000031;999@1000032;9999@1000034;999@1000035;999@1000036;999@1010002;999@1010011;999@1010012;999@1010013;999@1010014;999@1010015;999@1010030;999@1010031;999@1010032;1@1010033;1@1010034;999@1010035;999@1010036;999@1010038;999@1010045;9999@1010048;999@1010049;999@1010063;999@1010101;1@1010102;1@1010103;1@1010104;1@1020001;9999@1140000;9999@10001;1";
                    List<RewardItem> rewardItems = new List<RewardItem>();
                    foreach (string str in items.Split('@'))
                    {
                        string[] itemInfo = str.Split(';');
                        int itemId = int.Parse(itemInfo[0]);
                        int itemNumber = int.Parse(itemInfo[1]);
                        rewardItems.Add(new RewardItem() { ItemID = itemId, ItemNum = itemNumber });
                    }
                    bool restut = unit.GetComponent<BagComponentS>().OnAddItemData(rewardItems, string.Empty, $"{ItemGetWay.GM}_{TimeHelper.ServerNow()}", true, true);
                    
                    // 开启所有仓库页
                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.CangKuNumber, 4);
                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.JianYuanCangKu, 4);
                    
                    // 开启拾光收集
                    foreach (ShouJiItemConfig config in ShouJiItemConfigCategory.Instance.GetAll().Values)
                    {
                        if (config.StartType == 1)
                        {
                            unit.GetComponent<ShoujiComponentS>().OnGetItem(config.ItemID);
                        }

                        if (config.StartType == 2)
                        {
                            unit.GetComponent<ShoujiComponentS>().OnShouJiTreasure(config.Id, config.AcitveNum);
                        }
                    }
                    
                    // 坐骑
                    foreach (ZuoQiShowConfig config in ZuoQiShowConfigCategory.Instance.GetAll().Values)
                    {
                        unit.GetComponent<UserInfoComponentS>().OnHorseActive(config.Id, true);
                    }
                    unit.GetComponent<ChengJiuComponentS>().OpenAllJingLing();
                    unit.GetComponent<ChengJiuComponentS>().OpenAllPetTuJian();
                    
                    // 赛季等级
                    List<SeasonLevelConfig> seasonLevelConfigs = SeasonLevelConfigCategory.Instance.GetAll().Values.ToList();
                    unit.GetComponent<UserInfoComponentS>().UserInfo.SeasonLevel = seasonLevelConfigs[^1].Id;
                    
                    return;
                }
                
                if (message.GMMsg == "#middletest")
                {
                    // 提升等级
                    int level = 40 - unit.GetComponent<UserInfoComponentS>().UserInfo.Lv;
                    unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.Lv, level.ToString());
                    
                    // 添加道具
                    string items = "1;100000000@3;100000000@1030001;1";
                    List<RewardItem> rewardItems = new List<RewardItem>();
                    foreach (string str in items.Split('@'))
                    {
                        string[] itemInfo = str.Split(';');
                        int itemId = int.Parse(itemInfo[0]);
                        int itemNumber = int.Parse(itemInfo[1]);
                        rewardItems.Add(new RewardItem() { ItemID = itemId, ItemNum = itemNumber });
                    }
                    unit.GetComponent<BagComponentS>().OnAddItemData(rewardItems, string.Empty, $"{ItemGetWay.GM}_{TimeHelper.ServerNow()}", true, true);
                    
                    // 开启所有仓库页
                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.CangKuNumber, 4);
                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.JianYuanCangKu, 4);
                    
                    // 开启拾光收集
                    foreach (ShouJiItemConfig config in ShouJiItemConfigCategory.Instance.GetAll().Values)
                    {
                        if (config.StartType == 1)
                        {
                            unit.GetComponent<ShoujiComponentS>().OnGetItem(config.ItemID);
                        }

                        if (config.StartType == 2)
                        {
                            unit.GetComponent<ShoujiComponentS>().OnShouJiTreasure(config.Id, config.AcitveNum);
                        }
                    }
                    
                    // 坐骑
                    foreach (ZuoQiShowConfig config in ZuoQiShowConfigCategory.Instance.GetAll().Values)
                    {
                        unit.GetComponent<UserInfoComponentS>().OnHorseActive(config.Id, true);
                    }
                    unit.GetComponent<ChengJiuComponentS>().OpenAllJingLing();
                    unit.GetComponent<ChengJiuComponentS>().OpenAllPetTuJian();
                    return;
                }

                if (message.GMMsg == "#alljingling")
                {
                    unit.GetComponent<ChengJiuComponentS>().OpenAllJingLing();
                    unit.GetComponent<ChengJiuComponentS>().OpenAllPetTuJian();
                    return;
                }

                if (message.GMMsg == "#testmonster")
                {
                    List<Unit> allmonster = UnitHelper.GetUnitList(unit.Scene(), UnitType.Monster);
                    for (int i = 0; i < allmonster.Count; i++)
                    {
                        int monsterid = allmonster[i].ConfigId;
                        MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterid);
                        if (monsterConfig.MonsterName.Contains("森林熊"))
                        {
                            Console.WriteLine($"森林熊:  {monsterid}");
                        }
                    }
                }

                if (message.GMMsg == "#allmonster")
                {
                    List<MonsterConfig> monsterConfigs = MonsterConfigCategory.Instance.GetAll().Values.ToList();
                    for (int i = 0; i < monsterConfigs.Count; i++)
                    {
                        await unit.Root().GetComponent<TimerComponent>().WaitAsync(1);
                        float3 pos = unit.Position;
                        float3 vector3 = new float3(pos.x + RandomHelper.RandFloat01() * 1, pos.y, pos.z + RandomHelper.RandFloat01() * 1);
                        Unit monster = UnitFactory.CreateMonster(unit.Scene(), monsterConfigs[i].Id, vector3, new CreateMonsterInfo()
                        {
                            Camp = CampEnum.CampMonster1
                        });
                    }
                    return;
                }

                // 获得并生成所有宠物
                if (message.GMMsg == "#allPet")
                {
                    PetComponentS petComponent = unit.GetComponent<PetComponentS>();
                    foreach (PetConfig config in PetConfigCategory.Instance.GetAll().Values)
                    {
                        bool have = false;
                        foreach (RolePetInfo rolePetInfo in petComponent.RolePetInfos)
                        {
                            if (rolePetInfo.ConfigId == config.Id)
                            {
                                have = true;
                                break;
                            }
                        }

                        if (!have)
                        {
                            petComponent.OnAddPet(ItemGetWay.GM, config.Id);
                        }
                    }


                    foreach (RolePetInfo rolePetInfo in petComponent.RolePetInfos)
                    {
                        UnitFactory.CreatePet(unit, rolePetInfo);
                    }

                    return;
                }

                // 免伤
                if (message.GMMsg == "#mianshang")
                {
                    BuffData buffData_1 = new BuffData();
                    buffData_1.SkillId = 67000278;
                    buffData_1.BuffId = 90106002;
                    unit.GetComponent<BuffManagerComponentS>().BuffFactory(buffData_1, unit, null);
                    return;
                }
                
                // 无限生命值
                if (message.GMMsg == "#maxHp")
                {
                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.Base_MaxHp_Add, 999999999);
                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.Now_Hp, 999999999);
                    return;
                }
                
                switch (int.Parse(commands[0]))
                {
                    case 1: //新增道具1#12000003#200 【添加道具/道具id/道具数量】
                        int itemId = int.Parse(commands[1]);
                        int itemNumber = int.Parse(commands[2]);

                        List<RewardItem> rewardItems = new List<RewardItem>();
                        rewardItems.Add(new RewardItem() { ItemID = itemId, ItemNum = itemNumber });
                        unit.GetComponent<BagComponentS>()
                                 .OnAddItemData(rewardItems, string.Empty, $"{ItemGetWay.GM}_{TimeHelper.ServerNow()}", true, true);
                        break;
                    case 2:       //72009041死亡技能      //2#7#0.19#-25#310161#1 70001001 90000005-爆炸怪 72002013-脱战技能没移除2#-78#0#0.7#72004002#1  70001001  72009001
                        float posX = float.Parse(commands[1]);
                        float posY = float.Parse(commands[2]); 
                        float posZ = float.Parse(commands[3]);
                        int monsterId = int.Parse(commands[4]);
                        int number = int.Parse(commands[5]);
                        if (number > 100)
                        {
                            Log.Error("number > 100");
                            return;
                        }

                        for (int c = 0; c < number; c++)
                        {
                            await unit.Root().GetComponent<TimerComponent>().WaitAsync(1);
                            float3 vector3 = new float3(posX + RandomHelper.RandomNumberFloat(-1, 1), posY, posZ + RandomHelper.RandomNumberFloat(-1, 1));
                            Unit monster = UnitFactory.CreateMonster(unit.Scene(), monsterId, vector3, new CreateMonsterInfo()
                            { 
                                Camp = CampEnum.CampMonster1
                            });

                            //M2C_CreateSpilings createSpilings = new M2C_CreateSpilings();
                            //SpilingInfo spilingInfo = UnitHelper.CreateSpilingInfo(monster);
                            //createSpilings.Spilings.Add(spilingInfo);
                            //MessageHelper.Broadcast(unit, createSpilings);
                        }
                        break;
                    case 4: //直接接取某个任务      4#82000008
                        unit.GetComponent<TaskComponentS>().OnGMGetTask(int.Parse(commands[1]));
                        break;
                    case 5: //直接获得某个宠物      5#1000601
                        unit.GetComponent<PetComponentS>().OnAddPet(ItemGetWay.GM, int.Parse(commands[1]));
                        break;  
                    case 6:
                        int newLevel = int.Parse(commands[1]);
                        if (newLevel <= 70)
                        {
                            int level = newLevel - unit.GetComponent<UserInfoComponentS>().UserInfo.Lv;
                            unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.Lv, level.ToString());
                        }
                        break;
                    case 7:
						
						break;
					case 8:
						unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.Ling_DiLv, int.Parse(commands[1]), false);
						unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.Ling_DiExp, 0, false);
						break;
					case 9:
                        
						break;
					case 10:
                        Log.Warning("刷新机器人！！");
                        
                        break;
					case 11:
                        BuffData buffData_2 = new BuffData();
                        buffData_2.SkillId = 67000278;
                        buffData_2.BuffId = int.Parse(commands[1]); 
                        //unit.GetComponent<BuffComponentS>().BuffFactory(buffData_2, unit, null);
                        break;
					case 12:
						for (int i = 0; i < long.Parse(commands[1]); i++)
						{
                            buffData_2 = new BuffData();
                            buffData_2.SkillId = 67000278;
                            buffData_2.BuffId = int.Parse(commands[2]);
                            //unit.GetComponent<BuffComponentS>().BuffFactory(buffData_2, unit, null);
                        }
						break;
					case 13:
						List<EntityRef<Unit>> players = unit.GetParent<UnitComponent>().GetAll();
						for (int player = 0; player < players.Count; player++)
						{
                            for (int i = 0; i < long.Parse(commands[1]); i++)
                            {
                                buffData_2 = new BuffData();
                                buffData_2.SkillId = 67000278;
                                buffData_2.BuffId = int.Parse(commands[2]);
                                //players[player].GetComponent<BuffComponentS>()?.BuffFactory(buffData_2, unit, null);
                            }
                        }
						break;
                    case 15:
                        List<ItemInfoProto> itemList = new List<ItemInfoProto>();
                        ItemInfoProto BagInfo_1 = ItemInfoProto.Create();
                        BagInfo_1.ItemID = 1;
                        BagInfo_1.ItemNum = 100;
                        itemList.Add(BagInfo_1);
                        MailInfo mailInfo = MailInfo.Create();
                        mailInfo.Status = 0;
                        mailInfo.Title = "测试邮件";
                        mailInfo.MailId = IdGenerater.Instance.GenerateId();
                        mailInfo.ItemList.AddRange(itemList);
                        MailHelp.SendUserMail( unit.Root(), unit.Id, mailInfo, ItemGetWay.GM).Coroutine();
                        break;
                    case 16:  //16#0#200
                        int addtype = int.Parse(commands[1]);
                        int addpoint = int.Parse(commands[2]);
                        unit.GetComponent<PetComponentS>().OnPetQiangHua(addtype, addpoint);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.Debug(ex.ToString());
            }

            await ETTask.CompletedTask;
        }
    }
}