namespace ET.Server
{

    [MessageHandler(SceneType.Team)]
    public class C2T_TeamDungeonApplyHandler : MessageHandler<Scene, C2T_TeamDungeonApplyRequest, T2C_TeamDungeonApplyResponse>
    {
        protected override async ETTask Run(Scene scene, C2T_TeamDungeonApplyRequest request, T2C_TeamDungeonApplyResponse response)
        {
            TeamSceneComponent teamSceneComponent = scene.GetComponent<TeamSceneComponent>();
            if (teamSceneComponent.GetTeamInfo(request.TeamPlayerInfo.UserID) != null)
            {
                response.Error = ErrorCode.ERR_IsHaveTeam;
                return;
            }

            TeamInfo teamInfo = teamSceneComponent.GetTeamInfo(request.TeamId);
            if (teamInfo == null || teamInfo.PlayerList.Count == 3)
            {
                response.Error = ErrorCode.ERR_TeamIsFull;

                return;
            }

            //需要判断次数就添加C2M
            M2C_TeamDungeonApplyResult m2C_HorseNoticeInfo = M2C_TeamDungeonApplyResult.Create();
            m2C_HorseNoticeInfo.TeamPlayerInfo = request.TeamPlayerInfo;
            
            scene.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession).Send(teamInfo.TeamId, m2C_HorseNoticeInfo);
            await ETTask.CompletedTask;
        }
    }
}
