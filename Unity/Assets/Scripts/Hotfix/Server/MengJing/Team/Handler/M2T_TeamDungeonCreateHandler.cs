﻿namespace ET.Server
{
    [MessageHandler(SceneType.Team)]
    public class M2T_TeamDungeonCreateHandler : MessageHandler<Scene, M2T_TeamDungeonCreateRequest, T2M_TeamDungeonCreateResponse>
    {
        protected override async ETTask Run(Scene scene, M2T_TeamDungeonCreateRequest request, T2M_TeamDungeonCreateResponse response)
        {
            TeamSceneComponent teamSceneComponent = scene.GetComponent<TeamSceneComponent>();
            TeamInfo teamInfo = teamSceneComponent.GetTeamInfo(request.TeamPlayerInfo.UserID);
            if (teamInfo != null && teamInfo.TeamId != request.TeamPlayerInfo.UserID)
            {
                //非队长
                response.Error = ErrorCode.ERR_IsNotLeader;
                return;
            }

            //无队伍
            if (teamInfo == null)
            {
                teamInfo = teamSceneComponent.CreateTeamInfo(request.TeamPlayerInfo, request.FubenId);
            }
            else
            {
                teamInfo.SceneId = request.FubenId;
            }
            teamInfo.FubenType = request.FubenType; 
            teamSceneComponent.SyncTeamInfo(teamInfo, teamInfo.PlayerList);
            
            await ETTask.CompletedTask;
        }
    }
}
