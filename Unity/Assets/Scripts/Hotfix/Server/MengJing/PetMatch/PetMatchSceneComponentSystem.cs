using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;

namespace ET.Server
{

    [EntitySystemOf(typeof(PetMatchSceneComponent))]
    [FriendOf(typeof(PetMatchSceneComponent))]
    public static partial class PetMatchSceneComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.PetMatchSceneComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Server.PetMatchSceneComponent self)
        {

        }
        
        
    }
}