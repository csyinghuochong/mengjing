using System.Collections.Generic;

namespace ET.Server 
{

    [FriendOf(typeof(AccountSessionsComponent))]
    [EntitySystemOf(typeof(AccountSessionsComponent))]
    public static partial class AccountSessionsComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.AccountSessionsComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Server.AccountSessionsComponent self)
        {
            self.AccountSessionsDictionary.Clear();
        }

        public static long Get(this AccountSessionsComponent self, long accountId)
        {
            if (!self.AccountSessionsDictionary.TryGetValue(accountId, out long instanceId))
            {
                return 0;
            }
            return instanceId;
        }

        // <summary>
        /// AccountCheckOutTimeComponent 十分钟后
        /// DisconnectHelper.KickPlayer
        /// G2A_ExitGame
        /// </summary>
        /// <param name="self"></param>
        /// <param name="accountId"></param>
        public static void Remove(this AccountSessionsComponent self, long accountId)
        {
            if (self.AccountSessionsDictionary.ContainsKey(accountId))
            {
                self.AccountSessionsDictionary.Remove(accountId);
            }
        }

        public static Dictionary<long, long> GetAll(this AccountSessionsComponent self)
        {
            return self.AccountSessionsDictionary;
        }

        public static void Add(this AccountSessionsComponent self, long accountId, long instanceId)
        {
            if (self.AccountSessionsDictionary.ContainsKey(accountId))
            {
                self.AccountSessionsDictionary[accountId] = instanceId;
                return;
            }
            self.AccountSessionsDictionary.Add(accountId, instanceId);
        }
    }

}