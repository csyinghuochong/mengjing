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

    }
}