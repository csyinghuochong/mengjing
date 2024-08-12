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
            //Console.WriteLine($"M2M_UnitTransferRequest:1");
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
            numericComponent.ApplyValue(NumericType.RunRaceTransform, 0, false);
            numericComponent.ApplyValue(NumericType.CardTransform, 0, false);
        
            unit.GetComponent<HeroDataComponentS>().CheckNumeric();
            Function_Fight.UnitUpdateProperty_Base(unit, false, false);
            
            ///暂时写在这 没想到好的解决方案。
            scene.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession).Remove(unit.Id);
            scene.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Remove(unit.Id);
            
            // 通知客户端开始切场景
            M2C_StartSceneChange m2CStartSceneChange = new() { SceneInstanceId = scene.InstanceId, SceneId = request.SceneId, SceneType = request.SceneType, Difficulty = request.Difficulty, ParamInfo = request.ParamInfo };
            MapMessageHelper.SendToClient(unit, m2CStartSceneChange);
            
            int aoivalue = 5;
            switch (request.SceneType)
            {
                case SceneTypeEnum.CellDungeon:
                    int sonid = scene.GetComponent<CellDungeonComponent>().CurrentFubenCell.sonid;
                    ChapterSonConfig chapterSon = ChapterSonConfigCategory.Instance.Get(sonid);
                    unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
                    //Game.Scene.GetComponent<RecastPathComponent>().Update(scene.GetComponent<MapComponent>().NavMeshId);
                    //更新unit坐标
                    unit.Position = new float3(chapterSon.BornPosLeft[0] * 0.01f, chapterSon.BornPosLeft[1] * 0.01f, chapterSon.BornPosLeft[2] * 0.01f);
                    unit.Rotation = quaternion.identity;
                    scene.GetComponent<CellDungeonComponent>().GenerateFubenScene(false);
                    break;
                case (int)SceneTypeEnum.PetMing:
                case (int)SceneTypeEnum.PetDungeon:
                case (int)SceneTypeEnum.PetTianTi:
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
                    if (request.SceneType == (int)SceneTypeEnum.PetDungeon)
                    {
                        scene.GetComponent<PetFubenComponent>().GeneratePetFuben(unit, int.Parse(request.ParamInfo));
                    }
                    if (request.SceneType == (int)SceneTypeEnum.PetTianTi)
                    {
                        aoivalue = 40;
                        
                        scene.GetComponent<PetTianTiComponent>().MainUnit = unit;
                        scene.GetComponent<PetTianTiComponent>().GeneratePetFuben().Coroutine();
                        unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.PetTianTiNumber_14,0, 1 );
                        unit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.PetTianTiNumber_310, 0, 1);
                    }
                    if (request.SceneType == (int)SceneTypeEnum.PetMing)
                    {
                        scene.GetComponent<PetMingDungeonComponent>().MainUnit = unit;
                        scene.GetComponent<PetMingDungeonComponent>().GeneratePetFuben().Coroutine();
                    }
                    break;
                case  SceneTypeEnum.LocalDungeon:
                    unit.Position = new float3(-0.72f, 0, -2.57f);
                    unit.AddComponent<PathfindingComponent, int>(10001);
                    scene.GetComponent<LocalDungeonComponent>().MainUnit = unit;
                    scene.GetComponent<LocalDungeonComponent>().GenerateFubenScene(request.SceneId);
                    break;
                case SceneTypeEnum.JiaYuan:
                case SceneTypeEnum.Union:
                case SceneTypeEnum.BaoZang:
                case SceneTypeEnum.MiJing:
                case SceneTypeEnum.Tower:
                case SceneTypeEnum.TeamDungeon:
                case SceneTypeEnum.RandomTower:
                case SceneTypeEnum.TrialDungeon:
                case SceneTypeEnum.SeasonTower:
                    unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
                    sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                    unit.Position = new float3(sceneConfig.InitPos[0] * 0.01f, sceneConfig.InitPos[1] * 0.01f, sceneConfig.InitPos[2] * 0.01f);
                    unit.Rotation = quaternion.identity;
                    if (!unit.IsRobot() && request.SceneType == SceneTypeEnum.TeamDungeon)
                    {
                        TeamDungeonComponent teamDungeonComponent = unit.Scene().GetComponent<TeamDungeonComponent>();
                        int fubenType = teamDungeonComponent.FubenType;
                        bool firstEnter = !teamDungeonComponent.TeamPlayers.ContainsKey(unit.Id);
                        if (firstEnter)
                        {
                            teamDungeonComponent.AddPlayerList( unit.Id );
                            if (fubenType == TeamFubenType.XieZhu && unit.Id == teamDungeonComponent.TeamId)
                            {
                                int times_2 = unit.GetTeamDungeonXieZhu();
                                int totalTimes_2 = int.Parse(GlobalValueConfigCategory.Instance.Get(74).Value);
                                if (totalTimes_2 > times_2)
                                {
                                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.TeamDungeonXieZhu, unit.GetTeamDungeonXieZhu() + 1);
                                }
                                else
                                {
                                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.TeamDungeonTimes, unit.GetTeamDungeonTimes() + 1);
                                }
                            }
                            else
                            {
                                unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.TeamDungeonTimes, unit.GetTeamDungeonTimes() + 1);
                            }

                            if (fubenType == TeamFubenType.ShenYuan && unit.Id == teamDungeonComponent.TeamId)
                            {
                                unit.GetComponent<BagComponentS>().OnCostItemData($"{CommonHelp.ShenYuanCostId};1");
                            }

                            if (fubenType == TeamFubenType.ShenYuan)
                            {
                                unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.ShenYuanNumber_135, 0, 1);
                            }
                        }
                    }

                    if (request.SceneType == (int)SceneTypeEnum.Tower)
                    { 
                        //Game.Scene.GetComponent<RecastPathComponent>().Update(scene.GetComponent<MapComponent>().NavMeshId);
                        unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.Tower_1013, 0, 1);
                    }

                    if (request.SceneType == SceneTypeEnum.RandomTower)
                    {
                        //Game.Scene.GetComponent<RecastPathComponent>().Update(scene.GetComponent<MapComponent>().NavMeshId);
                        //scene.GetComponent<RandomTowerComponent>().MainUnit = unit;
                    }

                    if (request.SceneType == SceneTypeEnum.TrialDungeon)
                    {
                        //Game.Scene.GetComponent<RecastPathComponent>().Update(scene.GetComponent<MapComponent>().NavMeshId);
                        scene.GetComponent<TrialDungeonComponent>().GenerateFuben(int.Parse(request.ParamInfo));
                        unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.TrialFuben_1012, 0, 1);
                    }

                    if (request.SceneType == SceneTypeEnum.SeasonTower)
                    {
                        //Game.Scene.GetComponent<RecastPathComponent>().Update(scene.GetComponent<MapComponent>().NavMeshId);
                        scene.GetComponent<SeasonTowerComponent>().GenerateFuben(int.Parse(request.ParamInfo));
                    }
                    break;
                case SceneTypeEnum.SealTower:
                    unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
                    sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);

                    float pos_x = sceneConfig.InitPos[0] * 0.01f;
                    float pos_y = sceneConfig.InitPos[1] * 0.01f;
                    float pos_z = sceneConfig.InitPos[2] * 0.01f;
                    unit.Position = new float3(pos_x, pos_y, pos_z);
                    unit.Rotation = quaternion.identity;

                    //Game.Scene.GetComponent<RecastPathComponent>().Update(scene.GetComponent<MapComponent>().NavMeshId);
                    int towerarrived = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.SealTowerArrived);
                    int towerfinished = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.SealTowerFinished);
                    scene.GetComponent<SealTowerComponent>().GenerateFuben(towerarrived,towerfinished);
                    break;
                case SceneTypeEnum.Solo:
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
                    break;
                case SceneTypeEnum.RunRace:
                    unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
                    sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                    unit.Position = new float3(sceneConfig.InitPos[0] * 0.01f + RandomHelper.RandomNumberFloat(-1f, 1f), sceneConfig.InitPos[1] * 0.01f, sceneConfig.InitPos[2] * 0.01f + RandomHelper.RandomNumberFloat(-1f, 1f));
                    unit.Rotation = quaternion.identity;

                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.HorseRide, 0, false);
                    int runracemonster = ConfigData.RunRaceMonsterList[RandomHelper.RandomNumber(0, ConfigData.RunRaceMonsterList.Count)];
                    numericComponent.ApplyValue(NumericType.RunRaceTransform, runracemonster, false);
                    Function_Fight.UnitUpdateProperty_RunRace(unit, false);
                    unit.Scene().GetComponent<RunRaceDungeonComponent>().OnEnter(unit);
                    break;
                case SceneTypeEnum.Happy:
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
                    unit.Scene().GetComponent<HappyDungeonComponent>().NoticeRefreshTime(unit);
                    break;
                case SceneTypeEnum.Battle:
                    //int todayCamp = numericComponent.GetAsInt(NumericType.BattleTodayCamp);
                    //todayCamp = todayCamp > 0 ? todayCamp : int.Parse(request.ParamInfo);
                    int todayCamp = int.Parse(request.ParamInfo);
                    numericComponent.Set(NumericType.BattleCamp, todayCamp); //1 2
                    //numericComponent.Set(NumericType.BattleTodayCamp, todayCamp); //1 2
                    unit.AddComponent<PathfindingComponent, int>(scene.GetComponent<MapComponent>().NavMeshId);
                    sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                    int startIndex = todayCamp == 1 ? 0 : 3;
                    unit.Position = new float3(sceneConfig.InitPos[startIndex+0] * 0.01f, sceneConfig.InitPos[startIndex + 1] * 0.01f, sceneConfig.InitPos[startIndex + 2] * 0.01f);
                    unit.Rotation = quaternion.identity;

                    break;
                case SceneTypeEnum.MainCityScene:
                    float last_x = numericComponent.GetAsFloat(NumericType.MainCity_X);
                    float last_y = numericComponent.GetAsFloat(NumericType.MainCity_Y);
                    float last_z = numericComponent.GetAsFloat(NumericType.MainCity_Z);
                    if (last_x ==0f)
                    {
                        unit.Position = new float3(-10, 0, -10);
                    }
                    else
                    {
                        unit.Position = new float3(last_x, last_y, last_z);
                    }

                    unit.AddComponent<PathfindingComponent, int>(101);
                    unit.GetComponent<HeroDataComponentS>().OnReturn();
                    break;
            }
            
            TransferHelper.AfterTransfer(unit, request.SceneType);
            
            // 通知客户端创建My Unit
            M2C_CreateMyUnit m2CCreateUnits = M2C_CreateMyUnit.Create();
            m2CCreateUnits.Unit = MapMessageHelper.CreateUnitInfo(unit);
            MapMessageHelper.SendToClient(unit, m2CCreateUnits);

            // 加入aoi
            unit.AddComponent<AOIEntity, int, float3>(aoivalue * 1000, unit.Position);

            // 解锁location，可以接收发给Unit的消息
            await scene.Root().GetComponent<LocationProxyComponent>().UnLock(LocationType.Unit, unit.Id, request.OldActorId, unit.GetActorId());
        }
    }
}