using System;
using Unity.Mathematics;
using System.Collections.Generic;

namespace ET.Server
{
    public static partial class UnitFactory
    {
        public static async ETTask Create(Scene scene, Unit unit, long id, int unitType,CreateRoleInfo createRoleInfo, string account, long accountId)
        {
            //UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            switch (unitType)
            {
                case UnitType.Player:
                {
                    //Unit unit = unitComponent.AddChildWithId<Unit, int>(id, 1001);
                    unit.AddComponent<MoveComponent>();
                    unit.Position = new float3(-10, 0, -10);
                    unit.Type = UnitType.Player;
                    unit.ConfigId = createRoleInfo.PlayerOcc;
                    if (unit.GetComponent<UserInfoComponentS>() == null)
                    {
                        UserInfoComponentS userInfoComponentS = unit.AddComponent<UserInfoComponentS>();
                        userInfoComponentS.OnInit(account, id, accountId, createRoleInfo);
                    }

                    if (unit.GetComponent<NumericComponentS>() ==  null)
                    {
                        NumericComponentS numericComponentS = unit.AddComponent<NumericComponentS>();
                        numericComponentS.SetNoEvent(NumericType.Speed, 60000); // 速度是6米每秒
                        numericComponentS.SetNoEvent(NumericType.AOI, 15000); // 视野15米
                    }
                    unit.AddDataComponent<TaskComponentS>();
                    unit.AddDataComponent<ShoujiComponentS>();
                    unit.AddDataComponent<ChengJiuComponentS>();
                    unit.AddDataComponent<BagComponentS>();
                    unit.AddDataComponent<PetComponentS>();
                    unit.AddDataComponent<SkillSetComponentS>();
                    unit.AddDataComponent<RechargeComponent>();
                    unit.AddDataComponent<ReddotComponentS>();
                    unit.AddDataComponent<TitleComponentS>();
                    unit.AddDataComponent<JiaYuanComponentS>();
                    unit.AddDataComponent<DataCollationComponent>();
                    
                    unit.AddDataComponent<StateComponentS>();
                    unit.AddDataComponent<DBSaveComponent>();
                    unit.AddDataComponent<HeroDataComponentS>();
                    unit.AddDataComponent<SkillPassiveComponent>();
                    
                    DBComponent dbComponent = scene.Root().GetComponent<DBManagerComponent>().GetZoneDB(scene.Zone());
                    List<DBFriendInfo> dbFriendInfos = await dbComponent.Query<DBFriendInfo>( scene.Zone(), d=> d.Id == id);
                    if (dbFriendInfos == null || dbFriendInfos.Count == 0)
                    {
                        DBFriendInfo dbFriendInfo = unit.AddComponent<DBFriendInfo>();
                        await  dbComponent.Save(scene.Zone(), dbFriendInfo);
                        dbFriendInfo.Dispose();
                    }
                    
                    //unitComponent.Add(unit);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
                    return;
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
             NumericComponentS numericComponent = unit.AddComponent<NumericComponentS>();
             HeroDataComponentS heroDataComponent = unit.AddComponent<HeroDataComponentS>();
             UnitInfoComponent unitInfoComponent = unit.AddComponent<UnitInfoComponent>();
             unitInfoComponent.EnergySkillId = createMonsterInfo.SkillId;
             unitInfoComponent.UnitName = monsterConfig.MonsterName;
             unit.Type = UnitType.Monster;
             unit.Position = vector3;
             unit.ConfigId = monsterConfig.Id;
             unit.Rotation = quaternion.Euler(0, createMonsterInfo.Rotation, 0);
             numericComponent.SetNoEvent(NumericType.BattleCamp, createMonsterInfo.Camp);
             numericComponent.SetNoEvent(NumericType.TeamId, master != null ? master.GetTeamId() : 0);
             numericComponent.SetNoEvent(NumericType.AttackMode, master!=null ?  master.GetAttackMode() : 0);
             numericComponent.SetNoEvent(NumericType.UnionId_0, master != null ? master.GetUnionId() : 0);
             numericComponent.SetNoEvent(NumericType.PetSkin, createMonsterInfo.SkinId);
        
             unit.SetBornPosition(unit.Position, false);
             unit.MasterId = createMonsterInfo.MasterID;

             long revetime = 0;
             Unit mainUnit = null;
             if (mapComponent.SceneType == SceneTypeEnum.LocalDungeon)
             {
                 mainUnit = scene.GetComponent<LocalDungeonComponent>().MainUnit;
                 revetime = mainUnit.GetComponent<UserInfoComponentS>().GetReviveTime(monsterConfig.Id);
             }

             if (monsterConfig.DeathTime > 0)
             {
                 unit.AddComponent<DeathTimeComponent, long>(monsterConfig.DeathTime * 1000 - createMonsterInfo.BornTime);
             }

             if (mainUnit != null && TimeHelper.ServerNow() < revetime)
             {
                 unit.AddComponent<ReviveTimeComponent, long>(revetime);
                 numericComponent.SetNoEvent(NumericType.ReviveTime, revetime);
                 numericComponent.SetNoEvent(NumericType.Now_Dead, 1);
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
                 unit.AddComponent<SkillManagerComponentS>();
                 unit.AddComponent<SkillPassiveComponent>();
                 unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
                 //添加其他组件
                 unit.AddComponent<StateComponentS>();         //添加状态组件
                 unit.AddComponent<BuffManagerComponentS>();      //添加Buff管理器
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
            NumericComponentS numericComponent = unit.AddComponent<NumericComponentS>();
            if (npcConfig.AI > 0)
            {
                unit.AddComponent<MoveComponent>();
                unit.AddComponent<StateComponentS>();
                numericComponent.Set(NumericType.Now_Speed, npcConfig.NpcPar[0]);
                unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
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
               NumericComponentS numericComponent = unit.AddComponent<NumericComponentS>();
               UnitInfoComponent unitInfoComponent = unit.AddComponent<UnitInfoComponent>();
               unit.AddComponent<MoveComponent>();
               unit.AddComponent<SkillManagerComponentS>();
               unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
               unit.AddComponent<AttackRecordComponent>();
               unitInfoComponent.MasterName = petinfo.PlayerName;
               unitInfoComponent.UnitName = petinfo.PetName;
              
               unit.ConfigId = petinfo.ConfigId;
               unit.MasterId = master.Id;
               unit.AddComponent<StateComponentS>();         //添加状态组件
               unit.AddComponent<BuffManagerComponentS>();      //添加
               unit.Position = new float3(master.Position.x + RandomHelper.RandFloat01() * 1f, master.Position.y, master.Position.z + RandomHelper.RandFloat01() * 1f);
               unit.Type = UnitType.Pet;
               AIComponent aIComponent = unit.AddComponent<AIComponent, int>(2);     //AI行为树序号
               aIComponent.InitPet(petinfo);
               aIComponent.Begin();
               //添加其他组件
               unit.AddComponent<HeroDataComponentS>().InitPet(petinfo, false);
               numericComponent.SetEvent(NumericType.MasterId, master.Id, false);
               numericComponent.SetEvent(NumericType.BattleCamp, master.GetBattleCamp(), false);
               numericComponent.SetEvent(NumericType.AttackMode, master != null ? master.GetAttackMode() : 0, false);
               numericComponent.SetEvent(NumericType.TeamId, master.GetTeamId(), false); ;
               numericComponent.SetEvent(NumericType.UnionId_0, master.GetUnionId(), false);
               long max_hp = numericComponent.GetAsLong(NumericType.Now_MaxHp);
               numericComponent.SetNoEvent(NumericType.Now_Hp, max_hp);
               numericComponent.SetEvent(NumericType.Base_Speed_Base, master.GetComponent<NumericComponentS>().GetAsLong(NumericType.Base_Speed_Base), false); 

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
              NumericComponentS numericComponent = unit.AddComponent<NumericComponentS>();
              unit.AddComponent<MoveComponent>();
              UnitInfoComponent unitInfoComponent = unit.AddComponent<UnitInfoComponent>();
              unit.AddComponent<SkillManagerComponentS>();
              unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
              unit.AddComponent<AttackRecordComponent>();
              unit.ConfigId = petinfo.ConfigId;
              unit.MasterId = masterId;
              unitInfoComponent.UnitName = petinfo.PetName;
              unitInfoComponent.MasterName = petinfo.PlayerName;
              unit.AddComponent<StateComponentS>();         //添加状态组件
              unit.AddComponent<BuffManagerComponentS>();      //添加
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
              unit.AddComponent<HeroDataComponentS>().InitPet(petinfo, false);
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
    NumericComponentS numericComponent = unit.AddComponent<NumericComponentS>();
    UnitInfoComponent unitInfoComponent = unit.AddComponent<UnitInfoComponent>();
    unit.AddComponent<MoveComponent>();
    unit.AddComponent<SkillManagerComponentS>();
    unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
    unit.AddComponent<AttackRecordComponent>();
    unitInfoComponent.MasterName = master.GetComponent<UserInfoComponentS>().GetName();
    unitInfoComponent.UnitName = JingLingConfigCategory.Instance.Get(jinglingId).Name;
   
    unit.ConfigId = jinglingId;
    unit.MasterId = master.Id;
    unit.AddComponent<StateComponentS>();         //添加状态组件
    unit.AddComponent<BuffManagerComponentS>();      //添加
    unit.Position = new float3(master.Position.x + RandomHelper.RandFloat01() * 1f, master.Position.y, master.Position.z + RandomHelper.RandFloat01() * 1f);
    unit.Type = UnitType.JingLing;

    AIComponent aIComponent = unit.AddComponent<AIComponent, int>(10);     //AI行为树序号
    aIComponent.InitJingLing(jinglingId);
    aIComponent.Begin();

    //添加其他组件
    unit.AddComponent<HeroDataComponentS>().InitJingLing(master, jinglingId, false);
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
                unit.AddComponent<StateComponentS>();
                NumericComponentS numericComponent = unit.AddComponent<NumericComponentS>();
                numericComponent.Set(NumericType.Now_Speed, npcConfig.NpcPar[0]);
                unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
                unit.AddComponent<AIComponent, int>(npcConfig.AI);     //AI行为树序号	
                unit.GetComponent<AIComponent>().InitNpc(npcId);
                unit.GetComponent<AIComponent>().Begin();
            }

            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
            return unit;
        }
    }
}