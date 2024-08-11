namespace ET.Server
{
    [MessageHandler(SceneType.FubenCenter)]
    public class M2F_UnionEnterHandler : MessageHandler<Scene, M2F_UnionEnterRequest, F2M_UnionEnterResponse>
    {
        protected override async ETTask Run(Scene scene, M2F_UnionEnterRequest request, F2M_UnionEnterResponse response)
        {
            FubenCenterComponent unionSceneComponent = scene.GetComponent<FubenCenterComponent>();
            if (request.OperateType == 1)
            {
                response.FubenActorId = unionSceneComponent.UnionRaceScene.ActorId;
                unionSceneComponent.OnJoinUnionRace(request.UnionId, request.UnitId);
            }
            else
            {
                response.FubenActorId = unionSceneComponent.GetUnionFubenId(request.UnionId, request.UnitId);
            }
            
            await ETTask.CompletedTask;
        }
    }
}
