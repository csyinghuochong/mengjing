namespace ET.Client
{
    [EntitySystemOf(typeof (FriendComponent))]
    [FriendOf(typeof (FriendComponent))]
    public static partial class FriendComponentSystem
    {
        [EntitySystem]
        private static void Awake(this FriendComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this FriendComponent self)
        {
        }

        public static void OnFriendDelelte(this FriendComponent self, long friendId)
        {
            for (int i = self.FriendList.Count - 1; i >= 0; i--)
            {
                if (self.FriendList[i].UserId == friendId)
                {
                    self.FriendList.RemoveAt(i);
                }
            }
        }
    }
}