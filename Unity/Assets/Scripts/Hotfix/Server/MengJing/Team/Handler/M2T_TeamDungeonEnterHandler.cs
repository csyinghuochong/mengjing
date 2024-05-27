using System;

namespace ET.Server
{

    [MessageHandler(SceneType.Team)]
    public class M2T_TeamDungeonEnterHandler : MessageHandler<Scene, M2T_TeamDungeonEnterRequest, T2M_TeamDungeonEnterResponse>
    {
        protected override async ETTask Run(Scene scene, M2T_TeamDungeonEnterRequest request, T2M_TeamDungeonEnterResponse response)
        {
            TeamInfo teamInfo = scene.GetComponent<TeamSceneComponent>().GetTeamInfo( request.UserID );
            if (teamInfo == null)
            {
                response.Error = ErrorCode.ERR_TransferFailError;

                return;
            }
            if (teamInfo.FubenInstanceId == 0)
            {
                scene.GetComponent<TeamSceneComponent>().CreateTeamDungeon(teamInfo);
            }

            response.FubenId = teamInfo.SceneId;
            response.FubenType = teamInfo.FubenType;
            response.FubenInstanceId = teamInfo.FubenInstanceId;
            await ETTask.CompletedTask;
        }
    }
}
