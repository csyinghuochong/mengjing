using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{

    [EntitySystemOf(typeof(DragonDungeonComponent))]
    [FriendOf(typeof(DragonDungeonComponent))]
    public static partial class DragonDungeonComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.DragonDungeonComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Server.DragonDungeonComponent self)
        {

        }
        
        
    }

}