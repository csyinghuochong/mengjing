namespace ET.Server
{

    [MessageHandler(SceneType.Team)]
    public class C2T_TeamInviteHandler : MessageHandler<Scene, C2T_TeamInviteRequest, T2C_TeamInviteResponse>
    {
        protected override async ETTask Run(Scene scene, C2T_TeamInviteRequest request, T2C_TeamInviteResponse response)
        {
            //检测是否可以邀请玩家组队
            TeamSceneComponent teamSceneComponent = scene.GetComponent<TeamSceneComponent>();
            TeamInfo teamInfo = teamSceneComponent.GetTeamInfo( request.UserID );
            if (teamInfo != null)
            {
                return;
            }

            teamInfo = teamSceneComponent.GetTeamInfo(request.TeamPlayerInfo.UserID);
            if (teamInfo != null)
            {
                if (teamInfo.TeamId != request.TeamPlayerInfo.UserID || teamInfo.PlayerList.Count == 3)
                {
                    return;
                }
                for (int i = 0; i < teamInfo.PlayerList.Count; i++)
                {
                    if (teamInfo.PlayerList[i].UserID == request.UserID)
                    {
                        return;
                    }
                }
            }

            M2C_TeamInviteResult m2C_HorseNoticeInfo = M2C_TeamInviteResult.Create();
            m2C_HorseNoticeInfo.TeamPlayerInfo = request.TeamPlayerInfo;
            MapMessageHelper.SendToClient(scene.Root(),request.UserID, m2C_HorseNoticeInfo);

            await ETTask.CompletedTask;
        }
    }
}
