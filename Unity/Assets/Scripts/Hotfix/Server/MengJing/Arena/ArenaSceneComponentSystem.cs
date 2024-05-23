using System;

namespace ET.Server
{
    [EntitySystemOf(typeof (ArenaSceneComponent))]
    [FriendOf(typeof (ArenaSceneComponent))]
    public static partial class ArenaSceneComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.ArenaSceneComponent self)
        {
            self.CheckTimer();
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.ArenaSceneComponent self)
        {
        }

        public static void OnZeroClockUpdate(this ArenaSceneComponent self)
        {
            LogHelper.LogWarning("Arena:  OnZeroClockUpdate", true);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer); 
            self.AreneSceneStatu = 0;
            self.BeginTimer();
        }

        public static void CheckTimer(this ArenaSceneComponent self)
        {
            DateTime dateTime = TimeHelper.DateTimeNow();
            int curTime = (dateTime.Hour * 60 + dateTime.Minute) * 60 + dateTime.Second;
            FuntionConfig funtionConfig = FuntionConfigCategory.Instance.Get(1031);
            string[] openTimes = funtionConfig.OpenTime.Split('@');
            int openTime = (int.Parse(openTimes[0].Split(';')[0]) * 60 + int.Parse(openTimes[0].Split(';')[1])) * 60;
            int closeTime = (int.Parse(openTimes[1].Split(';')[0]) * 60 + int.Parse(openTimes[1].Split(';')[1])) * 60;
            int overTime = (int.Parse(openTimes[2].Split(';')[0]) * 60 + int.Parse(openTimes[2].Split(';')[1])) * 60;
            if (curTime < openTime)
            {
                self.AreneSceneStatu = 0;
            }
            else if (curTime < closeTime)
            {
                self.AreneSceneStatu = 1;
                self.CanEnter = true;
            }
            else if (curTime < overTime)
            {
                self.AreneSceneStatu = 2;
                self.CanEnter = false;
            }
            else
            {
                return;
            }

            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.BeginTimer();
        }

        public static void BeginTimer(this ArenaSceneComponent self)
        {
            DateTime dateTime = TimeHelper.DateTimeNow();
            int curTime = (dateTime.Hour * 60 + dateTime.Minute) * 60 + dateTime.Second;
            FuntionConfig funtionConfig = FuntionConfigCategory.Instance.Get(1031);
            string[] openTimes = funtionConfig.OpenTime.Split('@');
            int openTime = (int.Parse(openTimes[0].Split(';')[0]) * 60 + int.Parse(openTimes[0].Split(';')[1])) * 60;
            int closeTime = (int.Parse(openTimes[1].Split(';')[0]) * 60 + int.Parse(openTimes[1].Split(';')[1])) * 60;
            int overTime = (int.Parse(openTimes[2].Split(';')[0]) * 60 + int.Parse(openTimes[2].Split(';')[1])) * 60;

            if (curTime < openTime && self.AreneSceneStatu == 0)
            {
                self.AreneSceneStatu = 1;
                self.Timer = self.Root().GetComponent<TimerComponent>().NewOnceTimer(TimeHelper.ServerNow() + TimeHelper.Second * (openTime - curTime),
                    TimerInvokeType.ArenaSceneTimer, self);
                return;
            }

            if (curTime < closeTime && self.AreneSceneStatu == 1)
            {
                self.AreneSceneStatu = 2;
                self.Timer = self.Root().GetComponent<TimerComponent>().NewOnceTimer(TimeHelper.ServerNow() + TimeHelper.Second * (closeTime - curTime + 20),
                    TimerInvokeType.ArenaSceneTimer, self);
                return;
            }

            if (curTime < overTime && self.AreneSceneStatu == 2)
            {
                self.AreneSceneStatu = 3;
                self.Timer = self.Root().GetComponent<TimerComponent>().NewOnceTimer(TimeHelper.ServerNow() + TimeHelper.Second * (overTime - curTime),
                    TimerInvokeType.ArenaSceneTimer, self);
            }
        }

        public static void OnArenaOpen(this ArenaSceneComponent self)
        {
            self.CanEnter = true;
            if (ServerHelper.GetOpenServerDay(false, self.Zone()) > 0)
            {
                LogHelper.LogWarning($"OnArenaOpen：{self.Zone()}", true);
            }

            foreach (var item in self.Children)
            {
                Scene scene = item.Value as Scene;
                scene.GetComponent<ArenaDungeonComponent>().OnArenaOpen();
            }
        }

        public static void OnCheck(this ArenaSceneComponent self)
        {
            if (self.AreneSceneStatu == 1)
            {
                self.OnArenaOpen();
            }

            if (self.AreneSceneStatu == 2)
            {
                self.OnArenaClose();
            }

            if (self.AreneSceneStatu == 3)
            {
                self.OnArenaOver().Coroutine();
            }

            self.BeginTimer();
        }

        public static void OnArenaClose(this ArenaSceneComponent self)
        {
            LogHelper.LogWarning($"OnArenaClose： {self.Zone()}", true);
            self.CanEnter = false;
            foreach (var item in self.Children)
            {
                Scene scene = item.Value as Scene;
                scene.GetComponent<ArenaDungeonComponent>().OnArenaClose();
            }
        }

        public static async ETTask OnArenaOver(this ArenaSceneComponent self)
        {
            LogHelper.LogWarning($"OnArenaOver：{self.Zone()}", true);
            foreach (var item in self.Children)
            {
                Scene scene = item.Value as Scene;
                await scene.GetComponent<ArenaDungeonComponent>().OnArenaOver();
                await self.Root().GetComponent<TimerComponent>().WaitAsync(60000);
                TransferHelper.NoticeFubenCenter(scene, 2).Coroutine();
                scene.Dispose();
            }
        }

        public static long GetArenaInstanceId(this ArenaSceneComponent self, long unitId, int sceneId)
        {
            if (!self.CanEnter)
            {
                return 0;
            }

            ArenaInfo battleInfo = null;
            foreach (var item in self.Children)
            {
                Scene scene = item.Value as Scene;
                battleInfo = scene.GetComponent<ArenaInfo>();
                if (battleInfo.SceneId != sceneId)
                {
                    continue;
                }

                if (battleInfo.PlayerList.ContainsKey(unitId))
                {
                    return battleInfo.FubenInstanceId;
                }

                if (battleInfo.PlayerList.Count < ComHelp.GetPlayerLimit(sceneId))
                {
                    battleInfo.PlayerList.Add(unitId, new ArenaPlayerStatu() { UnitId = unitId });
                    return battleInfo.FubenInstanceId;
                }
            }

            //动态创建副本
            long fubenid = IdGenerater.Instance.GenerateId();
            long fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
            Scene fubnescene = GateMapFactory.Create(self, fubenid, fubenInstanceId, "Battle" + fubenid.ToString());
            fubnescene.AddComponent<ArenaDungeonComponent>();
            TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
            MapComponent mapComponent = fubnescene.GetComponent<MapComponent>();
            mapComponent.SetMapInfo((int)SceneTypeEnum.Arena, sceneId, 0);
            mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(sceneId).MapID;
            //Game.Scene.GetComponent<RecastPathComponent>().Update(mapComponent.NavMeshId);
            fubnescene.AddComponent<YeWaiRefreshComponent>().SceneId = sceneId;
            FubenHelp.CreateMonsterList(fubnescene, SceneConfigCategory.Instance.Get(sceneId).CreateMonster);
            FubenHelp.CreateMonsterList(fubnescene, SceneConfigCategory.Instance.Get(sceneId).CreateMonsterPosi);
            battleInfo = fubnescene.AddComponent<ArenaInfo>();
            battleInfo.FubenId = fubenid;
            battleInfo.PlayerList.Add(unitId, new ArenaPlayerStatu() { UnitId = unitId });
            battleInfo.FubenInstanceId = fubenInstanceId;
            battleInfo.SceneId = sceneId;
            return battleInfo.FubenInstanceId;
        }
    }
}