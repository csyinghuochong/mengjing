namespace ET.Server
{

    [MessageHandler(SceneType.FubenCenter)]
    public class M2F_TeamDungeonEnterHandler : MessageHandler<Scene, M2F_TeamDungeonEnterRequest, F2M_TeamDungeonEnterResponse>
    {
        protected override async ETTask Run(Scene scene, M2F_TeamDungeonEnterRequest request, F2M_TeamDungeonEnterResponse response)
        {
            if (request.TeamId == 0)
            {
                return;
            }

            ActorId fubenActorId = default;
            FubenCenterComponent fubenCenterComponent = scene.GetComponent<FubenCenterComponent>();
            fubenCenterComponent.TeamFubens.TryGetValue(request.TeamId, out fubenActorId);
            if (fubenActorId == default || request.UserID == request.TeamId)
            {
                fubenCenterComponent.TeamFubens[request.TeamId] = default;
            }

            switch (request.SceneType)
            {
                    case SceneTypeEnum.TeamDungeon:
                        fubenCenterComponent.CreateTeamDungeon(request.TeamId, request.SceneId, request.FubenType);
                        break;
                    case SceneTypeEnum.DragonDungeon:
                        
                        break;
                    default:
                        Log.Error($"M2F_TeamDungeonEnterRequest.request.SceneType.Error: {request.SceneType}");
                        break;
            }
            
            response.FubenActorId = fubenCenterComponent.TeamFubens[request.TeamId];
            await ETTask.CompletedTask;
        }
    }
}
