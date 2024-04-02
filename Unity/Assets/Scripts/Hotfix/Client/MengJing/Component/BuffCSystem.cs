namespace ET.Client
{


    [EntitySystemOf(typeof(BuffC))]
    [FriendOf(typeof(BuffC))]
    public static partial class BuffCSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.BuffC self)
        {

        }
    }

}