using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof (JiaYuanSceneComponent))]
    [FriendOf(typeof (JiaYuanSceneComponent))]
    public static partial class JiaYuanSceneComponentSystem
    {
        [EntitySystem]
        private static void Awake(this JiaYuanSceneComponent self)
        {

        }

        [EntitySystem]
        private static void Destroy(this JiaYuanSceneComponent self)
        {
        }
        
    }
}