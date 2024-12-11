using System;
using System.Collections.Generic;
using System.Text;
using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{

    [FriendOf(typeof(SceneUnitManagerComponent))]
    [EntitySystemOf(typeof(SceneUnitManagerComponent))]
    public static partial class SceneUnitManagerComponentSystem
    {

        [Invoke(TimerInvokeType.ResourcesLoaderTimer)]
        public class ResourcesLoaderTimer : ATimer<SceneUnitManagerComponent>
        {
            protected override void Run(SceneUnitManagerComponent self)
            {
                try
                {
                    self.CheckUnUseAssets();
                }
                catch (Exception e)
                {
                    using (zstring.Block())
                    {
                        Log.Error(zstring.Format("move timer error: {0}\n{1}", self.Id, e.ToString()));
                    }
                }
            }
        }

        [EntitySystem]
        private static void Awake(this ET.Client.SceneUnitManagerComponent self)
        {

        }

        [EntitySystem]
        private static void Destroy(this ET.Client.SceneUnitManagerComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }
        
        public static void CheckUnUseAssets(this SceneUnitManagerComponent self)
        {
            //if (GameObjectPoolHelper.GetAssetNumber() >= 50)
            {
                //导致卡顿不能用、、
                //Resources.UnloadUnusedAssets();
                //GC.Collect();
                
                self.GetGameMemory();
            }
        }

        public static void GetGameMemory(this SceneUnitManagerComponent self)
        {
            long monouse        = UnityEngine.Profiling.Profiler.GetMonoUsedSizeLong() ;               //使用的
            long totalallocated = UnityEngine.Profiling.Profiler.GetTotalAllocatedMemoryLong();         //unity分配的
            long totalreserved = UnityEngine.Profiling.Profiler.GetTotalReservedMemoryLong();           //总内存
            long unusedreserved = UnityEngine.Profiling.Profiler.GetTotalUnusedReservedMemoryLong();    //未使用的内存

            StringBuilder stringBuilder =  new StringBuilder();
            stringBuilder.Clear();
            stringBuilder.Append($"内存占用: 当前使用:{monouse/1024/1024}MB Unity分配:{totalallocated / 1024 / 1024}MB 总内存:{totalreserved / 1024 / 1024}MB 空闲内存:{unusedreserved / 1024 / 1024}MB");
            stringBuilder.AppendLine();

            stringBuilder.Append("EventSystem:");
            stringBuilder.AppendLine();
            stringBuilder.Append(EventSystem.Instance.ToString());
            stringBuilder.Append("ObjectPool:");
            stringBuilder.AppendLine();
            stringBuilder.Append(ObjectPool.Instance.ToString());
            stringBuilder.Append("MonoPool:");
            stringBuilder.AppendLine();
            stringBuilder.Append("GameObjectPool:");
            stringBuilder.AppendLine();
            
            Debug.Log($"GameMemory..GetGameMemory:  {stringBuilder.ToString()}");
        }

        public static void Move(this SceneUnitManagerComponent self, Unit unit, ChangePosition args)
        {
            if (!SettingData.UseSceneAOI)
            {
                return;
            }

            
            float3 oldPos = args.OldPos;
            int oldCellX = (int)(oldPos.x * 1000) / SceneAOIManagerComponent.CellSize;
            int oldCellY = (int)(oldPos.z * 1000) / SceneAOIManagerComponent.CellSize;
            int newCellX = (int)(unit.Position.x * 1000) / SceneAOIManagerComponent.CellSize;
            int newCellY = (int)(unit.Position.z * 1000) / SceneAOIManagerComponent.CellSize;
            if (oldCellX == newCellX && oldCellY == newCellY)
            {
                return;
            }

            if (self.MainSceneUnit == null)
            {
                return;
            }

            SceneAOIEntity aoiEntity = self.MainSceneUnit.GetComponent<SceneAOIEntity>();
            if (aoiEntity == null)
            {
                return;
            }

            self.Root().GetComponent<SceneAOIManagerComponent>().Move(aoiEntity, newCellX, newCellY);
        }

        public static void InitMainHero(this ET.Client.SceneUnitManagerComponent self, float3 position, long unitid)
        {
            if (!SettingData.UseSceneAOI)
            {
                return;
            }

            SceneUnit sceneUnit = self.AddChildWithId<SceneUnit>(unitid, true);
            sceneUnit.Position = position;
            sceneUnit.AddComponent<SceneAOIEntity, int, float3>(10 * 1000, sceneUnit.Position).MainHero = true;
            self.MainSceneUnit = sceneUnit;

            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(TimeHelper.Minute, TimerInvokeType.ResourcesLoaderTimer, self);
        }

        public static void BeginEnterScene(this ET.Client.SceneUnitManagerComponent self)
        {
            if (!SettingData.UseSceneAOI)
            {
                return;
            }

            //清除scneunit。。
            List<long> removeids = new List<long>();
            foreach ((long key, Entity value) in self.Children)
            {
                removeids.Add(key);
            }
            foreach (long id in removeids)
            {
                self.RemoveChild(id);
            }

            self.MainSceneUnit?.Dispose();
            self.MainSceneUnit = null;
        }

        public static void InitMapObject(this ET.Client.SceneUnitManagerComponent self, byte[] bytes, string scenename)
        {
            //动态生成场景
            if (bytes == null)
            {
                return;
            }

            if (GameObject.Find("AdditiveHide") == null)
            {
                Log.Error("该场景没有AdditiveHide节点！！");
                return;
            }

            GameObject gameObjectpool = GameObject.Find("AdditiveHide/pool"); // 获取当前GameObject的Transform
            if (gameObjectpool != null)
            {
                Log.Error("该场景没有没有清空pool！！");
                return;
            }

            gameObjectpool = new GameObject("pool");
            gameObjectpool.transform.SetParent(GameObject.Find("AdditiveHide").transform);
            gameObjectpool.transform.SetAsFirstSibling();
            gameObjectpool.transform.localScale = Vector3.one;
            gameObjectpool.transform.localPosition = Vector3.zero;

            object category = MongoHelper.Deserialize(typeof(MapObjectConfig), bytes, 0, bytes.Length);
            MapObjectConfig singleton = category as MapObjectConfig;

            List<MapObjectItem> mapObjectItem = null;
            self.MapObjectConfigs.TryGetValue(scenename, out mapObjectItem);
            if (mapObjectItem == null)
            {
                mapObjectItem = MapObjectItem.ToMapObjectItem(singleton.MapConfig);
                self.MapObjectConfigs.Add(scenename, mapObjectItem);
            }

            long unitid = 0;
            foreach (var mapconfig in mapObjectItem)
            {
                GameObject gamenode = new GameObject(mapconfig.AssetPath);
                gamenode.transform.SetParent(gameObjectpool.transform); ;
                gamenode.transform.localScale = Vector3.one;
                gamenode.transform.localPosition = Vector3.zero;

                for (int i = 0; i < mapconfig.PositionList.Count; i++)
                {
                    unitid++;
                    float3 vector3 = mapconfig.PositionList[i];
                    if (mapconfig.AssetPath.Equals("Fence_5"))
                    {
                        Log.Debug($"Fence_5:  {vector3}");
                    }

                    SceneUnit sceneUnit = self.AddChildWithId<SceneUnit>(unitid, true);
                    sceneUnit.InitSceneUnit(mapconfig.AssetPath, mapconfig.TagList[i], mapconfig.LayerList[i], gameObjectpool);
                    sceneUnit.Position = vector3;
                    sceneUnit.Rotation = mapconfig.RotationList[i];
                    sceneUnit.Scale = mapconfig.ScaleList[i];
                    sceneUnit.AddComponent<SceneAOIEntity, int, float3>(1 * 1000, sceneUnit.Position).MainHero = false; ;
                }
            }

        }
        
    }
}