namespace ET.Server
{
    [EntitySystemOf(typeof(SessionPlayerComponent))]
    public static partial class SessionPlayerComponentSystem
    {
        [EntitySystem]
        private static void Destroy(this SessionPlayerComponent self)
        {
            Scene root = self.Root();
            if (root.IsDisposed)
            {
                return;
            }
            // 发送断线消息
            //root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(self.Player.Id, G2M_SessionDisconnect.Create());

            if ( self.Player == null || self.Player.IsDisposed )
            {
                return;
            }

            Session playerSession = self.Player.GetComponent<PlayerSessionComponent>()?.Session;
            if ( playerSession == null)
            {
                return;
            }
            
            if (playerSession.InstanceId != self.GetParent<Session>().InstanceId)
            {
                return;
            }

            if (self.Player.GetComponent<PlayerOfflineOutTimeComponent>() == null)
            {
                self.Player.AddComponent<PlayerOfflineOutTimeComponent>();
            }
        }
        
        [EntitySystem]
        private static void Awake(this SessionPlayerComponent self)
        {

        }
    }
}