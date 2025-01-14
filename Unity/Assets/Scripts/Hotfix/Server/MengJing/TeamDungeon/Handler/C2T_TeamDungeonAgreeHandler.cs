using System;
using System.Linq;

namespace ET.Server
{
    [MessageHandler(SceneType.Team)]
    public class C2T_TeamDungeonAgreeHandler : MessageHandler<Scene, C2T_TeamDungeonAgreeRequest, T2C_TeamDungeonAgreeResponse>
    {
        protected override async ETTask Run(Scene scene, C2T_TeamDungeonAgreeRequest request, T2C_TeamDungeonAgreeResponse response)
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
            
            bool haveplayer = teamInfo.PlayerList.Any( d=>d.UserID ==  request.TeamPlayerInfo.UserID);
            Console.WriteLine($"C2T_TeamDungeonAgreeRequest:  haveplayer:{haveplayer}");
            if (!haveplayer)
            {
                teamInfo.PlayerList.Add(request.TeamPlayerInfo);
            }
            teamSceneComponent.SyncTeamInfo(teamInfo,teamInfo.PlayerList);
            await ETTask.CompletedTask;
        }
    }
}
