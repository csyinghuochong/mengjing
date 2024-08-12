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
            scene.GetComponent<FubenCenterComponent>().TeamFubens.TryGetValue(request.TeamId, out fubenActorId);
            if (fubenActorId == default)
            {
                scene.GetComponent<FubenCenterComponent>().CreateTeamDungeon(request.TeamId, request.SceneId, request.FubenType);
            }

            response.FubenActorId = fubenActorId;
            await ETTask.CompletedTask;
        }
    }
}
