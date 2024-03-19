namespace ET.Server
{
    [EntitySystemOf(typeof(BuffComponentServer))]
    [FriendOf(typeof(BuffComponentServer))]
    public static partial class BuffComponentServerSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.BuffComponentServer self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Server.BuffComponentServer self)
        {

        }

        public static int GetBuffSourceNumber(this ET.Server.BuffComponentServer self ,long unitid, int  buffid)
        {
            return 0;
        }

        public static void BuffRemoveByUnit(this ET.Server.BuffComponentServer self, long unitid, int  buffid)
        {
            
        }
    }
}

