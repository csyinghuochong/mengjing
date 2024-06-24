using System;

namespace ET.Server
{
    [MessageHandler(SceneType.FubenCenter)]
    public class M2F_YeWaiSceneIdHandler : MessageHandler<Scene, M2F_YeWaiSceneIdRequest, F2M_YeWaiSceneIdResponse>
    {
        protected override async ETTask Run(Scene scene, M2F_YeWaiSceneIdRequest request, F2M_YeWaiSceneIdResponse response)
        {
            if (request.SceneId == 6000002 || request.SceneId == 6000003)
            {
                if (request.UnitId == 0)
                {
                    return;
                }
                int functionId = request.SceneId == 6000002 ? 1058 : 1059;
                response.FubenInstanceId = scene.GetComponent<FubenCenterComponent>().GetFunctionFubenId(functionId, request.UnitId);
                response.FubenActorId = new ActorId(scene.Fiber().Process, scene.Fiber().Id, response.FubenInstanceId);
                response.Message = "0";
            }
            else if (scene.GetComponent<FubenCenterComponent>().YeWaiFubenList.ContainsKey(request.SceneId))
            {
                response.FubenInstanceId = scene.GetComponent<FubenCenterComponent>().YeWaiFubenList[request.SceneId];
                response.FubenActorId = scene.GetComponent<FubenCenterComponent>().FubenActorIdList[request.SceneId];
                response.Message = scene.GetComponent<FubenCenterComponent>().GetScenePlayer(response.FubenInstanceId).ToString();
            }
            else
            {
                response.FubenInstanceId = 0;
                response.Message = "0";
            }
            
            await ETTask.CompletedTask;
        }
    }
}
