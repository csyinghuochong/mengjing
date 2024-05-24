using System;

namespace ET.Server
{

    [MessageHandler(SceneType.Happy)]
    public class M2H_HapplyEnterHandler : MessageHandler<Scene, M2H_HapplyEnterRequest, H2M_HapplyEnterResponse>
    {
        protected override async ETTask Run(Scene scene, M2H_HapplyEnterRequest request, H2M_HapplyEnterResponse response)
        {
            HappySceneComponent happySceneComponent = scene.GetComponent<HappySceneComponent>();
           
            response.FubenInstanceId = happySceneComponent.GetFubenInstanceId(request.UnitId);

            await ETTask.CompletedTask;
        }
    }
}
