using System;
using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    [EntitySystemOf(typeof (FubenCenterComponent))]
    [FriendOf(typeof (FubenCenterComponent))]
    public static partial class FubenCenterComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.FubenCenterComponent self)
        {
            self.FubenInstanceList.Clear();
            self.YeWaiFubenList.Clear();

            self.InitYeWaiScene().Coroutine();
        }

        public static int GetScenePlayer(this FubenCenterComponent self, long instanced)
        {
            foreach ((long id, Entity Entity) in self.Children)
            {
                if (Entity.InstanceId != instanced)
                {
                    continue;
                }

                return UnitHelper.GetUnitList(Entity as Scene, UnitType.Player).Count;
            }

            return 0;
        }

        public static void OnActivityOpen(this FubenCenterComponent self, int functionId)
        {
            if (functionId == 1025)
            {
                self.BattleOpen = true;
                self.BattleInfos.Clear();
                LogHelper.LogWarning($"OnBattleOpen : {self.Zone()}", true);
                // if (ServerHelper.GetOpenServerDay(false, self.Zone()) > 0 && !ComHelperS.IsInnerNet())
                // {
                //     ActorId robotSceneId = StartSceneConfigCategory.Instance.GetBySceneName(203, "Robot01").ActorId;
                //     self.Root().GetComponent<MessageSender>().Send(robotSceneId,
                //         new G2Robot_MessageRequest() { Zone = self.Zone(), MessageType = NoticeType.BattleOpen });
                // }
            }

            if (functionId == 1031)
            {
                self.ArenaOpen = true;
                self.ArenaInfos.Clear();
            }

            if (functionId == 1055)
            {
                self.HappyOpen = true;
                self.HappyInfos.Clear();
            }

            if (functionId == 1058)
            {
                self.RunRaceOpen = true;
                self.RunRaceInfos.Clear();
            }

            if (functionId == 1059)
            {
                self.DemonOpen = true;
                self.DemonInfos.Clear();
            }

            //Log.Console($"OnActivityOpen: {functionId}");
        }

        public static void OnActivityClose(this FubenCenterComponent self, int functionId)
        {
            if (functionId == 1025)
            {
                self.BattleOpen = false;
                self.OnBattleOver().Coroutine();
            }

            if (functionId == 1031)
            {
                self.ArenaOpen = false;
                self.DisposeFuben(functionId).Coroutine();
            }

            if (functionId == 1055)
            {
                self.HappyOpen = false;
                self.DisposeFuben(functionId).Coroutine();
            }

            if (functionId == 1058)
            {
                self.RunRaceOpen = false;
                self.DisposeFuben(functionId).Coroutine();
            }

            if (functionId == 1059)
            {
                self.DemonOpen = false;
                self.DisposeFuben(functionId).Coroutine();
            }

            //Log.Console($"OnActivityClose: {functionId}");
        }

        public static BattleInfo GetFunctionFubenId(this FubenCenterComponent self, int functionId, long unitId)
        {
            List<BattleInfo> battleInfos = null;
            int playerLimit = 20;
            if (functionId == 1031)
            {
                battleInfos = self.ArenaInfos;
                playerLimit = 1000000;
            }
            if (functionId == 1055)
            {
                battleInfos = self.HappyInfos;
            }
            if (functionId == 1058)
            {
                battleInfos = self.RunRaceInfos;
            }
            if (functionId == 1059)
            {
                battleInfos = self.DemonInfos;
            }

            if (battleInfos == null)
            {
                return null;
            }

            for (int i = 0; i < battleInfos.Count; i++)
            {
                BattleInfo battleInfoItem = battleInfos[i];
                Scene fubenscene = self.GetChild<Scene>(battleInfoItem.FubenId);
                if (fubenscene == null)
                {
                    Log.Error("scene == null");
                    continue;
                }

                if (battleInfoItem.Camp1Player.Contains(unitId))
                {
                    return battleInfoItem;
                }

                if (battleInfoItem.Camp1Player.Count < playerLimit)
                {
                    battleInfoItem.Camp1Player.Add(unitId);
                    return battleInfoItem;
                }
            }

            //动态创建副本.....RecastPathComponent.awake寻路
            int sceneid = 0;
            if (functionId == 1031)
            {
                sceneid = BattleHelper.GetSceneIdByType(SceneTypeEnum.Arena);
            }
            if (functionId == 1055)
            {
                sceneid = BattleHelper.GetSceneIdByType(SceneTypeEnum.Happy);
            }
            if (functionId == 1058)
            {
                sceneid = BattleHelper.GetSceneIdByType(SceneTypeEnum.RunRace);
            }
            if (functionId == 1059)
            {
                sceneid = BattleHelper.GetSceneIdByType(SceneTypeEnum.Demon);
            }

            if (sceneid == 0)
            {
                return null;
            }

            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneid);
            long fubenid = IdGenerater.Instance.GenerateId();
            long fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
            Log.Warning($"GenarateFuben2.{fubenInstanceId}");

            self.FubenInstanceList.Add(fubenInstanceId);
            //self.YeWaiFubenList.Add(sceneConfig.Id, fubenInstanceId);  可能有多个不能这样搞

            Scene fubnescene = GateMapFactory.Create(self, fubenid, fubenInstanceId, "Fuben" + sceneConfig.Id.ToString());
            MapComponent mapComponent = fubnescene.GetComponent<MapComponent>();
            mapComponent.SetMapInfo(sceneConfig.MapType, sceneConfig.Id, 0);
            mapComponent.NavMeshId = sceneConfig.MapID;
            //Game.Scene.GetComponent<RecastPathComponent>().Update(mapComponent.NavMeshId);
            fubnescene.GetComponent<ServerInfoComponent>().ServerInfo = self.ServerInfo;
            YeWaiRefreshComponent yeWaiRefreshComponen = fubnescene.AddComponent<YeWaiRefreshComponent>();
            yeWaiRefreshComponen.SceneId = sceneConfig.Id;

            switch (sceneConfig.MapType)
            {
                case SceneTypeEnum.Arena:
                    fubnescene.AddComponent<ArenaDungeonComponent>();
                    fubnescene.GetComponent<ArenaDungeonComponent>().OnArenaOpen();
                    break;
                case SceneTypeEnum.Happy:
                    fubnescene.AddComponent<HappyDungeonComponent>();
                    fubnescene.GetComponent<HappyDungeonComponent>().OnHappyBegin();
                    break;
                case SceneTypeEnum.RunRace:
                    fubnescene.AddComponent<RunRaceDungeonComponent>();
                    fubnescene.GetComponent<RunRaceDungeonComponent>().OnBegin();
                    break;
                case SceneTypeEnum.Demon:
                    fubnescene.AddComponent<DemonDungeonComponent>();
                    fubnescene.GetComponent<DemonDungeonComponent>().OnBegin();
                    break;
                default:
                    break;
            }

            FubenHelp.CreateNpc(fubnescene, sceneid);
            FubenHelp.CreateMonsterList(fubnescene, sceneConfig.CreateMonster);
            FubenHelp.CreateMonsterList(fubnescene, sceneConfig.CreateMonsterPosi);

            ActorId actorId = new ActorId(self.Fiber().Process, self.Fiber().Id, fubenInstanceId);
            BattleInfo battleInfo = new BattleInfo() { SceneId = sceneid, FubenId = fubenid, FubenInstanceId = fubenInstanceId, ActorId = actorId };
            battleInfo.PlayerList.Add(unitId, new ArenaPlayerStatu() { UnitId = unitId });
            battleInfos.Add(battleInfo);

            return battleInfo;
        }

        public static BattleInfo GetArenaInfo(this FubenCenterComponent self, long fubenId)
        {
            for (int i = 0; i < self.ArenaInfos.Count; i++)
            {
                if (fubenId!= self.ArenaInfos[i].FubenId)
                {
                    continue;
                }

                Scene scene = self.GetChild<Scene>(self.ArenaInfos[i].FubenId);
                if (scene == null)
                {
                    Log.Error($"scene == null");
                    break;
                }

                return self.ArenaInfos[i];
            }

            return null;
        }

        /// <summary>
        /// 活动关闭 ，一段时间后销毁副本
        /// </summary>
        /// <param name="self"></param>
        /// <param name="functionId"></param>
        /// <returns></returns>
        public static async ETTask DisposeFuben(this FubenCenterComponent self, int functionId)
        {
            long waitDisposeTime = 0;

            List<BattleInfo> battleInfos = null;
            if (functionId == 1025)
            {
                battleInfos = self.BattleInfos;
            }

            if (functionId == 1031)
            {
                battleInfos = self.ArenaInfos;
            }

            if (functionId == 1055)
            {
                battleInfos = self.HappyInfos;
            }

            if (functionId == 1058)
            {
                battleInfos = self.RunRaceInfos;
            }

            if (functionId == 1059)
            {
                battleInfos = self.DemonInfos;
            }

            switch (functionId)
            {
                case 1025:

                    break;
                case 1031:
                    for (int i = 0; i < battleInfos.Count; i++)
                    {
                        Scene scene = self.GetChild<Scene>(battleInfos[i].FubenId);
                        if (scene == null)
                        {
                            Log.Error($"scene == null");
                            break;
                        }
                        scene.GetComponent<ArenaDungeonComponent>().OnArenaClose();
                    }
                    FuntionConfig funtionConfig = FuntionConfigCategory.Instance.Get(1031);
                    string[] openTimes = funtionConfig.OpenTime.Split('@');

                    int closeTime_1 = int.Parse(openTimes[1].Split(';')[0]);
                    int closeTime_2 = int.Parse(openTimes[1].Split(';')[1]);
                    long closeTime = (closeTime_1 * 60 + closeTime_2) * 60;

                    int endTime_1 = int.Parse(openTimes[2].Split(';')[0]);
                    int endTime_2 = int.Parse(openTimes[2].Split(';')[1]);
                    long endTime = (endTime_1 * 60 + endTime_2) * 60;

                    waitDisposeTime = (endTime - closeTime) * 1000;
                    break;
                case 1055:
                    for (int i = 0; i < battleInfos.Count; i++)
                    {
                        Scene scene = self.GetChild<Scene>(battleInfos[i].FubenId);
                        if (scene == null)
                        {
                            Log.Error($"scene == null");
                            break;
                        }

                        scene.GetComponent<HappyDungeonComponent>().OnHappyOver().Coroutine();
                        waitDisposeTime = 60;
                    }

                    break;
                case 1058:
                    for (int i = 0; i < battleInfos.Count; i++)
                    {
                        Scene scene = self.GetChild<Scene>(battleInfos[i].FubenId);
                        if (scene == null)
                        {
                            Log.Error($"scene == null");
                            break;
                        }

                        scene.GetComponent<RunRaceDungeonComponent>().OnClose();
                    }

                    funtionConfig = FuntionConfigCategory.Instance.Get(1058);
                    openTimes = funtionConfig.OpenTime.Split('@');

                     closeTime_1 = int.Parse(openTimes[1].Split(';')[0]);
                     closeTime_2 = int.Parse(openTimes[1].Split(';')[1]);
                     closeTime = (closeTime_1 * 60 + closeTime_2) * 60;

                     endTime_1 = int.Parse(openTimes[2].Split(';')[0]);
                     endTime_2 = int.Parse(openTimes[2].Split(';')[1]);
                     endTime = (endTime_1 * 60 + endTime_2) * 60;

                    waitDisposeTime = (endTime - closeTime) * 1000;
                    break;
                case 1059:
                    for (int i = 0; i < battleInfos.Count; i++)
                    {
                        Scene scene = self.GetChild<Scene>(battleInfos[i].FubenId);
                        if (scene == null)
                        {
                            Log.Error($"scene == null");
                            break;
                        }

                        scene.GetComponent<DemonDungeonComponent>().OnClose();
                    }

                    funtionConfig = FuntionConfigCategory.Instance.Get(1059);
                    openTimes = funtionConfig.OpenTime.Split('@');

                    closeTime_1 = int.Parse(openTimes[1].Split(';')[0]);
                    closeTime_2 = int.Parse(openTimes[1].Split(';')[1]);
                    closeTime = (closeTime_1 * 60 + closeTime_2) * 60;

                    endTime_1 = int.Parse(openTimes[2].Split(';')[0]);
                    endTime_2 = int.Parse(openTimes[2].Split(';')[1]);
                    endTime = (endTime_1 * 60 + endTime_2) * 60;

                    waitDisposeTime = (endTime - closeTime) * 1000;
                    break;
            }

            await self.Root().GetComponent<TimerComponent>().WaitAsync(waitDisposeTime);

            foreach (var item in battleInfos)
            {
                BattleInfo battleInfo = item;
                Scene fubenScene = self.GetChild<Scene>(battleInfo.FubenId);
                if (fubenScene == null)
                {
                    Log.Error($"scene == null");
                    break;
                }

                long instanceid = fubenScene.InstanceId;
                if (self.FubenInstanceList.Contains(instanceid))
                {
                    self.FubenInstanceList.Remove(instanceid);
                    Log.Warning($"DisposeFubenInstance; {functionId}  {instanceid}");
                }

                C2M_TransferMap actor_Transfer = new C2M_TransferMap() { SceneType = SceneTypeEnum.MainCityScene, };
                List<EntityRef<Unit>> units = fubenScene.GetComponent<UnitComponent>().GetAll();
                for (int unit = 0; unit < units.Count; unit++)
                {
                    Unit uniitem = units[unit];
                    if (uniitem.Type != UnitType.Player)
                    {
                        continue;
                    }

                    if (uniitem.IsDisposed || uniitem.IsRobot())
                    {
                        continue;
                    }

                    TransferHelper.TransferUnit(uniitem, actor_Transfer).Coroutine();
                }

                await self.Root().GetComponent<TimerComponent>().WaitAsync(60000 + RandomHelper.RandomNumber(0, 1000));
                fubenScene.Dispose();
                break;
            }

            battleInfos.Clear();
        }
        

        #region YeWai
        public static async ETTask InitYeWaiScene(this FubenCenterComponent self)
        {
            await self.Root().GetComponent<TimerComponent>().WaitAsync(RandomHelper.RandomNumber(0, 1000));

            List<SceneConfig> sceneConfigs = SceneConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < sceneConfigs.Count; i++)
            {
                if (sceneConfigs[i].MapType != SceneTypeEnum.BaoZang
                    && sceneConfigs[i].MapType != SceneTypeEnum.MiJing)
                {
                    continue;
                }

                //动态创建副本.....RecastPathComponent.awake寻路
                long fubenid = IdGenerater.Instance.GenerateId();
                long fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();

                self.FubenInstanceList.Add(fubenInstanceId);
                self.YeWaiFubenList.Add(sceneConfigs[i].Id, fubenInstanceId);
                self.FubenActorIdList.Add(sceneConfigs[i].Id, new ActorId(self.Fiber().Process, self.Fiber().Id, fubenInstanceId));

                Scene fubnescene = GateMapFactory.Create(self, fubenid, fubenInstanceId, "YeWai" + sceneConfigs[i].Id.ToString());
                MapComponent mapComponent = fubnescene.GetComponent<MapComponent>();
                mapComponent.SetMapInfo(sceneConfigs[i].MapType, sceneConfigs[i].Id, 0);
                mapComponent.NavMeshId = sceneConfigs[i].MapID;
                fubnescene.GetComponent<ServerInfoComponent>().ServerInfo = self.ServerInfo;
                YeWaiRefreshComponent yeWaiRefreshComponen = fubnescene.AddComponent<YeWaiRefreshComponent>();
                yeWaiRefreshComponen.SceneId = sceneConfigs[i].Id;

                switch (sceneConfigs[i].MapType)
                {
                    case SceneTypeEnum.MiJing:
                        fubnescene.AddComponent<MiJingComponent>();
                        break;
                    default:
                        break;
                }

                FubenHelp.CreateMonsterList(fubnescene, sceneConfigs[i].CreateMonster);
                FubenHelp.CreateMonsterList(fubnescene, sceneConfigs[i].CreateMonsterPosi);

                int openDay = ServerHelper.GetOpenServerDay(false, self.Zone());
                yeWaiRefreshComponen.OnZeroClockUpdate(openDay);
            }
        }
        #endregion

        #region Battle
public static (int, BattleInfo) GenerateBattleInstanceId(this FubenCenterComponent self, long unitid, int sceneId)
        {
            //动态创建副本
            long fubenid = IdGenerater.Instance.GenerateId();
            long fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
            Scene fubnescene = GateMapFactory.Create(self, fubenid, fubenInstanceId, "Battle" + fubenid.ToString());
            //Console.WriteLine($"M2LocalDungeon_Enter: {fubnescene.Name}   {scene.DomainZone()}");
            fubnescene.AddComponent<BattleDungeonComponent>().SendReward = false;
            fubnescene.GetComponent<BattleDungeonComponent>().BattleOpenTime = TimeHelper.ServerNow();
            MapComponent mapComponent = fubnescene.GetComponent<MapComponent>();
            mapComponent.SetMapInfo((int)SceneTypeEnum.Battle, sceneId, 0);
            mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(sceneId).MapID;
            //Game.Scene.GetComponent<RecastPathComponent>().Update(mapComponent.NavMeshId);
            fubnescene.AddComponent<YeWaiRefreshComponent>().SceneId = sceneId;
            FubenHelp.CreateNpc(fubnescene, sceneId);
            FubenHelp.CreateMonsterList(fubnescene, SceneConfigCategory.Instance.Get(sceneId).CreateMonster);
            FubenHelp.CreateMonsterList(fubnescene, SceneConfigCategory.Instance.Get(sceneId).CreateMonsterPosi);

            TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();

            BattleInfo battleInfo = self.AddChild<BattleInfo>();
            battleInfo.FubenId = fubenid;
            battleInfo.PlayerNumber = 0;
            battleInfo.FubenInstanceId = fubenInstanceId;
            battleInfo.SceneId = sceneId;
            battleInfo.ActorId = new ActorId(self.Fiber().Process, self.Fiber().Id, fubenInstanceId);

            battleInfo.PlayerNumber++;
            int camp = battleInfo.PlayerNumber % 2 + 1;
            if (camp == 1)
            {
                battleInfo.Camp1Player.Add(unitid);
            }
            else
            {
                battleInfo.Camp2Player.Add(unitid);
            }

            self.BattleInfos.Add(battleInfo);
            return (camp, battleInfo);
        }

        public static (int, BattleInfo) GetBattleInstanceId(this FubenCenterComponent self, long unitid, int sceneId)
        {
            if (!self.BattleOpen)
            {
                return (0, null);
            }

            int camp = 0;
            BattleInfo battleInfo = null;
            for (int i = 0; i < self.BattleInfos.Count; i++)
            {
                battleInfo = self.BattleInfos[i];
                if (battleInfo.SceneId != sceneId)
                {
                    continue;
                }

                if (battleInfo.Camp1Player.Contains(unitid))
                {
                    camp = 1;
                    break;
                }

                if (battleInfo.Camp2Player.Contains(unitid))
                {
                    camp = 2;
                    break;
                }

                if (battleInfo.PlayerNumber < CommonHelp.GetPlayerLimit(sceneId))
                {
                    battleInfo.PlayerNumber++;
                    camp = battleInfo.PlayerNumber % 2 + 1;
                    if (camp == 1)
                    {
                        battleInfo.Camp1Player.Add(unitid);
                    }
                    else
                    {
                        battleInfo.Camp2Player.Add(unitid);
                    }

                    break;
                }
            }

            if (battleInfo == null)
            {
                return self.GenerateBattleInstanceId(unitid, sceneId);
            }

            return (camp, battleInfo);
        }

        public static async ETTask OnBattleOver(this FubenCenterComponent self)
        {
            self.BattleOpen = false;
            LogHelper.LogDebug($"OnBattleOver : {self.Zone()}");
            //Console.WriteLine($"OnBattleOver : {self.DomainZone()}");
            ActorId robotSceneId = StartSceneConfigCategory.Instance.GetBySceneName(203, "Robot01").ActorId;
            self.Root().GetComponent<MessageSender>().Send(robotSceneId,
                new G2Robot_MessageRequest() { Zone = self.Zone(), MessageType = NoticeType.BattleOver });

            await self.Root().GetComponent<TimerComponent>().WaitAsync(RandomHelper.RandomNumber(10000, 20000));
            for (int i = 0; i < self.BattleInfos.Count; i++)
            {
                try
                {
                    Scene fubenscene = self.GetChild<Scene>(self.BattleInfos[i].FubenId);
                    fubenscene.GetComponent<BattleDungeonComponent>().OnBattleOver(self.BattleInfos[i].Camp1Player, self.BattleInfos[i].Camp2Player);
                    await fubenscene.GetComponent<BattleDungeonComponent>().KickOutPlayer();
                    await fubenscene.Root().GetComponent<TimerComponent>().WaitAsync(60000 + RandomHelper.RandomNumber(0, 1000));
                    TransferHelper.NoticeFubenCenter(fubenscene, 2).Coroutine();
                    fubenscene.Dispose();
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                }
            }

            self.BattleInfos.Clear();
        }
        #endregion
    }
}