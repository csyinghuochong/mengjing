
namespace ET.Client
{
    [MessageHandler(SceneType.NetClient)]
    public class Main2NetClient_CheckSessionHandler: MessageHandler<Scene, Main2NetClient_CheckSession, NetClient2Main_CheckSession>
    {
        protected override async ETTask Run(Scene root, Main2NetClient_CheckSession request, NetClient2Main_CheckSession response)
        {
            await ETTask.CompletedTask;
            SessionComponent sessionComponent = root.GetComponent<SessionComponent>();
            if (sessionComponent.Session == null || sessionComponent.Session.IsDisposed)
            {
                response.Error = ErrorCode.ERR_SessionDisconnect;
                return;
            }

            Session session = sessionComponent.Session;
            if (request.MapType < MapTypeEnum.MainCityScene)
            {
                RealmPingComponent realmPingComponent = session.GetComponent<RealmPingComponent>();
                if (realmPingComponent == null)
                {
                    response.Error = ErrorCode.ERR_SessionDisconnect;
                    return;
                }

                Log.Warning($"realmPingComponent :{realmPingComponent!=null}");
                C2R_Ping c2GPing = C2R_Ping.Create(true);
                using R2C_Ping response_1 = await session.Call(c2GPing) as R2C_Ping;
                if (response_1 == null)
                {
                    response.Error = ErrorCode.ERR_SessionDisconnect;
                    return;
                }

                response.Error = response_1.Error;
            }
            else
            {
                PingComponent pingComponent = session.GetComponent<PingComponent>();
                if (pingComponent == null)
                {
                    response.Error = ErrorCode.ERR_SessionDisconnect;
                    return;
                }
                
                Log.Warning($"pingComponent :{pingComponent!=null}");
                C2G_Ping c2GPing = C2G_Ping.Create(true);
                using G2C_Ping response_1 = await session.Call(c2GPing) as G2C_Ping;
                if (response_1 == null)
                {
                    response.Error = ErrorCode.ERR_SessionDisconnect;
                    return;
                }
                response.Error = response_1.Error;
            }
        }
    }
}