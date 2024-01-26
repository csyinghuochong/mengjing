using System.Collections.Generic;

namespace ET.Server
{

    [EntitySystemOf(typeof(BagComponentServer))]
    [FriendOf(typeof(BagComponentServer))]
    public static partial class BagComponentServerSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.BagComponentServer self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Server.BagComponentServer self)
        {

        }

    }
}