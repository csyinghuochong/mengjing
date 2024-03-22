using System;
using Unity.Mathematics;
using System.Collections.Generic;

namespace ET.Server
{
    public static partial class UnitFactory
    {
        public static Unit Create(Scene scene, long id, int unitType,CreateRoleInfo createRoleInfo, string account, long accountId)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            switch (unitType)
            {
                case UnitType.Player:
                {
                    Unit unit = unitComponent.AddChildWithId<Unit, int>(id, 1001);
                    unit.AddComponent<MoveComponent>();
                    unit.Position = new float3(-10, 0, -10);
                    unit.Type = UnitType.Player;
                    
                    if (unit.GetComponent<UserInfoComponent_S>() == null)
                    {
                        UserInfoComponent_S userInfoComponentS = unit.AddComponent<UserInfoComponent_S>();
                        userInfoComponentS.OnInit(account, id, accountId, createRoleInfo);
                    }

                    if (unit.GetComponent<NumericComponent_S>() ==  null)
                    {
                        NumericComponent_S numericComponentS = unit.AddComponent<NumericComponent_S>();
                        numericComponentS.SetNoEvent(NumericType.Speed, 60000); // 速度是6米每秒
                        numericComponentS.SetNoEvent(NumericType.AOI, 15000); // 视野15米
                    }
                    unit.AddDataComponent<TaskComponent_S>();
                    unit.AddDataComponent<ShoujiComponent_S>();
                    unit.AddDataComponent<ChengJiuComponent_S>();
                    unit.AddDataComponent<BagComponent_S>();
                    unit.AddDataComponent<PetComponent_S>();
                    unit.AddDataComponent<SkillSetComponent_S>();
                    unit.AddDataComponent<RechargeComponent>();
                    unit.AddDataComponent<ReddotComponent_S>();
                    unit.AddDataComponent<TitleComponent_S>();
                    unit.AddDataComponent<JiaYuanComponent_S>();
                    unit.AddDataComponent<DataCollationComponent>();
                    
                    unit.AddDataComponent<StateComponent_S>();
                    unit.AddDataComponent<DBSaveComponent>();
                    unit.AddDataComponent<HeroDataComponent_S>();
                    unit.AddDataComponent<SkillPassiveComponent>();
                    
                    unitComponent.Add(unit);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
                    return unit;
                }
                default:
                    throw new Exception($"not such unit type: {unitType}");
            }
        }
        
        
         public static Unit CreateMonster(Scene scene, int monsterID, float3 vector3, CreateMonsterInfo createMonsterInfo)
         {
             int openDay = ServerHelper.GetOpenServerDay( false, scene.Zone()) ;
             monsterID = MonsterConfigCategory.Instance.GetNewMonsterId( openDay, monsterID );

             //精灵不能作为主人
             Unit master = scene.GetComponent<UnitComponent>().Get(createMonsterInfo.MasterID);
             if (master != null && master.Type == UnitType.JingLing)
             {
                 createMonsterInfo.MasterID = master.MasterId;
             }

             MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterID);
             MapComponent mapComponent = scene.GetComponent<MapComponent>();

             long unitid = createMonsterInfo.UnitId > 0 ? createMonsterInfo.UnitId : IdGenerater.Instance.GenerateId();
             Unit unit = scene.GetComponent<UnitComponent>().AddChildWithId<Unit, int>(unitid, 1001);
             //unit.AddComponent<AttackRecordComponent>();
             NumericComponent_S numericComponent = unit.AddComponent<NumericComponent_S>();
             HeroDataComponent_S heroDataComponent = unit.AddComponent<HeroDataComponent_S>();
             UnitInfoComponent unitInfoComponent = unit.AddComponent<UnitInfoComponent>();
             unitInfoComponent.EnergySkillId = createMonsterInfo.SkillId;
             unitInfoComponent.UnitName = monsterConfig.MonsterName;
             unit.Type = UnitType.Monster;
             unit.Position = vector3;
             unit.ConfigId = monsterConfig.Id;
             unit.Rotation = quaternion.Euler(0, createMonsterInfo.Rotation, 0);
             numericComponent.Set(NumericType.BattleCamp, createMonsterInfo.Camp);
             numericComponent.Set(NumericType.TeamId, master != null ? master.GetTeamId() : 0);
             numericComponent.Set(NumericType.AttackMode, master!=null ?  master.GetAttackMode() : 0);
             numericComponent.Set(NumericType.UnionId_0, master != null ? master.GetUnionId() : 0);
             numericComponent.Set(NumericType.PetSkin, createMonsterInfo.SkinId);
        
             unit.SetBornPosition(unit.Position, false);
             unit.MasterId = createMonsterInfo.MasterID;

             long revetime = 0;
             Unit mainUnit = null;
             if (mapComponent.SceneType == SceneTypeEnum.LocalDungeon)
             {
                 mainUnit = scene.GetComponent<LocalDungeonComponent>().MainUnit;
                 revetime = mainUnit.GetComponent<UserInfoComponent_S>().GetReviveTime(monsterConfig.Id);
             }

             if (monsterConfig.DeathTime > 0)
             {
                 unit.AddComponent<DeathTimeComponent, long>(monsterConfig.DeathTime * 1000 - createMonsterInfo.BornTime);
             }

             if (mainUnit != null && TimeHelper.ServerNow() < revetime)
             {
                 unit.AddComponent<ReviveTimeComponent, long>(revetime);
                 numericComponent.SetEvent(NumericType.ReviveTime, revetime, false);
                 numericComponent.SetEvent(NumericType.Now_Dead, 1, false);
             }
             //51 场景怪
             //52 能量台子
             //53 传送门
             //54 场景怪 显示名称
             //55 宝箱
             if (monsterConfig.AI != 0)
             {
                 if (createMonsterInfo.MasterID > 0 && !string.IsNullOrEmpty(createMonsterInfo.AttributeParams))
                 {
                     heroDataComponent.InitMonsterInfo_Summon2(monsterConfig, createMonsterInfo);
                 }
                 else
                 {
                     heroDataComponent.InitMonsterInfo(monsterConfig, createMonsterInfo);
                 }
             }

             if (monsterConfig.AI != 0)
             {
                 int ai = createMonsterInfo.AI > 0 ? createMonsterInfo.AI : monsterConfig.AI;
                 unit.AI = ai;
                 unit.AddComponent<ObjectWait>();
                 unit.AddComponent<MoveComponent>();
                 unit.AddComponent<SkillManagerComponent_S>();
                 unit.AddComponent<SkillPassiveComponent>();
                 unit.AddComponent<PathfindingComponent, string>(scene.GetComponent<MapComponent>().NavMeshId.ToString());
                 //添加其他组件
                 unit.AddComponent<StateComponent_S>();         //添加状态组件
                 unit.AddComponent<BuffComponent_S>();      //添加Buff管理器
                 unit.GetComponent<SkillPassiveComponent>().UpdateMonsterPassiveSkill();
                 unit.GetComponent<SkillPassiveComponent>().Activeted();
                 numericComponent.Set(NumericType.MasterId, createMonsterInfo.MasterID);
                 AIComponent aIComponent = unit.AddComponent<AIComponent, int>(ai);
                 switch (mapComponent.SceneType)
                 {
                     case SceneTypeEnum.LocalDungeon:
                         aIComponent.LocalDungeonUnit = mainUnit;
                         //aIComponent.LocalDungeonUnitPetComponent = mainUnit.GetComponent<PetComponentServer>();
                         aIComponent.InitMonster(monsterConfig.Id);
                         break;
                     case SceneTypeEnum.PetDungeon:
                         aIComponent.InitPetFubenMonster(monsterConfig.Id);
                         break;
                     default:
                         aIComponent.InitMonster(monsterConfig.Id);
                         aIComponent.Begin();
                         break;
                 }
             }
             scene.GetComponent<UnitComponent>().Add(unit);
             unit.AddComponent<AOIEntity, int, float3>(5 * 1000, unit.Position);
             return unit;
         }

        
        public static Unit CreateNpc(Scene scene, int npcId)
        {
            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(npcId);

            Unit unit = scene.GetComponent<UnitComponent>().AddChildWithId<Unit, int>(IdGenerater.Instance.GenerateId(), npcId);
            scene.GetComponent<UnitComponent>().Add(unit);

            unit.AddComponent<UnitInfoComponent>();
            unit.ConfigId = npcId;
            unit.Position = new float3(npcConfig.Position[0] * 0.01f, npcConfig.Position[1] * 0.01f, npcConfig.Position[2] * 0.01f);
            unit.Rotation = quaternion.Euler(0, npcConfig.Rotation, 0);
            unit.Type = UnitType.Npc;
            if (npcConfig.AI > 0)
            {
                unit.AddComponent<MoveComponent>();
                unit.AddComponent<StateComponent_S>();
                NumericComponent_S numericComponent = unit.AddComponent<NumericComponent_S>();
                numericComponent.Set(NumericType.Now_Speed, npcConfig.NpcPar[0]);
                unit.AddComponent<PathfindingComponent, string>(scene.GetComponent<MapComponent>().NavMeshId.ToString());
                unit.AddComponent<AIComponent, int>(npcConfig.AI);     //AI行为树序号	
                unit.GetComponent<AIComponent>().InitNpc(npcId);
                unit.GetComponent<AIComponent>().Begin();
            }

            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
            return unit;
        }
        
           public static Unit CreatePet(Unit master, RolePetInfo petinfo)
           {
               Scene scene = master.Root();
               Unit unit = scene.GetComponent<UnitComponent>().AddChildWithId<Unit, int>(petinfo.Id, 1);
               scene.GetComponent<UnitComponent>().Add(unit);
               unit.AddComponent<ObjectWait>();
               NumericComponent_S numericComponent = unit.AddComponent<NumericComponent_S>();
               UnitInfoComponent unitInfoComponent = unit.AddComponent<UnitInfoComponent>();
               unit.AddComponent<MoveComponent>();
               unit.AddComponent<SkillManagerComponent_S>();
               unit.AddComponent<PathfindingComponent, string>(scene.GetComponent<MapComponent>().NavMeshId.ToString());
               unit.AddComponent<AttackRecordComponent>();
               unitInfoComponent.MasterName = petinfo.PlayerName;
               unitInfoComponent.UnitName = petinfo.PetName;
              
               unit.ConfigId = petinfo.ConfigId;
               unit.MasterId = master.Id;
               unit.AddComponent<StateComponent_S>();         //添加状态组件
               unit.AddComponent<BuffComponent_S>();      //添加
               unit.Position = new float3(master.Position.x + RandomHelper.RandFloat01() * 1f, master.Position.y, master.Position.z + RandomHelper.RandFloat01() * 1f);
               unit.Type = UnitType.Pet;
               AIComponent aIComponent = unit.AddComponent<AIComponent, int>(2);     //AI行为树序号
               aIComponent.InitPet(petinfo);
               aIComponent.Begin();
               //添加其他组件
               unit.AddComponent<HeroDataComponent_S>().InitPet(petinfo, false);
               numericComponent.SetEvent(NumericType.MasterId, master.Id, false);
               numericComponent.SetEvent(NumericType.BattleCamp, master.GetBattleCamp(), false);
               numericComponent.SetEvent(NumericType.AttackMode, master != null ? master.GetAttackMode() : 0, false);
               numericComponent.SetEvent(NumericType.TeamId, master.GetTeamId(), false); ;
               numericComponent.SetEvent(NumericType.UnionId_0, master.GetUnionId(), false);
               long max_hp = numericComponent.GetAsLong(NumericType.Now_MaxHp);
               numericComponent.SetNoEvent(NumericType.Now_Hp, max_hp);
               numericComponent.SetEvent(NumericType.Base_Speed_Base, master.GetComponent<NumericComponent_S>().GetAsLong(NumericType.Base_Speed_Base), false); 

               unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
               if (scene.GetComponent<MapComponent>().SceneType != (int)SceneTypeEnum.MainCityScene)
               {
                   unit.AddComponent<SkillPassiveComponent>().UpdatePetPassiveSkill(petinfo);
                   unit.GetComponent<SkillPassiveComponent>().Activeted();
               }

               return unit;
           }
        
          public static Unit CreateTianTiPet(Scene scene,  long masterId, int roleCamp, RolePetInfo petinfo, float3 postion, float rotation, int cell)
          {
              Unit unit = scene.GetComponent<UnitComponent>().AddChildWithId<Unit, int>(petinfo.Id, 1);
              scene.GetComponent<UnitComponent>().Add(unit);
              unit.AddComponent<ObjectWait>();
              NumericComponent_S numericComponent = unit.AddComponent<NumericComponent_S>();
              unit.AddComponent<MoveComponent>();
              UnitInfoComponent unitInfoComponent = unit.AddComponent<UnitInfoComponent>();
              unit.AddComponent<SkillManagerComponent_S>();
              unit.AddComponent<PathfindingComponent, string>(scene.GetComponent<MapComponent>().NavMeshId.ToString());
              unit.AddComponent<AttackRecordComponent>();
              unit.ConfigId = petinfo.ConfigId;
              unit.MasterId = masterId;
              unitInfoComponent.UnitName = petinfo.PetName;
              unitInfoComponent.MasterName = petinfo.PlayerName;
              unit.AddComponent<StateComponent_S>();         //添加状态组件
              unit.AddComponent<BuffComponent_S>();      //添加
              unit.Position = postion;
              unit.Type = UnitType.Pet;
              unit.Rotation = quaternion.Euler(0f, rotation, 0f);
              AIComponent aIComponent = unit.AddComponent<AIComponent, int>(1);     //AI行为树序号
              MapComponent mapComponent = scene.GetComponent<MapComponent>();
              switch (mapComponent.SceneType)
              {
                  case (int)SceneTypeEnum.PetDungeon:
                  case (int)SceneTypeEnum.PetTianTi:
                  case (int)SceneTypeEnum.PetMing:
                      aIComponent.InitTianTiPet(petinfo.ConfigId);
                      break;
                  default:
                      aIComponent.InitPet(petinfo);
                      break;
              }

              //添加其他组件
              unit.AddComponent<HeroDataComponent_S>().InitPet(petinfo, false);
              numericComponent.Set(NumericType.BattleCamp, roleCamp);
              numericComponent.Set(NumericType.MasterId, masterId);
              numericComponent.Set(NumericType.UnitPositon, cell);
              long max_hp = numericComponent.GetAsLong(NumericType.Now_MaxHp);
              numericComponent.SetNoEvent( NumericType.Now_Hp  ,max_hp);
              unit.AddComponent<AOIEntity, int, float3>(1 * 1000, unit.Position);
              unit.AddComponent<SkillPassiveComponent>().UpdatePetPassiveSkill(petinfo);
              unit.GetComponent<SkillPassiveComponent>().Activeted();
              return unit;
          }
        
          
          public static Unit CreateJingLing( Unit master, int jinglingId)
{
    Scene scene = master.Root();
    Unit unit = scene.GetComponent<UnitComponent>().AddChildWithId<Unit, int>(IdGenerater.Instance.GenerateId(), jinglingId);
    scene.GetComponent<UnitComponent>().Add(unit);
    unit.AddComponent<ObjectWait>();
    NumericComponent_S numericComponent = unit.AddComponent<NumericComponent_S>();
    UnitInfoComponent unitInfoComponent = unit.AddComponent<UnitInfoComponent>();
    unit.AddComponent<MoveComponent>();
    unit.AddComponent<SkillManagerComponent_S>();
    unit.AddComponent<PathfindingComponent, string>(scene.GetComponent<MapComponent>().NavMeshId.ToString());
    unit.AddComponent<AttackRecordComponent>();
    unitInfoComponent.MasterName = master.GetComponent<UserInfoComponent_S>().GetName();
    unitInfoComponent.UnitName = JingLingConfigCategory.Instance.Get(jinglingId).Name;
   
    unit.ConfigId = jinglingId;
    unit.MasterId = master.Id;
    unit.AddComponent<StateComponent_S>();         //添加状态组件
    unit.AddComponent<BuffComponent_S>();      //添加
    unit.Position = new float3(master.Position.x + RandomHelper.RandFloat01() * 1f, master.Position.y, master.Position.z + RandomHelper.RandFloat01() * 1f);
    unit.Type = UnitType.JingLing;

    AIComponent aIComponent = unit.AddComponent<AIComponent, int>(10);     //AI行为树序号
    aIComponent.InitJingLing(jinglingId);
    aIComponent.Begin();

    //添加其他组件
    unit.AddComponent<HeroDataComponent_S>().InitJingLing(master, jinglingId, false);
    numericComponent.SetEvent(NumericType.MasterId, master.Id, false);
    numericComponent.SetEvent(NumericType.BattleCamp, master.GetBattleCamp(), false);
    numericComponent.SetEvent(NumericType.AttackMode, master != null ? master.GetAttackMode() : 0, false);
    numericComponent.SetEvent(NumericType.TeamId, master.GetTeamId(), false);
    numericComponent.SetEvent(NumericType.UnionId_0, master.GetUnionId(), false);
    //numericComponent.Set(NumericType.Base_Speed_Base, 50000, false);

    unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
    unit.AddComponent<SkillPassiveComponent>().UpdateJingLingSkill(jinglingId);
    unit.GetComponent<SkillPassiveComponent>().Activeted();
    return unit;
}
          
        public static Unit CreateNpcByPosition(Scene scene, int npcId, float3 vector3)
        {
            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(npcId);

            Unit unit = scene.GetComponent<UnitComponent>().AddChildWithId<Unit, int>(IdGenerater.Instance.GenerateId(), npcId);
            scene.GetComponent<UnitComponent>().Add(unit);

            unit.AddComponent<UnitInfoComponent>();
            unit.ConfigId = npcId;
            unit.Position = vector3;
            unit.Rotation = quaternion.LookRotation(npcConfig.Rotation, math.up());
            unit.Type = UnitType.Npc;
            if (npcConfig.AI > 0)
            {
                unit.AddComponent<MoveComponent>();
                unit.AddComponent<StateComponent_S>();
                NumericComponent_S numericComponent = unit.AddComponent<NumericComponent_S>();
                numericComponent.Set(NumericType.Now_Speed, npcConfig.NpcPar[0]);
                unit.AddComponent<PathfindingComponent, string>(scene.GetComponent<MapComponent>().NavMeshId.ToString());
                unit.AddComponent<AIComponent, int>(npcConfig.AI);     //AI行为树序号	
                unit.GetComponent<AIComponent>().InitNpc(npcId);
                unit.GetComponent<AIComponent>().Begin();
            }

            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
            return unit;
        }
    }
}