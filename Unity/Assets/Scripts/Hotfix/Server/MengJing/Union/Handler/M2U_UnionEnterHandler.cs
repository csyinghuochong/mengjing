using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class M2U_UnionEnterHandler : MessageHandler<Scene, M2U_UnionEnterRequest, U2M_UnionEnterResponse>
    {
        protected override async ETTask Run(Scene scene, M2U_UnionEnterRequest request, U2M_UnionEnterResponse response)
        {
            UnionSceneComponent unionSceneComponent = scene.GetComponent<UnionSceneComponent>();
            if (request.OperateType == 1)
            {
                response.FubenActorId = unionSceneComponent.UnionRaceSceneInstanceId;
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
