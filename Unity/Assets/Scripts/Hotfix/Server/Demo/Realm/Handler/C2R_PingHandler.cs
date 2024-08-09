namespace ET.Server
{
    [MessageSessionHandler(SceneType.Realm)]
    public class C2R_PingHandler : MessageSessionHandler<C2R_Ping, R2C_Ping>
    {
        protected override async ETTask Run(Session session, C2R_Ping request, R2C_Ping response)
        {
            using C2R_Ping _ = request; // 这里用完调用Dispose可以回收到池，不调用的话GC会回收
			
            response.Time = TimeInfo.Instance.ClientNow();
            await ETTask.CompletedTask;
			
            // MessageSessionHandler的response会在函数返回发送完消息回收到池
        }
    }
}