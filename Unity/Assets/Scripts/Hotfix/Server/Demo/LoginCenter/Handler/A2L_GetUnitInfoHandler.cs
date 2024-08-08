
namespace ET.Server
{
    [MessageHandler(SceneType.LoginCenter)]
    public class A2L_GetUnitInfoHandler : MessageHandler<Scene,A2L_GetUnitInfoRequest,L2A_GetUnitInfoResponse>
    {
        protected override async ETTask Run(Scene scene, A2L_GetUnitInfoRequest request, L2A_GetUnitInfoResponse response)
        {
            response.PlayerState = (int)PlayerState.Disconnect;
            await ETTask.CompletedTask;
        }
    }
}