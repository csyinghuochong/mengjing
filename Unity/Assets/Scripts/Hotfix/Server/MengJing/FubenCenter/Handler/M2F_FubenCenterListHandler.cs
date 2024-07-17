namespace ET.Server
{

    [MessageHandler(SceneType.FubenCenter)]
    public class M2F_FubenCenterListHandler : MessageHandler<Scene, M2F_FubenCenterListRequest, F2M_FubenCenterListResponse>
    {
        protected override async ETTask Run(Scene scene, M2F_FubenCenterListRequest request, F2M_FubenCenterListResponse response)
        {
            response.FubenInstanceList .AddRange( scene.GetComponent<FubenCenterComponent>().FubenInstanceList);

            await ETTask.CompletedTask;
        }
    }
}
