using System.Collections.Generic;

namespace ET.Server
{

    [EntitySystemOf(typeof(PetTianTiDungeonComponent))]
    [FriendOf(typeof(PetTianTiDungeonComponent))]
    public static partial class PetTianTiDungeonComponentSystem
    {
        [EntitySystem]
        private static void Awake(this PetTianTiDungeonComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this PetTianTiDungeonComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }
        

         public static  async ETTask GenerateFuben(this PetTianTiDungeonComponent self)
         {
             Unit unit = self.MainUnit;
             unit.GetComponent<StateComponentS>().StateTypeAdd(StateTypeEnum.WuDi);

             PetComponentS petComponent = self.MainUnit.GetComponent<PetComponentS>();
             petComponent.CheckSkin();
             for (int i = 0; i < petComponent.TeamPetList.Count; i++)
             {
                 RolePetInfo rolePetInfo = petComponent.GetPetInfo(petComponent.TeamPetList[i]);
                 if (rolePetInfo == null)
                 {
                     continue;
                 }
                 
                 Unit petunit = UnitFactory.CreateTianTiPet(unit.Scene(), unit.Id,
                    unit.GetBattleCamp(), rolePetInfo, ConfigData.Formation_1[i], 0f, i);
             }

             //先查找真实玩家。再查找
             PetComponentS petComponent_enemy =  await UnitCacheHelper.GetComponentCache<PetComponentS>(self.Root(), self.EnemyId);
             if (petComponent_enemy!= null)
             {
                 petComponent_enemy.CheckSkin();
                 for (int i = 0; i < petComponent_enemy.TeamPetList.Count; i++)
                 {
                     RolePetInfo rolePetInfo = petComponent_enemy.GetPetInfo(petComponent_enemy.TeamPetList[i]);
                     if (rolePetInfo == null)
                     {
                         continue;
                     }
                     if (unit.Root().GetComponent<UnitComponent>().Get(rolePetInfo.Id)!=null)
                     {
                         Log.Debug($"宠物ID重复：{unit.Id}");
                         continue;
                     }

                     BagComponentS bagComponent_enemy =  await UnitCacheHelper.GetComponentCache<BagComponentS>(self.Root(), self.EnemyId);
                     bagComponent_enemy.DeserializeDB();
                     NumericComponentS numericComponent_enemy =  await UnitCacheHelper.GetComponentCache<NumericComponentS>(self.Root(), self.EnemyId);
                     
                     petComponent_enemy.UpdatePetAttributeWithData(bagComponent_enemy, numericComponent_enemy, rolePetInfo, false);
                     Unit petunit = UnitFactory.CreateTianTiPet(unit.Scene(), 0,
                        CampEnum.CampPlayer_2, rolePetInfo, ConfigData.Formation_2[i], 180f, i);

                 }
             }
             else
             {
                 List<int> petlist = new List<int>() { 310101, 310101, 310101 };
                 for (int k = 0; k < petlist.Count; k++)
                 {
                     RolePetInfo petInfo = petComponent.GenerateNewPet(petlist[0], 0, 0, 1);
                     petComponent.PetXiLian(petInfo, 2, 0, 0 );
                     petComponent.UpdatePetAttribute(petInfo, false);
                     petInfo.PlayerName = "机器人";
                     Unit petunit = UnitFactory.CreateTianTiPet(unit.Scene(), 0,
                        CampEnum.CampPlayer_2,  petInfo, ConfigData.Formation_2[k], 180f, k);
                 }
             }
         }
         

         public static void OnKillEvent(this PetTianTiDungeonComponent self)
         {
             int result = self.GetCombatResult();
             if (result != CombatResultEnum.None)
             {
                 self.OnGameOver(result).Coroutine();
             }
         }

         public static async ETTask OnGameOver(this PetTianTiDungeonComponent self, int result)
         {
             List<EntityRef<Unit>> units = self.Root().GetComponent<UnitComponent>().GetAll();
             for (int i = 0; i < units.Count; i++)
             {
                 Unit unit = units[i];
                 AIComponent aIComponent = unit.GetComponent<AIComponent>();
                 aIComponent?.Stop();
             }

             int rankid = await self.NoticeRankServer(result);

             M2C_FubenSettlement m2C_FubenSettlement = M2C_FubenSettlement.Create();
             m2C_FubenSettlement.BattleResult = result;
             if (result == CombatResultEnum.Win)
             {
                 GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(68);
                 int dropId = int.Parse(globalValueConfig.Value);
                 List<RewardItem> rewardItems = new List<RewardItem>();
                 DropHelper.DropIDToDropItem(dropId, rewardItems);
                 DropHelper.zhenglirewardItems(rewardItems);
                 m2C_FubenSettlement.RewardList.AddRange(rewardItems);
                 m2C_FubenSettlement.StarInfos = new List<int> { 1, 1, 1 };

                 self.MainUnit.GetComponent<BagComponentS>().OnAddItemData(rewardItems, string.Empty, $"{ItemGetWay.PetTianTiReward}_{TimeHelper.ServerNow()}");
                 self.MainUnit.GetComponent<TaskComponentS>().TriggerTaskEvent( TaskTargetType.PetTianDiWin_37, 0, 1 );
             }
             else
             {
                 m2C_FubenSettlement.StarInfos = new List<int> { 0,0,0 };
             }
             if (rankid > 0)
             {
                 self.MainUnit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.PetTianTiRank_309, 0, rankid);
                 self.MainUnit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.PetTianTiRank_82, 0, rankid);
             }
             MapMessageHelper.SendToClient(self.MainUnit, m2C_FubenSettlement);
         }

             /// <summary>
             /// 失败不通知
             /// </summary>
             /// <param name="self"></param>
             /// <param name=""></param>
             /// <returns></returns>
             public static async ETTask<int> NoticeRankServer(this PetTianTiDungeonComponent self, int result)
             {
                 //获取传送map的 actorId
                 ActorId mapInstanceId = UnitCacheHelper.GetRankServerId(self.Zone());

                 Unit unit = self.MainUnit;
                 RankPetInfo rankPetInfo = RankPetInfo.Create();
                 UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
                 rankPetInfo.UserId = userInfoComponent.UserInfo.UserId;
                 rankPetInfo.PlayerName = userInfoComponent.UserInfo.Name;
                 rankPetInfo.PetUId = unit.GetComponent<PetComponentS>().TeamPetList;
                 rankPetInfo.TeamName = rankPetInfo.PlayerName;
                 for (int i = 0; i < rankPetInfo.PetUId.Count; i++ )
                 {
                     RolePetInfo rolePetInfo = unit.GetComponent<PetComponentS>().GetPetInfo(rankPetInfo.PetUId[i]);
                     rankPetInfo.PetConfigId.Add(rolePetInfo != null ? rolePetInfo.ConfigId : 0);
                     rankPetInfo.Combat += rolePetInfo != null ? rolePetInfo.PetPingFen : 0;
                 }

                 M2R_PetRankUpdateRequest M2R_PetRankUpdateRequest = M2R_PetRankUpdateRequest.Create();
                 M2R_PetRankUpdateRequest.RankPetInfo = rankPetInfo;
                 M2R_PetRankUpdateRequest.Win = result;
                 M2R_PetRankUpdateRequest.EnemyId = self.EnemyId;
                 R2M_PetRankUpdateResponse m2m_TrasferUnitResponse = (R2M_PetRankUpdateResponse)await self.Root().GetComponent<MessageSender>().Call
                          (mapInstanceId, M2R_PetRankUpdateRequest);

                 return m2m_TrasferUnitResponse.SelfRank;
             }
 
             /// <summary>
             /// 1 成功 2失败
             /// </summary>
             /// <param name="self"></param>
             /// <returns></returns>
             public static int GetCombatResult(this PetTianTiDungeonComponent self)
             {
                 int number_self = 0;
                 int number_enemy = 0;
                 List<EntityRef<Unit>> unitList = self.Scene().GetComponent<UnitComponent>().GetAll();
                 for(int i = 0; i < unitList.Count; i++)
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
                    
    }


}

