using System;

namespace ET.Server
{
    [MessageHandler(SceneType.FubenCenter)]
    public class M2F_FubenSceneIdHandler : MessageHandler<Scene, M2F_FubenSceneIdRequest, F2M_FubenSceneIdResponse>
    {
        protected override async ETTask Run(Scene scene, M2F_FubenSceneIdRequest request, F2M_FubenSceneIdResponse response)
        {
            if (scene.GetComponent<FubenCenterComponent>().YeWaiFubenList.ContainsKey(request.SceneId))
            {
                response.FubenInstanceId = scene.GetComponent<FubenCenterComponent>().YeWaiFubenList[request.SceneId];
                response.FubenActorId = scene.GetComponent<FubenCenterComponent>().FubenActorIdList[request.SceneId];
                response.Message = scene.GetComponent<FubenCenterComponent>().GetScenePlayer(response.FubenInstanceId).ToString();
            }
            else if (request.SceneId == 3000001 || request.SceneId == 3000002)  //战场
            {
                (int, BattleInfo) iteminfo = scene.GetComponent<FubenCenterComponent>().GetBattleInstanceId(request.UnitId, request.SceneId);
                response.FubenInstanceId = iteminfo.Item2.FubenInstanceId;
                response.FubenActorId = iteminfo.Item2.ActorId;
                response.Camp = iteminfo.Item1;
                response.Message = "0";
            }
            else 
            {
                if (request.UnitId == 0)
                {
                    return;
                }

                int functionId = 0;
                if (request.SceneId == 8000001)
                {
                    functionId = 1055;
                }
                if (request.SceneId == 6000001)
                {
                    functionId = 1031;
                }
                if (request.SceneId == 6000002)
                {
                    functionId = 1058;
                }
                if (request.SceneId == 6000003)
                {
                    functionId = 1059;
                }
                BattleInfo battleInfo = scene.GetComponent<FubenCenterComponent>().GetFunctionFubenId(functionId, request.UnitId);
                response.FubenInstanceId = battleInfo.FubenInstanceId;
                response.FubenActorId = battleInfo.ActorId;
                response.Message = "0";
            }
            
            await ETTask.CompletedTask;
        }
    }
}
