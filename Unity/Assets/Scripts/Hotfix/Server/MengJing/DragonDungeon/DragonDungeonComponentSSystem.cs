using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{

    [EntitySystemOf(typeof(DragonDungeonComponentS))]
    [FriendOf(typeof(DragonDungeonComponentS))]
    public static partial class DragonDungeonComponentSSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.DragonDungeonComponentS self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Server.DragonDungeonComponentS self)
        {

        }
        
        
    }

}