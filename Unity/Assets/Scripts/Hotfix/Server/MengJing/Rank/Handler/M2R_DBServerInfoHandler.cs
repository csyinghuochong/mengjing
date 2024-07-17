namespace ET.Server
{
    [MessageHandler(SceneType.Rank)]
    public class M2R_DBServerInfoHandler : MessageHandler<Scene, M2R_DBServerInfoRequest, R2M_DBServerInfoResponse>
    {
        protected override async ETTask Run(Scene scene, M2R_DBServerInfoRequest request, R2M_DBServerInfoResponse response)
        {
            DBServerInfo dBServerInfo = scene.GetComponent<RankSceneComponent>().DBServerInfo;
            response.ServerInfo = dBServerInfo.ServerInfo;
            await ETTask.CompletedTask;
        }
    }
}
