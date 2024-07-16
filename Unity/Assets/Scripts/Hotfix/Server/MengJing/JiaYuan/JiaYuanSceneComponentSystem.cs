using Unity.Mathematics;
using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof (JiaYuanSceneComponent))]
    [FriendOf(typeof (JiaYuanSceneComponent))]
    public static partial class JiaYuanSceneComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.JiaYuanSceneComponent self)
        {
            self.JiaYuanFubens.Clear();
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.JiaYuanSceneComponent self)
        {
        }

        public static void OnUnitLeave(this JiaYuanSceneComponent self, Scene scene)
        {
            List<Unit> units = UnitHelper.GetUnitList(scene, UnitType.Player);
            if (units.Count > 0)
            {
                return;
            }

            long unitid = scene.GetComponent<JiaYuanDungeonComponent>().MasterId;

            long fubeninstanceid = 0;
            self.JiaYuanFubens.TryGetValue(unitid, out fubeninstanceid);

            TransferHelper.NoticeFubenCenter(scene, 2).Coroutine();
            scene.Dispose();
            if (fubeninstanceid != 0)
            {
                self.JiaYuanFubens.Remove(unitid);
            }
        }

        public static async ETTask CreateJiaYuanUnit(this JiaYuanSceneComponent self, Scene fubnescene, long masterid, long unitid)
        {
            JiaYuanComponentS jiaYuanComponent = await UnitCacheHelper.GetComponentCache<JiaYuanComponentS>(fubnescene.Root(), masterid);
            if (jiaYuanComponent.JiaYuanPastureList_7.Count > 100
                || jiaYuanComponent.JianYuanPlantList_7.Count > 100
                || jiaYuanComponent.JiaYuanMonster_2.Count > 100)
            {
                Log.Error($"CreateJiaYuanUnit:  {masterid}");
                return;
            }

            for (int i = 0; i < jiaYuanComponent.JiaYuanPastureList_7.Count; i++)
            {
                UnitFactory.CreatePasture(fubnescene, jiaYuanComponent.JiaYuanPastureList_7[i], masterid);
            }

            for (int i = 0; i < jiaYuanComponent.JianYuanPlantList_7.Count; i++)
            {
                UnitFactory.CreatePlan(fubnescene, jiaYuanComponent.JianYuanPlantList_7[i], masterid);
            }

            long serverTime = TimeHelper.ServerNow();
            for (int i = 0; i < jiaYuanComponent.JiaYuanMonster_2.Count; i++)
            {
                JiaYuanMonster keyValuePair = jiaYuanComponent.JiaYuanMonster_2[i];
                float3 vector3 = new float3(keyValuePair.x, keyValuePair.y, keyValuePair.z);
                UnitFactory.CreateMonster(fubnescene, keyValuePair.ConfigId, vector3,
                    new CreateMonsterInfo()
                    {
                        Camp = CampEnum.CampMonster1, BornTime = serverTime - keyValuePair.BornTime, UnitId = keyValuePair.unitId
                    });
            }

            for (int i = 0; i < jiaYuanComponent.JiaYuanPetList_2.Count; i++)
            {
                UnitFactory.CreateJiaYuanPet(fubnescene, masterid, jiaYuanComponent.JiaYuanPetList_2[i]);
            }
            
            Log.Debug("1111111111111");
        }

        public static async ETTask<long> GetJiaYuanFubenId(this JiaYuanSceneComponent self, long masterid, long unitid)
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
                mapComponent.SetMapInfo((int)SceneTypeEnum.JiaYuan, jiayuansceneid, 0);
                mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(jiayuansceneid).MapID;
                await self.CreateJiaYuanUnit(fubnescene, masterid, unitid);
                FubenHelp.CreateNpc(fubnescene, jiayuansceneid);
                TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
                self.JiaYuanFubens.Add(masterid, fubenInstanceId);
                return fubenInstanceId;
            }
        }
    }
}