using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Battle)]
    public class M2B_BattleEnterRequestHandler : MessageHandler<Scene, M2B_BattleEnterRequest, B2M_BattleEnterResponse>
    {
        protected override async ETTask Run(Scene scene, M2B_BattleEnterRequest request, B2M_BattleEnterResponse response)
        {
            KeyValuePairInt keyValuePairInt  = scene.GetComponent<BattleSceneComponent>().GetBattleInstanceId(request.UserID, request.SceneId);
            if (keyValuePairInt != null)
            {
                response.FubenInstanceId = keyValuePairInt.Value;
                response.Camp = keyValuePairInt.KeyId;
            }
            else
            {
                using (await scene.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Battle, scene.Zone()))
                {
                    keyValuePairInt = await scene.GetComponent<BattleSceneComponent>().GenerateBattleInstanceId(request.UserID, request.SceneId);
                    if (keyValuePairInt != null)
                    {
                        response.FubenInstanceId = keyValuePairInt.Value;
                        response.Camp = keyValuePairInt.KeyId;
                    }
                }
            }

            response.FubenActorId = new ActorId(scene.Fiber().Process, scene.Fiber().Id, response.FubenInstanceId);
            await ETTask.CompletedTask;
        }
    }
}
