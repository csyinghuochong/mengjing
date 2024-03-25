namespace ET.Server
{
    [EntitySystemOf(typeof(BuffComponentS))]
    [FriendOf(typeof(BuffComponentS))]
    public static partial class BuffComponent_SSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.BuffComponentS self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Server.BuffComponentS self)
        {

        }

        public static int GetBuffSourceNumber(this ET.Server.BuffComponentS self ,long unitid, int  buffid)
        {
            return 0;
        }

        public static void BuffRemoveByUnit(this ET.Server.BuffComponentS self, long unitid, int  buffid)
        {
            
        }
    }
}

