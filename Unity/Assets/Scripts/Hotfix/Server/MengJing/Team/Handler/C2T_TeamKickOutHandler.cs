using System;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2T_TeamKickOutHandler : MessageHandler<Scene, C2T_TeamKickOutRequest, T2C_TeamKickOutResponse>
    {
        protected override async ETTask Run(Scene scene, C2T_TeamKickOutRequest request, T2C_TeamKickOutResponse response)
        {
            TeamInfo teamInfo = scene.GetComponent<TeamSceneComponent>().GetTeamInfo(request.UserId);
            scene.GetComponent<TeamSceneComponent>().OnRecvUnitLeave(request.UserId);
            await ETTask.CompletedTask;
        }
    }
}
