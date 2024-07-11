using System;
using System.Collections.Generic;
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
                    case 2:       //72009041死亡技能      //2#-58#0#-2#70005012#1 70001001 90000005-爆炸怪 72002013-脱战技能没移除2#-78#0#0.7#72004002#1  70001001  72009001
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
                            float3 vector3 = new float3(posX + RandomHelper.RandomNumberFloat(-2, 2), posY, RandomHelper.RandomNumberFloat(-2, 2));
                            Unit monster = UnitFactory.CreateMonster(unit.Root(), monsterId, vector3, new CreateMonsterInfo()
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
						unit.GetComponent<NumericComponentS>().SetNoEvent(NumericType.Ling_DiLv, int.Parse(commands[1]));
						unit.GetComponent<NumericComponentS>().SetNoEvent(NumericType.Ling_DiExp, 0);
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
                        List<BagInfo> itemList = new List<BagInfo>();
                        BagInfo BagInfo_1 = BagInfo.Create();
                        BagInfo_1.ItemID = 1;
                        BagInfo_1.ItemNum = 100;
                        itemList.Add(BagInfo_1);
                        MailInfo mailInfo = MailInfo.Create();
                        mailInfo.Status = 0;
                        mailInfo.Title = "测试邮件";
                        mailInfo.MailId = IdGenerater.Instance.GenerateId();
                        mailInfo.ItemList.AddRange(itemList);
                        MailHelp.SendUserMail( unit.Root(), unit.Id, mailInfo).Coroutine();
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