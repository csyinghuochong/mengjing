using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    public static partial class UnitFactory
    {
        public static async ETTask<Unit> LoadUnit(Player player, Scene scene, CreateRoleInfo createRoleInfo, string account, long accountId)
        {
            Unit unit = await UnitCacheHelper.GetUnitCache(scene, player.UnitId);

            bool isNewUnit = unit == null;

            // if (isNewUnit)
            // {
            //     unit = await UnitFactory.Create(scene, player.UnitId, UnitType.Player,createRoleInfo,account, accountId);
            //
            //     UnitCacheHelper.AddOrUpdateUnitAllCache(unit);
            // }

            await Create(scene, unit, player.UnitId, UnitType.Player, createRoleInfo, account, accountId);

            //UnitCacheHelper.AddOrUpdateUnitAllCache(unit);

            return unit;
        }

        public static async ETTask Create(Scene scene, Unit unit, long id, int unitType, CreateRoleInfo createRoleInfo, string account,
        long accountId)
        {
            //UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            switch (unitType)
            {
                case UnitType.Player:
                {
                    //Unit unit = unitComponent.AddChildWithId<Unit, int>(id, 1001);
                    unit.AddComponent<MoveComponent>();
                    unit.AddComponent<UnitInfoComponent>();
                    unit.Position = new float3(-10, 0, -10);
                    unit.Type = UnitType.Player;
                    unit.ConfigId = createRoleInfo.PlayerOcc;
                    if (unit.GetComponent<UserInfoComponentS>() == null)
                    {
                        UserInfoComponentS userInfoComponentS = unit.AddComponent<UserInfoComponentS>();
                        userInfoComponentS.OnInit(account, id, accountId, createRoleInfo);
                    }

                    if (unit.GetComponent<NumericComponentS>() == null)
                    {
                        NumericComponentS numericComponentS = unit.AddComponent<NumericComponentS>();
                        numericComponentS.ApplyValue(NumericType.Now_Speed, 60000, false); // 速度是6米每秒
                        numericComponentS.ApplyValue(NumericType.AOI, 15000, false); // 视野15米
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
                    unit.AddDataComponent<ActivityComponentS>();
                    unit.AddDataComponent<StateComponentS>();
                    unit.AddDataComponent<DBSaveComponent>();
                    unit.AddDataComponent<EnergyComponentS>();
                    unit.AddDataComponent<HeroDataComponentS>();
                    unit.AddDataComponent<SkillPassiveComponent>();

                    DBComponent dbComponent = scene.Root().GetComponent<DBManagerComponent>().GetZoneDB(scene.Zone());
                    List<DBFriendInfo> dbFriendInfos = await dbComponent.Query<DBFriendInfo>(scene.Zone(), d => d.Id == id);
                    if (dbFriendInfos == null || dbFriendInfos.Count == 0)
                    {
                        DBFriendInfo dbFriendInfo = scene.AddChildWithId<DBFriendInfo>(id);
                        await dbComponent.Save(scene.Zone(), dbFriendInfo);
                        dbFriendInfo.Dispose();
                    }

                    List<DBMailInfo> dbMailInfos = await dbComponent.Query<DBMailInfo>(scene.Zone(), d => d.Id == id);
                    if (dbMailInfos == null || dbMailInfos.Count == 0)
                    {
                        DBMailInfo dbMailInfo = scene.AddChildWithId<DBMailInfo>(id);
                        await dbComponent.Save(scene.Zone(), dbMailInfo);
                        dbMailInfo.Dispose();
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
            int openDay = ServerHelper.GetServeOpenDay(scene.Zone());
            monsterID = MonsterConfigCategory.Instance.GetNewMonsterId(openDay, monsterID);

            //精灵不能作为主人
            Unit master = scene.GetComponent<UnitComponent>().Get(createMonsterInfo.MasterID);
            if (master != null && master.Type == UnitType.JingLing)
            {
                createMonsterInfo.MasterID = master.GetMasterId();
            }
           
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterID);
            
            int SkinId = createMonsterInfo.SkinId;
            if (monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_58 && SkinId ==0) //奇遇宠物
            {
                int itemid = monsterConfig.Parameter[1];

                if (!ItemConfigCategory.Instance.Contain(itemid))
                {
                    Console.WriteLine($" itemid==null {itemid}");
                }

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemid);
                int petId = int.Parse(itemConfig.ItemUsePar);

                if (!PetConfigCategory.Instance.Contain(petId))
                {
                    Console.WriteLine($" petId==null {petId}");
                }
                PetConfig petConfig = PetConfigCategory.Instance.Get(petId);

                List<int> weight = new List<int>(petConfig.SkinPro);
                int index = RandomHelper.RandomByWeight(weight);
                SkinId = petConfig.Skin[index];
            }

            
            
            MapComponent mapComponent = scene.GetComponent<MapComponent>();

            long unitid = createMonsterInfo.UnitId > 0 ? createMonsterInfo.UnitId : IdGenerater.Instance.GenerateId();
            Unit unit = scene.GetComponent<UnitComponent>().AddChildWithId<Unit, int>(unitid, 1001);
            unit.AddComponent<AttackRecordComponent>();
            NumericComponentS numericComponent = unit.AddComponent<NumericComponentS>();
            HeroDataComponentS heroDataComponent = unit.AddComponent<HeroDataComponentS>();
            UnitInfoComponent unitInfoComponent = unit.AddComponent<UnitInfoComponent>();
            unitInfoComponent.UnitName = monsterConfig.MonsterName;
            unit.Type = UnitType.Monster;
            unit.Position = vector3;
            unit.ConfigId = monsterConfig.Id;
            unit.Rotation = quaternion.Euler(0, math.radians(createMonsterInfo.Rotation), 0);
            numericComponent.ApplyValue(NumericType.BattleCamp, createMonsterInfo.Camp, false);
            numericComponent.ApplyValue(NumericType.TeamId, master != null ? master.GetTeamId() : 0, false);
            numericComponent.ApplyValue(NumericType.AttackMode, master != null ? master.GetAttackMode() : 0, false);
            numericComponent.ApplyValue(NumericType.UnionId_0, master != null ? master.GetUnionId() : 0, false);
            numericComponent.ApplyValue(NumericType.PetSkin, SkinId, false);
            numericComponent.ApplyValue(NumericType.EnergySkillId, createMonsterInfo.SkillId, false);
            numericComponent.ApplyValue(NumericType.BaByType, createMonsterInfo.BaByType, false);
            unit.SetBornPosition(unit.Position, false);

            long revetime = 0;
            Unit mainUnit = null;
            if (mapComponent.MapType == MapTypeEnum.LocalDungeon)
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
                numericComponent.ApplyValue(NumericType.ReviveTime, revetime, false);
                numericComponent.ApplyValue(NumericType.Now_Dead, 1, false);
            }
            
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
            // 暂时这样，后面可能会给基地加AI
            if (monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_62)
            {
                heroDataComponent.InitMonsterInfo(monsterConfig, createMonsterInfo);
            }

            unit.AddComponent<MoveComponent>();
            unit.AddComponent<StateComponentS>(); //添加状态组件
            unit.AddComponent<SkillManagerComponentS>();
            unit.AddComponent<SkillPassiveComponent>();
            unit.AddComponent<BuffManagerComponentS>();
            if (monsterConfig.AI != 0)
            {
                int ai = createMonsterInfo.AI > 0 ? createMonsterInfo.AI : monsterConfig.AI;
                unit.AI = ai;
                unit.AddComponent<ObjectWait>();
                SkillPassiveComponent skillPassiveComponent = unit.GetComponent<SkillPassiveComponent>();
                unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);

                skillPassiveComponent.UpdateMonsterPassiveSkill();
                numericComponent.ApplyValue(NumericType.MasterId, createMonsterInfo.MasterID, false);
                AIComponent aIComponent = unit.AddComponent<AIComponent, int>(ai);
                switch (mapComponent.MapType)
                {
                    case MapTypeEnum.LocalDungeon:
                        aIComponent.InitMonster(monsterConfig.Id);
                        aIComponent.Begin();
                        skillPassiveComponent.Begin();
                        break;
                    case MapTypeEnum.PetDungeon:
                        aIComponent.InitPetFubenMonster(monsterConfig.Id);
                        break;
                    default:
                        aIComponent.InitMonster(monsterConfig.Id);
                        aIComponent.Begin();
                        skillPassiveComponent.Begin();
                        break;
                }
            }

            scene.GetComponent<UnitComponent>().Add(unit);
            unit.AddComponent<AOIEntity, int, float3>(5 * 1000, unit.Position);
            return unit;
        }

        //创建一个子弹unit
        public static Unit CreateBullet(Scene scene, long masterid, int skillid, int starangle, float3 vector3, CreateMonsterInfo createMonsterInfo)
        {
            Unit unit = scene.GetComponent<UnitComponent>().AddChildWithId<Unit, int>(IdGenerater.Instance.GenerateId(), skillid); //创建一个Unit
            scene.GetComponent<UnitComponent>().Add(unit);
            unit.AddComponent<ObjectWait>();

            unit.AddComponent<MoveComponent>();
            unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
            unit.AddComponent<UnitInfoComponent>();
            NumericComponentS numericComponent = unit.AddComponent<NumericComponentS>();
            unit.ConfigId = skillid;
            unit.Position = vector3;
            unit.Type = UnitType.Bullet; //子弹Unity,根据这个类型会实例化出特效
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillid);
            numericComponent.ApplyValue(NumericType.Base_Speed_Base, skillConfig.SkillMoveSpeed, false);
            numericComponent.ApplyValue(NumericType.MasterId, masterid, false);
            numericComponent.ApplyValue(NumericType.StartAngle, starangle, false);
            numericComponent.ApplyValue(NumericType.StartTime, TimeHelper.ServerNow(), false);
            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position); //添加视野
            return unit;
        }

        public static Unit CreateNpc(Scene scene, int npcId)
        {
            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(npcId);
            if (npcConfig.Position == null || npcConfig.Position.Length != 3)
            {
                Log.Console($"npcConfig.Position.Length != 3:  {npcId}");
                return null;
            }

            Unit unit = scene.GetComponent<UnitComponent>().AddChildWithId<Unit, int>(IdGenerater.Instance.GenerateId(), npcId);
            scene.GetComponent<UnitComponent>().Add(unit);

            unit.AddComponent<UnitInfoComponent>();
            unit.ConfigId = npcId;
            unit.Position = new float3(npcConfig.Position[0] * 0.01f, npcConfig.Position[1] * 0.01f, npcConfig.Position[2] * 0.01f);
            unit.Rotation = quaternion.Euler(0, math.radians(npcConfig.Rotation), 0);
            unit.Type = UnitType.Npc;
            NumericComponentS numericComponent = unit.AddComponent<NumericComponentS>();
            if (npcConfig.AI > 0)
            {
                unit.AddComponent<MoveComponent>();
                unit.AddComponent<StateComponentS>();
                numericComponent.ApplyValue(NumericType.Now_Speed, npcConfig.NpcPar[0], false);
                unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
                unit.AddComponent<AIComponent, int>(npcConfig.AI); //AI行为树序号	
                unit.GetComponent<AIComponent>().InitNpc(npcId);
                unit.GetComponent<AIComponent>().Begin();
            }

            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
            return unit;
        }

           public static Unit CreateJingLing(Unit master, int jinglingId)
        {
            Scene scene = master.Scene();
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
            unit.AddComponent<StateComponentS>(); //添加状态组件
            unit.AddComponent<BuffManagerComponentS>(); //添加
            unit.Position = new float3(master.Position.x + RandomHelper.RandFloat01() * 1f, master.Position.y,
                master.Position.z + RandomHelper.RandFloat01() * 1f);
            unit.Type = UnitType.JingLing;

            AIComponent aIComponent = unit.AddComponent<AIComponent, int>(10); //AI行为树序号
            aIComponent.InitJingLing(jinglingId);
            aIComponent.Begin();
            
            //添加其他组件
            unit.AddComponent<HeroDataComponentS>().InitJingLing(master, jinglingId, false);
            numericComponent.ApplyValue(NumericType.MasterId, master.Id, false);
            numericComponent.ApplyValue(NumericType.BattleCamp, master.GetBattleCamp(), false);
            numericComponent.ApplyValue(NumericType.AttackMode, master != null ? master.GetAttackMode() : 0, false);
            numericComponent.ApplyValue(NumericType.TeamId, master.GetTeamId(), false);
            numericComponent.ApplyValue(NumericType.UnionId_0, master.GetUnionId(), false);
            numericComponent.ApplyValue(NumericType.Base_Speed_Base, master.GetComponent<NumericComponentS>().GetAsLong(NumericType.Base_Speed_Base), false);


            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
            unit.AddComponent<SkillPassiveComponent>().UpdateJingLingSkill(jinglingId);
            unit.GetComponent<SkillPassiveComponent>().Begin();
            return unit;
        }
        
        public static Unit CreatePet(Unit master, RolePetInfo petinfo)
        {
            Scene scene = master.Scene();
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
            unit.AddComponent<StateComponentS>(); //添加状态组件
            unit.AddComponent<BuffManagerComponentS>(); //添加
            unit.Position = new float3(master.Position.x + RandomHelper.RandFloat01() * 1f, master.Position.y,
                master.Position.z + RandomHelper.RandFloat01() * 1f);
            unit.Type = UnitType.Pet;
            AIComponent aIComponent = unit.AddComponent<AIComponent, int>(2); //AI行为树序号
            aIComponent.TargetID = 0;
            aIComponent.InitPet(petinfo);
            aIComponent.Begin();
            //添加其他组件
            unit.AddComponent<HeroDataComponentS>().InitPet(petinfo, false);
            numericComponent.ApplyValue(NumericType.MasterId, master.Id, false);
            numericComponent.ApplyValue(NumericType.BattleCamp, master.GetBattleCamp(), false);
            numericComponent.ApplyValue(NumericType.AttackMode, master != null ? master.GetAttackMode() : 0, false);
            numericComponent.ApplyValue(NumericType.TeamId, master.GetTeamId(), false);
            
            numericComponent.ApplyValue(NumericType.UnionId_0, master.GetUnionId(), false);
            long max_hp = numericComponent.GetAsLong(NumericType.Now_MaxHp);
            numericComponent.ApplyValue(NumericType.Now_Hp, max_hp, false);
            numericComponent.ApplyValue(NumericType.Base_Speed_Base, master.GetComponent<NumericComponentS>().GetAsLong(NumericType.Base_Speed_Base), false);

            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
            if (scene.GetComponent<MapComponent>().MapType != (int)MapTypeEnum.MainCityScene)
            {
                unit.AddComponent<SkillPassiveComponent>().UpdatePetPassiveSkill(petinfo);
                unit.GetComponent<SkillPassiveComponent>().Begin();
            }

            return unit;
        }

        public static Unit CreatePasture(Scene scene, JiaYuanPastures jiaYuanPastures, long unitid)
        {
            Unit unit = scene.GetComponent<UnitComponent>().AddChildWithId<Unit, int>(jiaYuanPastures.UnitId, jiaYuanPastures.ConfigId);
            scene.GetComponent<UnitComponent>().Add(unit);
            unit.AddComponent<ObjectWait>();
            NumericComponentS numericComponent = unit.AddComponent<NumericComponentS>();
            UnitInfoComponent unitInfoComponent = unit.AddComponent<UnitInfoComponent>();
            unit.AddComponent<MoveComponent>();
            unit.AddComponent<SkillManagerComponentS>();
            unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
            unit.AddComponent<AttackRecordComponent>();

            unitInfoComponent.UnitName = JiaYuanPastureConfigCategory.Instance.Get(jiaYuanPastures.ConfigId).Name;

            unit.ConfigId = jiaYuanPastures.ConfigId;
            unit.AddComponent<StateComponentS>(); //添加状态组件
            unit.AddComponent<BuffManagerComponentS>(); //添加
            unit.Position = ConfigData.PastureInitPos;
            unit.Type = UnitType.Pasture;

            AIComponent aIComponent = unit.AddComponent<AIComponent, int>(11); //AI行为树序号
            aIComponent.InitPasture();
            aIComponent.Begin();

            //添加其他组件
            unit.AddComponent<HeroDataComponentS>().InitPasture(jiaYuanPastures, false);
            numericComponent.ApplyValue(NumericType.MasterId, unitid, false);
            numericComponent.ApplyValue(NumericType.Base_Speed_Base, 30000, false);
            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
            return unit;
        }

        public static Unit CreateTianTiPet(Scene scene, long masterId, int roleCamp, RolePetInfo petinfo, float3 postion, float rotation, int cell , long customId = 0)
        {
            Unit unit = null;
            if (customId == 0)
            {
                unit = scene.GetComponent<UnitComponent>().AddChildWithId<Unit, int>(petinfo.Id, 1);
            }
            else
            {
                unit = scene.GetComponent<UnitComponent>().AddChildWithId<Unit, int>(customId, 1);
            }
            scene.GetComponent<UnitComponent>().Add(unit);
            unit.AddComponent<ObjectWait>();
            NumericComponentS numericComponent = unit.AddComponent<NumericComponentS>();
            unit.AddComponent<MoveComponent>();
            UnitInfoComponent unitInfoComponent = unit.AddComponent<UnitInfoComponent>();
            unit.AddComponent<SkillManagerComponentS>();
            unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
            unit.AddComponent<AttackRecordComponent>();
            unit.ConfigId = petinfo.ConfigId;
            unitInfoComponent.UnitName = petinfo.PetName;
            unitInfoComponent.MasterName = petinfo.PlayerName;
            unit.AddComponent<StateComponentS>(); //添加状态组件
            unit.AddComponent<BuffManagerComponentS>(); //添加
            unit.Position = postion;
            unit.Type = UnitType.Pet;
            unit.Rotation = quaternion.Euler(0f, math.radians(rotation), 0f);
            MapComponent mapComponent = scene.GetComponent<MapComponent>();
            //添加其他组件
            unit.AddComponent<HeroDataComponentS>().InitPet(petinfo, false);
            numericComponent.ApplyValue(NumericType.BattleCamp, roleCamp, false);
            numericComponent.ApplyValue(NumericType.MasterId, masterId, false);
            numericComponent.ApplyValue(NumericType.UnitPositon, cell, false);
            long max_hp = numericComponent.GetAsLong(NumericType.Now_MaxHp);
            numericComponent.ApplyValue(NumericType.Now_Hp, max_hp, false);
            unit.AddComponent<SkillPassiveComponent>().UpdatePetPassiveSkill(petinfo);
            switch (mapComponent.MapType)
            {
                case MapTypeEnum.PetDungeon:
                case MapTypeEnum.PetTianTi:
                case MapTypeEnum.PetMing:
                    unit.AddComponent<AIComponent, int>(1).InitTianTiPet(petinfo.ConfigId); //AI行为树序号  撤退
                    break;
                case MapTypeEnum.PetMelee:
                    AIComponent aiComponent = unit.AddComponent<AIComponent, int>(16);
                    aiComponent.TargetPoint.Add(new float3(13, 0, 0));
                    aiComponent.InitPet(petinfo); //AI行为树序号  不撤退
                    break;
                case MapTypeEnum.PetMatch:
                    aiComponent = unit.AddComponent<AIComponent, int>(16);
                    aiComponent.TargetPoint.Add(roleCamp == CampEnum.CampPlayer_1 ?  new float3(13, 0, 0) : new float3(-13, 0, 0) );
                    aiComponent.InitPet(petinfo); //AI行为树序号  不撤退
                    break;
                default:
                    unit.AddComponent<AIComponent, int>(1).InitPet(petinfo); //AI行为树序号  撤退
                    break;
            }

            unit.AddComponent<AOIEntity, int, float3>(1 * 1000, unit.Position);
            return unit;
        }
        
        public static Unit CreateStall(Scene scene, Unit master)
        {
            Unit unit = scene.GetComponent<UnitComponent>().AddChildWithId<Unit, int>(IdGenerater.Instance.GenerateId(), 1);
            scene.GetComponent<UnitComponent>().Add(unit);
            unit.AddComponent<ObjectWait>();
            unit.AddComponent<StateComponentS>(); //添加状态组件
            unit.AddComponent<HeroDataComponentS>();
            NumericComponentS numericComponent = unit.AddComponent<NumericComponentS>();
            UnitInfoComponent unitInfoComponent = unit.AddComponent<UnitInfoComponent>();
            unitInfoComponent.UnitName = master.GetComponent<UserInfoComponentS>().UserInfo.StallName;
            numericComponent.ApplyValue(NumericType.MasterId, master.Id, false);
            unit.Type = UnitType.Stall;
            unit.Position = master.Position;
            //unit.AddComponent<DeathTimeComponent, long>(TimeHelper.Hour * 6);
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
                unit.AddComponent<StateComponentS>();
                NumericComponentS numericComponent = unit.AddComponent<NumericComponentS>();
                numericComponent.ApplyValue(NumericType.Now_Speed, npcConfig.NpcPar[0], false);
                unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
                unit.AddComponent<AIComponent, int>(npcConfig.AI); //AI行为树序号	
                unit.GetComponent<AIComponent>().InitNpc(npcId);
                unit.GetComponent<AIComponent>().Begin();
            }

            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
            return unit;
        }

        public static Unit CreateJiaYuanPet(Scene scene, long masterid, JiaYuanPet jiaYuanPet)
        {
            Unit unit = scene.GetComponent<UnitComponent>().AddChildWithId<Unit, int>(jiaYuanPet.unitId, 1);
            scene.GetComponent<UnitComponent>().Add(unit);
            unit.AddComponent<ObjectWait>();
            NumericComponentS numericComponent = unit.AddComponent<NumericComponentS>();
            UnitInfoComponent unitInfoComponent = unit.AddComponent<UnitInfoComponent>();
            unit.AddComponent<MoveComponent>();
            unit.AddComponent<SkillManagerComponentS>();
            unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
            unit.AddComponent<AttackRecordComponent>();
            unitInfoComponent.MasterName = jiaYuanPet.PlayerName;
            unitInfoComponent.UnitName = jiaYuanPet.PetName;
            unit.ConfigId = jiaYuanPet.ConfigId;
            unit.AddComponent<StateComponentS>(); //添加状态组件
            unit.AddComponent<BuffManagerComponentS>(); //添加
            unit.Position = ConfigData.JiaYuanPetPosition[1];
            unit.Type = UnitType.Pet;
            numericComponent.ApplyValue(NumericType.MasterId, masterid, false);
            numericComponent.ApplyValue(NumericType.Base_Speed_Base, 10000, false);
            AIComponent aIComponent = unit.AddComponent<AIComponent, int>(11); //AI行为树序号
            aIComponent.InitJiaYuanPet();
            aIComponent.Begin();
            //添加其他组件
            unit.AddComponent<HeroDataComponentS>().InitJiaYuanPet(false);
            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);

            return unit;
        }

        public static Unit CreatePlan(Scene scene, JiaYuanPlant jiaYuanPlant, long unitid)
        {
            Unit unit = scene.GetComponent<UnitComponent>().AddChildWithId<Unit, int>(jiaYuanPlant.UnitId, jiaYuanPlant.ItemId);
            scene.GetComponent<UnitComponent>().Add(unit);
            unit.AddComponent<ObjectWait>();
            NumericComponentS numericComponent = unit.AddComponent<NumericComponentS>();
            UnitInfoComponent unitInfoComponent = unit.AddComponent<UnitInfoComponent>();
            unit.AddComponent<MoveComponent>();
            unit.AddComponent<SkillManagerComponentS>();
            unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
            unit.AddComponent<AttackRecordComponent>();

            unitInfoComponent.UnitName = JiaYuanFarmConfigCategory.Instance.Get(jiaYuanPlant.ItemId).Name;

            unit.ConfigId = jiaYuanPlant.ItemId;
            unit.AddComponent<StateComponentS>(); //添加状态组件
            unit.AddComponent<BuffManagerComponentS>(); //添加
            unit.Position = ConfigData.PlanPositionList[jiaYuanPlant.CellIndex];
            unit.Type = UnitType.Plant;

            //添加其他组件
            unit.AddComponent<HeroDataComponentS>().InitPlan(jiaYuanPlant, false);
            numericComponent.ApplyValue(NumericType.MasterId, unitid, false);
            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
            return unit;
        }

        public static List<RewardItem> AI_MonsterDrop(Unit unit, int monsterID, float dropProValue, bool all)
        {
            //根据怪物ID获得掉落ID
            MonsterConfig monsterCof = MonsterConfigCategory.Instance.Get(monsterID);
            List<RewardItem> dropItemList = new List<RewardItem>();
            int[] dropID = monsterCof.DropID;

            if (dropID != null)
            {
                for (int i = 0; i < dropID.Length; i++)
                {
                    if (dropID[i] == 0)
                        continue;

                    DropConfig dropConfig = DropConfigCategory.Instance.Get(dropID[i]);
                    List<RewardItem> dropItemList_2 = new List<RewardItem>();
                    DropHelper.DropIDToDropItem(dropID[i], dropItemList_2, monsterID, dropProValue, all);
                    if (dropConfig.ifEnterBag == 1)
                    {
                        unit.GetComponent<BagComponentS>()
                                .OnAddItemData(dropItemList_2, string.Empty, $"{ItemGetWay.PickItem}_{TimeHelper.ServerNow()}");
                    }
                    else
                    {
                        dropItemList.AddRange(dropItemList_2);
                    }
                }
            }

            return dropItemList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bekill"></param>
        /// <param name="main"></param>
        /// <param name="sceneType"></param>
        /// <param name="playerNumer"></param>
        public static void CreateDropItems(Unit bekill, Unit main, int sceneType, int scenid, int playerNumer)
        {
            if (bekill.Type != UnitType.Monster || main.Type != UnitType.Player)
            {
                return;
            }

            bool drop = true;
            MonsterConfig monsterCof = MonsterConfigCategory.Instance.Get(bekill.ConfigId);
            if (SceneConfigHelper.IsSingleFuben(sceneType))
            {
                drop = main.GetComponent<UserInfoComponentS>().UserInfo.PiLao > 0 || bekill.IsBoss();

                //场景宝箱掉落和体力无关
                if (monsterCof.MonsterType == 5 &&
                    (monsterCof.MonsterSonType == MonsterSonTypeEnum.Type_55 || monsterCof.MonsterSonType == MonsterSonTypeEnum.Type_57))
                {
                    drop = true;
                }

                if (monsterCof.MonsterType == 1 && monsterCof.MonsterSonType == MonsterSonTypeEnum.Type_3)
                {
                    drop = true;
                }

                if (main.IsRobot())
                {
                    drop = false;
                }
            }

            if (ConfigData.IsShowLieOpen && !drop && !main.IsRobot())
            {
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(bekill.ConfigId);
                int userlv = main.GetComponent<UserInfoComponentS>().UserInfo.Lv;
                if (monsterConfig.Lv >= 60 || math.abs(userlv - monsterConfig.Lv) <= 9)
                {
                    drop = true;
                }
            }

            if (!drop)
            {
                return;
            }

            float dropAdd_Pro = 1;
            if (bekill.IsBoss() && main != null && !CommonHelp.IsSeasonBoss(bekill.ConfigId ))
            {
                int fubenDifficulty = FubenDifficulty.None;
                dropAdd_Pro += main.GetComponent<NumericComponentS>().GetAsFloat(NumericType.Base_DropAdd_Pro_Add);
                if (sceneType == (int)MapTypeEnum.CellDungeon)
                {
                    fubenDifficulty = bekill.Scene().GetComponent<CellDungeonComponentS>().FubenDifficulty;
                }

                if (sceneType == (int)MapTypeEnum.LocalDungeon)
                {
                    fubenDifficulty = bekill.Scene().GetComponent<LocalDungeonComponent>().FubenDifficulty;
                }

                switch (fubenDifficulty)
                {
                    case FubenDifficulty.TiaoZhan:
                        dropAdd_Pro += 0.2f;
                        break;
                    case FubenDifficulty.DiYu:
                        dropAdd_Pro += 0.5f;
                        break;
                }
            }

            if (!bekill.IsBoss() && ConfigData.IsShowLieOpen)
            {
                dropAdd_Pro += 1f;
            }

            //1个人掉率降低
            if (sceneType == MapTypeEnum.TeamDungeon)
            {
                if (playerNumer == 1)
                {
                    dropAdd_Pro -= 0.25f;
                }

                if (playerNumer == 2)
                {
                    dropAdd_Pro += 0.8f;
                }

                if (playerNumer == 3)
                {
                    dropAdd_Pro += 1.5f;
                }

                MapComponent mapComponent = bekill.Scene().GetComponent<MapComponent>();
                if (mapComponent.FubenDifficulty == TeamFubenType.ShenYuan)
                {
                    dropAdd_Pro += 1.5f;
                }
            }

            // 封印之塔提升爆率
            if (sceneType == MapTypeEnum.SealTower)
            {
                dropAdd_Pro += 1f;
            }

            //个人副本根据成长来
            if (sceneType == MapTypeEnum.LocalDungeon && bekill.IsBoss() && !CommonHelp.IsSeasonBoss(bekill.ConfigId ))
            {
                int killNumber = main.GetComponent<UserInfoComponentS>().GetMonsterKillNumber(monsterCof.Id);
                int chpaterid = DungeonConfigCategory.Instance.GetChapterByDungeon(scenid);
                BossDevelopment bossDevelopment = ConfigHelper.GetBossDevelopmentByKill(chpaterid, killNumber);
                dropAdd_Pro += bossDevelopment.DropAdd;
            }

            //创建掉落
            if (main != null && monsterCof.MonsterSonType == MonsterSonTypeEnum.Type_1)
            {
                int nowUserLv = main.GetComponent<UserInfoComponentS>().UserInfo.Lv;
                for (int i = 0; i < monsterCof.Parameter.Length; i++)
                {
                    MonsterConfig nowmonsterCof = MonsterConfigCategory.Instance.Get(monsterCof.Parameter[i]);
                    if (nowUserLv >= nowmonsterCof.Lv)
                    {
                        //指定等级对应属性
                        monsterCof = nowmonsterCof;
                    }
                }
            }

            List<RewardItem> droplist = AI_MonsterDrop(main, monsterCof.Id, dropAdd_Pro, false);

            List<RewardItem> droplist_2 = null;
            if (main != null && !main.IsDisposed)
            {
                int playerLv = main.GetComponent<UserInfoComponentS>().UserInfo.Lv;
                droplist_2 = DropHelper.AI_DropByPlayerLv(monsterCof.Id, playerLv, dropAdd_Pro, false);
            }

            if (droplist_2 != null)
            {
                droplist.AddRange(droplist_2);
            }

            if ((monsterCof.MonsterSonType == MonsterSonTypeEnum.Type_55 || monsterCof.MonsterSonType == MonsterSonTypeEnum.Type_56) && droplist.Count == 0)
            {
                Log.Warning($"宝箱掉落为空{monsterCof.Id} {main.Id}");
            }

            if (monsterCof.MonsterType == (int)MonsterTypeEnum.Boss && droplist.Count == 0)
            {
                Log.Warning($"BOSS掉落为空{monsterCof.Id}  {main.Id}");
            }

            if (monsterCof.Id == 72006013)
            {
                Log.Warning($"BOSS掉落数量[72006013]： {monsterCof.Id}  {droplist.Count}");
            }

            if (droplist.Count > 100)
            {
                Log.Error($"掉落道具数量异常： {monsterCof.Id}  {droplist.Count}");
                Log.Warning($"掉落道具数量异常： {monsterCof.Id}  {droplist.Count}");
                return;
            }

            List<long> beattackIds = bekill.GetComponent<AttackRecordComponent>().GetBeAttackPlayerList();
            if (main != null && !beattackIds.Contains(main.Id))
            {
                beattackIds.Add(main.Id);
            }

            //1只要造成伤害就有 2是保护掉落 最后一刀 3是那个按照伤害统计
            // 0 公共掉落 2保护掉落   1私有掉落 3 归属掉落
            if (monsterCof.DropType == 0
                || monsterCof.DropType == 2
                || monsterCof.DropType == 3)
            {
                long serverTime = TimeHelper.ServerNow();
                Scene DomainScene = main != null ? main.Scene() : bekill.Scene();
                for (int i = 0; i < droplist.Count; i++)
                {
                    if (sceneType == MapTypeEnum.TeamDungeon && (droplist[i].ItemID >= 10030011 && droplist[i].ItemID <= 10030019))
                    {
                        Log.Error($"掉落装备.字: {droplist[i].ItemID}   {sceneType}");
                    }

                    UnitComponent unitComponent = DomainScene.GetComponent<UnitComponent>();
                    Unit dropitem = unitComponent.AddChildWithId<Unit, int>(IdGenerater.Instance.GenerateId(), 1);
                    dropitem.AddComponent<UnitInfoComponent>();
                    dropitem.Type = UnitType.DropItem;
                    DropComponentS dropComponent = dropitem.AddComponent<DropComponentS>();
                    dropComponent.IfDamgeDrop = monsterCof.IfDamgeDrop;
                    dropComponent.BeAttackPlayerList = beattackIds;
                    
                    NumericComponentS numericComponentS = dropitem.AddComponent<NumericComponentS>();
                    numericComponentS.ApplyValue(NumericType.DropItemId, droplist[i].ItemID, false);
                    numericComponentS.ApplyValue(NumericType.DropItemNum, droplist[i].ItemNum, false);
                    numericComponentS.ApplyValue(NumericType.DropType, monsterCof.DropType, false);
                    numericComponentS.ApplyValue(NumericType.BeKillId, bekill.Id, false);
                    
                    //掉落归属问题 掉落类型为2 原来为： 最后一刀 修改为 第一拾取权限为优先攻击他的人,如果这个人死了，那么拾取权限清空，下一次伤害是谁归属权就是谁。

                    long ownderId = main != null ? main.Id : 0;
                    switch (monsterCof.DropType)
                    {
                        case 2:
                            if (beattackIds.Count > 0 && unitComponent.Get(beattackIds[0]) != null)
                            {
                                ownderId = beattackIds[0];
                            }

                            dropComponent.OwnerId = monsterCof.DropType == 0 ? 0 : ownderId;
                            dropComponent.ProtectTime = monsterCof.DropType == 0 ? 0 : serverTime + 30000;
                            break;
                        case 3:
                            long belongid = bekill.GetComponent<NumericComponentS>().GetAsLong(NumericType.BossBelongID);
                            if (belongid > 0)
                            {
                                ownderId = belongid;
                            }

                            dropComponent.OwnerId = ownderId;
                            dropComponent.ProtectTime = monsterCof.DropType == 0 ? 0 : serverTime + 30000;
                            break;
                    }

                    //单人副本不要搞归属掉落，以免出问题
                    if (SceneConfigHelper.IsSingleFuben(sceneType))
                    {
                        dropComponent.OwnerId = 0;
                    }

                    float dropX = bekill.Position.x + RandomHelper.RandomNumberFloat(-1f, 1f);
                    float dropY = bekill.Position.y;
                    float dropZ = bekill.Position.z + RandomHelper.RandomNumberFloat(-1f, 1f);
                    dropitem.Position = new float3(dropX, dropY, dropZ);
                    dropitem.AddComponent<AOIEntity, int, float3>(9 * 1000, dropitem.Position);
                }

                if (monsterCof.DropType == 3)
                {
                    long belongid = bekill.GetComponent<NumericComponentS>().GetAsLong(NumericType.BossBelongID);
                    ServerLogHelper.LogWarning($"BOSS归属掉落日志：{monsterCof.MonsterName}");
                    ServerLogHelper.LogWarning($"BOSS归属者ID: {bekill.Zone()} {belongid}");
                    ServerLogHelper.LogWarning("BOSS伤害日志：");
                    Dictionary<long, long> keyValuePairsHurt = bekill.GetComponent<AttackRecordComponent>().BeAttackPlayerList;
                    foreach ((long uid, long hurt) in keyValuePairsHurt)
                    {
                        ServerLogHelper.LogWarning($"{uid} {hurt}");
                    }
                }
            }

            if (monsterCof.DropType == 1)
            {
                for (int i = 0; i < beattackIds.Count; i++)
                {
                    Unit beAttack = bekill.Scene().GetComponent<UnitComponent>().Get(beattackIds[i]);
                    if (beAttack == null || beAttack.Type != UnitType.Player)
                    {
                        continue;
                    }

                    if (i >= 20)
                    {
                        break;
                    }

                    M2C_CreateDropItems m2C_CreateDropItems = M2C_CreateDropItems.Create();
                    for (int k = 0; k < droplist.Count; k++)
                    {
                        //if (sceneType == SceneTypeEnum.TeamDungeon && (droplist[k].ItemID >= 10030011 && droplist[k].ItemID <= 10030019))
                        //{
                        //    Log.Error($"掉落装备.字: {droplist[k].ItemID}   {sceneType}");
                        //}

                        //宠物蛋直接进背包
                        if (monsterCof.MonsterSonType == MonsterSonTypeEnum.Type_57)
                        {
                            beAttack.GetComponent<BagComponentS>().OnAddItemData($"{droplist[k].ItemID};{droplist[k].ItemNum}",
                                $"{ItemGetWay.PickItem}_{TimeHelper.ServerNow()}");
                            continue;
                        }

                        UnitInfo dropInfo = UnitInfo.Create();
                        dropInfo.KV.Add(NumericType.DropType, 1);
                        dropInfo.KV.Add(NumericType.DropItemId, droplist[k].ItemID);
                        dropInfo.KV.Add(NumericType.DropItemNum, droplist[k].ItemNum);
                        dropInfo.Position = new float3(bekill.Position.x + RandomHelper.RandomNumberFloat(-1f, 1f), bekill.Position.y,
                            bekill.Position.z + RandomHelper.RandomNumberFloat(-1f, 1f));
                        dropInfo.UnitId = IdGenerater.Instance.GenerateId();
                        m2C_CreateDropItems.Drops.Add(dropInfo);
                        beAttack.GetComponent<UnitInfoComponent>().Drops.Add(dropInfo);

                        if (monsterCof.Id == 70003003)
                        {
                            Log.Warning($"BOSS掉落道具位置:  {main.Position.x}  {main.Position.z}  {bekill.Position.x} {bekill.Position.z}");
                        }

                        if (math.distance(main.Position, dropInfo.Position) > 10f)
                        {
                            Log.Warning($"BOSS掉落道具位置过远:  {main.Position.x}  {main.Position.z}  {bekill.Position.x} {bekill.Position.z}");
                        }
                    }

                    MapMessageHelper.SendToClient(beAttack, m2C_CreateDropItems);
                }
            }
        }

        public static void CreateDropItems(Unit main, Unit beKill, int dropType, int dropId, string par)
        {
            Scene domainScene = beKill.Scene();
            int sceneType = domainScene.GetComponent<MapComponent>().MapType;

            // 0 公共掉落 2保护掉落   1私有掉落  3 归属掉落
            if (dropType == 0)
            {
                List<RewardItem> droplist = new List<RewardItem>();
                DropHelper.DropIDToDropItem(dropId, droplist);
                if (par == "2")
                {
                    droplist.AddRange(droplist);
                }

                if (droplist.Count > 100)
                {
                    Log.Error($"掉落道具数量异常： {beKill.ConfigId}  {droplist.Count}");
                    Log.Warning($"掉落道具数量异常： {beKill.ConfigId}  {droplist.Count}");
                }

                for (int i = 0; i < droplist.Count; i++)
                {
                    if ((droplist[i].ItemID >= 10030011 && droplist[i].ItemID <= 10030019) && sceneType != MapTypeEnum.LocalDungeon)
                    {
                        Log.Error($"掉落装备.字: {droplist[i].ItemID}  {par}   {sceneType}");
                    }

                    UnitComponent unitComponent = domainScene.GetComponent<UnitComponent>();
                    Unit dropitem = unitComponent.AddChildWithId<Unit, int>(IdGenerater.Instance.GenerateId(), 1);
                    dropitem.AddComponent<UnitInfoComponent>();
                    dropitem.Type = UnitType.DropItem;
                    DropComponentS dropComponent = dropitem.AddComponent<DropComponentS>();
                    float dropX = beKill.Position.x + RandomHelper.RandomNumberFloat(-1f, 1f);
                    float dropY = beKill.Position.y;
                    float dropZ = beKill.Position.z + RandomHelper.RandomNumberFloat(-1f, 1f);
                    dropitem.Position = new float3(dropX, dropY, dropZ);
                    dropitem.AddComponent<AOIEntity, int, float3>(9 * 1000, dropitem.Position);
                    
                    NumericComponentS numericComponentS = dropitem.AddComponent<NumericComponentS>();
                    numericComponentS.ApplyValue(NumericType.DropItemId, droplist[i].ItemID, false);
                    numericComponentS.ApplyValue(NumericType.DropItemNum, droplist[i].ItemNum, false);
                    numericComponentS.ApplyValue(NumericType.DropType, dropType, false);
                    numericComponentS.ApplyValue(NumericType.BeKillId, beKill.Id, false);
                }
            }

            if (dropType == 1)
            {
                M2C_CreateDropItems m2C_CreateDropItems = M2C_CreateDropItems.Create();
                List<RewardItem> droplist = new List<RewardItem>();
                DropHelper.DropIDToDropItem(dropId, droplist);

                if (droplist.Count > 100)
                {
                    Log.Error($"掉落道具数量异常： {dropId}  {droplist.Count}");
                    Log.Warning($"掉落道具数量异常： {dropId}  {droplist.Count}");
                    return;
                }

                for (int k = 0; k < droplist.Count; k++)
                {
                    if ((droplist[k].ItemID >= 10030011 && droplist[k].ItemID <= 10030019) && sceneType == MapTypeEnum.TeamDungeon)
                    {
                        Log.Error($"掉落装备.字: {droplist[k].ItemID}  {par}   {sceneType}");
                    }

                    UnitInfo dropInfo = UnitInfo.Create();
                    dropInfo.KV.Add(NumericType.DropType, 1);
                    dropInfo.KV.Add(NumericType.DropItemId, droplist[k].ItemID);
                    dropInfo.KV.Add(NumericType.DropItemNum, droplist[k].ItemNum);
                    dropInfo.KV.Add(NumericType.BeKillId, beKill.Id);
                    dropInfo.Position = new float3(beKill.Position.x + RandomHelper.RandomNumberFloat(-1f, 1f), beKill.Position.y,
                        beKill.Position.z + RandomHelper.RandomNumberFloat(-1f, 1f));
                    dropInfo.UnitId = IdGenerater.Instance.GenerateId();
                    m2C_CreateDropItems.Drops.Add(dropInfo);
                    main.GetComponent<UnitInfoComponent>().Drops.Add(dropInfo);
                }

                MapMessageHelper.SendToClient(main, m2C_CreateDropItems);
            }
        }
    }
}