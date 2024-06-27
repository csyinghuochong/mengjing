namespace ET.Server
{

    [FriendOf(typeof(AccountCheckOutTimeComponent))]
    [EntitySystemOf(typeof(AccountCheckOutTimeComponent))]
    public static partial class AccountCheckOutTimeComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.AccountCheckOutTimeComponent self, long args2)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Server.AccountCheckOutTimeComponent self)
        {

        }

        private  static async ETTask CloseSession(Session session)
        {
            await session.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            session.Dispose();
        }

        public static void DeleteSession(this AccountCheckOutTimeComponent self)
        {
            Session session = self.GetParent<Session>();

            long sessionInstanceId = session.Root().GetComponent<AccountSessionsComponent>().Get(self.AccountId);
            Log.Debug($"DeleteSession: {sessionInstanceId} {session.InstanceId}");
            if (session.InstanceId == sessionInstanceId)
            {
                session.Root().GetComponent<AccountSessionsComponent>().Remove(self.AccountId);
            }
            session?.Send(new A2C_Disconnect() { Error = ErrorCode.ERR_LoginTimeOut });
            CloseSession(session).Coroutine();
        }
    }

}