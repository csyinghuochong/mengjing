using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Battle)]
    public class M2B_BattleEnterRequestHandler : MessageHandler<Scene, M2B_BattleEnterRequest, B2M_BattleEnterResponse>
    {
        protected override async ETTask Run(Scene scene, M2B_BattleEnterRequest request, B2M_BattleEnterResponse response)
        {
            (int, BattleInfo) iteminfo  = scene.GetComponent<BattleSceneComponent>().GetBattleInstanceId(request.UserID, request.SceneId);
            
            if (iteminfo.Item2 != null)
            {
                response.FubenActorId = iteminfo.Item2.ActorId;
                response.FubenInstanceId = iteminfo.Item2.InstanceId;
                response.Camp = iteminfo.Item1;
            }
            else
            {
                using (await scene.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Battle, scene.Zone()))
                {
                    iteminfo =  scene.GetComponent<BattleSceneComponent>().GenerateBattleInstanceId(request.UserID, request.SceneId);
                    if (iteminfo.Item2 != null)
                    {
                        response.FubenActorId = iteminfo.Item2.ActorId;
                        response.FubenInstanceId = iteminfo.Item2.InstanceId;
                        response.Camp = iteminfo.Item1;
                    }
                }
            }
            
            await ETTask.CompletedTask;
        }
    }
}
