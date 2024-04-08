namespace ET.Server
{
    [EntitySystemOf(typeof(BuffManagerComponentS))]
    [FriendOf(typeof(BuffManagerComponentS))]
    public static partial class BuffManagerComponentSSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.BuffManagerComponentS self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Server.BuffManagerComponentS self)
        {

        }

        public static int GetBuffSourceNumber(this ET.Server.BuffManagerComponentS self ,long unitid, int  buffid)
        {
            return 0;
        }

        public static void BuffRemoveByUnit(this ET.Server.BuffManagerComponentS self, long unitid, int  buffid)
        {
            
        }

        public static void BuffFactory(this BuffManagerComponentS self, BuffData buffData, Unit from, SkillS skillHandler, bool notice = true)
        {
            
        }
    }
}

