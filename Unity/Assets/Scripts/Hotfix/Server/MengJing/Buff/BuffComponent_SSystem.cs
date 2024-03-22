namespace ET.Server
{
    [EntitySystemOf(typeof(BuffComponent_S))]
    [FriendOf(typeof(BuffComponent_S))]
    public static partial class BuffComponent_SSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.BuffComponent_S self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Server.BuffComponent_S self)
        {

        }

        public static int GetBuffSourceNumber(this ET.Server.BuffComponent_S self ,long unitid, int  buffid)
        {
            return 0;
        }

        public static void BuffRemoveByUnit(this ET.Server.BuffComponent_S self, long unitid, int  buffid)
        {
            
        }
    }
}

