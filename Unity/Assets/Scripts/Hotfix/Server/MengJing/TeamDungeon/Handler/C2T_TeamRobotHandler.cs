namespace ET.Server
{

    [MessageHandler(SceneType.Team)]
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
            G2Robot_MessageRequest G2Robot_MessageRequest = G2Robot_MessageRequest.Create();
            G2Robot_MessageRequest.Zone = scene.Zone();
            G2Robot_MessageRequest.MessageType = teamInfo.SceneType == MapTypeEnum.TeamDungeon ? NoticeType.TeamDungeon:NoticeType.DragonDungeon;
            G2Robot_MessageRequest.Message = $"{teamInfo.SceneId}_{teamInfo.TeamId}";
            scene.Root().GetComponent<MessageSender>().Send(robotSceneId, G2Robot_MessageRequest);
            
            await ETTask.CompletedTask;

        }
    }
}
