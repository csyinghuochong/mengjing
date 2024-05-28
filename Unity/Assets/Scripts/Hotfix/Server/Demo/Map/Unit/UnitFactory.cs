using System;
using Unity.Mathematics;
using System.Collections.Generic;

namespace ET.Server
{
    public static partial class UnitFactory
    {
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
                        numericComponentS.SetNoEvent(NumericType.Now_Speed, 60000); // 速度是6米每秒
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
                    List<DBFriendInfo> dbFriendInfos = await dbComponent.Query<DBFriendInfo>(scene.Zone(), d => d.Id == id);
                    if (dbFriendInfos == null || dbFriendInfos.Count == 0)
                    {
                        DBFriendInfo dbFriendInfo = unit.AddComponent<DBFriendInfo>();
                        await dbComponent.Save(scene.Zone(), dbFriendInfo);
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
            int openDay = ServerHelper.GetOpenServerDay(false, scene.Zone());
            monsterID = MonsterConfigCategory.Instance.GetNewMonsterId(openDay, monsterID);

            //精灵不能作为主人
            Unit master = scene.GetComponent<UnitComponent>().Get(createMonsterInfo.MasterID);
            if (master != null && master.Type == UnitType.JingLing)
            {
                createMonsterInfo.MasterID = master.MasterId;
            }

            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterID);
            MapComponent mapComponent = scene.GetComponent<MapComponent>();

            long unitid = createMonsterInfo.UnitId > 0? createMonsterInfo.UnitId : IdGenerater.Instance.GenerateId();
            Unit unit = scene.GetComponent<UnitComponent>().AddChildWithId<Unit, int>(unitid, 1001);
            unit.AddComponent<AttackRecordComponent>();
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
            numericComponent.SetNoEvent(NumericType.TeamId, master != null? master.GetTeamId() : 0);
            numericComponent.SetNoEvent(NumericType.AttackMode, master != null? master.GetAttackMode() : 0);
            numericComponent.SetNoEvent(NumericType.UnionId_0, master != null? master.GetUnionId() : 0);
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
                int ai = createMonsterInfo.AI > 0? createMonsterInfo.AI : monsterConfig.AI;
                unit.AI = ai;
                unit.AddComponent<ObjectWait>();
                unit.AddComponent<MoveComponent>();
                unit.AddComponent<SkillManagerComponentS>();
                unit.AddComponent<SkillPassiveComponent>();
                unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
                //添加其他组件
                unit.AddComponent<StateComponentS>(); //添加状态组件
                unit.AddComponent<BuffManagerComponentS>(); //添加Buff管理器
                unit.GetComponent<SkillPassiveComponent>().UpdateMonsterPassiveSkill();
                unit.GetComponent<SkillPassiveComponent>().Activeted();
                numericComponent.Set(NumericType.MasterId, createMonsterInfo.MasterID);
                AIComponent aIComponent = unit.AddComponent<AIComponent, int>(ai);
                switch (mapComponent.SceneType)
                {
                    case SceneTypeEnum.LocalDungeon:
                        aIComponent.LocalDungeonUnit = mainUnit;
                        aIComponent.InitMonster(monsterConfig.Id);
                        aIComponent.Begin();
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
                unit.AddComponent<AIComponent, int>(npcConfig.AI); //AI行为树序号	
                unit.GetComponent<AIComponent>().InitNpc(npcId);
                unit.GetComponent<AIComponent>().Begin();
            }

            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
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
            unit.MasterId = master.Id;
            unit.AddComponent<StateComponentS>(); //添加状态组件
            unit.AddComponent<BuffManagerComponentS>(); //添加
            unit.Position = new float3(master.Position.x + RandomHelper.RandFloat01() * 1f, master.Position.y,
                master.Position.z + RandomHelper.RandFloat01() * 1f);
            unit.Type = UnitType.Pet;
            AIComponent aIComponent = unit.AddComponent<AIComponent, int>(2); //AI行为树序号
            aIComponent.InitPet(petinfo);
            aIComponent.Begin();
            //添加其他组件
            unit.AddComponent<HeroDataComponentS>().InitPet(petinfo, false);
            numericComponent.ApplyValue(NumericType.MasterId, master.Id, false);
            numericComponent.ApplyValue(NumericType.BattleCamp, master.GetBattleCamp(), false);
            numericComponent.ApplyValue(NumericType.AttackMode, master != null? master.GetAttackMode() : 0, false);
            numericComponent.ApplyValue(NumericType.TeamId, master.GetTeamId(), false);
            ;
            numericComponent.ApplyValue(NumericType.UnionId_0, master.GetUnionId(), false);
            long max_hp = numericComponent.GetAsLong(NumericType.Now_MaxHp);
            numericComponent.SetNoEvent(NumericType.Now_Hp, max_hp);
            numericComponent.ApplyValue(NumericType.Base_Speed_Base, master.GetComponent<NumericComponentS>().GetAsLong(NumericType.Base_Speed_Base),
                false);

            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
            if (scene.GetComponent<MapComponent>().SceneType != (int)SceneTypeEnum.MainCityScene)
            {
                unit.AddComponent<SkillPassiveComponent>().UpdatePetPassiveSkill(petinfo);
                unit.GetComponent<SkillPassiveComponent>().Activeted();
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
            //unitInfoComponent.MasterName = userInfoComponent.UserInfo.Name;
            unitInfoComponent.UnitName = JiaYuanPastureConfigCategory.Instance.Get(jiaYuanPastures.ConfigId).Name;

            unit.ConfigId = jiaYuanPastures.ConfigId;
            unit.AddComponent<StateComponentS>();         //添加状态组件
            unit.AddComponent<BuffManagerComponentS>();      //添加
            unit.Position = ConfigData.PastureInitPos;
            unit.Type = UnitType.Pasture;

            AIComponent aIComponent = unit.AddComponent<AIComponent, int>(11);     //AI行为树序号
            aIComponent.InitPasture();
            aIComponent.Begin();

            //添加其他组件
            unit.AddComponent<HeroDataComponentS>().InitPasture(jiaYuanPastures, false);
            numericComponent.SetNoEvent(NumericType.MasterId, unitid);
            numericComponent.SetNoEvent(NumericType.Base_Speed_Base, 30000);
            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
            return unit;
        }

        
        public static Unit CreateTianTiPet(Scene scene, long masterId, int roleCamp, RolePetInfo petinfo, float3 postion, float rotation, int cell)
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
            unit.AddComponent<StateComponentS>(); //添加状态组件
            unit.AddComponent<BuffManagerComponentS>(); //添加
            unit.Position = postion;
            unit.Type = UnitType.Pet;
            unit.Rotation = quaternion.Euler(0f, rotation, 0f);
            AIComponent aIComponent = unit.AddComponent<AIComponent, int>(1); //AI行为树序号
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
            numericComponent.SetNoEvent(NumericType.Now_Hp, max_hp);
            unit.AddComponent<AOIEntity, int, float3>(1 * 1000, unit.Position);
            unit.AddComponent<SkillPassiveComponent>().UpdatePetPassiveSkill(petinfo);
            unit.GetComponent<SkillPassiveComponent>().Activeted();
            return unit;
        }

        public static Unit CreateJingLing(Unit master, int jinglingId)
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
            numericComponent.ApplyValue(NumericType.AttackMode, master != null? master.GetAttackMode() : 0, false);
            numericComponent.ApplyValue(NumericType.TeamId, master.GetTeamId(), false);
            numericComponent.ApplyValue(NumericType.UnionId_0, master.GetUnionId(), false);
            //numericComponent.Set(NumericType.Base_Speed_Base, 50000, false);

            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
            unit.AddComponent<SkillPassiveComponent>().UpdateJingLingSkill(jinglingId);
            unit.GetComponent<SkillPassiveComponent>().Activeted();
            return unit;
        }

        public static Unit CreateStall(Scene scene, Unit master)
        {
            Unit unit = scene.GetComponent<UnitComponent>().AddChildWithId<Unit, int>(IdGenerater.Instance.GenerateId(), 1);
            scene.GetComponent<UnitComponent>().Add(unit);
            unit.AddComponent<ObjectWait>();
            unit.AddComponent<StateComponentS>();            //添加状态组件
            unit.AddComponent<HeroDataComponentS>();
            NumericComponentS numericComponent = unit.AddComponent<NumericComponentS>();
            UnitInfoComponent unitInfoComponent = unit.AddComponent<UnitInfoComponent>();
            unitInfoComponent.UnitName = master.GetComponent<UserInfoComponentS>().UserInfo.StallName;
            unit.GetComponent<NumericComponentS>().Set(NumericType.MasterId, master.Id);
            unit.MasterId = master.Id;
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
                numericComponent.Set(NumericType.Now_Speed, npcConfig.NpcPar[0]);
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
            unit.AddComponent<StateComponentS>();         //添加状态组件
            unit.AddComponent<BuffManagerComponentS>();      //添加
            unit.Position = ConfigData.JiaYuanPetPosition[1];
            unit.Type = UnitType.Pet;
            numericComponent.SetNoEvent(NumericType.MasterId, masterid);
            numericComponent.SetNoEvent(NumericType.Base_Speed_Base, 10000);
            AIComponent aIComponent = unit.AddComponent<AIComponent, int>(11);     //AI行为树序号
            aIComponent.InitJiaYuanPet( );
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
            unit.AddComponent<StateComponentS>();         //添加状态组件
            unit.AddComponent<BuffManagerComponentS>();      //添加
            unit.Position = ConfigData.PlanPositionList[jiaYuanPlant.CellIndex];
            unit.Type = UnitType.Plant;

            //添加其他组件
            unit.AddComponent<HeroDataComponentS>().InitPlan(jiaYuanPlant,false);
            numericComponent.SetNoEvent(NumericType.MasterId, unitid);
            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
            return unit;
        }
        
        public static void CreateDropItems(Unit main, Unit beKill, int dropType, int dropId, string par)
        {
            Scene domainScene = beKill.Scene();
            int sceneType = domainScene.GetComponent<MapComponent>().SceneType;

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
                    if ((droplist[i].ItemID >= 10030011 && droplist[i].ItemID <= 10030019) && sceneType != SceneTypeEnum.LocalDungeon)
                    {
                        Log.Error($"掉落装备.字: {droplist[i].ItemID}  {par}   {sceneType}");
                    }

                    UnitComponent unitComponent = domainScene.GetComponent<UnitComponent>();
                    Unit dropitem = unitComponent.AddChildWithId<Unit, int>(IdGenerater.Instance.GenerateId(), 1);
                    dropitem.AddComponent<UnitInfoComponent>();
                    dropitem.Type = UnitType.DropItem;
                    DropComponentS dropComponent = dropitem.AddComponent<DropComponentS>();
                    dropComponent.SetItemInfo(droplist[i].ItemID, droplist[i].ItemNum);
                    float dropX = beKill.Position.x + RandomHelper.RandomNumberFloat(-1f, 1f);
                    float dropY = beKill.Position.y;
                    float dropZ = beKill.Position.z + RandomHelper.RandomNumberFloat(-1f, 1f);
                    dropitem.Position = new float3(dropX, dropY, dropZ);
                    dropitem.AddComponent<AOIEntity, int, float3>(9 * 1000, dropitem.Position);
                    dropComponent.DropType = dropType;
                    dropComponent.BeKillId = beKill.Id;
                }
            }

            if (dropType == 1)
            {
                M2C_CreateDropItems m2C_CreateDropItems = new M2C_CreateDropItems();
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
                    if ((droplist[k].ItemID >= 10030011 && droplist[k].ItemID <= 10030019) && sceneType == SceneTypeEnum.TeamDungeon)
                    {
                        Log.Error($"掉落装备.字: {droplist[k].ItemID}  {par}   {sceneType}");
                    }

                    DropInfo dropInfo = new DropInfo()
                    {
                        DropType = 1,
                        ItemID = droplist[k].ItemID,
                        ItemNum = droplist[k].ItemNum,
                        X = beKill.Position.x + RandomHelper.RandomNumberFloat(-1f, 1f),
                        Y = beKill.Position.y,
                        Z = beKill.Position.z + RandomHelper.RandomNumberFloat(-1f, 1f),
                        UnitId = IdGenerater.Instance.GenerateId(),
                        BeKillId = beKill.Id,
                    };
                    m2C_CreateDropItems.Drops.Add(dropInfo);
                    main.GetComponent<UnitInfoComponent>().Drops.Add(dropInfo);
                }

                MapMessageHelper.SendToClient(main, m2C_CreateDropItems);
            }
        }
    }
}