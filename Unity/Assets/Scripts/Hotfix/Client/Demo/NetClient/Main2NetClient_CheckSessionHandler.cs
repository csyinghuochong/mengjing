
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
                Log.Warning($"realmPingComponent :{realmPingComponent!=null}");
            }
            else
            {
                PingComponent pingComponent = session.GetComponent<PingComponent>();
                Log.Warning($"pingComponent :{pingComponent!=null}");
            }
        }
    }
}