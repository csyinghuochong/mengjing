using System;

namespace ET.Server
{
    
    [Invoke(TimerInvokeType.PlayerOfflineOutTime)]
    public class PlayerOfflineOutTime: ATimer<PlayerOfflineOutTimeComponent>
    {
        protected override void Run(PlayerOfflineOutTimeComponent t)
        {
            Console.WriteLine($"PlayerOfflineOutTime:  {t.Id}");
            t?.KickPlayer();
        }
    }
    
    
    [EntitySystemOf(typeof(PlayerOfflineOutTimeComponent))]
    [FriendOfAttribute(typeof(PlayerOfflineOutTimeComponent))]
    public static partial class PlayerOfflineOutTimeComponentSystem
    {
        [EntitySystem]
        private static void Awake(this PlayerOfflineOutTimeComponent self)
        {
            self.Timer = self.Root().GetComponent<TimerComponent>().NewOnceTimer(TimeInfo.Instance.ServerNow() +  
                MessageLocationSenderOneType.TIMEOUT_TIME * 5, TimerInvokeType.PlayerOfflineOutTime, self);
        }
        
        [EntitySystem]
        private static void Destroy(this PlayerOfflineOutTimeComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }
        
        public static void KickPlayer(this PlayerOfflineOutTimeComponent self)
        {
            DisconnectHelper.KickPlayer(self.GetParent<Player>()).Coroutine();
        }
    }
}