namespace ET.Server
{
    [MessageHandler(SceneType.Rank)]
    public class C2R_DBServerInfoHandler : MessageHandler<Scene, C2R_DBServerInfoRequest, R2C_DBServerInfoResponse>
    {
        protected override async ETTask Run(Scene scene, C2R_DBServerInfoRequest request, R2C_DBServerInfoResponse response)
        {
            DBServerInfo dBServerInfo = scene.GetComponent<RankSceneComponent>().DBServerInfo;
            response.ServerInfo = dBServerInfo.ServerInfo;
            await ETTask.CompletedTask;
        }
    }
}
