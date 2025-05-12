using System;
using System.Collections.Generic;
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
                int oldScene = unit.Scene().GetComponent<MapComponent>().MapType;
                if (!SceneConfigHelper.CanTransfer(oldScene, request.SceneType))
                {
                    Log.Debug($"LoginTest1  Actor_Transfer unitId{unit.Id} oldScene:{oldScene}  requestscene{request.SceneType}");
                    return ErrorCode.ERR_RequestRepeatedly;
                }
                UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
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
                if (oldScene == MapTypeEnum.MainCityScene && request.SceneType != MapTypeEnum.MainCityScene)
                {
                    unit.RecordPostion(request.SceneType, request.SceneId);
                }

                switch (request.SceneType)
                {
                    case MapTypeEnum.MainCityScene:
                        await MainCityTransfer(unit);
                        break;
                    //宠物闯关
                    case (int)MapTypeEnum.PetDungeon:
                        int petfubenid = int.Parse(request.paramInfo);
                        if (!PetFubenConfigCategory.Instance.Contain(petfubenid))
                        {
                            return ErrorCode.ERR_ModifyData;
                        }
                        Scene oldscene = unit.Root();
                        int sceneTypeEnum = oldscene.GetComponent<MapComponent>().MapType;
                        long fubenid = IdGenerater.Instance.GenerateId();
                        long fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();

                        Scene fubnescene = GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId, "PetFuben" + fubenid.ToString());
                        fubnescene.AddComponent<PetDungeonComponent>();
                        fubnescene.GetComponent<MapComponent>().SetMapInfo((int)MapTypeEnum.PetDungeon, request.SceneId, int.Parse(request.paramInfo));
                        BeforeTransfer(unit,sceneTypeEnum);
                        await Transfer(unit, fubnescene.GetActorId(), (int)MapTypeEnum.PetDungeon, request.SceneId, FubenDifficulty.None, request.paramInfo);
                        NoticeFubenCenter(fubnescene, 1).Coroutine();
                        if (SceneConfigHelper.IsSingleFuben(sceneTypeEnum))
                        {
                            NoticeFubenCenter(oldscene, 2).Coroutine();
                            oldscene.Dispose();
                        }
                        break;
                    case MapTypeEnum.PetMelee:
                        oldscene = unit.Root();
                        sceneTypeEnum = oldscene.GetComponent<MapComponent>().MapType;
                        fubenid = IdGenerater.Instance.GenerateId();
                        fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();

                        fubnescene = GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId, "PetMelee" + fubenid.ToString());
                        fubnescene.GetComponent<MapComponent>().SetMapInfo((int)MapTypeEnum.PetMelee, request.SceneId, int.Parse(request.paramInfo));
                        fubnescene.AddComponent<YeWaiRefreshComponent>();
                        fubnescene.AddComponent<PetMeleeDungeonComponent>();
                        BeforeTransfer(unit,sceneTypeEnum);
                        await Transfer(unit, fubnescene.GetActorId(), (int)MapTypeEnum.PetMelee, request.SceneId, FubenDifficulty.None, request.paramInfo);
                        
                        NoticeFubenCenter(fubnescene, 1).Coroutine();
                        if (SceneConfigHelper.IsSingleFuben(sceneTypeEnum))
                        {
                            NoticeFubenCenter(oldscene, 2).Coroutine();
                            oldscene.Dispose();
                        }
                        break;
                    case MapTypeEnum.PetMatch:
                        ActorId petmathServerId = UnitCacheHelper.GetPetMatchServerId(unit.Zone());
                        M2PetMatch_EnterMapRequest matchEnterMapRequest = M2PetMatch_EnterMapRequest.Create();
                        matchEnterMapRequest.FubenId = long.Parse(request.paramInfo);
                        PetMatch2M_EnterMapResponse enterResponse = (PetMatch2M_EnterMapResponse)await unit.Root().GetComponent<MessageSender>().Call(petmathServerId, matchEnterMapRequest);
                        if (enterResponse.Error != ErrorCode.ERR_Success)
                        {
                            return enterResponse.Error;
                        }
                        if (enterResponse.FubenInstanceId == 0)
                        {
                            return ErrorCode.ERR_ModifyData;
                        }
                        if (!FunctionHelp.IsInTime(1074))
                        {
                            return ErrorCode.ERR_AlreadyFinish;
                        }
                        
                        oldscene = unit.Scene();
                        MapComponent  mapComponent = oldscene.GetComponent<MapComponent>();
                        sceneTypeEnum = mapComponent.MapType;
                        BeforeTransfer(unit,sceneTypeEnum);
                        await Transfer(unit, enterResponse.FubenActorId, MapTypeEnum.PetMatch, request.SceneId, 0, "0");
                        if (SceneConfigHelper.IsSingleFuben(sceneTypeEnum))
                        {
                            NoticeFubenCenter(oldscene, 2).Coroutine();
                            oldscene.Dispose();
                        }
                        break;
                    case (int)MapTypeEnum.CellDungeon:
                        if (request.SceneId > 0)
                        {
                            //第一个格子
                            oldscene = unit.Root();
                            sceneTypeEnum = oldscene.GetComponent<MapComponent>().MapType;
                            fubenid = IdGenerater.Instance.GenerateId();
                            fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();

                            fubnescene = GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId, "CellDungeon" + fubenid.ToString());
                            CellDungeonComponentS cellDungeonComponentS = fubnescene.AddComponent<CellDungeonComponentS>();
                            cellDungeonComponentS.InitFubenCell(request.SceneId);
                            cellDungeonComponentS.InitFirstCell();
                            BeforeTransfer(unit,sceneTypeEnum);
                            await Transfer(unit, fubnescene.GetActorId(), (int)MapTypeEnum.CellDungeon, request.SceneId, request.Difficulty, request.paramInfo);
                            NoticeFubenCenter(fubnescene, 1).Coroutine();
                            if (SceneConfigHelper.IsSingleFuben(sceneTypeEnum))
                            {
                                NoticeFubenCenter(oldscene, 2).Coroutine();
                                oldscene.Dispose();
                            }
                        }
                        else
                        {
                            Console.WriteLine($"SceneTypeEnum.CellDungeon:request.SceneId == 0 ");
                        }

                        // else
                        // {
                        //     UnitHelper.RemoveAllNoSelf(unit);
                        //     CellDungeonComponentS cellDungeonComponentS = unit.Scene().GetComponent<CellDungeonComponentS>();
                        //     cellDungeonComponentS.InitSonCell(request.paramInfo);
                        //     cellDungeonComponentS.OnEnterSonCell(request.paramInfo);
                        //     AfterTransfer(unit, SceneTypeEnum.CellDungeon);
                        // }
                        break;
                    case (int)MapTypeEnum.TrialDungeon:
                        int requestTowerId = int.Parse(request.paramInfo);
                        int passId = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.TrialDungeonId);
                        if (!TowerConfigCategory.Instance.Contain(requestTowerId))
                        {
                            Log.Error($"试炼之地作弊1:{unit.Zone()} {unit.Id} {requestTowerId}   {passId}");
                            return ErrorCode.ERR_ModifyData;
                        }
                        if (TowerConfigCategory.Instance.Get(requestTowerId).MapType != MapTypeEnum.TrialDungeon)
                        {
                            Log.Error($"试炼之地作弊2:{unit.Zone()} {unit.Id} {requestTowerId}   {passId}");
                            return ErrorCode.ERR_ModifyData;
                        }

                        if (passId == 0 && requestTowerId != 20001)
                        {
                            Log.Error($"试炼之地作弊3:{unit.Zone()} {unit.Id} {requestTowerId}   {passId}");
                            return ErrorCode.ERR_ModifyData;
                        }
                        if (passId != 0 && requestTowerId > passId + 1)
                        {
                            Log.Error($"试炼之地作弊4:{unit.Zone()} {unit.Id} {requestTowerId}   {passId}");
                            return ErrorCode.ERR_ModifyData;
                        }

                        fubenid = IdGenerater.Instance.GenerateId();
                        fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                        fubnescene = GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId, "TrialDungeon" + fubenid.ToString());
                        fubnescene.AddComponent<TrialDungeonComponent>();
                        mapComponent = fubnescene.GetComponent<MapComponent>();
                        mapComponent.SetMapInfo((int)MapTypeEnum.TrialDungeon, request.SceneId, int.Parse(request.paramInfo));
                        mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(request.SceneId).MapID;
                        BeforeTransfer(unit, MapTypeEnum.MainCityScene);
                        await Transfer(unit, fubnescene.GetActorId(), (int)MapTypeEnum.TrialDungeon, request.SceneId, FubenDifficulty.None, request.paramInfo);
                        NoticeFubenCenter(fubnescene, 1).Coroutine();
                        break;
                    case MapTypeEnum.SeasonTower:
                        //计算赛季之塔下一关
                        int seasonTowerid = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.SeasonTowerId);
                        if (seasonTowerid == 0)
                        {
                            request.paramInfo = TowerHelper.GetFirstTowerIdByScene(MapTypeEnum.SeasonTower).ToString();
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
                        fubnescene = GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId, "SeasonTower" + fubenid.ToString());
                        fubnescene.AddComponent<SeasonTowerComponent>();
                        mapComponent = fubnescene.GetComponent<MapComponent>();
                        mapComponent.SetMapInfo((int)MapTypeEnum.SeasonTower, request.SceneId, int.Parse(request.paramInfo));
                        mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(request.SceneId).MapID;
                        BeforeTransfer(unit, MapTypeEnum.MainCityScene);
                        await Transfer(unit, fubnescene.GetActorId(), (int)MapTypeEnum.SeasonTower, request.SceneId, FubenDifficulty.None, request.paramInfo);
                        NoticeFubenCenter(fubnescene, 1).Coroutine();
                        break;
                    case MapTypeEnum.SealTower:
                        int finished = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.SealTowerFinished);
                        // 服务端再判断是否已经通关塔顶
                        if (finished >= 100)
                        {
                            return ErrorCode.ERR_TowerOfSealReachTop;
                        }

                        fubenid = IdGenerater.Instance.GenerateId();
                        fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                        fubnescene = GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId, "TowerOfSeal" + fubenid.ToString());
                        fubnescene.AddComponent<SealTowerComponent>();
                        mapComponent = fubnescene.GetComponent<MapComponent>();
                        mapComponent.SetMapInfo((int)MapTypeEnum.SealTower, request.SceneId, int.Parse(request.paramInfo));
                        mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(request.SceneId).MapID;
                        BeforeTransfer(unit, MapTypeEnum.MainCityScene);
                        await Transfer(unit, fubnescene.GetActorId(), (int)MapTypeEnum.SealTower, request.SceneId, FubenDifficulty.None, request.paramInfo);
                        NoticeFubenCenter(fubnescene, 1).Coroutine();
                        break;
                    case (int)MapTypeEnum.RandomTower:
                        //2200001
                        fubenid = IdGenerater.Instance.GenerateId();
                        fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                        fubnescene = GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId, "RandomTower" + fubenid.ToString());
                        fubnescene.AddComponent<RandomTowerComponent>();
                        mapComponent = fubnescene.GetComponent<MapComponent>();
                        mapComponent.SetMapInfo((int)MapTypeEnum.RandomTower, request.SceneId, 0);
                        mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(request.SceneId).MapID;
                        BeforeTransfer(unit, MapTypeEnum.MainCityScene);
                        await Transfer(unit, fubnescene.GetActorId(), (int)MapTypeEnum.RandomTower, request.SceneId, 0, "0");
                        NoticeFubenCenter(fubnescene, 1).Coroutine();
                        break;
                    case (int)MapTypeEnum.Union:
                        long unionid = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.UnionId_0);
                        if (unionid == 0)
                        {
                            return ErrorCode.ERR_Union_Not_Exist;
                        }
                        ActorId mapInstanceId = UnitCacheHelper.GetFubenCenterId(unit.Zone());
                        M2F_UnionEnterRequest M2U_UnionEnterRequest = M2F_UnionEnterRequest.Create();
                        M2U_UnionEnterRequest.UnionId = unionid;
                        M2U_UnionEnterRequest.SceneId = request.SceneId;
                        F2M_UnionEnterResponse responseUnionEnter = (F2M_UnionEnterResponse)await unit.Root().GetComponent<MessageSender>().Call(
                        mapInstanceId, M2U_UnionEnterRequest);
                        BeforeTransfer(unit, MapTypeEnum.MainCityScene);
                        await Transfer(unit, responseUnionEnter.FubenActorId, (int)MapTypeEnum.Union, request.SceneId, request.Difficulty, "0");
                        break;
                    case (int)MapTypeEnum.JiaYuan:
                        //动态创建副本
                        Scene scene = unit.Root();
                        mapInstanceId = UnitCacheHelper.GetFubenCenterId(unit.Zone());

                        ///进入之前先刷新一下
                        if (long.Parse(request.paramInfo) == unit.Id)
                        {
                            JiaYuanComponentS jiaYuanComponent = unit.GetComponent<JiaYuanComponentS>();
                            jiaYuanComponent.OnBeforEnter();
                        }
                        M2F_JiaYuanEnterRequest M2J_JiaYuanEnterRequest = M2F_JiaYuanEnterRequest.Create();
                        M2J_JiaYuanEnterRequest.MasterId = long.Parse(request.paramInfo);
                        M2J_JiaYuanEnterRequest.UnitId = unit.Id;
                        M2J_JiaYuanEnterRequest.SceneId = request.SceneId;
                        F2M_JiaYuanEnterResponse j2M_JianYuanEnterResponse = (F2M_JiaYuanEnterResponse)await unit.Root().GetComponent<MessageSender>().Call(
                        mapInstanceId, M2J_JiaYuanEnterRequest);
                        BeforeTransfer(unit, MapTypeEnum.MainCityScene);
                        await Transfer(unit, j2M_JianYuanEnterResponse.FubenActorId, (int)MapTypeEnum.JiaYuan, request.SceneId, request.Difficulty, "0");
                        // if (oldScene == SceneTypeEnum.JiaYuan) //派发事件处理
                        // {
                        //     JiaYuanSceneComponent jiayuanSceneComponent = scene.GetParent<JiaYuanSceneComponent>();
                        //     jiayuanSceneComponent.OnUnitLeave(scene);
                        // }
                        break;
                    case (int)MapTypeEnum.Tower:
                        //动态创建副本
                        fubenid = IdGenerater.Instance.GenerateId();
                        fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                        fubnescene = GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId, "Tower" + fubenid.ToString());
                        fubnescene.AddComponent<TowerComponent>().FubenDifficulty = request.Difficulty;
                        mapComponent = fubnescene.GetComponent<MapComponent>();
                        mapComponent.SetMapInfo((int)MapTypeEnum.Tower, request.SceneId, 0);
                        mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(request.SceneId).MapID;
                        BeforeTransfer(unit, MapTypeEnum.MainCityScene);
                        await Transfer(unit, fubnescene.GetActorId(), (int)MapTypeEnum.Tower, request.SceneId, request.Difficulty, "0");
                        NoticeFubenCenter(fubnescene, 1).Coroutine();
                        break;
                    case MapTypeEnum.OneChallenge:
                        fubenid = long.Parse(request.paramInfo);
                        fubnescene = unit.Root().GetChild<Scene>(fubenid);
                        bool newdungeon = false;
                        if (fubnescene == null)
                        {
                            newdungeon = true;
                            fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                            fubnescene = GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId, "OneChallenge" + fubenid.ToString());
                            mapComponent = fubnescene.GetComponent<MapComponent>();
                            mapComponent.SetMapInfo((int)MapTypeEnum.OneChallenge, request.SceneId, 0);
                            mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(request.SceneId).MapID;
                            //Game.Scene.GetComponent<RecastPathComponent>().Update(fubnescene.GetComponent<MapComponent>().NavMeshId);
                        }
                        fubenInstanceId = fubnescene.InstanceId;
                        BeforeTransfer(unit, MapTypeEnum.MainCityScene);;
                        await Transfer(unit, fubnescene.GetActorId(), (int)MapTypeEnum.OneChallenge, request.SceneId, request.Difficulty, "0");
                        if (newdungeon)
                        {
                            NoticeFubenCenter(fubnescene, 1).Coroutine();
                        }
                        break;
                    case (int)MapTypeEnum.PetMing:
                        long cdTime = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.PetMineCDTime);
                        if (cdTime > TimeHelper.ServerNow())
                        {
                            return ErrorCode.ERR_InMakeCD;
                        }

                        string[] praminfos = request.paramInfo.Split('_');
                        fubenid = IdGenerater.Instance.GenerateId();
                        fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                        fubnescene = GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId, "Fuben" + fubenid.ToString());
                        PetMingDungeonComponent petMingDungeon = fubnescene.AddComponent<PetMingDungeonComponent>();
                        petMingDungeon.MineType = request.Difficulty;
                        petMingDungeon.Position = int.Parse(praminfos[0]);
                        petMingDungeon.TeamId = int.Parse(praminfos[1]);
                        fubnescene.GetComponent<MapComponent>().SetMapInfo((int)MapTypeEnum.PetMing, request.SceneId, 0);
                        BeforeTransfer(unit, MapTypeEnum.MainCityScene);
                        await Transfer(unit, fubnescene.GetActorId(), (int)MapTypeEnum.PetMing, request.SceneId, request.Difficulty, praminfos[0]);
                        NoticeFubenCenter(fubnescene, 1).Coroutine();
                        break;
                    case (int)MapTypeEnum.PetTianTi:
                        ////动态创建副本
                        long enemyId = long.Parse(request.paramInfo);
                        fubenid = IdGenerater.Instance.GenerateId();
                        fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                        fubnescene = GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId, "Fuben" + fubenid.ToString());
                        fubnescene.AddComponent<PetTianTiDungeonComponent>().EnemyId = enemyId;
                        fubnescene.GetComponent<MapComponent>().SetMapInfo((int)MapTypeEnum.PetTianTi, request.SceneId, 0);
                        BeforeTransfer(unit, MapTypeEnum.MainCityScene);
                        await Transfer(unit, fubnescene.GetActorId(), (int)MapTypeEnum.PetTianTi, request.SceneId, 0, "0");
                        NoticeFubenCenter(fubnescene, 1).Coroutine();
                        break;
                    case (int)MapTypeEnum.LocalDungeon:
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
                        int errorCode = await LocalDungeonTransfer(unit, request.SceneId, int.Parse(request.paramInfo), request.Difficulty);
                        if (errorCode != ErrorCode.ERR_Success)
                        {
                            return errorCode;
                        }
                        break;
                    case MapTypeEnum.BaoZang:
                    case MapTypeEnum.MiJing:
                        M2F_FubenSceneIdRequest M2F_FubenSceneIdRequest = M2F_FubenSceneIdRequest.Create();
                        M2F_FubenSceneIdRequest.SceneId = request.SceneId;
                        F2M_FubenSceneIdResponse f2M_YeWaiSceneIdResponse = (F2M_FubenSceneIdResponse)await unit.Root().GetComponent<MessageSender>().Call(
                        UnitCacheHelper.GetFubenCenterId(unit.Zone()), M2F_FubenSceneIdRequest);
                        if (f2M_YeWaiSceneIdResponse.FubenInstanceId == 0)
                        {
                            return ErrorCode.ERR_MapLimit;
                        }

                        SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                        int curPlayerNum = int.Parse(f2M_YeWaiSceneIdResponse.Message);
                        if (sceneConfig.PlayerLimit > 0 && sceneConfig.PlayerLimit <= curPlayerNum)
                        {
                            return ErrorCode.ERR_MapLimit;
                        }
                        BeforeTransfer(unit, MapTypeEnum.MainCityScene);
                        await Transfer(unit, f2M_YeWaiSceneIdResponse.FubenActorId, sceneConfig.MapType, request.SceneId, 0, "0");
                        break;
                    case MapTypeEnum.RunRace:
                    case MapTypeEnum.Demon:
                        M2F_FubenSceneIdRequest = M2F_FubenSceneIdRequest.Create();
                        M2F_FubenSceneIdRequest.SceneId = request.SceneId;
                        M2F_FubenSceneIdRequest.UnitId = unit.Id;
                        f2M_YeWaiSceneIdResponse = (F2M_FubenSceneIdResponse)await unit.Root().GetComponent<MessageSender>().Call(
                        UnitCacheHelper.GetFubenCenterId(unit.Zone()), M2F_FubenSceneIdRequest);
                        if (f2M_YeWaiSceneIdResponse.FubenInstanceId == 0)
                        {
                            return ErrorCode.ERR_AlreadyFinish;
                        }
                        sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                        BeforeTransfer(unit, MapTypeEnum.MainCityScene);
                        await Transfer(unit, f2M_YeWaiSceneIdResponse.FubenActorId, sceneConfig.MapType, request.SceneId, 0, "0");
                        break;
                    case MapTypeEnum.Solo:
                        ActorId soloServerId = UnitCacheHelper.GetSoloServerId(unit.Zone());
                        M2S_SoloEnterRequest M2S_SoloEnterRequest = M2S_SoloEnterRequest.Create();
                        M2S_SoloEnterRequest.FubenId = long.Parse(request.paramInfo);
                        S2M_SoloEnterResponse d2GGetUnit = (S2M_SoloEnterResponse)await unit.Root().GetComponent<MessageSender>().Call(soloServerId, M2S_SoloEnterRequest);

                        if (d2GGetUnit.Error != ErrorCode.ERR_Success)
                        {
                            return d2GGetUnit.Error;
                        }
                        if (d2GGetUnit.FubenInstanceId == 0)
                        {
                            return ErrorCode.ERR_ModifyData;
                        }
                        if (!FunctionHelp.IsInTime(1045))
                        {
                            return ErrorCode.ERR_AlreadyFinish;
                        }
                        oldscene = unit.Scene();
                        mapComponent = oldscene.GetComponent<MapComponent>();
                        sceneTypeEnum = mapComponent.MapType;
                        BeforeTransfer(unit, sceneTypeEnum);
                        await Transfer(unit, d2GGetUnit.FubenActorId, MapTypeEnum.Solo, request.SceneId, 0, "0");
                        if (SceneConfigHelper.IsSingleFuben(sceneTypeEnum))
                        {
                            NoticeFubenCenter(oldscene, 2).Coroutine();
                            oldscene.Dispose();
                        }
                        break;
                    case MapTypeEnum.UnionRace:
                        unionid = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.UnionId_0);
                        if (unionid == 0)
                        {
                            return ErrorCode.ERR_Union_Not_Exist;
                        }
                        if (!FunctionHelp.IsInUnionRaceTime())
                        {
                            return ErrorCode.ERR_AlreadyFinish;
                        }
                        mapInstanceId = UnitCacheHelper.GetUnionServerId(unit.Zone());
                        M2U_UnionEnterRequest = M2F_UnionEnterRequest.Create();
                        M2U_UnionEnterRequest.OperateType = 1;
                        M2U_UnionEnterRequest.UnionId = unionid;
                        M2U_UnionEnterRequest.UnitId = unit.Id;
                        M2U_UnionEnterRequest.SceneId = request.SceneId;
                        responseUnionEnter = (F2M_UnionEnterResponse)await unit.Root().GetComponent<MessageSender>().Call(
                        mapInstanceId, M2U_UnionEnterRequest);
                        if (responseUnionEnter.FubenInstanceId == 0)
                        {
                            return ErrorCode.ERR_AlreadyFinish;
                        }
                        BeforeTransfer(unit, MapTypeEnum.MainCityScene);
                        await Transfer(unit, responseUnionEnter.FubenActorId, MapTypeEnum.UnionRace, request.SceneId, 0, "0");
                        break;
                    case MapTypeEnum.SingleHappy:
                        fubenid = IdGenerater.Instance.GenerateId();
                        fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                        fubnescene = GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId, "SingleHappy" + fubenid.ToString());
                        fubnescene.AddComponent<SingleHappyDungeonComponent>();
                        fubnescene.GetComponent<MapComponent>().SetMapInfo((int)MapTypeEnum.SingleHappy, request.SceneId, 0);
                        BeforeTransfer(unit, MapTypeEnum.MainCityScene);
                        await Transfer(unit, fubnescene.GetActorId(), (int)MapTypeEnum.SingleHappy, request.SceneId, request.Difficulty, "0");
                        NoticeFubenCenter(fubnescene, 1).Coroutine();
                        break;
                    case MapTypeEnum.Happy:
                        M2F_FubenSceneIdRequest = M2F_FubenSceneIdRequest.Create();
                        M2F_FubenSceneIdRequest.SceneId = request.SceneId;
                        M2F_FubenSceneIdRequest.UnitId = unit.Id;
                        f2M_YeWaiSceneIdResponse = (F2M_FubenSceneIdResponse)await unit.Root().GetComponent<MessageSender>().Call(
                            UnitCacheHelper.GetFubenCenterId(unit.Zone()), M2F_FubenSceneIdRequest);
                        if (f2M_YeWaiSceneIdResponse.FubenInstanceId == 0)
                        {
                            return ErrorCode.ERR_AlreadyFinish;
                        }
                        BeforeTransfer(unit, MapTypeEnum.MainCityScene);
                        await Transfer(unit, f2M_YeWaiSceneIdResponse.FubenActorId, (int)MapTypeEnum.Happy, request.SceneId, FubenDifficulty.Normal, f2M_YeWaiSceneIdResponse.Position.ToString());
                        break;
                    case MapTypeEnum.Battle:
                        M2F_FubenSceneIdRequest = M2F_FubenSceneIdRequest.Create();
                        M2F_FubenSceneIdRequest.SceneId = request.SceneId;
                        M2F_FubenSceneIdRequest.UnitId = unit.Id;
                        f2M_YeWaiSceneIdResponse = (F2M_FubenSceneIdResponse)await unit.Root().GetComponent<MessageSender>().Call(
                            UnitCacheHelper.GetFubenCenterId(unit.Zone()), M2F_FubenSceneIdRequest);
                        if (f2M_YeWaiSceneIdResponse.FubenInstanceId == 0)
                        {
                            return ErrorCode.ERR_AlreadyFinish;
                        }

                        BeforeTransfer(unit, MapTypeEnum.MainCityScene);
                        await Transfer(unit, f2M_YeWaiSceneIdResponse.FubenActorId, (int)MapTypeEnum.Battle, request.SceneId, FubenDifficulty.Normal, f2M_YeWaiSceneIdResponse.Camp.ToString());
                        break;
                    case MapTypeEnum.Arena:
                        userInfoComponent = unit.GetComponent<UserInfoComponentS>();
                        sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                        if (userInfoComponent.UserInfo.Lv < sceneConfig.EnterLv)
                        {
                            return ErrorCode.ERR_LevelIsNot;
                        }

                        M2F_FubenSceneIdRequest = M2F_FubenSceneIdRequest.Create();
                        M2F_FubenSceneIdRequest.SceneId = request.SceneId;
                        M2F_FubenSceneIdRequest.UnitId = unit.Id;

                        f2M_YeWaiSceneIdResponse = (F2M_FubenSceneIdResponse)await unit.Root().GetComponent<MessageSender>().Call(
                            UnitCacheHelper.GetFubenCenterId(unit.Zone()), M2F_FubenSceneIdRequest);
                        if (f2M_YeWaiSceneIdResponse.FubenInstanceId == 0)
                        {
                            return ErrorCode.ERR_AlreadyFinish;
                        }
                        BeforeTransfer(unit, MapTypeEnum.MainCityScene);
                        await Transfer(unit, f2M_YeWaiSceneIdResponse.FubenActorId, (int)MapTypeEnum.Arena, request.SceneId, FubenDifficulty.Normal, "0");
                        break;
                    case (int)MapTypeEnum.TeamDungeon:
                    case (int)MapTypeEnum.DragonDungeon:
                        Console.WriteLine($"EnterDungeon:  {request.SceneType}  {unit.Id}");
                        
                        oldscene = unit.Scene();
                        mapComponent = oldscene.GetComponent<MapComponent>();
                        sceneTypeEnum = mapComponent.MapType;
                        mapInstanceId = UnitCacheHelper.GetTeamServerId(unit.Zone());
                        //[创建副本Scene]
                        M2T_TeamDungeonEnterRequest M2T_TeamDungeonEnterRequest = M2T_TeamDungeonEnterRequest.Create();
                        M2T_TeamDungeonEnterRequest.UserID = unit.Id;
                        M2T_TeamDungeonEnterRequest.SceneId =  request.SceneId;
                        M2T_TeamDungeonEnterRequest.SceneType = request.SceneType;
                        M2T_TeamDungeonEnterRequest.TeamId = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.TeamId);
                        request.SceneId = M2T_TeamDungeonEnterRequest.SceneId;
                        T2M_TeamDungeonEnterResponse createUnit = (T2M_TeamDungeonEnterResponse)await unit.Root().GetComponent<MessageSender>().Call(
                        mapInstanceId, M2T_TeamDungeonEnterRequest);
                        Console.WriteLine($"T2M_TeamDungeonEnterResponse:  {createUnit} { M2T_TeamDungeonEnterRequest.TeamId}");
                        if (createUnit.Error != ErrorCode.ERR_Success)
                        {
                            return ErrorCode.ERR_TransferFailError;
                        }
                        BeforeTransfer(unit,sceneTypeEnum);

                        await Transfer(unit, createUnit.FubenActorId, request.SceneType, createUnit.FubenId, createUnit.FubenType, "0");
                        if (SceneConfigHelper.IsSingleFuben(sceneTypeEnum))
                        {
                            NoticeFubenCenter(oldscene, 2).Coroutine();
                            oldscene.Dispose();
                        }
                        break;
                    default:
                        break;
                }
            }
            return ErrorCode.ERR_Success;
        }


        public static async ETTask<int> LocalDungeonTransfer(Unit unit, int sceneId, int transferId, int difficulty)
        {
            Log.Debug("M2LocalDungeon_EnterRequest_1");
            if (transferId != 0 && !DungeonTransferConfigCategory.Instance.Contain(transferId))
            {
                return ErrorCode.ERR_ModifyData;
            }

            //前往神秘之门
            if (DungeonSectionConfigCategory.Instance.MysteryDungeonList.Contains(sceneId))
            {
                unit.GetComponent<UnitInfoComponent>().LastDungeonId = unit.Root().GetComponent<MapComponent>().SceneId;
                unit.GetComponent<UnitInfoComponent>().LastDungeonPosition = unit.Position;
            }

            Scene oldscene = unit.Scene();
            sceneId = transferId != 0 ? DungeonTransferConfigCategory.Instance.Get(transferId).MapID : sceneId;
            if (sceneId == 0)
            {
                Log.Error($"zonelocaldungeonsb:  unitid: {unit.Id}  transferId: {transferId} sceneId: {sceneId} ");
                return ErrorCode.ERR_NotFindLevel;
            }

            Log.Debug("M2LocalDungeon_EnterRequest_2");

            long fubenid = IdGenerater.Instance.GenerateId();
            long fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
            Scene fubnescene = GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId, "LocalDungeon" + fubenid.ToString());
            fubnescene.AddComponent<YeWaiRefreshComponent>();
            LocalDungeonComponent localDungeon = fubnescene.AddComponent<LocalDungeonComponent>();
            localDungeon.FubenDifficulty = difficulty;
            MapComponent mapComponent = fubnescene.GetComponent<MapComponent>();
            mapComponent.SetMapInfo((int)MapTypeEnum.LocalDungeon, sceneId, 0);
            mapComponent.NavMeshId = DungeonConfigCategory.Instance.Get(sceneId).MapID;

            NoticeFubenCenter(fubnescene, 1).Coroutine();
            BeforeTransfer(unit, oldscene.GetComponent<MapComponent>().MapType);
            await Transfer(unit, fubnescene.GetActorId(), (int)MapTypeEnum.LocalDungeon, sceneId, difficulty, transferId.ToString());

            //移除旧scene
            if (oldscene.GetComponent<LocalDungeonComponent>() != null)
            {
                //动态删除副本
                TransferHelper.NoticeFubenCenter(oldscene, 2).Coroutine();
                oldscene.Dispose();
            }
            return ErrorCode.ERR_Success;
        }

        public static async ETTask TransferAtFrameFinish(Unit unit, ActorId sceneInstanceId, string sceneName)
        {
            await unit.Fiber().WaitFrameFinish();

            await Transfer(unit, sceneInstanceId, MapTypeEnum.MainCityScene, 101, 1, "0");
        }

        public static async ETTask MainCityTransfer(Unit unit)
        {
            MapComponent mapComponent = unit.Scene().GetComponent<MapComponent>();
            if (mapComponent.MapType == MapTypeEnum.MainCityScene)
            {
                OnMainToMain(unit);
                return;
            }
            
            
            unit.GetComponent<UnitInfoComponent>().LastDungeonId = 0;
            //传送回主场景
            ActorId mapInstanceId = UnitCacheHelper.MainCityServerId(unit.Zone());
            long userId = unit.Id;
            Scene scene = unit.Scene();
            BeforeTransfer(unit,mapComponent.MapType);
            await Transfer(unit, mapInstanceId, (int)MapTypeEnum.MainCityScene, GlobalValueConfigCategory.Instance.MainCityID, 0, "0");
            //动态删除副本
            OnFubenToMain(scene, userId);
        }

        public static int OnFlyToPosition(Unit unit, int unitType, int configid)
        {
            Unit tonpc = null;
            List<Unit> npclist= FubenHelp.GetUnitList(unit.Scene(), unitType);
            foreach (Unit npc in npclist)
            {
                if (npc.ConfigId == configid)
                {
                    tonpc = npc;
                    break;
                }
            }
            
            if (tonpc == null)
            {
                return ErrorCode.ERR_NotFindNpc;
            }

            RemovePetAndJingLing(unit);
           
            unit.Position =  tonpc.Position + math.mul(tonpc.Rotation, math.forward()) * 1f;;
            unit.Stop(-2);
            
            CreateFightPetList(unit);
            CreateJingLing(unit);
            
            return ErrorCode.ERR_Success;   
        }

        private static void OnMainToMain(Unit unit)
        {
            RemovePetAndJingLing(unit);
            
            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(GlobalValueConfigCategory.Instance.MainCityID);
            unit.Position = new float3(sceneConfig.InitPos[0] * 0.01f, sceneConfig.InitPos[1] * 0.01f, sceneConfig.InitPos[2] * 0.01f);
            unit.Stop(-2);
            
            CreateFightPetList(unit);
            CreateJingLing(unit);
        }

        public static void OnFubenToMain(Scene scene, long userId)
        {
            Console.WriteLine($"OnFubenToMain: {userId}");
            
            if (scene.IsDisposed)
            {
                Log.Warning($"ReturnMainCity: scene.IsDisposed");
                return;
            }

            int sceneTypeEnum = scene.GetComponent<MapComponent>().MapType;
            if (SceneConfigHelper.IsSingleFuben(sceneTypeEnum))
            {
                NoticeFubenCenter(scene, 2).Coroutine();
                scene.Dispose();
                return;
            }
            
            switch (sceneTypeEnum)
            {
                case MapTypeEnum.TeamDungeon:
                case MapTypeEnum.DragonDungeon:
                    TeamSceneComponent teamSceneComponent = scene.GetParent<TeamSceneComponent>();
                    teamSceneComponent.OnUnitReturn(scene, userId);
                    break;
                case MapTypeEnum.PetMatch:
                    PetMeleeDungeonComponent petMeleeDungeonComponent = scene.GetComponent<PetMeleeDungeonComponent>();
                    petMeleeDungeonComponent.OnUnitReturn(userId);
                    break;
            }
            // if (sceneTypeEnum == SceneTypeEnum.TeamDungeon)
            // {
            //     TeamSceneComponent teamSceneComponent = scene.GetParent<TeamSceneComponent>();
            //     teamSceneComponent.OnUnitReturn(scene, userId);
            // }
            // if (sceneTypeEnum == (int)SceneTypeEnum.Arena)
            // {
            //     ArenaDungeonComponent areneSceneComponent = scene.GetComponent<ArenaDungeonComponent>();
            //     areneSceneComponent.OnUnitDisconnect(userId);
            // }
            // if (sceneTypeEnum == SceneTypeEnum.JiaYuan)
            // {
            //     JiaYuanSceneComponent jiayuanSceneComponent = scene.GetParent<JiaYuanSceneComponent>();
            //     jiayuanSceneComponent.OnUnitLeave(scene);
            // }
            // if (sceneTypeEnum == (int)SceneTypeEnum.OneChallenge)
            // {
            //     OneChallengeDungeonComponent jiayuanSceneComponent = scene.GetParent<OneChallengeDungeonComponent>();
            //     jiayuanSceneComponent.OnUnitLeave(scene);
            // }
        }

        public static void OnPlayerDisconnect(Scene scene, long userId)
        {
            int sceneTypeEnum = scene.GetComponent<MapComponent>().MapType;
            if (SceneConfigHelper.IsSingleFuben(sceneTypeEnum))
            {
                //动态删除副本
                TransferHelper.NoticeFubenCenter(scene, 2).Coroutine();
                scene.Dispose();
                return;
            }
            switch (sceneTypeEnum)
            {
                case MapTypeEnum.TeamDungeon:
                case MapTypeEnum.DragonDungeon:
                    TeamSceneComponent teamSceneComponent = scene.GetParent<TeamSceneComponent>();
                    teamSceneComponent.OnRecvUnitLeave(userId, true);
                    teamSceneComponent.OnUnitDisconnect(scene, sceneTypeEnum, userId);
                    break;
                case MapTypeEnum.PetMatch:
                    PetMeleeDungeonComponent petMeleeDungeonComponent = scene.GetComponent<PetMeleeDungeonComponent>();
                    petMeleeDungeonComponent.OnUnitReturn(userId);
                    break;
            }
            // if (sceneTypeEnum == (int)SceneTypeEnum.TeamDungeon)
            // {
            //     TeamSceneComponent teamSceneComponent = scene.GetParent<TeamSceneComponent>();
            //     teamSceneComponent.OnUnitDisconnect(scene, userId);
            // }
            // if (sceneTypeEnum == (int)SceneTypeEnum.Arena)
            // {
            //     ArenaDungeonComponent areneSceneComponent = scene.GetComponent<ArenaDungeonComponent>();
            //     areneSceneComponent.OnUnitDisconnect(userId);
            // }
            // if (sceneTypeEnum == (int)SceneTypeEnum.JiaYuan)
            // {
            //     JiaYuanSceneComponent jiayuanSceneComponent = scene.GetParent<JiaYuanSceneComponent>();
            //     jiayuanSceneComponent.OnUnitLeave(scene);
            // }
            // if (sceneTypeEnum == (int)SceneTypeEnum.OneChallenge)
            // {
            //     OneChallengeDungeonComponent jiayuanSceneComponent = scene.GetParent<OneChallengeDungeonComponent>();
            //     jiayuanSceneComponent.OnUnitLeave(scene);
            // }
        }

        public static void BeforeTransfer(Unit unit, int sceneType)
        {
            //删除unit,让其它进程发送过来的消息找不到actor，重发
            //Game.EventSystem.Remove(unitId);
            // 删除Mailbox,让发给Unit的ActorLocation消息重发

            if (sceneType == MapTypeEnum.SingleHappy)
            {
                unit.Scene().GetComponent<SingleHappyDungeonComponent>()?.OnSave();
            }
            unit.RemoveComponent<MailBoxComponent>();
            unit.GetComponent<SkillPassiveComponent>()?.Stop();
            unit.GetComponent<BuffManagerComponentS>().OnTransfer();
            unit.GetComponent<HeroDataComponentS>().OnKillZhaoHuan(null);
            unit.GetComponent<SkillManagerComponentS>()?.OnFinish(false);
            RemovePetAndJingLing(unit);
        }

        public static void RemoveStall(Unit unit)
        {
            List<Unit> stallList = UnitHelper.GetUnitList(unit.Scene(), UnitType.Stall);
            for (int i = stallList.Count - 1; i >= 0; i--)
            {
                long masterid = stallList[i].GetMasterId();
                if (masterid == unit.Id)
                {
                    unit.GetParent<UnitComponent>().Remove(stallList[i].Id);
                }
            }
        }

        public static void RemovePetAndJingLing(Unit unit)
        {
            RemoveFightPetList(unit);
            RemoveJingLing(unit);
        }

        public static void RemoveFightPetList(Unit unit, List<long> newpetids = null)
        {
            UnitComponent unitComponent = unit.Scene().GetComponent<UnitComponent>();
            List<PetBarInfo> petfightlist = unit.GetComponent<PetComponentS>().GetNowPetFightList();
            for (int i = 0; i < petfightlist.Count; i++)
            {
                if (unitComponent.Get(petfightlist[i].PetId) == null)
                {
                    continue;
                }

                if (newpetids != null && newpetids.Contains(petfightlist[i].PetId))
                {
                    continue;
                }

                unitComponent.Remove(petfightlist[i].PetId);
            }
        }

        public static void RemoveJingLing(Unit unit)
        {
            UnitComponent unitComponent = unit.Scene().GetComponent<UnitComponent>();
            long jinglingUnitId = unit.GetComponent<ChengJiuComponentS>().JingLingUnitId;
            if (jinglingUnitId != 0 && unitComponent.Get(jinglingUnitId) != null)
            {
                unitComponent.Remove(jinglingUnitId);
            }
            unit.GetComponent<ChengJiuComponentS>().JingLingUnitId = 0;
        }

        public static void AfterTransfer(Unit unit, int sceneType)
        {
            if (sceneType == MapTypeEnum.PetDungeon
                || sceneType == MapTypeEnum.PetTianTi
                || sceneType == MapTypeEnum.PetMing
                || sceneType == MapTypeEnum.PetMelee
                || sceneType == MapTypeEnum.PetMatch
                || sceneType == MapTypeEnum.RunRace
                || sceneType == MapTypeEnum.Demon
                || sceneType == MapTypeEnum.Happy
                || sceneType == MapTypeEnum.SingleHappy)
            {
                return;
            }


            CreateFightPetList(unit);
            CreateJingLing(unit);
        }

        public static void CreateJingLing(Unit unit)
        {
            JingLingInfo jinglinginfo = unit.GetComponent<ChengJiuComponentS>().GetFightJingLing();
            if (jinglinginfo != null )
            {
                long JingLingUnitId = UnitFactory.CreateJingLing(unit, jinglinginfo.JingLingID).Id;
                unit.GetComponent<ChengJiuComponentS>().JingLingUnitId = JingLingUnitId;
            }
        }

        public static void CreateFightPetList(Unit unit)
        {
            PetComponentS petComponentS = unit.GetComponent<PetComponentS>();
            List<PetBarInfo> petfightlist = petComponentS.GetNowPetFightList();
            for (int i = 0; i < petfightlist.Count; i++)
            {
                RolePetInfo fightId = petComponentS.GetPetInfo(petfightlist[i].PetId);
                if (fightId == null)
                {
                    continue;
                }

                if (unit.GetParent<UnitComponent>().Get(fightId.Id) != null)
                {
                    continue;
                }

                petComponentS.UpdatePetAttribute(fightId, false);
                Unit petunit =  UnitFactory.CreatePet(unit, fightId);
                BuffData buffData_2 = new BuffData();
                buffData_2.SkillId = 67000278;
                buffData_2.BuffId = ConfigData.PetMianShangBuff; 
                petunit.GetComponent<BuffManagerComponentS>().BuffFactory(buffData_2, unit, null);
            }
        }


        public static async ETTask Transfer(Unit unit, ActorId sceneInstanceId, int sceneType, int sceneId, int fubenDifficulty, string paramInfo)
        {
            Scene root = unit.Root();
            // location加锁
            long unitId = unit.Id;

            M2M_UnitTransferRequest request = M2M_UnitTransferRequest.Create();
            request.OldActorId = unit.GetActorId();
            request.Unit = unit.ToBson();
            request.SceneType = sceneType;
            request.SceneId = sceneId;
            request.FubenDifficulty = fubenDifficulty;
            request.ParamInfo = paramInfo;

            foreach (Entity entity in unit.Components.Values)
            {
                if (entity is ITransfer)
                {
                    request.Entitys.Add(entity.ToBson());
                }
                else
                {
                }
            }
            //unit.Dispose();
            unit.GetParent<UnitComponent>().Remove(unit.Id);
            await root.GetComponent<TimerComponent>().WaitFrameAsync();
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
            // ActorId fubencenterId = UnitCacheHelper.GetFubenCenterId(scene.Zone());
            // int sceneType = 0;
            // if (scene != null && scene.GetComponent<MapComponent>() != null)
            // {
            //     sceneType = scene.GetComponent<MapComponent>().SceneType;
            // }
            //
            // M2F_FubenCenterOperateRequest request = M2F_FubenCenterOperateRequest.Create();
            // request.SceneType = sceneType;
            // request.OperateType = operateType;
            // request.FubenInstanceId = scene.InstanceId;
            // F2M_FubenCenterOpenResponse response = (F2M_FubenCenterOpenResponse)await scene.Root().GetComponent<MessageSender>().Call(fubencenterId, request);
            await ETTask.CompletedTask;
        }
    }
}