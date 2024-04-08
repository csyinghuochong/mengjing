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
        
        
    }

}