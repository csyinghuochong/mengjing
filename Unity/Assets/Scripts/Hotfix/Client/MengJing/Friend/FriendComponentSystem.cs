namespace ET.Client
{

    [EntitySystemOf(typeof(FriendComponent))]
    [FriendOf(typeof(FriendComponent))]
    public static partial class FriendComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.FriendComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Client.FriendComponent self)
        {

        }
    }
}