using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof (BagComponentServer))]
    [FriendOf(typeof (BagComponentServer))]
    public static partial class BagComponentServerSystem
    {
        [EntitySystem]
        private static void Awake(this BagComponentServer self)
        {
        }

        [EntitySystem]
        private static void Destroy(this BagComponentServer self)
        {
        }
    }
}