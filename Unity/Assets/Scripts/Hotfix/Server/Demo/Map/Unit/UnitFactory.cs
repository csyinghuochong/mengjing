using System;
using Unity.Mathematics;
using System.Collections.Generic;

namespace ET.Server
{
    
    [FriendOf(typeof(UserInfoComponentServer))]
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
                    if (unit.GetComponent<NumericComponentServer>() ==  null)
                    {
                        NumericComponentServer numericComponentServer = unit.AddComponent<NumericComponentServer>();
                        numericComponentServer.Set(NumericType.Speed, 6f); // 速度是6米每秒
                        numericComponentServer.Set(NumericType.AOI, 15000); // 视野15米
                    }

                    if (unit.GetComponent<UserInfoComponentServer>() == null)
                    {
                        
                        UserInfoComponentServer userInfoComponentServer = unit.AddComponent<UserInfoComponentServer>();
                        userInfoComponentServer.Account = account;
                        UserInfo userInfo = userInfoComponentServer.UserInfo;
                        userInfo.Sp = 1;
                        userInfo.UserId = id;
                        userInfo.BaoShiDu = 100;
                        userInfo.JiaYuanLv = 10001;
                        userInfo.JiaYuanFund = 10000;
                        userInfo.AccInfoID = accountId;
                        userInfo.Name = "";
                        userInfo.ServerMailIdCur = -1;
                        userInfo.PiLao = int.Parse(GlobalValueConfigCategory.Instance.Get(10).Value);        //初始化疲劳
                        userInfo.Vitality = int.Parse(GlobalValueConfigCategory.Instance.Get(10).Value);
                        userInfo.MakeList.AddRange(ComHelp.StringArrToIntList(GlobalValueConfigCategory.Instance.Get(18).Value.Split(';')));
                        userInfo.CreateTime = TimeHelper.ServerNow();
                        userInfo.RobotId = createRoleInfo.RobotId;

                        if (createRoleInfo.RobotId > 0)
                        {
                            int robotId = createRoleInfo.RobotId;
                            RobotConfig robotConfig = RobotConfigCategory.Instance.Get(robotId);
                            userInfo.Lv = robotConfig.Behaviour == 1 ?  RandomHelper.RandomNumber(10, 19) : robotConfig.Level;
                            userInfo.Occ = robotConfig.Behaviour == 1 ?  RandomHelper.RandomNumber(1, 3) : robotConfig.Occ;
                            userInfo.Gold = 100000;
                            userInfo.RobotId = robotId;
                            //userInfo.OccTwo = robotConfig.OccTwo;
                        }
                        else
                        {
                            userInfo.Lv = 1;
                            userInfo.Gold = 0;
                            userInfo.SeasonLevel = 1;
                            userInfo.Occ = createRoleInfo.PlayerOcc;
                            userInfo.Name = createRoleInfo.PlayerName;
                        }
                    }

                    if (unit.GetComponent<BagComponentServer>() == null)
                    {
                        unit.AddComponent<BagComponentServer>();
                    }
                    if (unit.GetComponent<TaskComponentServer>() == null)
                    {
                        unit.AddComponent<TaskComponentServer>();
                    }


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
             NumericComponentServer numericComponent = unit.AddComponent<NumericComponentServer>();
             HeroDataComponentServer heroDataComponent = unit.AddComponent<HeroDataComponentServer>();
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
                 revetime = mainUnit.GetComponent<UserInfoComponentServer>().GetReviveTime(monsterConfig.Id);
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
                 unit.AddComponent<SkillManagerComponent>();
                 unit.AddComponent<SkillPassiveComponent>();
                 unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
                 //添加其他组件
                 unit.AddComponent<StateComponentServer>();         //添加状态组件
                 unit.AddComponent<BuffManagerComponent>();      //添加Buff管理器
                 unit.GetComponent<SkillPassiveComponent>().UpdateMonsterPassiveSkill();
                 unit.GetComponent<SkillPassiveComponent>().Activeted();
                 numericComponent.Set(NumericType.MasterId, createMonsterInfo.MasterID);
                 AIComponent aIComponent = unit.AddComponent<AIComponent, int>(ai);
                 switch (mapComponent.SceneType)
                 {
                     case SceneTypeEnum.LocalDungeon:
                         aIComponent.LocalDungeonUnit = mainUnit;
                         aIComponent.LocalDungeonUnitPetComponent = mainUnit.GetComponent<PetComponentServer>();
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
                unit.AddComponent<StateComponentServer>();
                NumericComponentServer numericComponent = unit.AddComponent<NumericComponentServer>();
                numericComponent.Set(NumericType.Now_Speed, npcConfig.NpcPar[0]);
                unit.AddComponent<PathfindingComponent, string>(scene.GetComponent<MapComponent>().NavMeshId.ToString());
                unit.AddComponent<AIComponent, int>(npcConfig.AI);     //AI行为树序号	
                unit.GetComponent<AIComponent>().InitNpc(npcId);
                unit.GetComponent<AIComponent>().Begin();
            }

            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
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
                unit.AddComponent<StateComponentServer>();
                NumericComponentServer numericComponent = unit.AddComponent<NumericComponentServer>();
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