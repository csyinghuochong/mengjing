using System;
using ET.Client;
using Unity.Mathematics;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class M2M_UnitTransferRequestHandler: MessageHandler<Scene, M2M_UnitTransferRequest, M2M_UnitTransferResponse>
    {
        protected override async ETTask Run(Scene scene, M2M_UnitTransferRequest request, M2M_UnitTransferResponse response)
        {
            Log.Debug($"M2M_UnitTransferRequest:1");
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
            Log.Debug($"M2M_UnitTransferRequest:2");
            
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

              
            Log.Debug($"M2M_UnitTransferRequest:3");
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
                    TransferHelper.AfterTransfer(unit);
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
                        unit.GetComponent<TaskComponentS>().TriggerTaskCountryEvent(TaskTargetType.PetTianTiNumber_14, 0, 1);
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
                        bool firstEnter = !teamDungeonComponent.EnterPlayers.Contains(unit.Id);
                        if (firstEnter)
                        {
                            teamDungeonComponent.EnterPlayers.Add(unit.Id);
                            if (fubenType == TeamFubenType.XieZhu && unit.Id == teamDungeonComponent.TeamInfo.TeamId)
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

                            if (fubenType == TeamFubenType.ShenYuan && unit.Id == teamDungeonComponent.TeamInfo.TeamId)
                            {
                                unit.GetComponent<BagComponentS>().OnCostItemData($"{ComHelp.ShenYuanCostId};1");
                            }

                            if (fubenType == TeamFubenType.ShenYuan)
                            {
                                unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.ShenYuanNumber_135, 0, 1);
                                unit.GetComponent<TaskComponentS>().TriggerTaskCountryEvent(TaskTargetType.ShenYuanNumber_135, 0, 1);
                            }
                        }
                    }

                    if (request.SceneType == (int)SceneTypeEnum.Tower)
                    { 
                        //Game.Scene.GetComponent<RecastPathComponent>().Update(scene.GetComponent<MapComponent>().NavMeshId);
                        unit.GetComponent<TaskComponentS>().TriggerTaskCountryEvent(TaskTargetType.Tower_1013, 0, 1);
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
                        unit.GetComponent<TaskComponentS>().TriggerTaskCountryEvent(TaskTargetType.TrialFuben_1012, 0, 1);
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

                    TransferHelper.AfterTransfer(unit);
                    break;
                
                case SceneTypeEnum.MainCityScene:
                    unit.Position = new float3(-10, 0, -10);
                    unit.AddComponent<PathfindingComponent, int>(101);
                    unit.GetComponent<HeroDataComponentS>().OnReturn();
                    break;
            }
            
            TransferHelper.AfterTransfer(unit);
            Log.Debug($"M2M_UnitTransferRequest:4");
            
            // 通知客户端创建My Unit
            M2C_CreateMyUnit m2CCreateUnits = new();
            m2CCreateUnits.Unit = UnitHelper.CreateUnitInfo(unit);
            MapMessageHelper.SendToClient(unit, m2CCreateUnits);
            Log.Debug($"M2M_UnitTransferRequest:5");
            // 加入aoi
            unit.AddComponent<AOIEntity, int, float3>(aoivalue * 1000, unit.Position);

            // 解锁location，可以接收发给Unit的消息
            await scene.Root().GetComponent<LocationProxyComponent>().UnLock(LocationType.Unit, unit.Id, request.OldActorId, unit.GetActorId());
        }
    }
}