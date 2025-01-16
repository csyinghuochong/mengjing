using System;

namespace ET.Client
{
    [EntitySystemOf(typeof(RealmPingComponent))]
    public static partial class RealmPingComponentSystem
    {
        [EntitySystem]
        private static void Awake(this RealmPingComponent self)
        {
            self.PingAsync().Coroutine();
        }
        
        [EntitySystem]
        private static void Destroy(this RealmPingComponent self)
        {
            self.Ping = default;
        }
        
        private static async ETTask PingAsync(this RealmPingComponent self)
        {
            Session session = self.GetParent<Session>();
            long instanceId = self.InstanceId;
            Fiber fiber = self.Fiber();
            while (true)
            {
                try
                {
                    await fiber.Root.GetComponent<TimerComponent>().WaitAsync(2000);
                    if (self.InstanceId != instanceId)
                    {
                        return;
                    }
                    long time1 = TimeInfo.Instance.ClientNow();
                    long serverTime  =0 ;

                    // C2G_Ping不需要调用dispose，Call中会判断，如果用了对象池会自动回收
                    C2R_Ping c2GPing = C2R_Ping.Create(true);
                    // 这里response要用using才能回收到池，默认不回收
                    using R2C_Ping response = await session.Call(c2GPing) as R2C_Ping;
                    serverTime = response.Time;
                    
                    if (self.InstanceId != instanceId)
                    {
                        return;
                    }
                    long time2 = TimeInfo.Instance.ClientNow();
                    self.Ping = time2 - time1;

                    TimeInfo.Instance.Ping = self.Ping;
                    TimeInfo.Instance.ServerMinusClientTime = serverTime + (time2 - time1) / 2 - time2;
                }
                catch (RpcException e)
                {
                    // session断开导致ping rpc报错，记录一下即可，不需要打成error
                    Log.Debug($"session disconnect, ping error: {self.Id} {e.Error}");
                    return;
                }
                catch (Exception e)
                {
                    Log.Debug($"ping error: \n{e}");
                }
            }
        }
    }
}
