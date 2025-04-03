using System;

namespace ET.Server
{

    [MessageHandler(SceneType.Team)]
    public class M2T_TeamDungeonEnterHandler : MessageHandler<Scene, M2T_TeamDungeonEnterRequest, T2M_TeamDungeonEnterResponse>
    {
        protected override async ETTask Run(Scene scene, M2T_TeamDungeonEnterRequest request, T2M_TeamDungeonEnterResponse response)
        {
            if (request.TeamId == 0)
            {
                response.Error = ErrorCode.Err_TeamIsNull;
                return;
            }

            TeamSceneComponent teamSceneComponent = scene.GetComponent<TeamSceneComponent>();
            TeamInfo teamInfo = teamSceneComponent.GetTeamInfo( request.UserID );
            if (teamInfo == null)
            {
                response.Error = ErrorCode.ERR_TransferFailError;
                Console.WriteLine($"teamInfo == null:  {request.UserID}");
                return;
            }
            
            ActorId fubenActorId = teamInfo.FubenActorId;
            if (fubenActorId == default)
            {
                switch (request.SceneType)
                {
                    case MapTypeEnum.TeamDungeon:
                        teamSceneComponent.CreateTeamDungeon(teamInfo);
                        break;
                    case MapTypeEnum.DragonDungeon:
                        teamSceneComponent.CreateDragonDungeon(teamInfo);
                        break;
                    default:
                        Log.Error($"M2T_TeamDungeonEnterHandler.request.SceneType.Error: {request.SceneType}");
                        break;
                }
            }

            response.FubenId = teamInfo.SceneId;
            response.FubenType = teamInfo.FubenType;
            response.FubenActorId = teamInfo.FubenActorId;
            await ETTask.CompletedTask;
        }
    }
}
