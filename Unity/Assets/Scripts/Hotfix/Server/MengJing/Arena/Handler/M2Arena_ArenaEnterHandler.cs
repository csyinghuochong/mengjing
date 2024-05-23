using System;
using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Arena)]
    public class M2Arena_ArenaEnterHandler : MessageHandler<Scene, M2Arena_ArenaEnterRequest, Arena2M_ArenaEnterResponse>
    {
    protected override async ETTask Run(Scene scene, M2Arena_ArenaEnterRequest request, Arena2M_ArenaEnterResponse response)
    {
        //不在时间范围内， 返回0


        response.FubenInstanceId = scene.GetComponent<ArenaSceneComponent>().GetArenaInstanceId(request.UserID, request.SceneId);
        
        await ETTask.CompletedTask;
    }
    }
}
