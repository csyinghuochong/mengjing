using System.Collections.Generic;
using MongoDB.Bson;
using Unity.Mathematics;

namespace ET.Server
{
    public static partial class TransferHelper
    {

        public static void RemoveStall(Unit unit)
        {
            List<Unit> stallList = UnitHelper.GetUnitList( unit.Scene(), UnitType.Stall );
            for (int i = stallList.Count - 1; i>= 0; i--)
            {
                if (stallList[i].MasterId == unit.Id)
                {
                    unit.GetParent<UnitComponent>().Remove(stallList[i].Id);
                }
            }
        }
        
        public static void RemovePetAndJingLing(Unit unit)
        {
            UnitComponent unitComponent = unit.Scene().GetComponent<UnitComponent>();
            RolePetInfo fightId = unit.GetComponent<PetComponentS>().GetFightPet();
            if (fightId != null)
            {
                unitComponent.Remove(fightId.Id);
            }
            long jinglingUnitId = unit.GetComponent<ChengJiuComponentS>().JingLingUnitId;
            if (jinglingUnitId != 0 && unitComponent.Get(jinglingUnitId) != null)
            {
                unitComponent.Remove(jinglingUnitId);
            }
            unit.GetComponent<ChengJiuComponentS>().JingLingUnitId = 0;
        }

        
        public static async ETTask<int> TransferUnit(Unit unit, C2M_TransferMap request)
        {
            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Transfer, unit.Id))
            {
                if (unit.IsDisposed)
                {
                    return ErrorCode.ERR_RequestRepeatedly;
                }
                int oldScene = unit.Scene().GetComponent<MapComponent>().SceneType;
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
                 
                        Scene fubnescene =  GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId, "PetFuben" + fubenid.ToString());
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
                        int requestTowerId = int.Parse(request.paramInfo);
                        int passId = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.TrialDungeonId);
                        if (!TowerConfigCategory.Instance.Contain(requestTowerId))
                        {
                            Log.Error($"试炼之地作弊1:{unit.Zone()} {unit.Id} {requestTowerId}   {passId}");
                            return ErrorCode.ERR_ModifyData;
                        }
                        if (TowerConfigCategory.Instance.Get(requestTowerId).MapType!= SceneTypeEnum.TrialDungeon)
                        {
                            Log.Error($"试炼之地作弊2:{unit.Zone()} {unit.Id} {requestTowerId}   {passId}");
                            return ErrorCode.ERR_ModifyData;
                        }
                        
                        if (passId == 0 && requestTowerId != 20001)
                        {
                            Log.Error($"试炼之地作弊3:{unit.Zone()} {unit.Id} {requestTowerId}   {passId}");
                            return ErrorCode.ERR_ModifyData;
                        }
                        if (passId != 0 && requestTowerId > passId + 1 )
                        {
                            Log.Error($"试炼之地作弊4:{unit.Zone()} {unit.Id} {requestTowerId}   {passId}");
                            return ErrorCode.ERR_ModifyData;
                        }
                        
                        fubenid = IdGenerater.Instance.GenerateId();
                        fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                        fubnescene =  GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId,  "TrialDungeon" + fubenid.ToString());
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
                        int seasonTowerid = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.SeasonTowerId);
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
                        fubnescene =  GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId,  "SeasonTower" + fubenid.ToString());
                        fubnescene.AddComponent<SeasonTowerComponent>();
                        mapComponent = fubnescene.GetComponent<MapComponent>();
                        mapComponent.SetMapInfo((int)SceneTypeEnum.SeasonTower, request.SceneId, int.Parse(request.paramInfo));
                        mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(request.SceneId).MapID;
                        TransferHelper.BeforeTransfer(unit);
                        await TransferHelper.Transfer(unit, fubnescene.GetActorId(), (int)SceneTypeEnum.SeasonTower, request.SceneId, FubenDifficulty.None, request.paramInfo);
                        TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
                        break;
                    case SceneTypeEnum.TowerOfSeal:
                        int finished = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.TowerOfSealFinished);
                        // 服务端再判断是否已经通关塔顶
                        if (finished >= 100)
                        {
                            return ErrorCode.ERR_TowerOfSealReachTop;
                        }

                        fubenid = IdGenerater.Instance.GenerateId();
                        fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                        fubnescene =   GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId,"TowerOfSeal" + fubenid.ToString());
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
                        fubnescene =  GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId,  "RandomTower" + fubenid.ToString());
                        fubnescene.AddComponent<RandomTowerComponent>();
                        mapComponent = fubnescene.GetComponent<MapComponent>();
                        mapComponent.SetMapInfo((int)SceneTypeEnum.RandomTower, request.SceneId, 0);
                        mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(request.SceneId).MapID;
                        TransferHelper.BeforeTransfer(unit);
                        await TransferHelper.Transfer(unit, fubnescene.GetActorId(), (int)SceneTypeEnum.RandomTower, request.SceneId, 0, "0");
                        TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
                        break;
                    case (int)SceneTypeEnum.Union:
                        long unionid = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.UnionId_0);
                        if (unionid == 0)
                        {
                            return ErrorCode.ERR_Union_Not_Exist;
                        }
                        ActorId mapInstanceId = UnitCacheHelper.GetUnionServerId(unit.Zone());
                         U2M_UnionEnterResponse responseUnionEnter = (U2M_UnionEnterResponse)await unit.Root().GetComponent<MessageSender>().Call(
                         mapInstanceId, new M2U_UnionEnterRequest() { UnionId = unionid, UnitId = unit.Id, SceneId = request.SceneId });
                        TransferHelper.BeforeTransfer(unit);
                        await TransferHelper.Transfer(unit, responseUnionEnter.FubenActorId, (int)SceneTypeEnum.Union, request.SceneId, request.Difficulty, "0");
                        break;
                    case (int)SceneTypeEnum.JiaYuan:
                        //动态创建副本
                        Scene scene = unit.Root();
                        mapInstanceId = UnitCacheHelper.GetJiaYuanServerId(unit.Zone());
                        ///进入之前先刷新一下
                        if (long.Parse(request.paramInfo) == unit.Id)
                        {
                            JiaYuanComponentS jiaYuanComponent = unit.GetComponent<JiaYuanComponentS>();
                            jiaYuanComponent.OnBeforEnter();
                            await UnitCacheHelper.SaveComponentCache(unit.Root(), jiaYuanComponent);
                        }
                        J2M_JiaYuanEnterResponse j2M_JianYuanEnterResponse = (J2M_JiaYuanEnterResponse)await unit.Root().GetComponent<MessageSender>().Call(
                        mapInstanceId, new M2J_JiaYuanEnterRequest() { MasterId = long.Parse(request.paramInfo), UnitId = unit.Id, SceneId = request.SceneId });
                        TransferHelper.BeforeTransfer(unit);
                        await TransferHelper.Transfer(unit, j2M_JianYuanEnterResponse.FubenActorId, (int)SceneTypeEnum.JiaYuan, request.SceneId, request.Difficulty, "0");
                        
                        if (oldScene == SceneTypeEnum.JiaYuan)
                        {
                            JiaYuanSceneComponent jiayuanSceneComponent = scene.GetParent<JiaYuanSceneComponent>();
                            jiayuanSceneComponent.OnUnitLeave(scene);
                        }
                        break;
                    case (int)SceneTypeEnum.Tower:
                        //动态创建副本
                        fubenid = IdGenerater.Instance.GenerateId();
                        fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                        fubnescene = GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId, "Tower" + fubenid.ToString());
                        fubnescene.AddComponent<TowerComponent>().FubenDifficulty = request.Difficulty;
                        mapComponent = fubnescene.GetComponent<MapComponent>();
                        mapComponent.SetMapInfo((int)SceneTypeEnum.Tower, request.SceneId, 0);
                        mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(request.SceneId).MapID;
                        TransferHelper.BeforeTransfer(unit);
                        await TransferHelper.Transfer(unit, fubnescene.GetActorId(), (int)SceneTypeEnum.Tower, request.SceneId, request.Difficulty, "0");
                        TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
                        break;
                    case SceneTypeEnum.OneChallenge:
                        fubenid = long.Parse(request.paramInfo);
                        fubnescene = unit.Root().GetChild<Scene>(fubenid);
                        bool newdungeon = false;
                        if (fubnescene == null)
                        {
                            newdungeon = true;
                            fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                            fubnescene = GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId,  "OneChallenge" + fubenid.ToString());
                            mapComponent = fubnescene.GetComponent<MapComponent>();
                            mapComponent.SetMapInfo((int)SceneTypeEnum.OneChallenge, request.SceneId, 0);
                            mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(request.SceneId).MapID;
                            //Game.Scene.GetComponent<RecastPathComponent>().Update(fubnescene.GetComponent<MapComponent>().NavMeshId);
                        }
                        fubenInstanceId = fubnescene.InstanceId;
                        TransferHelper.BeforeTransfer(unit);
                        await TransferHelper.Transfer(unit, fubnescene.GetActorId(), (int)SceneTypeEnum.OneChallenge, request.SceneId, request.Difficulty, "0");
                        if (newdungeon)
                        {
                            TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
                        }
                        break;
                    case (int)SceneTypeEnum.PetMing:
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
                        fubnescene.GetComponent<MapComponent>().SetMapInfo((int)SceneTypeEnum.PetMing, request.SceneId, 0);
                        TransferHelper.BeforeTransfer(unit);
                        await TransferHelper.Transfer(unit, fubnescene.GetActorId(), (int)SceneTypeEnum.PetMing, request.SceneId, request.Difficulty, praminfos[0]);
                        TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
                        break;
                    case (int)SceneTypeEnum.PetTianTi:
                        ////动态创建副本
                        long enemyId = long.Parse(request.paramInfo);
                        fubenid = IdGenerater.Instance.GenerateId();
                        fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                        fubnescene = GateMapFactory.Create(unit.Root(), fubenid, fubenInstanceId,  "Fuben" + fubenid.ToString());
                        fubnescene.AddComponent<PetTianTiComponent>().EnemyId = enemyId;
                        fubnescene.GetComponent<MapComponent>().SetMapInfo((int)SceneTypeEnum.PetTianTi, request.SceneId, 0);
                        TransferHelper.BeforeTransfer(unit);
                        await TransferHelper.Transfer(unit, fubnescene.GetActorId(), (int)SceneTypeEnum.PetTianTi, request.SceneId, 0, "0");
                        TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
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
                        unit.GetComponent<SkillManagerComponentS>()?.OnFinish(false);
                         int errorCode = await TransferHelper.LocalDungeonTransfer(unit, request.SceneId, int.Parse(request.paramInfo), request.Difficulty);
                         if (errorCode != ErrorCode.ERR_Success)
                         {
                             return errorCode;
                         }
                        break;
                    case SceneTypeEnum.BaoZang:
                    case SceneTypeEnum.MiJing:
                        F2M_YeWaiSceneIdResponse f2M_YeWaiSceneIdResponse = (F2M_YeWaiSceneIdResponse)await unit.Root().GetComponent<MessageSender>().Call(
                        UnitCacheHelper.GetFubenCenterId(unit.Zone()), new M2F_YeWaiSceneIdRequest() { SceneId = request.SceneId });
                        if (f2M_YeWaiSceneIdResponse.FubenInstanceId == 0)
                        {
                            return ErrorCode.ERR_MapLimit;
                        }
                        
                        SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                        int curPlayerNum = int.Parse(f2M_YeWaiSceneIdResponse.Message); // UnitHelper.GetUnitList(unit.DomainScene(), UnitType.Player).Count;
                        if (sceneConfig.PlayerLimit > 0 && sceneConfig.PlayerLimit <= curPlayerNum)
                        {
                            return ErrorCode.ERR_MapLimit;
                        }
                        TransferHelper.BeforeTransfer(unit);
                        await TransferHelper.Transfer(unit, f2M_YeWaiSceneIdResponse.FubenActorId, sceneConfig.MapType, request.SceneId, 0, "0");
                        break;
                    case SceneTypeEnum.RunRace:
                    case SceneTypeEnum.Demon:
                        f2M_YeWaiSceneIdResponse = (F2M_YeWaiSceneIdResponse)await unit.Root().GetComponent<MessageSender>().Call(
                        UnitCacheHelper.GetFubenCenterId(unit.Zone()), new M2F_YeWaiSceneIdRequest() { SceneId = request.SceneId,UnitId = unit.Id  });
                        if (f2M_YeWaiSceneIdResponse.FubenInstanceId == 0)
                        {
                            return ErrorCode.ERR_AlreadyFinish;
                        }
                        sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                        TransferHelper.BeforeTransfer(unit);
                        await TransferHelper.Transfer(unit, f2M_YeWaiSceneIdResponse.FubenActorId, sceneConfig.MapType, request.SceneId, 0, "0");
                        break;
                    case SceneTypeEnum.Solo:
                        ActorId soloServerId = UnitCacheHelper.GetSoloServerId(unit.Zone());
                        S2M_SoloEnterResponse d2GGetUnit = (S2M_SoloEnterResponse)await unit.Root().GetComponent<MessageSender>().Call(soloServerId, new M2S_SoloEnterRequest()
                        {
                            FubenId = long.Parse(request.paramInfo)
                        });
                        
                        if (d2GGetUnit.Error != ErrorCode.ERR_Success)
                        {
                            return d2GGetUnit.Error;
                        }
                        if (d2GGetUnit.FubenInstanceId == 0)
                        {
                            return ErrorCode.ERR_ModifyData;
                        }
                        if ( !FunctionHelp.IsInTime(1045))
                        {
                            return ErrorCode.ERR_AlreadyFinish;
                        }
                        oldscene = unit.Scene();
                        mapComponent = oldscene.GetComponent<MapComponent>();
                        sceneTypeEnum = mapComponent.SceneType;
                        TransferHelper.BeforeTransfer(unit);
                        await TransferHelper.Transfer(unit, d2GGetUnit.FubenActorId, SceneTypeEnum.Solo, request.SceneId, 0, "0");
                        if (SceneConfigHelper.IsSingleFuben(sceneTypeEnum))
                        {
                            TransferHelper.NoticeFubenCenter(oldscene, 2).Coroutine();
                            oldscene.Dispose();
                        }
                        break;
                    case SceneTypeEnum.UnionRace:
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
                        responseUnionEnter = (U2M_UnionEnterResponse)await unit.Root().GetComponent<MessageSender>().Call(
                        mapInstanceId, new M2U_UnionEnterRequest() { OperateType = 1, UnionId = unionid, UnitId = unit.Id, SceneId = request.SceneId });
                        if (responseUnionEnter.FubenInstanceId == 0)
                        {
                            return ErrorCode.ERR_AlreadyFinish;
                        }
                        TransferHelper.BeforeTransfer(unit);
                        await TransferHelper.Transfer(unit, responseUnionEnter.FubenActorId, SceneTypeEnum.UnionRace, request.SceneId, 0, "0");
                        break;
                    case SceneTypeEnum.Happy:
                        mapInstanceId = UnitCacheHelper.GetHappyServerId(unit.Zone());
                        H2M_HapplyEnterResponse happyEnter = (H2M_HapplyEnterResponse)await unit.Root().GetComponent<MessageSender>().Call(
                        mapInstanceId, new M2H_HapplyEnterRequest() { UnitId = unit.Id, SceneId = request.SceneId }); if (happyEnter.FubenInstanceId == 0)
                        {
                             return ErrorCode.ERR_AlreadyFinish;
                         }
                        TransferHelper.BeforeTransfer(unit);
                        await TransferHelper.Transfer(unit, happyEnter.FubenActorId, (int)SceneTypeEnum.Happy, request.SceneId, FubenDifficulty.Normal, happyEnter.Position.ToString());
                        break;
                    case SceneTypeEnum.Battle:
                        mapInstanceId = UnitCacheHelper.GetBattleServerId(unit.Zone());
                        B2M_BattleEnterResponse battleEnter = (B2M_BattleEnterResponse)await unit.Root().GetComponent<MessageSender>().Call(mapInstanceId, new M2B_BattleEnterRequest() { UserID = unit.Id, SceneId = request.SceneId });
                         if (battleEnter.FubenInstanceId == 0)
                         {
                             return ErrorCode.ERR_AlreadyFinish;
                         }
                        
                        TransferHelper.BeforeTransfer(unit);
                        await TransferHelper.Transfer(unit, battleEnter.FubenActorId, (int)SceneTypeEnum.Battle, request.SceneId, FubenDifficulty.Normal, battleEnter.Camp.ToString());
                        break;
                    case SceneTypeEnum.Arena:
                        userInfoComponent = unit.GetComponent<UserInfoComponentS>();
                        sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
                        if (userInfoComponent.UserInfo.Lv < sceneConfig.EnterLv)
                        {
                            return ErrorCode.ERR_LevelIsNot;
                        }
                        
                        mapInstanceId = UnitCacheHelper.GetArenaServerId(unit.Zone());
                        Arena2M_ArenaEnterResponse areneEnter = (Arena2M_ArenaEnterResponse)await unit.Root().GetComponent<MessageSender>().Call(
                        mapInstanceId, new M2Arena_ArenaEnterRequest() { UserID = unit.Id, SceneId = request.SceneId });
                        if (areneEnter.Error != ErrorCode.ERR_Success || areneEnter.FubenInstanceId == 0)
                        {
                            return ErrorCode.ERR_AlreadyFinish;
                        }
                        TransferHelper.BeforeTransfer(unit);
                        await TransferHelper.Transfer(unit, areneEnter.FubenActorId, (int)SceneTypeEnum.Arena, request.SceneId, FubenDifficulty.Normal, "0");
                        break;
                    case (int)SceneTypeEnum.TeamDungeon:
                        oldscene = unit.Scene();
                        mapComponent = oldscene.GetComponent<MapComponent>();
                        sceneTypeEnum = mapComponent.SceneType;
                        mapInstanceId = StartSceneConfigCategory.Instance.GetBySceneName(unit.Zone(), "Team").ActorId;
                        //[创建副本Scene]
                        T2M_TeamDungeonEnterResponse createUnit = (T2M_TeamDungeonEnterResponse)await unit.Root().GetComponent<MessageSender>().Call(
                        mapInstanceId, new M2T_TeamDungeonEnterRequest() { UserID = unit.GetComponent<UserInfoComponentS>().UserInfo.UserId });
                        if (createUnit.Error != ErrorCode.ERR_Success)
                        {
                            return ErrorCode.ERR_TransferFailError;
                        }
                        TransferHelper.BeforeTransfer(unit);
                        await TransferHelper.Transfer(unit, createUnit.FubenInstanceId, (int)SceneTypeEnum.TeamDungeon, createUnit.FubenId, createUnit.FubenType, "0");
                        if (SceneConfigHelper.IsSingleFuben(sceneTypeEnum))
                        {
                            TransferHelper.NoticeFubenCenter(oldscene, 2).Coroutine();
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

             long oldsceneid = unit.Root().Id;
             List<StartSceneConfig> zonelocaldungeons = StartSceneConfigCategory.Instance.LocalDungeons[unit.Zone()];
             int n = (int)( (unit.Id / 99) % zonelocaldungeons.Count);
             
             StartSceneConfig startSceneConfig =  zonelocaldungeons[n];
             sceneId = transferId != 0 ? DungeonTransferConfigCategory.Instance.Get(transferId).MapID : sceneId;
             if (sceneId == 0)
             {
                 Log.Error($"zonelocaldungeonsb:  unitid: {unit.Id}  n: {n}  transferId: {transferId} sceneId: {sceneId} ");
                 return ErrorCode.ERR_NotFindLevel;
             }
             
             Log.Debug("M2LocalDungeon_EnterRequest_2");
             
             LocalDungeon2M_EnterResponse createUnit = (LocalDungeon2M_EnterResponse)await unit.Root().GetComponent<MessageSender>().Call(
                         startSceneConfig.ActorId, new M2LocalDungeon_EnterRequest()
                         { 
                             UserID = unit.Id, SceneType = SceneTypeEnum.LocalDungeon, SceneId = sceneId, TransferId = transferId, Difficulty = difficulty
                         });

             if (createUnit.Error != ErrorCode.ERR_Success)
             {
                 return createUnit.Error;
             }

             TransferHelper.BeforeTransfer(unit);
             
             Log.Debug($"M2LocalDungeon_EnterRequest_2:{createUnit.Process} {createUnit.RootId} {createUnit.FubenInstanceId}");
             
             ActorId FubenInstanceId =  new ActorId(createUnit.Process, createUnit.RootId, createUnit.FubenInstanceId);
             await TransferHelper.Transfer(unit, FubenInstanceId, (int)SceneTypeEnum.LocalDungeon, sceneId, difficulty, transferId.ToString());

             //移除旧scene
             // Scene scene = unit.Root().GetChild<Scene>(oldsceneid);
             // if (scene.GetComponent<LocalDungeonComponent>() != null)
             // {
             //     //动态删除副本
             //     TransferHelper.NoticeFubenCenter(scene, 2).Coroutine();
             //     scene.Dispose();
             // }
             return ErrorCode.ERR_Success;   
         }
        
        public static async ETTask TransferAtFrameFinish(Unit unit, ActorId sceneInstanceId, string sceneName)
        {
            await unit.Fiber().WaitFrameFinish();

            await Transfer(unit, sceneInstanceId, SceneTypeEnum.MainCityScene, 101,  1, "0");
        }
        
        public static async ETTask MainCityTransfer(Unit unit)
        {
            MapComponent mapComponent = unit.Scene().GetComponent<MapComponent>();
            unit.GetComponent<UnitInfoComponent>().LastDungeonId = 0;
            //传送回主场景
            ActorId mapInstanceId = UnitCacheHelper.MainCityServerId(unit.Zone());
            //动态删除副本
            long userId = unit.Id;
            Scene scene = unit.Scene();
            TransferHelper.BeforeTransfer(unit);
            await TransferHelper.Transfer(unit, mapInstanceId, (int)SceneTypeEnum.MainCityScene, ComHelp.MainCityID(), 0, "0");
            OnTransfer(scene, userId);
        }
        
        public static void OnTransfer( Scene scene, long userId )
        {
            if (scene.IsDisposed)
            {
                Log.Warning($"ReturnMainCity: scene.IsDisposed");
                return;
            }

            int sceneTypeEnum = scene.GetComponent<MapComponent>().SceneType;
            if (SceneConfigHelper.IsSingleFuben(sceneTypeEnum))
            {
                TransferHelper.NoticeFubenCenter(scene, 2).Coroutine();
                scene.Dispose();
            }
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

        public static void AfterTransfer(Unit unit)
        {
            RolePetInfo fightId = unit.GetComponent<PetComponentS>().GetFightPet();
            if (fightId != null)
            {
                unit.GetComponent<PetComponentS>().UpdatePetAttribute(fightId, false);
                UnitFactory.CreatePet(unit, fightId);
            }
            int jinglingid  = unit.GetComponent<ChengJiuComponentS>().JingLingId;
            if (jinglingid != 0)
            {
                long JingLingUnitId = UnitFactory.CreateJingLing(unit, jinglingid).Id;
                unit.GetComponent<ChengJiuComponentS>().JingLingUnitId = JingLingUnitId;
            }
        }
        
        public static async ETTask Transfer(Unit unit, ActorId sceneInstanceId, int sceneType, int sceneId, int fubenDifficulty,  string paramInfo)
        {
            Scene root = unit.Root();
            // location加锁
            long unitId = unit.Id;
            
            M2M_UnitTransferRequest request = M2M_UnitTransferRequest.Create();
            request.OldActorId = unit.GetActorId();
            request.Unit = unit.ToBson();
            request.SceneType = sceneType;
            request.SceneId = sceneId;
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