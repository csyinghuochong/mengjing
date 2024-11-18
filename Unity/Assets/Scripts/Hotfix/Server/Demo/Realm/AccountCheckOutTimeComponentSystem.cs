namespace ET.Server
{
    [Invoke(TimerInvokeType.AccountSessionCheckOutTime)]
    public class  AccountSessionCheckOutTimer : ATimer<AccountCheckOutTimeComponent>
    {
        protected override void Run(AccountCheckOutTimeComponent t)
        {
            t?.DeleteSession();
        }
    }
    
    
    [EntitySystemOf(typeof(AccountCheckOutTimeComponent))]
    [FriendOfAttribute(typeof(AccountCheckOutTimeComponent))]
    public static partial class AccountCheckOutTimeComponentSystem
    {
        [EntitySystem]
        private static void Awake(this AccountCheckOutTimeComponent self, string account)
        {
            self.Account = account;
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.Timer = self.Root().GetComponent<TimerComponent>()
                    .NewOnceTimer(TimeInfo.Instance.ServerNow() + 600000, TimerInvokeType.AccountSessionCheckOutTime, self);

        }
        [EntitySystem]
        private static void Destroy(this AccountCheckOutTimeComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }


        public static void DeleteSession(this AccountCheckOutTimeComponent self)
        {
            Session session = self.GetParent<Session>();

            Session originSession = session.Root().GetComponent<AccountSessionsComponent>().Get(self.Account);
            if (originSession != null && session.InstanceId == originSession.InstanceId)
            {
                session.Root().GetComponent<AccountSessionsComponent>().Remove(self.Account);
            }

            A2C_Disconnect a2CDisconnect = A2C_Disconnect.Create();
            a2CDisconnect.Error = ErrorCode.ERR_SessionDisconnect;
            session?.Send(a2CDisconnect);
            session?.Disconnect().Coroutine();
        }
    }
}