using System;
using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof (HappySceneComponent))]
    [FriendOf(typeof (HappySceneComponent))]
    public static partial class HappySceneComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.HappySceneComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.HappySceneComponent self)
        {
        }

        public static long GetFubenInstanceId(this HappySceneComponent self, long unitId)
        {
            if (!self.HappyOpen)
            {
                return 0;
            }

            foreach ((long id, List<long> players) in self.FubenPlayers)
            {
                Scene scene = self.GetChild<Scene>(id);
                if (scene == null)
                {
                    Log.Error("scene == null");
                    continue;
                }

                if (players.Contains(unitId))
                {
                    return scene.InstanceId;
                }

                if (players.Count < 20)
                {
                    players.Add(unitId);
                    return scene.InstanceId;
                }
            }

            int sceneId = BattleHelper.GetSceneIdByType(SceneTypeEnum.Happy);

            long fubenid = IdGenerater.Instance.GenerateId();
            long fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
            Scene fubnescene = GateMapFactory.Create(self, fubenid, fubenInstanceId,  "Happy" + fubenid.ToString());
            TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
            fubnescene.AddComponent<HappyDungeonComponent>().OnHappyBegin();
            MapComponent mapComponent = fubnescene.GetComponent<MapComponent>();
            mapComponent.SetMapInfo((int)SceneTypeEnum.Happy, sceneId, 0);
            mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(sceneId).MapID;
            //Game.Scene.GetComponent<RecastPathComponent>().Update(mapComponent.NavMeshId);
            FubenHelp.CreateNpc(fubnescene, sceneId);
            self.FubenPlayers.Add(fubenid, new List<long>() { unitId });
            return fubenInstanceId;
        }

        public static void OnHappyBegin(this HappySceneComponent self)
        {
            Log.Warning($"OnHappyBegin :{self.Zone()}");
            self.HappyOpen = true;
            self.FubenPlayers.Clear();
        }

        public static void OnHappyOver(this HappySceneComponent self)
        {
            Log.Warning($"OnHappyOver11:{self.Zone()}");
            self.HappyOpen = false;
            foreach ((long id, List<long> plays) in self.FubenPlayers)
            {
                Scene scene = self.GetChild<Scene>(id);
                if (scene == null)
                {
                    Log.Error("scene == null");
                    continue;
                }

                scene.GetComponent<HappyDungeonComponent>().OnHappyOver().Coroutine();
            }

            self.FubenPlayers.Clear();
        }
    }
}