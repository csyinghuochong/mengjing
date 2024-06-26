using System;

namespace ET.Server
{
    [MessageHandler(SceneType.FubenCenter)]
    public class M2F_YeWaiSceneIdHandler : MessageHandler<Scene, M2F_FubenSceneIdRequest, F2M_FubenSceneIdResponse>
    {
        protected override async ETTask Run(Scene scene, M2F_FubenSceneIdRequest request, F2M_FubenSceneIdResponse response)
        {
            if (scene.GetComponent<FubenCenterComponent>().YeWaiFubenList.ContainsKey(request.SceneId))
            {
                response.FubenInstanceId = scene.GetComponent<FubenCenterComponent>().YeWaiFubenList[request.SceneId];
                response.FubenActorId = scene.GetComponent<FubenCenterComponent>().FubenActorIdList[request.SceneId];
                response.Message = scene.GetComponent<FubenCenterComponent>().GetScenePlayer(response.FubenInstanceId).ToString();
            }
            else if (request.SceneId == 3000001 || request.SceneId == 3000002)
            {
                (int, BattleInfo) iteminfo = scene.GetComponent<FubenCenterComponent>().GetBattleInstanceId(request.UnitId, request.SceneId);
                response.FubenInstanceId = iteminfo.Item2.FubenInstanceId;
                response.FubenActorId = iteminfo.Item2.ActorId;
                response.Camp = iteminfo.Item1;
                response.Message = "0";
            }
            else if (request.SceneId == 1111211)
            {
                //response.FubenInstanceId = scene.GetComponent<ArenaSceneComponent>().GetArenaInstanceId(request.UserID, request.SceneId);
            }
            else if (request.SceneId == 2222222)
            {

                // HappySceneComponent happySceneComponent = scene.GetComponent<HappySceneComponent>();
                //
                // response.FubenInstanceId = happySceneComponent.GetFubenInstanceId(request.UnitId);
                // response.FubenActorId = new ActorId(scene.Fiber().Process, scene.Fiber().Id, response.FubenInstanceId);

            }
            else 
            {
                if (request.UnitId == 0)
                {
                    return;
                }
                int functionId = request.SceneId == 6000002 ? 1058 : 1059;
                BattleInfo battleInfo = scene.GetComponent<FubenCenterComponent>().GetFunctionFubenId(functionId, request.UnitId);
                response.FubenInstanceId = battleInfo.FubenInstanceId;
                response.FubenActorId = battleInfo.ActorId;
                response.Message = "0";
            }
            
            await ETTask.CompletedTask;
        }
    }
}
