namespace ET.Server
{

    [MessageHandler(SceneType.Team)]
    public class C2T_GetTeamInfoHandler : MessageHandler<Scene, C2T_GetTeamInfoRequest, T2C_GetTeamInfoResponse>
    {
        protected override async ETTask Run(Scene scene, C2T_GetTeamInfoRequest request, T2C_GetTeamInfoResponse response)
        {
            TeamSceneComponent teamSceneComponent = scene.GetComponent<TeamSceneComponent>();
            response.TeamInfo = teamSceneComponent.GetTeamInfo(request.UserID); 
            await ETTask.CompletedTask;

        }
    }
}
