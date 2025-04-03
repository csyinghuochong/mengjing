using System;
using System.Collections.Generic;


namespace ET.Server
{

    [EntitySystemOf(typeof(PetMatchDungeonComponent))]
    [FriendOf(typeof(PetMatchDungeonComponent))]
    public static partial class PetMatchDungeonComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.PetMatchDungeonComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Server.PetMatchDungeonComponent self)
        {

        }
    }
}
