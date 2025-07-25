using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof(FubenCenterComponent))]
    [FriendOf(typeof(FubenCenterComponent))]
    public static partial class FubenCenterComponentSystem
    {
        [EntitySystem]
        private static void Awake(this FubenCenterComponent self)
        {
            self.FubenInstanceList.Clear();
            self.YeWaiFubenList.Clear();
            
            //野外场景都放在FubenCenter1  其他玩法根据规则放在不同的
            self.InitYeWaiScene(new List<int>(){MapTypeEnum.BaoZang,  MapTypeEnum.MiJing}).Coroutine();
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

        public static async ETTask NoticeBattleOpen(this FubenCenterComponent self)
        {
            if (ServerHelper.GetServeOpenDay( self.Zone()) <= 0)
            {
                  return;
            }
            await self.Root().GetComponent<TimerComponent>().WaitAsync( RandomHelper.RandomNumber(5,10)*1000 );
            ActorId robotSceneId = UnitCacheHelper.GetRobotServerId();
            G2Robot_MessageRequest g2RobotMessageRequest = G2Robot_MessageRequest.Create();
            g2RobotMessageRequest.Zone = self.Zone();
            g2RobotMessageRequest.MessageType = NoticeType.BattleOpen;
            self.Root().GetComponent<MessageSender>().Send(robotSceneId,g2RobotMessageRequest);
        }

        public static void OnActivityOpen(this FubenCenterComponent self, int functionId)
        {
            if (functionId == 1025)
            {
                self.BattleOpen = true;
                self.BattleInfos.Clear();
                Console.WriteLine($"OnBattleOpen : {self.Zone()}");
                self.NoticeBattleOpen().Coroutine();
            }

            if (functionId == 1031)
            {
                self.ArenaOpen = true;
                self.ArenaInfos.Clear();
            }

            if (functionId == 1043 )
            {
                //Log.Console("OnUnionBoss");
                self.OnUnionBoss();
            }
            if (functionId == 1044)
            {
                //Log.Console("OnUnionRaceBegin");
                self.OnUnionRaceBegin();
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


            Console.WriteLine($"OnActivityOpen: {functionId}");
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
            
            if (functionId == 1044 )
            {
                //Log.Console("UnionSceneComponent.OnUnionRaceOver");
                self.OnUnionRaceOver();
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

             Console.WriteLine($"OnActivityClose: {functionId}");
        }

        public static int GetFunctionId(this FubenCenterComponent self,int sceneId)
        {
            int functionId = 0;

            if (sceneId == 1200001 || sceneId == 1200002)
            {
                functionId = 1025; //战场
            }

            if (sceneId == 6000001)
            {
                functionId = 1031;  //角斗场
            }
            if (sceneId == 8000001)
            {
                functionId = 1055;  //喜从天降
            }
            if (sceneId == 6000002)
            {
                functionId = 1058;  //变身比赛
            }
            if (sceneId == 6000003)
            {
                functionId = 1059;  //恶魔比赛
            }

            return functionId;
        }
        
        public static BattleInfo GetBattleFuben(this FubenCenterComponent self, int functionId, long unitId)
        {
            List<BattleInfo> battleInfos = null;
            int playerLimit = 20;
            if (functionId == 1031)
            {
                if(!self.ArenaOpen)
                {
                    return null;
                }
                battleInfos = self.ArenaInfos;
                playerLimit = 1000000;
            }

            if (functionId == 1055)
            {
                if(!self.HappyOpen)
                {
                    return null;
                }
                battleInfos = self.HappyInfos;
            }

            if (functionId == 1058)
            {
                if(!self.RunRaceOpen)
                {
                    return null;
                }
                battleInfos = self.RunRaceInfos;
            }

            if (functionId == 1059)
            {
                if(!self.DemonOpen)
                {
                    return null;
                }
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
                sceneid = BattleHelper.GetSceneIdByType(MapTypeEnum.Arena);
            }

            if (functionId == 1055)
            {
                sceneid = BattleHelper.GetSceneIdByType(MapTypeEnum.Happy);
            }

            if (functionId == 1058)
            {
                sceneid = BattleHelper.GetSceneIdByType(MapTypeEnum.RunRace);
            }

            if (functionId == 1059)
            {
                sceneid = BattleHelper.GetSceneIdByType(MapTypeEnum.Demon);
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
            YeWaiRefreshComponent yeWaiRefreshComponen = fubnescene.AddComponent<YeWaiRefreshComponent>();
            yeWaiRefreshComponen.SceneId = sceneConfig.Id;

            ActorId actorId = new ActorId(self.Fiber().Process, self.Fiber().Id, fubenInstanceId);
            BattleInfo battleInfo = new BattleInfo() { SceneId = sceneid, FubenId = fubenid, FubenInstanceId = fubenInstanceId, ActorId = actorId };
            battleInfo.PlayerList.Add(unitId, new ArenaPlayerStatu() { UnitId = unitId });
            battleInfos.Add(battleInfo);

            switch (sceneConfig.MapType)
            {
                case MapTypeEnum.Arena:
                    fubnescene.AddComponent<ArenaDungeonComponent>().ArenaInfo = battleInfo;
                    fubnescene.GetComponent<ArenaDungeonComponent>().OnArenaOpen();
                    break;
                case MapTypeEnum.Happy:
                    fubnescene.AddComponent<HappyDungeonComponent>();
                    fubnescene.GetComponent<HappyDungeonComponent>().OnHappyBegin();
                    break;
                case MapTypeEnum.RunRace:
                    fubnescene.AddComponent<RunRaceDungeonComponent>();
                    fubnescene.GetComponent<RunRaceDungeonComponent>().OnBegin();
                    break;
                case MapTypeEnum.Demon:
                    fubnescene.AddComponent<DemonDungeonComponent>();
                    fubnescene.GetComponent<DemonDungeonComponent>().OnBegin();
                    break;
                case MapTypeEnum.Union:

                    break;
                case MapTypeEnum.UnionRace:

                    break;
                default:
                    break;
            }

            FubenHelp.CreateNpc(fubnescene, sceneid);
            FubenHelp.CreateMonsterList(fubnescene, sceneConfig.CreateMonsterPosi);

            return battleInfo;
        }

        public static BattleInfo GetArenaInfo(this FubenCenterComponent self, long fubenId)
        {
            for (int i = 0; i < self.ArenaInfos.Count; i++)
            {
                if (fubenId != self.ArenaInfos[i].FubenId)
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

            switch (functionId)
            {
                case 1025:
                    battleInfos = self.BattleInfos;
                    break;
                case 1031:
                    battleInfos = self.ArenaInfos;
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
                    battleInfos = self.HappyInfos;
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
                    battleInfos = self.RunRaceInfos;
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
                    battleInfos = self.DemonInfos;
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

                C2M_TransferMap actor_Transfer = C2M_TransferMap.Create();
                actor_Transfer.SceneType = MapTypeEnum.MainCityScene;
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

        public static async ETTask InitYeWaiScene(this FubenCenterComponent self, List<int> sceneTypelist)
        {
            await self.Root().GetComponent<TimerComponent>().WaitAsync(RandomHelper.RandomNumber(0, 1000));

            List<SceneConfig> sceneConfigs = SceneConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < sceneConfigs.Count; i++)
            {
                if (!sceneTypelist.Contains(sceneConfigs[i].MapType))
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
                YeWaiRefreshComponent yeWaiRefreshComponen = fubnescene.AddComponent<YeWaiRefreshComponent>();
                yeWaiRefreshComponen.SceneId = sceneConfigs[i].Id;

                switch (sceneConfigs[i].MapType)
                {
                    case MapTypeEnum.MiJing:
                        fubnescene.AddComponent<MiJingDungeonComponent>();
                        break;
                    case MapTypeEnum.PetMatch:
                        
                        break;
                    default:
                        break;
                }
                
                FubenHelp.CreateMonsterList(fubnescene, sceneConfigs[i].CreateMonsterPosi);

                int openDay = ServerHelper.GetServeOpenDay(self.Zone());
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
            mapComponent.SetMapInfo((int)MapTypeEnum.Battle, sceneId, 0);
            mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(sceneId).MapID;
            //Game.Scene.GetComponent<RecastPathComponent>().Update(mapComponent.NavMeshId);
            fubnescene.AddComponent<YeWaiRefreshComponent>().SceneId = sceneId;
            FubenHelp.CreateNpc(fubnescene, sceneId);
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

            if (camp == 0)
            {
                return self.GenerateBattleInstanceId(unitid, sceneId);
            }

            return (camp, battleInfo);
        }

        public static async ETTask OnBattleOver(this FubenCenterComponent self)
        {
            self.BattleOpen = false;
            ServerLogHelper.LogDebug($"OnBattleOver : {self.Zone()}");
            //Console.WriteLine($"OnBattleOver : {self.DomainZone()}");
            ActorId robotSceneId = UnitCacheHelper.GetRobotServerId();

            G2Robot_MessageRequest G2Robot_MessageRequest = G2Robot_MessageRequest.Create();
            G2Robot_MessageRequest.Zone = self.Zone();
            G2Robot_MessageRequest.MessageType = NoticeType.BattleOver;
            self.Root().GetComponent<MessageSender>().Send(robotSceneId, G2Robot_MessageRequest);

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

        #region Union

        public static ActorId GetUnionFubenId(this FubenCenterComponent self, long unionid, long unitid)
        {
            //需要判读一下unitid 是否属于这个公会！
            if (self.UnionFubens.ContainsKey(unionid))
            {
                return self.UnionFubens[unionid];
            }

            int unionsceneid = 2000009;
            long fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
            Scene fubnescene = GateMapFactory.Create(self, unionid, fubenInstanceId, "Union" + unionid.ToString());

            MapComponent mapComponent = fubnescene.GetComponent<MapComponent>();
            mapComponent.SetMapInfo((int)MapTypeEnum.Union, unionsceneid, 0);
            mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(unionsceneid).MapID;
            //Game.Scene.GetComponent<RecastPathComponent>().Update(mapComponent.NavMeshId);
            fubnescene.AddComponent<UnionDungeonComponet>().GenerateUnionBoss();
            FubenHelp.CreateNpc(fubnescene, unionsceneid);
            TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();

            ActorId actorId_2 = new ActorId(self.Fiber().Process, self.Fiber().Id, fubenInstanceId);

            Log.Debug($"GetUnionFubenI: {fubnescene.GetActorId().ToString()}");
            Log.Debug($"GetUnionFuben2: {actorId_2.ToString()}");
            self.UnionFubens.Add(unionid, fubnescene.GetActorId());

            return fubnescene.GetActorId();
        }

        public static void OnUnionBoss(this FubenCenterComponent self)
        {
            foreach ((long unionid, ActorId actorId) in self.UnionFubens)
            {
                Scene scene = self.GetChild<Scene>(unionid);
                if (scene == null)
                {
                    Log.Debug($"{self.Zone()} {unionid} scene == null");
                    continue;
                }

                scene.GetComponent<UnionDungeonComponet>().GenerateUnionBoss();
            }
        }

        #endregion

        #region UnionRace
        public static void GenerateUnionRace(this FubenCenterComponent self)
        {
            if (self.UnionRaceScene != null)
            {
                self.UnionRaceScene.Dispose();
                self.UnionRaceScene = null;
            }

            long fubenid = IdGenerater.Instance.GenerateId();
            long fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();

            SceneConfig sceneConfigs = SceneConfigCategory.Instance.Get(2000008);
            Scene fubnescene = GateMapFactory.Create(self, fubenid, fubenInstanceId, "UnionRace" + sceneConfigs.Id.ToString());
            MapComponent mapComponent = fubnescene.GetComponent<MapComponent>();
            mapComponent.SetMapInfo(sceneConfigs.MapType, sceneConfigs.Id, 0);
            mapComponent.NavMeshId = sceneConfigs.MapID;
            //Game.Scene.GetComponent<RecastPathComponent>().Update(mapComponent.NavMeshId);
            fubnescene.AddComponent<YeWaiRefreshComponent>().SceneId = 2000008;
            fubnescene.AddComponent<UnionRaceDungeonComponent>();
            FubenHelp.CreateMonsterList(fubnescene, sceneConfigs.CreateMonsterPosi);
            TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
            self.UnionRaceScene = self.AddChild<BattleInfo>();
            self.UnionRaceScene.ActorId =  fubnescene.GetActorId();
            
            fubnescene.GetComponent<UnionRaceDungeonComponent>().OnUnionRaceBegin().Coroutine();
        }

        public static void OnJoinUnionRace(this FubenCenterComponent self, long unionid, long unitid)
        {
            Scene racescene = self.GetChild<Scene>(self.UnionRaceScene.FubenId);
            racescene.GetComponent<UnionRaceDungeonComponent>().OnJoinUnionRace(unionid, unitid);
        }

        public static  void OnUnionRaceBegin(this FubenCenterComponent self)
        {
            self.GenerateUnionRace();
        }

        public static void OnUnionRaceOver(this FubenCenterComponent self)
        {
            
        }

        #endregion
        
        #region JiaYuan
        public static void OnUnitLeave(this FubenCenterComponent self, Scene scene)
        {
            List<Unit> units = UnitHelper.GetUnitList(scene, UnitType.Player);
            if (units.Count > 0)
            {
                return;
            }

            ActorId fubeninstanceid  =default;
            long unitid = scene.GetComponent<JiaYuanDungeonComponent>().MasterId;
            self.JiaYuanFubens.TryGetValue(unitid, out fubeninstanceid);
            TransferHelper.NoticeFubenCenter(scene, 2).Coroutine();
            scene.Dispose();
            if (fubeninstanceid != default)
            {
                self.JiaYuanFubens.Remove(unitid);
            }
        }
        
        public static async ETTask<ActorId> GetJiaYuanFubenId(this FubenCenterComponent self, long masterid, long unitid)
        {
            using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.JiaYuan, masterid))
            {
                if (self.JiaYuanFubens.ContainsKey(masterid))
                {
                    return self.JiaYuanFubens[masterid];
                }

                int jiayuansceneid = 2000011;
                long fubenid = IdGenerater.Instance.GenerateId();
                long fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
                Scene fubnescene = GateMapFactory.Create(self, fubenid, fubenInstanceId, "JiaYuan" + masterid.ToString());
                fubnescene.AddComponent<JiaYuanDungeonComponent>().MasterId = masterid;
                MapComponent mapComponent = fubnescene.GetComponent<MapComponent>();
                mapComponent.SetMapInfo((int)MapTypeEnum.JiaYuan, jiayuansceneid, 0);
                mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(jiayuansceneid).MapID;
                JiaYuanDungeonComponent jiaYuanDungeonComponent = fubnescene.GetComponent<JiaYuanDungeonComponent>();
                await jiaYuanDungeonComponent.CreateJiaYuanUnit( masterid, unitid);
                FubenHelp.CreateNpc(fubnescene, jiayuansceneid);
                TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
                
                ActorId jiayuanActorid =  new ActorId(self.Fiber().Process, self.Fiber().Id, fubenInstanceId);
                self.JiaYuanFubens.Add(masterid, jiayuanActorid);
                return jiayuanActorid;
            }
        }
        
        #endregion
    }
}