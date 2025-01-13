namespace ET.Server
{
    /// <summary>
    /// 同意组队邀请
    /// </summary>
    [MessageHandler(SceneType.Team)]
    public class C2T_TeamAgreeHandler : MessageHandler<Scene, C2T_TeamAgreeRequest, T2C_TeamAgreeResponse>
    {

        protected override async ETTask Run(Scene scene, C2T_TeamAgreeRequest request, T2C_TeamAgreeResponse response)
        {
            TeamSceneComponent teamSceneComponent = scene.GetComponent<TeamSceneComponent>();
            TeamInfo teamInfo = teamSceneComponent.GetTeamInfo(request.TeamPlayerInfo_1.UserID);

            //不是队长。无法开组
            if (teamInfo != null && teamInfo.TeamId != request.TeamPlayerInfo_1.UserID)
            {
                return;
            }
            if (teamInfo == null)
            {
                teamInfo = teamSceneComponent.CreateTeamInfo(request.TeamPlayerInfo_1, 0, 0);
            }
            bool haveplayer = false;
            for (int i = 0; i < teamInfo.PlayerList.Count; i++ )
            {
                if (teamInfo.PlayerList[i].UserID == request.TeamPlayerInfo_2.UserID)
                {
                    haveplayer = true;
                    break;
                }
            }
            if (!haveplayer)
            {
                teamInfo.PlayerList.Add(request.TeamPlayerInfo_2);
            }

            teamSceneComponent.SyncTeamInfo(teamInfo, teamInfo.PlayerList);
            await ETTask.CompletedTask;
        }
    }
}
