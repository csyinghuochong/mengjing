namespace ET.Client
{
    [EntitySystemOf(typeof(PlayerInfoComponent))]
    [FriendOf(typeof(PlayerInfoComponent))]
    public static partial class PlayerInfoComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.PlayerInfoComponent self)
        {

        }

        public static int GetNewServerId(this ET.Client.PlayerInfoComponent self, int serverid)
        {
            for (int  i = 0; i < self.AllServerList.Count; i++)
            {
                if (self.AllServerList[i].OldServerIds.Contains(serverid))
                {
                    return self.AllServerList[i].ServerId;
                }
            }

            return serverid;
        }
    }
}