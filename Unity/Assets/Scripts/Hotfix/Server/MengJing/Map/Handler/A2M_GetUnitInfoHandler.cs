namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class A2M_GetUnitInfoHandler: MessageLocationHandler<Scene, A2M_GetUnitInfoRequest, M2A_GetUnitInfoResponse>
    {
        protected override async ETTask Run(Scene scene, A2M_GetUnitInfoRequest request, M2A_GetUnitInfoResponse response)
        {

            response.PlayerState = (int)PlayerState.Game;
            await ETTask.CompletedTask;
        }
    }
}