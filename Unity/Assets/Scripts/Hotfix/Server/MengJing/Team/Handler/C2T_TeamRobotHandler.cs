using System;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2T_TeamRobotHandler : MessageHandler<Scene, C2T_TeamRobotRequest, T2C_TeamRobotResponse>
    {
        protected override async ETTask Run(Scene scene, C2T_TeamRobotRequest request, T2C_TeamRobotResponse response)
        {
            TeamSceneComponent teamSceneComponent = scene.GetComponent<TeamSceneComponent>();
            TeamInfo teamInfo = teamSceneComponent.GetTeamInfo(request.UnitId);
            if (teamInfo == null)
            {
                response.Error = ErrorCode.Err_TeamIsNull;
                return;
            }

            ActorId robotSceneId = UnitCacheHelper.GetRobotServerId();
            scene.Root().GetComponent<MessageSender>().Send(robotSceneId, new G2Robot_MessageRequest()
            {
                Zone = scene.Zone(),
                MessageType = NoticeType.TeamDungeon,
                Message = $"{teamInfo.SceneId}_{teamInfo.TeamId}"
            });
            
            await ETTask.CompletedTask;

        }
    }
}
