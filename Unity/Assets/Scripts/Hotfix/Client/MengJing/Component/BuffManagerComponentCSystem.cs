namespace ET.Client
{

    [EntitySystemOf(typeof(BuffManagerComponentC))]
    [FriendOf(typeof(BuffManagerComponentC))]
    public static partial class BuffManagerComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.BuffManagerComponentC self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Client.BuffManagerComponentC self)
        {

        }

        public static void InitBuff(this ET.Client.BuffManagerComponentC self)
        {
            
        }
    }

}