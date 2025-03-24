using System.Collections.Generic;

namespace ET.Server
{

    [EntitySystemOf(typeof(PetMingDungeonComponent))]
    [FriendOf(typeof(PetMingDungeonComponent))]
    public static partial class PetMingDungeonComponentSystem
    {
        [EntitySystem]
        private static void Awake(this PetMingDungeonComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this PetMingDungeonComponent self)
        {

        }
        
         public static async ETTask OnPetMingOccupy(this PetMingDungeonComponent self, Unit mainUnit)
         {
             
             if (self.CombatResultEnum == CombatResultEnum.Win && mainUnit != null)
             {
                 string logInfo = string.Empty;
                 string unitName = mainUnit.GetComponent<UserInfoComponentS>().GetName();
                 MineBattleConfig mineBattleConfig = MineBattleConfigCategory.Instance.Get(self.MineType);
                 logInfo = $"玩家 {unitName} 队伍{self.TeamId + 1} 占领了第{self.Position+1} {mineBattleConfig.Name}";
                 
                 ActorId chargeServerId = UnitCacheHelper.GetActivityServerId(self.Zone());
                 M2A_PetMingBattleWinRequest M2A_PetMingBattleWinRequest = M2A_PetMingBattleWinRequest.Create();
                 M2A_PetMingBattleWinRequest.MingType = self.MineType;
                 M2A_PetMingBattleWinRequest.Postion = self.Position;
                 M2A_PetMingBattleWinRequest.UnitID = mainUnit.Id;
                 M2A_PetMingBattleWinRequest.TeamId = self.TeamId;
                 M2A_PetMingBattleWinRequest.WinPlayer = unitName;
                 A2M_PetMingBattleWinResponse r_GameStatusResponse = (A2M_PetMingBattleWinResponse)await self.Root().GetComponent<MessageSender>().Call
                     (chargeServerId, M2A_PetMingBattleWinRequest);
             }
         }

         public static async ETTask OnGameOver(this PetMingDungeonComponent self, int result)
         {
             Unit mainUnit = UnitHelper.GetUnitList(self.Scene(), UnitType.Player)[0];
             self.CombatResultEnum = result;

             self.OnPetMingOccupy(mainUnit).Coroutine();
             long cdTime = result == CombatResultEnum.Win ? TimeHelper.Hour : TimeHelper.Minute * 10;
             if (CommonHelperS.IsInnerNet())
             {
                 cdTime = TimeHelper.Second * 10;
             }
             
             M2C_FubenSettlement m2C_FubenSettlement = M2C_FubenSettlement.Create();
             m2C_FubenSettlement.BattleResult = result;
             m2C_FubenSettlement.StarInfos = result == CombatResultEnum.Win ?  new List<int>() { 1, 1, 1 } : new List<int>() { 0,0,0};
             MapMessageHelper.SendToClient(mainUnit, m2C_FubenSettlement);
             mainUnit.GetComponent<NumericComponentS>().ApplyValue( NumericType.PetMineBattle,1, true  );
             mainUnit.GetComponent<NumericComponentS>().ApplyValue( NumericType.PetMineCDTime, TimeHelper.ServerNow() + cdTime, true);

             mainUnit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.MineBattleNumber_402, 0, 1);
             if (result == CombatResultEnum.Win)
             {
                 mainUnit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.MineWinNumber_403, 0, 1);
             }

             await ETTask.CompletedTask;
         }

         /// <summary>
         /// 1 成功 2失败
         /// </summary>
         /// <param name="self"></param>
         /// <returns></returns>
         public static int GetCombatResult(this PetMingDungeonComponent self)
         {
             int number_self = 0;
             int number_enemy = 0;
             List<EntityRef<Unit>> unitList = self.Scene().GetComponent<UnitComponent>().GetAll();
             for (int i = 0; i < unitList.Count; i++)
             {
                 Unit unit = unitList[i];
                 if (unit.Type != UnitType.Pet || !unit.IsCanBeAttack())
                 {
                     continue;
                 }
                 if (unit.GetBattleCamp() == CampEnum.CampPlayer_1)
                 {
                     number_self++;
                 }
                 else
                 {
                     number_enemy++;
                 }
             }
             if (number_self > 0 && number_enemy > 0)
                 return CombatResultEnum.None;
             if (number_self > 0 && number_enemy == 0)
                 return CombatResultEnum.Win;
             return CombatResultEnum.Fail;
         }


         public static void OnKillEvent(this PetMingDungeonComponent self)
         {
             int result = self.GetCombatResult();
             if (result != CombatResultEnum.None)
             {
                 self.OnGameOver(result).Coroutine();
             }
         }

             public static async ETTask GenerateFuben(this PetMingDungeonComponent self)
             {
                 ActorId chargeServerId = UnitCacheHelper.GetActivityServerId(self.Zone());
                 M2A_PetMingPlayerInfoRequest M2A_PetMingPlayerInfoRequest = M2A_PetMingPlayerInfoRequest.Create();
                 M2A_PetMingPlayerInfoRequest.MingType = self.MineType;
                 M2A_PetMingPlayerInfoRequest.Postion = self.Position;
                 A2M_PetMingPlayerInfoResponse r_GameStatusResponse = (A2M_PetMingPlayerInfoResponse)await self.Root().GetComponent<MessageSender>().Call
                     (chargeServerId, M2A_PetMingPlayerInfoRequest);

                 if (r_GameStatusResponse.Error != ErrorCode.ERR_Success)
                 {
                     return;
                 }

                 //己方队伍
                 Unit unit = UnitHelper.GetUnitList(self.Scene(), UnitType.Player)[0];
                 unit.GetComponent<StateComponentS>().StateTypeAdd(StateTypeEnum.WuDi);
                 PetComponentS petComponent = unit.GetComponent<PetComponentS>();
                 petComponent.CheckSkin();
                 List<long> pets = petComponent.PetMingList;
                 for (int i = 0; i <  5; i++)
                 {
                     long petinfoid = pets[i + self.TeamId * 5];
                     RolePetInfo rolePetInfo = petComponent.GetPetInfo(petinfoid);
                     if (rolePetInfo == null)
                     {
                         continue;
                     }

                     int position = petComponent.PetMingPosition.IndexOf(petinfoid);
                     position = position != -1 ? position %= 9 : i;   

                     Unit petunit = UnitFactory.CreateTianTiPet(unit.Scene(), unit.Id,
                         CampEnum.CampPlayer_1, rolePetInfo, ConfigData.Formation_1[ position ], 0f, position);
                     petunit.GetComponent<AIComponent>().Stop();
                 }

                 //敌方队伍
                 if (r_GameStatusResponse.PetMingPlayerInfo == null)
                 {
                     MineBattleConfig mineBattleConfig = MineBattleConfigCategory.Instance.Get(self.MineType);
                     int[] petdefendlist = mineBattleConfig.PetDefendInit;
                     //初始配置

                     for (int k = 0; k < petdefendlist.Length; k++)
                     {
                         if (petdefendlist[k] == 0)
                         {
                             continue;
                         }

                         RolePetInfo petInfo = petComponent.GenerateNewPet(petdefendlist[k], 0, 0, 1);
                         petComponent.PetXiLian(petInfo, 2, 0, 0 );
                         petComponent.UpdatePetAttribute(petInfo, false);
                         petInfo.PlayerName = "机器人";
                         Unit petunit = UnitFactory.CreateTianTiPet(unit.Scene(), 0,
                            CampEnum.CampPlayer_2, petInfo, ConfigData.Formation_2[k], 180f, k);
                         petunit.GetComponent<AIComponent>().Stop();

                         if (CommonHelperS.IsInnerNet())
                         {
                             break;
                         }
                     }
                 }
                 else
                 {
                     long enemyId = r_GameStatusResponse.PetMingPlayerInfo.UnitId;
                     int teamid = r_GameStatusResponse.PetMingPlayerInfo.TeamId;
                     

                     //self.EnemyId = enemyId;
                     PetComponentS petComponent_enemy = await UnitCacheHelper.GetComponentCache<PetComponentS>(self.Root(), enemyId);
                     if (petComponent_enemy != null)
                     {
                         BagComponentS bagComponentS = await UnitCacheHelper.GetComponentCache<BagComponentS>(self.Root(), enemyId);
                         bagComponentS.DeserializeDB();
                         NumericComponentS numericComponentS = await UnitCacheHelper.GetComponentCache<NumericComponentS>(self.Root(), enemyId);
                         
                         petComponent_enemy.CheckSkin();
                         List<long> petsenemy = petComponent_enemy.PetMingList;
                         for (int i = 0; i < 5; i++)
                         {
                             long petinfoid = petsenemy[i + teamid * 5];
                             RolePetInfo rolePetInfo = petComponent_enemy.GetPetInfo(petinfoid);
                             if (rolePetInfo == null)
                             {
                                 continue;
                             }
                             if (unit.GetParent<UnitComponent>().Get(rolePetInfo.Id) != null)
                             {
                                 Log.Debug($"宠物ID重复：{unit.Id}");
                                 continue;
                             }

                             int position = petComponent_enemy.PetMingPosition.IndexOf(petinfoid);
                             position = position != -1 ? position %= 9 : i;
                             petComponent_enemy.UpdatePetAttributeWithData( bagComponentS, numericComponentS, rolePetInfo, false);
                             Unit petunit = UnitFactory.CreateTianTiPet(unit.Scene(), 0,
                                CampEnum.CampPlayer_2, rolePetInfo, ConfigData.Formation_2[position], 180f,position);
                             petunit.GetComponent<AIComponent>().Stop();
                         }
                     }

                 }
             }
    }

}