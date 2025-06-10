using System;

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
            
            if ( self.Player == null || self.Player.IsDisposed )
             {
                 return;
             }
            
            // 发送断线消息
            root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(self.Player.Id, G2M_SessionDisconnect.Create());
            
            Console.WriteLine($"SessionPlayerComponent.Destroy:  {self.Player.Id}");
            
            PlayerSessionComponent playerSessionComponent = self.Player.GetComponent<PlayerSessionComponent>();
            // Session playerSession = playerSessionComponent ?.Session;
            // if ( playerSession == null)
            // {
            //     return;
            // }
            //
            // if (playerSession.InstanceId != self.GetParent<Session>().InstanceId)
            // {
            //     return;
            // }
            
            if (self.Player.GetComponent<PlayerOfflineOutTimeComponent>() == null)
            {
                self.Player.AddComponent<PlayerOfflineOutTimeComponent>();
            }
            
            //机器人直接下线
            // if (self.Player.Account.Contains("_"))
            // {
            //     self.Player.RemoveComponent<PlayerOfflineOutTimeComponent>();
            //     DisconnectHelper.KickPlayer(self.Player).Coroutine();
            // }
        }
        
        [EntitySystem]
        private static void Awake(this SessionPlayerComponent self)
        {

        }
    }
}