using System.Collections.Generic;
using MongoDB.Bson;
using Unity.Mathematics;

namespace ET.Server
{
    public static partial class TransferHelper
    {

        public static async ETTask<int> TransferUnit(Unit unit, C2M_TransferMap request)
        {
            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Transfer, unit.Id))
            {
                if (unit.IsDisposed)
                {
                    return ErrorCode.ERR_RequestRepeatedly;
                }
                int oldScene = unit.Root().GetComponent<MapComponent>().SceneType;
                if (!SceneConfigHelper.CanTransfer(oldScene, request.SceneType))
                {
                    Log.Debug($"LoginTest1  Actor_Transfer unitId{unit.Id} oldScene:{oldScene}  requestscene{request.SceneType}");
                    return ErrorCode.ERR_RequestRepeatedly;
                }
                UserInfoComponentServer userInfoComponent = unit.GetComponent<UserInfoComponentServer>();
                if (SceneConfigHelper.UseSceneConfig(request.SceneType) && request.SceneId > 0)
                {
                    if (!SceneConfigCategory.Instance.Contain(request.SceneId))
                    {
                        return ErrorCode.ERR_TimesIsNot;
                    }

                    SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                    if (sceneConfig.DayEnterNum > 0 && sceneConfig.DayEnterNum <= userInfoComponent.GetSceneFubenTimes(request.SceneId))
                    {
                        return ErrorCode.ERR_TimesIsNot;
                    }
                    if (sceneConfig.EnterLv > userInfoComponent.GetUserLv())
                    {
                        return ErrorCode.ERR_LevelIsNot;
                    }
                    userInfoComponent.AddSceneFubenTimes(request.SceneId);
                }
                if (oldScene == SceneTypeEnum.MainCityScene && request.SceneType > SceneTypeEnum.MainCityScene)
                {
                    unit.RecordPostion(request.SceneType, request.SceneId);
                }

                switch (request.SceneType)
                {
                    case SceneTypeEnum.MainCityScene:
                        await TransferHelper.MainCityTransfer(unit);
                        break;
                    case (int)SceneTypeEnum.CellDungeon:
                        break;
                    //宠物闯关
                    case (int)SceneTypeEnum.PetDungeon:
                        int petfubenid = int.Parse(request.paramInfo);
                        if (!PetFubenConfigCategory.Instance.Contain(petfubenid))
                        {
                            return ErrorCode.ERR_ModifyData;
                        }
                        Scene oldscene = unit.Root();
                        MapComponent mapComponent = oldscene.GetComponent<MapComponent>();
                        int sceneTypeEnum = mapComponent.SceneType;
                        long fubenid = IdGenerater.Instance.GenerateId();
                        long fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                        
                        Scene fubnescene = await GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId, "PetFuben" + fubenid.ToString());
                        fubnescene.AddComponent<PetFubenComponent>();
                        fubnescene.GetComponent<MapComponent>().SetMapInfo((int)SceneTypeEnum.PetDungeon, request.SceneId, int.Parse(request.paramInfo));
                        TransferHelper.BeforeTransfer(unit);
                        await TransferHelper.Transfer(unit, fubnescene.GetActorId(), (int)SceneTypeEnum.PetDungeon, request.SceneId, FubenDifficulty.None, request.paramInfo);
                        TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
                        if (SceneConfigHelper.IsSingleFuben(sceneTypeEnum))
                        {
                            TransferHelper.NoticeFubenCenter(oldscene, 2).Coroutine();
                            oldscene.Dispose();
                        }
                        break;
                    case (int)SceneTypeEnum.TrialDungeon:
                        fubenid = IdGenerater.Instance.GenerateId();
                        fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                        fubnescene = await GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId,  "TrialDungeon" + fubenid.ToString());
                        fubnescene.AddComponent<TrialDungeonComponent>();
                        mapComponent = fubnescene.GetComponent<MapComponent>();
                        mapComponent.SetMapInfo((int)SceneTypeEnum.TrialDungeon, request.SceneId, int.Parse(request.paramInfo));
                        mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(request.SceneId).MapID;
                        TransferHelper.BeforeTransfer(unit);
                        await TransferHelper.Transfer(unit, fubnescene.GetActorId(), (int)SceneTypeEnum.TrialDungeon, request.SceneId, FubenDifficulty.None, request.paramInfo);
                        TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
                        break;
                    case SceneTypeEnum.SeasonTower:
                        //计算赛季之塔下一关
                        int seasonTowerid = unit.GetComponent<NumericComponentServer>().GetAsInt(NumericType.SeasonTowerId);
                        if (seasonTowerid == 0)
                        {
                            request.paramInfo = TowerHelper.GetFirstTowerIdByScene(SceneTypeEnum.SeasonTower).ToString();
                        }
                        else
                        {
                            if (!TowerConfigCategory.Instance.Contain(seasonTowerid + 1))
                            {
                                return ErrorCode.ERR_TowerOfSealReachTop;
                            }
                            request.paramInfo = (seasonTowerid + 1).ToString();
                        }

                        fubenid = IdGenerater.Instance.GenerateId();
                        fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                        fubnescene = await GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId,  "SeasonTower" + fubenid.ToString());
                        fubnescene.AddComponent<SeasonTowerComponent>();
                        mapComponent = fubnescene.GetComponent<MapComponent>();
                        mapComponent.SetMapInfo((int)SceneTypeEnum.SeasonTower, request.SceneId, int.Parse(request.paramInfo));
                        mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(request.SceneId).MapID;
                        TransferHelper.BeforeTransfer(unit);
                        await TransferHelper.Transfer(unit, fubnescene.GetActorId(), (int)SceneTypeEnum.SeasonTower, request.SceneId, FubenDifficulty.None, request.paramInfo);
                        TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
                        break;
                    case SceneTypeEnum.TowerOfSeal:
                        int finished = unit.GetComponent<NumericComponentServer>().GetAsInt(NumericType.TowerOfSealFinished);
                        // 服务端再判断是否已经通关塔顶
                        if (finished >= 100)
                        {
                            return ErrorCode.ERR_TowerOfSealReachTop;
                        }

                        fubenid = IdGenerater.Instance.GenerateId();
                        fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                        fubnescene =  await GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId,"TowerOfSeal" + fubenid.ToString());
                        fubnescene.AddComponent<TowerOfSealComponent>();
                        mapComponent = fubnescene.GetComponent<MapComponent>();
                        mapComponent.SetMapInfo((int)SceneTypeEnum.TowerOfSeal, request.SceneId, int.Parse(request.paramInfo));
                        mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(request.SceneId).MapID;
                        TransferHelper.BeforeTransfer(unit);
                        await TransferHelper.Transfer(unit, fubnescene.GetActorId(), (int)SceneTypeEnum.TowerOfSeal, request.SceneId, FubenDifficulty.None, request.paramInfo);
                        TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
                        break;
                    case (int)SceneTypeEnum.RandomTower:
                        //2200001
                        fubenid = IdGenerater.Instance.GenerateId();
                        fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                        fubnescene = await GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId,  "RandomTower" + fubenid.ToString());
                        fubnescene.AddComponent<RandomTowerComponent>();
                        mapComponent = fubnescene.GetComponent<MapComponent>();
                        mapComponent.SetMapInfo((int)SceneTypeEnum.RandomTower, request.SceneId, 0);
                        mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(request.SceneId).MapID;
                        TransferHelper.BeforeTransfer(unit);
                        await TransferHelper.Transfer(unit, fubnescene.GetActorId(), (int)SceneTypeEnum.RandomTower, request.SceneId, 0, "0");
                        TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
                        break;
                    case (int)SceneTypeEnum.Union:
                        long unionid = unit.GetComponent<NumericComponentServer>().GetAsLong(NumericType.UnionId_0);
                        if (unionid == 0)
                        {
                            return ErrorCode.ERR_Union_Not_Exist;
                        }
                        ActorId mapInstanceId = UnitCacheHelper.GetUnionServerId(unit.Zone());
                        // U2M_UnionEnterResponse responseUnionEnter = (U2M_UnionEnterResponse)await unit.Root().GetComponent<MessageSender>().Call(
                        // mapInstanceId, new M2U_UnionEnterRequest() { UnionId = unionid, UnitId = unit.Id, SceneId = request.SceneId });
                        //TransferHelper.BeforeTransfer(unit);
                        //await TransferHelper.Transfer(unit, responseUnionEnter.FubenInstanceId, (int)SceneTypeEnum.Union, request.SceneId, request.Difficulty, "0");
                        break;
                    case (int)SceneTypeEnum.JiaYuan:
                        //动态创建副本
                        Scene scene = unit.Root();
                        mapInstanceId = UnitCacheHelper.GetJiaYuanServerId(unit.Zone());
                        ///进入之前先刷新一下
                        // if (long.Parse(request.paramInfo) == unit.Id)
                        // {
                        //     JiaYuanComponent jiaYuanComponent = unit.GetComponent<JiaYuanComponent>();
                        //     jiaYuanComponent.OnBeforEnter();
                        //     await DBHelper.SaveComponent(unit.DomainZone(), unit.Id, jiaYuanComponent);
                        // }
                        // J2M_JiaYuanEnterResponse j2M_JianYuanEnterResponse = (J2M_JiaYuanEnterResponse)await ActorMessageSenderComponent.Instance.Call(
                        // mapInstanceId, new M2J_JiaYuanEnterRequest() { MasterId = long.Parse(request.paramInfo), UnitId = unit.Id, SceneId = request.SceneId });
                        // TransferHelper.BeforeTransfer(unit);
                        // await TransferHelper.Transfer(unit, j2M_JianYuanEnterResponse.FubenInstanceId, (int)SceneTypeEnum.JiaYuan, request.SceneId, request.Difficulty, "0");
                        //
                        // if (oldScene == SceneTypeEnum.JiaYuan)
                        // {
                        //     JiaYuanSceneComponent jiayuanSceneComponent = scene.GetParent<JiaYuanSceneComponent>();
                        //     jiayuanSceneComponent.OnUnitLeave(scene);
                        // }
                        break;
                    case (int)SceneTypeEnum.Tower:
                        //动态创建副本
                        fubenid = IdGenerater.Instance.GenerateId();
                        fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                        // fubnescene = SceneFactory.Create(Game.Scene, fubenid, fubenInstanceId, unit.DomainZone(), "Tower" + fubenid.ToString(), SceneType.Fuben);
                        // fubnescene.AddComponent<TowerComponent>().FubenDifficulty = request.Difficulty;
                        // mapComponent = fubnescene.GetComponent<MapComponent>();
                        // mapComponent.SetMapInfo((int)SceneTypeEnum.Tower, request.SceneId, 0);
                        // mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(request.SceneId).MapID;
                        // TransferHelper.BeforeTransfer(unit);
                        // await TransferHelper.Transfer(unit, fubenInstanceId, (int)SceneTypeEnum.Tower, request.SceneId, request.Difficulty, "0");
                        // TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
                        break;
                    case SceneTypeEnum.OneChallenge:
                        fubenid = long.Parse(request.paramInfo);
                        // fubnescene = Game.Scene.Get(fubenid);
                        // bool newdungeon = false;
                        // if (fubnescene == null)
                        // {
                        //     newdungeon = true;
                        //     fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                        //     fubnescene = SceneFactory.Create(Game.Scene, fubenid, fubenInstanceId, unit.DomainZone(), "OneChallenge" + fubenid.ToString(), SceneType.Fuben);
                        //     mapComponent = fubnescene.GetComponent<MapComponent>();
                        //     mapComponent.SetMapInfo((int)SceneTypeEnum.OneChallenge, request.SceneId, 0);
                        //     mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(request.SceneId).MapID;
                        //     Game.Scene.GetComponent<RecastPathComponent>().Update(fubnescene.GetComponent<MapComponent>().NavMeshId);
                        // }
                        // fubenInstanceId = fubnescene.InstanceId;
                        // TransferHelper.BeforeTransfer(unit);
                        // await TransferHelper.Transfer(unit, fubenInstanceId, (int)SceneTypeEnum.OneChallenge, request.SceneId, request.Difficulty, "0");
                        // if (newdungeon)
                        // {
                        //     TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
                        // }
                        break;
                    case (int)SceneTypeEnum.PetMing:
                        long cdTime = unit.GetComponent<NumericComponentServer>().GetAsLong(NumericType.PetMineCDTime);
                        if (cdTime > TimeHelper.ServerNow())
                        {
                            return ErrorCode.ERR_InMakeCD;
                        }

                        string[] praminfos = request.paramInfo.Split('_');
                        // fubenid = IdGenerater.Instance.GenerateId();
                        // fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                        // fubnescene = SceneFactory.Create(Game.Scene, fubenid, fubenInstanceId, unit.DomainZone(), "Fuben" + fubenid.ToString(), SceneType.Fuben);
                        // PetMingDungeonComponent petMingDungeon = fubnescene.AddComponent<PetMingDungeonComponent>();
                        // petMingDungeon.MineType = request.Difficulty;
                        // petMingDungeon.Position = int.Parse(praminfos[0]);
                        // petMingDungeon.TeamId = int.Parse(praminfos[1]);
                        // fubnescene.GetComponent<MapComponent>().SetMapInfo((int)SceneTypeEnum.PetMing, request.SceneId, 0);
                        // TransferHelper.BeforeTransfer(unit);
                        // await TransferHelper.Transfer(unit, fubenInstanceId, (int)SceneTypeEnum.PetMing, request.SceneId, request.Difficulty, praminfos[0]);
                        // TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
                        break;
                    case (int)SceneTypeEnum.PetTianTi:
                        ////动态创建副本
                        long enemyId = long.Parse(request.paramInfo);
                        fubenid = IdGenerater.Instance.GenerateId();
                        fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                        // fubnescene = SceneFactory.Create(Game.Scene, fubenid, fubenInstanceId, unit.DomainZone(), "Fuben" + fubenid.ToString(), SceneType.Fuben);
                        // fubnescene.AddComponent<PetTianTiComponent>().EnemyId = enemyId;
                        // fubnescene.GetComponent<MapComponent>().SetMapInfo((int)SceneTypeEnum.PetTianTi, request.SceneId, 0);
                        // TransferHelper.BeforeTransfer(unit);
                        // await TransferHelper.Transfer(unit, fubenInstanceId, (int)SceneTypeEnum.PetTianTi, request.SceneId, 0, "0");
                        // TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
                        break;
                    case (int)SceneTypeEnum.LocalDungeon:
                        if (request.Difficulty < 1 || request.Difficulty > 3)
                        {
                            request.Difficulty = 1;
                        }
                       
                        if (request.SceneId > 0)
                        {
                            int chaptierd = 1;
                            if (!DungeonConfigCategory.Instance.Contain(request.SceneId))
                            {
                                return ErrorCode.ERR_LevelIsNot;
                            }

                            DungeonSectionConfig dungeonSectionConfig = DungeonSectionConfigCategory.Instance.Get(chaptierd);
                            int openLv = dungeonSectionConfig.OpenLevel[request.Difficulty - 1];
                            int enterlv = DungeonConfigCategory.Instance.Get(request.SceneId).EnterLv;
                            enterlv = math.max(enterlv, openLv);
                            if (userInfoComponent.GetUserLv() < enterlv)
                            {
                                return ErrorCode.ERR_LevelIsNot;
                            }
                        }

                        LocalDungeonComponent localDungeon = unit.Root().GetComponent<LocalDungeonComponent>();
                        request.Difficulty = localDungeon != null ? localDungeon.FubenDifficulty : request.Difficulty;
                        unit.GetComponent<SkillManagerComponent>()?.OnFinish(false);
                        int errorCode = await TransferHelper.LocalDungeonTransfer(unit, request.SceneId, int.Parse(request.paramInfo), request.Difficulty);
                        if (errorCode != ErrorCode.ERR_Success)
                        {
                            return errorCode;
                        }
                        break;
                    case SceneTypeEnum.BaoZang:
                    case SceneTypeEnum.MiJing:
                        // F2M_YeWaiSceneIdResponse f2M_YeWaiSceneIdResponse = (F2M_YeWaiSceneIdResponse)await ActorMessageSenderComponent.Instance.Call(
                        // DBHelper.GetFubenCenterId(unit.DomainZone()), new M2F_YeWaiSceneIdRequest() { SceneId = request.SceneId });
                        // if (f2M_YeWaiSceneIdResponse.FubenInstanceId == 0)
                        // {
                        //     return ErrorCode.ERR_MapLimit;
                        // }
                        //
                        // SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                        // int curPlayerNum = int.Parse(f2M_YeWaiSceneIdResponse.Message); // UnitHelper.GetUnitList(unit.DomainScene(), UnitType.Player).Count;
                        // if (sceneConfig.PlayerLimit > 0 && sceneConfig.PlayerLimit <= curPlayerNum)
                        // {
                        //     return ErrorCode.ERR_MapLimit;
                        // }
                        // TransferHelper.BeforeTransfer(unit);
                        // await TransferHelper.Transfer(unit, f2M_YeWaiSceneIdResponse.FubenInstanceId, sceneConfig.MapType, request.SceneId, 0, "0");
                        break;
                    case SceneTypeEnum.RunRace:
                    case SceneTypeEnum.Demon:
                        // f2M_YeWaiSceneIdResponse = (F2M_YeWaiSceneIdResponse)await ActorMessageSenderComponent.Instance.Call(
                        // DBHelper.GetFubenCenterId(unit.DomainZone()), new M2F_YeWaiSceneIdRequest() { SceneId = request.SceneId,UnitId = unit.Id  });
                        // if (f2M_YeWaiSceneIdResponse.FubenInstanceId == 0)
                        // {
                        //     return ErrorCode.ERR_AlreadyFinish;
                        // }
                        // sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                        // TransferHelper.BeforeTransfer(unit);
                        // await TransferHelper.Transfer(unit, f2M_YeWaiSceneIdResponse.FubenInstanceId, sceneConfig.MapType, request.SceneId, 0, "0");
                        break;
                    case SceneTypeEnum.Solo:
                        // long soloServerId = DBHelper.GetSoloServerId(unit.DomainZone());
                        // S2M_SoloEnterResponse d2GGetUnit = (S2M_SoloEnterResponse)await ActorMessageSenderComponent.Instance.Call(soloServerId, new M2S_SoloEnterRequest()
                        // {
                        //     FubenId = long.Parse(request.paramInfo)
                        // });
                        //
                        // if (d2GGetUnit.Error != ErrorCode.ERR_Success)
                        // {
                        //     return d2GGetUnit.Error;
                        // }
                        // if (d2GGetUnit.FubenInstanceId == 0)
                        // {
                        //     return ErrorCode.ERR_ModifyData;
                        // }
                        // if ( !FunctionHelp.IsInTime(1045))
                        // {
                        //     return ErrorCode.ERR_AlreadyFinish;
                        // }
                        // oldscene = unit.DomainScene();
                        // mapComponent = oldscene.GetComponent<MapComponent>();
                        // sceneTypeEnum = mapComponent.SceneTypeEnum;
                        // TransferHelper.BeforeTransfer(unit);
                        // await TransferHelper.Transfer(unit, d2GGetUnit.FubenInstanceId, SceneTypeEnum.Solo, request.SceneId, 0, "0");
                        // if (SceneConfigHelper.IsSingleFuben(sceneTypeEnum))
                        // {
                        //     TransferHelper.NoticeFubenCenter(oldscene, 2).Coroutine();
                        //     oldscene.Dispose();
                        // }
                        break;
                    case SceneTypeEnum.UnionRace:
                        unionid = unit.GetComponent<NumericComponentServer>().GetAsLong(NumericType.UnionId_0);
                        if (unionid == 0)
                        {
                            return ErrorCode.ERR_Union_Not_Exist;
                        }
                        if (!FunctionHelp.IsInUnionRaceTime())
                        {
                            return ErrorCode.ERR_AlreadyFinish;
                        }
                        // mapInstanceId = DBHelper.GetUnionServerId(unit.DomainZone());
                        // responseUnionEnter = (U2M_UnionEnterResponse)await ActorMessageSenderComponent.Instance.Call(
                        // mapInstanceId, new M2U_UnionEnterRequest() { OperateType = 1, UnionId = unionid, UnitId = unit.Id, SceneId = request.SceneId });
                        // if (responseUnionEnter.FubenInstanceId == 0)
                        // {
                        //     return ErrorCode.ERR_AlreadyFinish;
                        // }
                        // TransferHelper.BeforeTransfer(unit);
                        // await TransferHelper.Transfer(unit, responseUnionEnter.FubenInstanceId, SceneTypeEnum.UnionRace, request.SceneId, 0, "0");
                        break;
                    case SceneTypeEnum.Happy:
                        // mapInstanceId = DBHelper.GetHappyServerId(unit.DomainZone());
                        // H2M_HapplyEnterResponse happyEnter = (H2M_HapplyEnterResponse)await ActorMessageSenderComponent.Instance.Call(
                        // mapInstanceId, new M2H_HapplyEnterRequest() { UnitId = unit.Id, SceneId = request.SceneId });
                        // if (happyEnter.FubenInstanceId == 0)
                        // {
                        //     return ErrorCode.ERR_AlreadyFinish;
                        // }
                        TransferHelper.BeforeTransfer(unit);
                        //await TransferHelper.Transfer(unit, happyEnter.FubenInstanceId, (int)SceneTypeEnum.Happy, request.SceneId, FubenDifficulty.Normal, happyEnter.Position.ToString());
                        break;
                    case SceneTypeEnum.Battle:
                        // mapInstanceId = DBHelper.GetBattleServerId(unit.DomainZone());
                        // B2M_BattleEnterResponse battleEnter = (B2M_BattleEnterResponse)await ActorMessageSenderComponent.Instance.Call(
                        // mapInstanceId, new M2B_BattleEnterRequest() { UserID = unit.Id, SceneId = request.SceneId });
                        // if (battleEnter.FubenInstanceId == 0)
                        // {
                        //     return ErrorCode.ERR_AlreadyFinish;
                        // }

                        TransferHelper.BeforeTransfer(unit);
                        //await TransferHelper.Transfer(unit, battleEnter.FubenInstanceId, (int)SceneTypeEnum.Battle, request.SceneId, FubenDifficulty.Normal, battleEnter.Camp.ToString());
                        break;
                    case SceneTypeEnum.Arena:
                        // userInfoComponent = unit.GetComponent<UserInfoComponent>();
                        // sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                        // if (userInfoComponent.UserInfo.Lv < sceneConfig.EnterLv)
                        // {
                        //     return ErrorCode.ERR_LevelIsNot;
                        // }
                        //
                        // mapInstanceId = DBHelper.GetArenaServerId(unit.DomainZone());
                        // Arena2M_ArenaEnterResponse areneEnter = (Arena2M_ArenaEnterResponse)await ActorMessageSenderComponent.Instance.Call(
                        // mapInstanceId, new M2Arena_ArenaEnterRequest() { UserID = unit.Id, SceneId = request.SceneId });
                        // if (areneEnter.Error != ErrorCode.ERR_Success || areneEnter.FubenInstanceId == 0)
                        // {
                        //     return ErrorCode.ERR_AlreadyFinish;
                        // }
                        // TransferHelper.BeforeTransfer(unit);
                        // await TransferHelper.Transfer(unit, areneEnter.FubenInstanceId, (int)SceneTypeEnum.Arena, request.SceneId, FubenDifficulty.Normal, "0");
                        break;
                    case (int)SceneTypeEnum.TeamDungeon:
                        // oldscene = unit.DomainScene();
                        // mapComponent = oldscene.GetComponent<MapComponent>();
                        // sceneTypeEnum = mapComponent.SceneTypeEnum;
                        // mapInstanceId = StartSceneConfigCategory.Instance.GetBySceneName(unit.DomainZone(), Enum.GetName(SceneType.Team)).InstanceId;
                        // //[创建副本Scene]
                        // T2M_TeamDungeonEnterResponse createUnit = (T2M_TeamDungeonEnterResponse)await ActorMessageSenderComponent.Instance.Call(
                        // mapInstanceId, new M2T_TeamDungeonEnterRequest() { UserID = unit.GetComponent<UserInfoComponent>().UserInfo.UserId });
                        // if (createUnit.Error != ErrorCode.ERR_Success)
                        // {
                        //     return ErrorCode.ERR_TransferFailError;
                        // }
                        // TransferHelper.BeforeTransfer(unit);
                        // await TransferHelper.Transfer(unit, createUnit.FubenInstanceId, (int)SceneTypeEnum.TeamDungeon, createUnit.FubenId, createUnit.FubenType, "0");
                        // if (SceneConfigHelper.IsSingleFuben(sceneTypeEnum))
                        // {
                        //     TransferHelper.NoticeFubenCenter(oldscene, 2).Coroutine();
                        //     oldscene.Dispose();
                        // }
                        break;
                    default:
                        break;
                }
            }
            return ErrorCode.ERR_Success;
        }
        
        
        public static async ETTask TransferAtFrameFinish(Unit unit, ActorId sceneInstanceId, string sceneName)
        {
            await unit.Fiber().WaitFrameFinish();

            await TransferHelper.Transfer(unit, sceneInstanceId, sceneName);
        }
        
        public static async ETTask MainCityTransfer(Unit unit)
        {
            MapComponent mapComponent = unit.Root().GetComponent<MapComponent>();
            int sceneTypeEnum = mapComponent.SceneType;
            long userId = unit.Id;
            //unit.GetComponent<UnitInfoComponent>().LastDungeonId = 0;
            //传送回主场景
            ActorId mapInstanceId = UnitCacheHelper.MainCityServerId(unit.Zone());
            //动态删除副本
            Scene scene = unit.Root();
            TransferHelper.BeforeTransfer(unit);
            await TransferHelper.Transfer(unit, mapInstanceId, (int)SceneTypeEnum.MainCityScene, ComHelp.MainCityID(), 0, "0");
        }
        
        public static void BeforeTransfer(Unit unit)
        {
            //删除unit,让其它进程发送过来的消息找不到actor，重发
            //Game.EventSystem.Remove(unitId);
            // 删除Mailbox,让发给Unit的ActorLocation消息重发
            unit.RemoveComponent<MailBoxComponent>();
            unit.GetComponent<SkillPassiveComponent>()?.Stop();
            //unit.GetComponent<BuffManagerComponentServer>().BeforeTransfer();
            //unit.GetComponent<HeroDataComponentServer>().OnKillZhaoHuan(null);
            //RemovePetAndJingLing(unit);
        }

        public static async ETTask Transfer(Unit unit, ActorId sceneInstanceId, int sceneType, int sceneId, int fubenDifficulty,  string paramInfo)
        {
            Scene root = unit.Root();
            Log.Debug($"M2M_UnitTransferRequest:0");
            // location加锁
            long unitId = unit.Id;
            
            M2M_UnitTransferRequest request = M2M_UnitTransferRequest.Create();
            request.OldActorId = unit.GetActorId();
            request.Unit = unit.ToBson();
            foreach (Entity entity in unit.Components.Values)
            {
                if (entity is ITransfer)
                {
                    request.Entitys.Add(entity.ToBson());
                }
            }
            unit.Dispose();
            
            await root.GetComponent<LocationProxyComponent>().Lock(LocationType.Unit, unitId, request.OldActorId);
            await root.GetComponent<MessageSender>().Call(sceneInstanceId, request);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="operateType">1创建副本 2销毁副本</param>
        /// <returns></returns>
        public static async ETTask NoticeFubenCenter(Scene scene, int operateType)
        {
            ActorId fubencenterId = UnitCacheHelper.GetFubenCenterId(scene.Zone());
            int sceneType = 0;
            if (scene!=null && scene.GetComponent<MapComponent>()!=null)
            {
                sceneType = scene.GetComponent<MapComponent>().SceneType;
            }
            // M2F_FubenCenterOperateRequest request = new M2F_FubenCenterOperateRequest()
            // {
            //     SceneType = sceneType,
            //     OperateType = operateType,
            //     FubenInstanceId = scene.InstanceId
            // };
            // F2M_FubenCenterOpenResponse response = (F2M_FubenCenterOpenResponse)await ActorMessageSenderComponent.Instance.Call(fubencenterId, request);
            // if (operateType == 1)
            // { 
            //     scene.GetComponent<ServerInfoComponent>().ServerInfo = response.ServerInfo;
            // }
            await ETTask.CompletedTask;
        }
    }
}