using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ET.Client
{

    [FriendOf(typeof(MapObjectManagerComponent))]
    [EntitySystemOf(typeof(MapObjectManagerComponent))]
    public static partial class MapObjectManagerComponentSystem
    {
        
        
        [EntitySystem]
        private static void Awake(this ET.Client.MapObjectManagerComponent self)
        {

        }

        public static void OnMainHeroMove(this ET.Client.MapObjectManagerComponent self, float3 mainPosition)
        {
            
        }

        public static void InitMapObject(this ET.Client.MapObjectManagerComponent self, byte[] bytes,  string scenename)
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

            foreach (var objecttrans in self.MapObjectTransList)
            {
                GameObjectTransInfo transInfo = objecttrans.Value;
                transInfo.Dispose();
            }
            self.MapObjectTransList.Clear();

            float? min_x = null;
            float? max_x = null;
            
            float? min_z = null;
            float? max_z = null;
            
            foreach (var mapconfig in mapObjectItem)
            {
                for (int i = 0; i < mapconfig.PositionList.Count; i++)
                {
                    Vector3 vector3 = mapconfig.PositionList[i];
                    
                    if (vector3.x < min_x || !min_x.HasValue)
                    {
                        min_x = vector3.x;
                    }
                    if (vector3.z < min_z || !min_z.HasValue)
                    {
                        min_z = vector3.z;
                    }
                    
                    if (vector3.x > max_x || !max_x.HasValue)
                    {
                        max_x = vector3.x;
                    }
                    if (vector3.z > max_z || !max_z.HasValue)
                    {
                        max_z = vector3.z;
                    }
                }
            }
            
            Debug.Log($"min_x:{min_x}   max_x:{max_x}   min_z:{min_z}   max_z:{max_z}");
        }

    }
}