using System;

namespace ET.Server
{
    [MessageHandler(SceneType.JiaYuan)]
    public class M2J_JiaYuanEnterHandler : MessageHandler<Scene, M2J_JiaYuanEnterRequest, J2M_JiaYuanEnterResponse>
    {
        protected override async ETTask Run(Scene scene, M2J_JiaYuanEnterRequest request, J2M_JiaYuanEnterResponse response)
        {
            response.FubenInstanceId = await scene.GetComponent<JiaYuanSceneComponent>().GetJiaYuanFubenId(request.MasterId, request.UnitId);
            response.FubenActorId = new ActorId(scene.Fiber().Process, scene.Fiber().Id, response.FubenInstanceId);
        }
    }
}
