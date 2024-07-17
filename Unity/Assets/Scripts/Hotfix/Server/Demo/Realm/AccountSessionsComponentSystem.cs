namespace ET.Server
{
    [EntitySystemOf(typeof(AccountSessionsComponent))]
    [FriendOfAttribute(typeof(AccountSessionsComponent))]
    public static partial class AccountSessionsComponentSystem
    {
        [EntitySystem]
        private static void Awake(this AccountSessionsComponent self)
        {

        }

        [EntitySystem]
        private static void Destroy(this AccountSessionsComponent self)
        {
            self.AccountSessionDictionary.Clear();
        }
        
        
        public static Session Get(this AccountSessionsComponent self, string accountName)
        {
            if (!self.AccountSessionDictionary.TryGetValue(accountName,out EntityRef<Session> session))
            {
                return null;
            }

            return session;
        }

        public static void Add(this AccountSessionsComponent self, string accountName, EntityRef<Session> session)
        {
            
            if (self.AccountSessionDictionary.ContainsKey(accountName))
            {
                self.AccountSessionDictionary[accountName] = session;
                return;
            }
            self.AccountSessionDictionary.Add(accountName,session);
        }


        public static void Remove(this AccountSessionsComponent self, string accountName)
        {
            if (self.AccountSessionDictionary.ContainsKey(accountName))
            {
                self.AccountSessionDictionary.Remove(accountName);
            }
        }
    }
}