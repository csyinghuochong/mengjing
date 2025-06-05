using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class M2M_UnitTransferRequestHandler: MessageHandler<Scene, M2M_UnitTransferRequest, M2M_UnitTransferResponse>
    {
        protected override async ETTask Run(Scene scene, M2M_UnitTransferRequest request, M2M_UnitTransferResponse response)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit unit = MongoHelper.Deserialize<Unit>(request.Unit);
            unitComponent.AddChild(unit);
            unitComponent.Add(unit);
            foreach (byte[] bytes in request.Entitys)
            {
                try
                {
                    Entity entity = MongoHelper.Deserialize<Entity>(bytes);
                    unit.AddComponent(entity);
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
           
            unit.AddComponent<MoveComponent>();
            unit.AddComponent<SkillManagerComponentS>();
            unit.AddComponent<BuffManagerComponentS>();
            unit.AddComponent<AttackRecordComponent>();
            
            unit.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.OrderedMessage);
            unit.GetComponent<DBSaveComponent>().Activeted();
            
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            numericComponent.ApplyValue(NumericType.BattleCamp, CampEnum.CampPlayer_1, false);
            numericComponent.ApplyValue(NumericType.PetFightIndex, 0, false);
            numericComponent.ApplyValue(NumericType.RunRaceTransform, 0, false);
            numericComponent.ApplyValue(NumericType.CardTransform, 0, false);
            numericComponent.ApplyValue(NumericType.PetMeleeMoLiAdd, 0, false);
        
            unit.GetComponent<HeroDataComponentS>().CheckNumeric();
            Function_Fight.UnitUpdateProperty_Base(unit, false, false);

            if (request.SceneType != MapTypeEnum.CellDungeon
                && request.SceneType != MapTypeEnum.DragonDungeon)
            {
                // parminfo = scene.GetComponent<CellDungeonComponentS>().CurrentFubenCell.sonid.ToString();
                // 通知客户端开始切场景
                M2C_StartSceneChange m2CStartSceneChange = new() { SceneInstanceId = scene.InstanceId, SceneId = request.SceneId, SceneType = request.SceneType, Difficulty = request.Difficulty, ParamInfo = request.ParamInfo };
                MapMessageHelper.SendToClient(unit, m2CStartSceneChange);
            }

            int aoivalue = 9;
            M2C_CreateMyUnit m2CCreateUnits =  M2C_CreateMyUnit.Create();;
            switch (request.SceneType)
            {
                case (int)MapTypeEnum.PetMing:
                case (int)MapTypeEnum.PetDungeon:
                case (int)MapTypeEnum.PetTianTi:
                case (int)MapTypeEnum.PetMelee:
                case (int)MapTypeEnum.PetMatch:
                    SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                    scene.GetComponent<MapComponent>().NavMeshId = sceneConfig.MapID;
                    unit.AddComponent<PathfindingComponent, int>(sceneConfig.MapID);

                    float posx = sceneConfig.InitPos[0] * 0.01f;
                    float posy = sceneConfig.InitPos[1] * 0.01f;
                    float posz = sceneConfig.InitPos[2] * 0.01f;
                    
                    //更新unit坐标
                    unit.Position = new float3(posx, posy, posz);
                    unit.Rotation = quaternion.identity;

                    // 加入aoi
                    if (request.SceneType == (int)MapTypeEnum.PetDungeon)
                    {
                        scene.GetComponent<PetDungeonComponent>().GenerateFuben(unit, int.Parse(request.ParamInfo));
                    }
                    if (request.SceneType == (int)MapTypeEnum.PetTianTi)
                    {
                        aoivalue = 40;
                        
                        scene.GetComponent<PetTianTiDungeonComponent>().MainUnit = unit;
                        scene.GetComponent<PetTianTiDungeonComponent>().GenerateFuben().Coroutine();
                        unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.PetTianTiNumber_14,0, 1 );
                        unit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.PetTianTiNumber_310, 0, 1);
                    }
                    if (request.SceneType == (int)MapTypeEnum.PetMing)
                    {
                        aoivalue = 40;
                        scene.GetComponent<PetMingDungeonComponent>().GenerateFuben().Coroutine();
                    }
                    if (request.SceneType == (int)MapTypeEnum.PetMelee)
                    {
                        scene.GetComponent<PetMeleeDungeonComponent>().SetPlayer(unit);
                        aoivalue = 40;
                    }
                    if (request.SceneType == (int)MapTypeEnum.PetMatch)
                    {
                        PetMeleeDungeonComponent petMeleeDungeonComponent = scene.GetComponent<PetMeleeDungeonComponent>();
                        List<Unit> playerList = UnitHelper.GetUnitList(scene, UnitType.Player);
                        int battlecamp = 0;
                        if (playerList.Count <= 1)
                        {
                            battlecamp  = RandomHelper.RandomNumber(1,3);
                        }
                        else
                        {
                            battlecamp = playerList[0].GetBattleCamp() == CampEnum.CampPlayer_1 ? CampEnum.CampPlayer_2 : CampEnum.CampPlayer_1;
                        }
                        numericComponent.ApplyValue(NumericType.BattleCamp, battlecamp, false);
                        petMeleeDungeonComponent.SetPlayer(unit);
                        aoivalue = 40;
                    }
                    // 通知客户端创建My Unit
                    m2CCreateUnits.Unit = MapMessageHelper.CreateUnitInfo(unit);
                    MapMessageHelper.SendToClient(unit, m2CCreateUnits);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(aoivalue * 1000, unit.Position);

                    break;
                case  MapTypeEnum.LocalDungeon:
                    DungeonConfig dungeonConfig = DungeonConfigCategory.Instance.Get(request.SceneId);
                    int transferId = int.Parse(request.ParamInfo);
                    if (transferId != 0)
                    {
                        DungeonTransferConfig transferConfig = DungeonTransferConfigCategory.Instance.Get(transferId);
                        unit.Position = new float3(transferConfig.BornPos[0] * 0.01f, transferConfig.BornPos[1] * 0.01f, transferConfig.BornPos[2] * 0.01f);
                    }
                    else
                    {
                        unit.Position = new float3(dungeonConfig.BornPosLeft[0] * 0.01f, dungeonConfig.BornPosLeft[1] * 0.01f, dungeonConfig.BornPosLeft[2] * 0.01f);
                    }
                    // 通知客户端创建My Unit
                    m2CCreateUnits.Unit = MapMessageHelper.CreateUnitInfo(unit);
                    MapMessageHelper.SendToClient(unit, m2CCreateUnits);
                    aoivalue = 12;
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(aoivalue * 1000, unit.Position);

                    unit.AddComponent<PathfindingComponent, int>(dungeonConfig.MapID);
                    scene.GetComponent<LocalDungeonComponent>().MainUnit = unit;
                    scene.GetComponent<LocalDungeonComponent>().GenerateFuben(request.SceneId);
                    break;
                case MapTypeEnum.CellDungeon:
                    
                    CellDungeonComponentS fubenComponentS = scene.GetComponent<CellDungeonComponentS>();
                    //起始格子
                    fubenComponentS.OnEnterFirstCell(unit, request);
                    
                    // 通知客户端创建My Unit
                    m2CCreateUnits.Unit = MapMessageHelper.CreateUnitInfo(unit);
                    MapMessageHelper.SendToClient(unit, m2CCreateUnits);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(aoivalue * 1000, unit.Position);

                    break;
                case MapTypeEnum.DragonDungeon:
                  
                    DragonDungeonComponentS dragonDungeonComponentS  =scene.GetComponent<DragonDungeonComponentS>();
                    dragonDungeonComponentS.OnEnterFirstCell(unit, request);
                    
                    // 通知客户端创建My Unit
                    m2CCreateUnits.Unit = MapMessageHelper.CreateUnitInfo(unit);
                    MapMessageHelper.SendToClient(unit, m2CCreateUnits);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(aoivalue * 1000, unit.Position);

                    break;
                case MapTypeEnum.JiaYuan:
                case MapTypeEnum.Union:
                case MapTypeEnum.BaoZang:
                case MapTypeEnum.MiJing:
                case MapTypeEnum.Tower:
                case MapTypeEnum.TeamDungeon:
                case MapTypeEnum.RandomTower:
                case MapTypeEnum.TrialDungeon:
                case MapTypeEnum.SeasonTower:
                    unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
                    sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                    unit.Position = new float3(sceneConfig.InitPos[0] * 0.01f, sceneConfig.InitPos[1] * 0.01f, sceneConfig.InitPos[2] * 0.01f);
                    unit.Rotation = quaternion.identity;
                    
                    // 通知客户端创建My Unit
                    m2CCreateUnits.Unit = MapMessageHelper.CreateUnitInfo(unit);
                    MapMessageHelper.SendToClient(unit, m2CCreateUnits);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(aoivalue * 1000, unit.Position);

                    if ( request.SceneType == MapTypeEnum.TeamDungeon)
                    {
                        TeamDungeonComponent teamDungeonComponent = unit.Scene().GetComponent<TeamDungeonComponent>();
                        teamDungeonComponent.OnEnterDungeon(unit);
                    }

                    if (request.SceneType == (int)MapTypeEnum.Tower)
                    { 
                        //Game.Scene.GetComponent<RecastPathComponent>().Update(scene.GetComponent<MapComponent>().NavMeshId);
                        unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.Tower_1013, 0, 1);
                    }

                    if (request.SceneType == MapTypeEnum.RandomTower)
                    {
                        //Game.Scene.GetComponent<RecastPathComponent>().Update(scene.GetComponent<MapComponent>().NavMeshId);
                        //scene.GetComponent<RandomTowerComponent>().MainUnit = unit;
                    }

                    if (request.SceneType == MapTypeEnum.TrialDungeon)
                    {
                        //Game.Scene.GetComponent<RecastPathComponent>().Update(scene.GetComponent<MapComponent>().NavMeshId);
                        scene.GetComponent<TrialDungeonComponent>().GenerateFuben(int.Parse(request.ParamInfo));
                        unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.TrialFuben_1012, 0, 1);
                    }

                    if (request.SceneType == MapTypeEnum.SeasonTower)
                    {
                        //Game.Scene.GetComponent<RecastPathComponent>().Update(scene.GetComponent<MapComponent>().NavMeshId);
                        scene.GetComponent<SeasonTowerComponent>().GenerateFuben(int.Parse(request.ParamInfo));
                    }
                    break;
                case MapTypeEnum.SealTower:
                    unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
                    sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);

                    float pos_x = sceneConfig.InitPos[0] * 0.01f;
                    float pos_y = sceneConfig.InitPos[1] * 0.01f;
                    float pos_z = sceneConfig.InitPos[2] * 0.01f;
                    unit.Position = new float3(pos_x, pos_y, pos_z);
                    unit.Rotation = quaternion.identity;

                    // 通知客户端创建My Unit
                    m2CCreateUnits.Unit = MapMessageHelper.CreateUnitInfo(unit);
                    MapMessageHelper.SendToClient(unit, m2CCreateUnits);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(aoivalue * 1000, unit.Position);

                    //Game.Scene.GetComponent<RecastPathComponent>().Update(scene.GetComponent<MapComponent>().NavMeshId);
                    int towerarrived = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.SealTowerArrived);
                    int towerfinished = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.SealTowerFinished);
                    scene.GetComponent<SealTowerComponent>().GenerateFuben(towerarrived,towerfinished);
                    break;
                case MapTypeEnum.Solo:
                    numericComponent.ApplyValue(NumericType.JueXingAnger, 0, false);
                    unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
                    sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                    List<Unit> units =  UnitHelper.GetUnitList(unit.Scene(), UnitType.Player );
                    if (units.Count == 1)
                    {
                        //第1个人
                        unit.Position = new float3(sceneConfig.InitPos[0] * 0.01f, sceneConfig.InitPos[1] * 0.01f, sceneConfig.InitPos[2] * 0.01f);
                    }

                    if (units.Count == 2)
                    {
                        //第2个人
                        unit.Position = new float3(10.07f, 0f, 0.27f);
                    }

                    unit.Rotation = quaternion.identity;
                    // 通知客户端创建My Unit
                    m2CCreateUnits.Unit = MapMessageHelper.CreateUnitInfo(unit);
                    MapMessageHelper.SendToClient(unit, m2CCreateUnits);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(aoivalue * 1000, unit.Position);

                    break;
                case MapTypeEnum.RunRace:
                    unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
                    sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                    unit.Position = new float3(sceneConfig.InitPos[0] * 0.01f + RandomHelper.RandomNumberFloat(-1f, 1f), sceneConfig.InitPos[1] * 0.01f, sceneConfig.InitPos[2] * 0.01f + RandomHelper.RandomNumberFloat(-1f, 1f));
                    unit.Rotation = quaternion.identity;

                    // 通知客户端创建My Unit
                    m2CCreateUnits.Unit = MapMessageHelper.CreateUnitInfo(unit);
                    MapMessageHelper.SendToClient(unit, m2CCreateUnits);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(aoivalue * 1000, unit.Position);

                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.HorseRide, 0, false);
                    int runracemonster = ConfigData.RunRaceMonsterList[RandomHelper.RandomNumber(0, ConfigData.RunRaceMonsterList.Count)];
                    numericComponent.ApplyValue(NumericType.RunRaceTransform, runracemonster, false);
                    Function_Fight.UnitUpdateProperty_RunRace(unit, false);
                    unit.Scene().GetComponent<RunRaceDungeonComponent>().OnEnter(unit);
                    break;
                case MapTypeEnum.Happy:
                    unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
                    sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);

                    int happcellIndex = numericComponent.GetAsInt(NumericType.HappyCellIndex);
                    if (happcellIndex > 0)
                    {
                        unit.Position = HappyData.PositionList[happcellIndex - 1];
                    }
                    else
                    {
                        int randomPosition = RandomHelper.RandomNumber(0, HappyData.PositionList.Count);
                        numericComponent.ApplyValue(NumericType.HappyCellIndex, randomPosition + 1, false);
                        unit.Position = HappyData.PositionList[randomPosition];
                    }
                    aoivalue = 40;
                    // 通知客户端创建My Unit
                    m2CCreateUnits.Unit = MapMessageHelper.CreateUnitInfo(unit);
                    MapMessageHelper.SendToClient(unit, m2CCreateUnits);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(aoivalue * 1000, unit.Position);

                    unit.Scene().GetComponent<HappyDungeonComponent>().NoticeRefreshTime(unit);
                    break;
                case MapTypeEnum.SingleHappy:
                    sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                    scene.GetComponent<MapComponent>().NavMeshId = sceneConfig.MapID;
                    unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
                    happcellIndex = numericComponent.GetAsInt(NumericType.SingleHappyCellIndex);
                    
                    if (happcellIndex > 0)
                    {
                        unit.Position = HappyData.PositionList[happcellIndex - 1];
                        unit.Scene().GetComponent<SingleHappyDungeonComponent>().OnRestore(unit);
                    }
                    else
                    {
                        int randomPosition = 40;
                        numericComponent.ApplyValue(NumericType.SingleHappyCellIndex, randomPosition + 1, false);
                        unit.Position = HappyData.PositionList[randomPosition];
                        unit.Scene().GetComponent<SingleHappyDungeonComponent>().OnTimer(unit);
                    }
                    aoivalue = 40;
                    // 通知客户端创建My Unit
                    m2CCreateUnits.Unit = MapMessageHelper.CreateUnitInfo(unit);
                    MapMessageHelper.SendToClient(unit, m2CCreateUnits);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(aoivalue * 1000, unit.Position);
                    break;
                case MapTypeEnum.Battle:
                    //int todayCamp = numericComponent.GetAsInt(NumericType.BattleTodayCamp);
                    //todayCamp = todayCamp > 0 ? todayCamp : int.Parse(request.ParamInfo);
                    int todayCamp = int.Parse(request.ParamInfo);
                    numericComponent.ApplyValue(NumericType.BattleCamp, todayCamp, false); //1 2
                    unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
                    sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                    int startIndex = todayCamp == 1 ? 0 : 3;
                    unit.Position = new float3(sceneConfig.InitPos[startIndex+0] * 0.01f, sceneConfig.InitPos[startIndex + 1] * 0.01f, sceneConfig.InitPos[startIndex + 2] * 0.01f);
                    unit.Rotation = quaternion.identity;
                    // 通知客户端创建My Unit
                    m2CCreateUnits.Unit = MapMessageHelper.CreateUnitInfo(unit);
                    MapMessageHelper.SendToClient(unit, m2CCreateUnits);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(aoivalue * 1000, unit.Position);

                    break;
                case MapTypeEnum.MainCityScene:
                    float last_x = numericComponent.GetAsFloat(NumericType.MainCity_X);
                    float last_y = numericComponent.GetAsFloat(NumericType.MainCity_Y);
                    float last_z = numericComponent.GetAsFloat(NumericType.MainCity_Z);
                    sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                    if (last_x ==0f)
                    {
                        unit.Position = new float3(sceneConfig.InitPos[0] * 0.01f, sceneConfig.InitPos[1] * 0.01f, sceneConfig.InitPos[2] * 0.01f);
                    }
                    else
                    {
                        unit.Position = new float3(last_x, last_y, last_z);
                    }
                    // 通知客户端创建My Unit
                    m2CCreateUnits.Unit = MapMessageHelper.CreateUnitInfo(unit);
                    MapMessageHelper.SendToClient(unit, m2CCreateUnits);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(aoivalue * 1000, unit.Position);

                    unit.AddComponent<PathfindingComponent, int>(101);
                    unit.GetComponent<HeroDataComponentS>().OnReturn();
                    break;
            }
          
            TransferHelper.AfterTransfer(unit, request.SceneType);
            TransferHelper.RemoveStall(unit);
            if (SceneConfigHelper.IsCanRideHorse(request.SceneType))
            {
                unit.GetComponent<BuffManagerComponentS>().InitBuff(request.SceneType);
                unit.GetComponent<SkillPassiveComponent>().Reset();
                unit.GetComponent<SkillPassiveComponent>().Begin();
                unit.OnUpdateHorseRide(0);
                unit.TriggerTeamBuff(request.SceneType);
            }

            // 解锁location，可以接收发给Unit的消息
            await scene.Root().GetComponent<LocationProxyComponent>().UnLock(LocationType.Unit, unit.Id, request.OldActorId, unit.GetActorId());
        }
    }
}