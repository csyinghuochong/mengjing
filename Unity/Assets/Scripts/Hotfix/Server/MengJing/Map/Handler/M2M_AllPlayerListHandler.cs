namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class M2M_AllPlayerListHandler : MessageHandler<Scene, M2M_AllPlayerListRequest, M2M_AllPlayerListResponse>
    {
        protected override async ETTask Run(Scene scene, M2M_AllPlayerListRequest request, M2M_AllPlayerListResponse response)
        {
            response.AllPlayers = scene.GetComponent<UnitComponent>().GetAllIds(UnitType.Player);
            
            await ETTask.CompletedTask;
        }
    }
}
