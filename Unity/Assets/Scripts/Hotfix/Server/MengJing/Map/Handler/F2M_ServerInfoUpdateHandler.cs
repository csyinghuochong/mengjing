namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class F2M_ServerInfoUpdateHandler : MessageHandler<Scene, F2M_ServerInfoUpdateRequest, M2F_ServerInfoUpdateResponse>
    {
        protected override async ETTask Run(Scene scene, F2M_ServerInfoUpdateRequest request, M2F_ServerInfoUpdateResponse response)
        {
            scene.GetComponent<ServerInfoComponent>().ServerInfo = request.ServerInfo;
            await ETTask.CompletedTask;
        }
    }
}
