using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver.Linq;

namespace ET.Server
{

    [MessageHandler(SceneType.Team)]
    public class C2T_TeamDungeonInfoHandler : MessageHandler<Scene, C2T_TeamDungeonInfoRequest, T2C_TeamDungeonInfoResponse>
    {

        protected override async ETTask Run(Scene scene, C2T_TeamDungeonInfoRequest request, T2C_TeamDungeonInfoResponse response)
        {
            List<TeamInfo> teamInfos = new List<TeamInfo>();
            List<TeamInfo> teamList = scene.GetComponent<TeamSceneComponent>().TeamList;
            for (int i = teamList.Count - 1; i >= 0; i--)
            {
                TeamInfo teamInfo = teamList[i];

                if (teamInfo.PlayerList.Count == 0)
                {
                    teamList.RemoveAt(i);
                    continue;
                }
                if (teamInfo.SceneId > 0 && teamInfo.SceneType == request.SceneType)
                {
                    teamInfos.Add(teamInfo);
                    continue;
                }
                if (teamInfo.PlayerList.Any(n => n.UserID == request.UserId))
                {
                    teamInfos.Add(teamInfo);
                }
            }
            response.TeamList = teamInfos;

            await ETTask.CompletedTask;
        }

    }
}
