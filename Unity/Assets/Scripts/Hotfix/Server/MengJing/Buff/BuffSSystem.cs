namespace ET.Server
{


    [EntitySystemOf(typeof(BuffS))]
    [FriendOf(typeof(BuffS))]
    public static partial class BuffSSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.BuffS self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Server.BuffS self)
        {

        }

        public static void OnFinished(this ET.Server.BuffS self)
        {
            BuffHandlerS aaiHandler = BuffDispatcherComponentS.Instance.Get(self.mBuffConfig.BuffScript);
            aaiHandler.OnFinished();
        }
        
        public static void OnInit(this ET.Server.BuffS self, Unit from , Unit to, SkillS skillS)
        {
            BuffHandlerS aaiHandler = BuffDispatcherComponentS.Instance.Get(self.mBuffConfig.BuffScript);
            aaiHandler.OnInit(self.BuffData, from, to, skillS);
        }

        public static void OnUpdate(this ET.Server.BuffS self)
        {
            BuffHandlerS aaiHandler = BuffDispatcherComponentS.Instance.Get(self.mBuffConfig.BuffScript);
            aaiHandler.OnUpdate();
        }
    }

}