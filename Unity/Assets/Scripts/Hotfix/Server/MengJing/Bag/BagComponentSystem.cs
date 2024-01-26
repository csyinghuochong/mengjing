using System.Collections.Generic;

namespace ET.Server
{

    [EntitySystemOf(typeof(BagComponent))]
    [FriendOf(typeof(BagComponent))]
    public static partial class BagComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.BagComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Server.BagComponent self)
        {

        }

    }
}