using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{

    [FriendOf(typeof(SceneUnitManagerComponent))]
    [EntitySystemOf(typeof(SceneUnitManagerComponent))]
    public static partial class SceneUnitManagerComponentSystem
    {
        
        
        [EntitySystem]
        private static void Awake(this ET.Client.SceneUnitManagerComponent self)
        {

        }

        public static void Move(this SceneUnitManagerComponent self, Unit unit, ChangePosition args)
        {
            float3 oldPos = args.OldPos;
            int oldCellX = (int) (oldPos.x * 1000) / SceneAOIManagerComponent.CellSize;
            int oldCellY = (int) (oldPos.z * 1000) / SceneAOIManagerComponent.CellSize;
            int newCellX = (int) (unit.Position.x * 1000) / SceneAOIManagerComponent.CellSize;
            int newCellY = (int) (unit.Position.z * 1000) / SceneAOIManagerComponent.CellSize;
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

            self.Root().GetComponent<SceneAOIManagerComponent>().Move(aoiEntity, newCellX, newCellY  );
        }


        public static void InitMainHero(this ET.Client.SceneUnitManagerComponent self, float3 position, long unitid)
        {
            SceneUnit sceneUnit =  self.AddChildWithId<SceneUnit>(unitid, true);
            sceneUnit.Position = position;
            sceneUnit.AddComponent<SceneAOIEntity, int, float3>(4 * 1000, sceneUnit.Position).MainHero = true;
            self.MainSceneUnit = sceneUnit;
        }

        public static void BeginEnterScene(this ET.Client.SceneUnitManagerComponent self)
        {
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

        public static void InitMapObject(this ET.Client.SceneUnitManagerComponent self, byte[] bytes,  string scenename)
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
                mapObjectItem =  MapObjectItem.ToMapObjectItem(singleton.MapConfig);
                self.MapObjectConfigs.Add( scenename, mapObjectItem );
            }

            long unitid = 0;
            foreach (var mapconfig in mapObjectItem)
            {
                for (int i = 0; i < mapconfig.PositionList.Count; i++)
                {
                    float3 vector3 = mapconfig.PositionList[i];

                    unitid++;
                    SceneUnit sceneUnit =  self.AddChildWithId<SceneUnit>(unitid, true);
                    sceneUnit.InitSceneUnit(mapconfig.AssetPath, mapconfig.TagList[i],  mapconfig.LayerList[i], gameObjectpool);
                    sceneUnit.Position = vector3;
                    sceneUnit.Rotation = mapconfig.RotationList[i];
                    sceneUnit.Scale = mapconfig.ScaleList[i];
                    sceneUnit.AddComponent<SceneAOIEntity, int, float3>(1 * 1000, sceneUnit.Position).MainHero = false;;
                }
            }

            // float? min_x = null;
            // float? max_x = null;
            //
            // float? min_z = null;
            // float? max_z = null;
            //
            // foreach (var mapconfig in mapObjectItem)
            // {
            //     for (int i = 0; i < mapconfig.PositionList.Count; i++)
            //     {
            //         Vector3 vector3 = mapconfig.PositionList[i];
            //         
            //         if (vector3.x < min_x || !min_x.HasValue)
            //         {
            //             min_x = vector3.x;
            //         }
            //         if (vector3.z < min_z || !min_z.HasValue)
            //         {
            //             min_z = vector3.z;
            //         }
            //         
            //         if (vector3.x > max_x || !max_x.HasValue)
            //         {
            //             max_x = vector3.x;
            //         }
            //         if (vector3.z > max_z || !max_z.HasValue)
            //         {
            //             max_z = vector3.z;
            //         }
            //     }
            // }
            //
            // float distance_x = max_x.GetValueOrDefault() - min_x.GetValueOrDefault();
            // float distance_z = max_z.GetValueOrDefault() - min_z.GetValueOrDefault();
            // float distance_m = math.max( distance_x, distance_z );
            //
            // int distance_i = Mathf.CeilToInt(distance_m);  //89.24->90  -89.24->-89  向上取整
            // Debug.Log($"min_x:{min_x}   max_x:{max_x}   min_z:{min_z}   max_z:{max_z}   distance_m:{distance_m}  distance_i:{distance_i}");
            //
            // //左上角为起点， 划分distance_i * distance_i格子。。
            //
        }
    }
}