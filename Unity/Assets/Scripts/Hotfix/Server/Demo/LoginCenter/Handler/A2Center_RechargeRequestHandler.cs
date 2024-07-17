using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.ReCharge)]
    public class A2Center_RechargeRequestHandler : MessageHandler<Scene, A2Center_RechargeRequest, Center2A_RechargeResponse>
    {
        protected override async ETTask Run(Scene scene, A2Center_RechargeRequest request, Center2A_RechargeResponse response)
        {

            using (await scene.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Recharge, request.AccountId))
            {
                int zone = scene.Zone();
                Log.Warning($"A2Center_RechargeRequest: {scene.Zone()}");
                DBManagerComponent dbManagerComponent = scene.Root().GetComponent<DBManagerComponent>();
                DBComponent dbComponent = dbManagerComponent.GetZoneDB(scene.Zone());
                
                List<DBCenterAccountInfo> resulets = await dbComponent.Query<DBCenterAccountInfo>(zone, d => d.Id == request.AccountId);
                resulets[0].PlayerInfo.RechargeInfos.Add(request.RechargeInfo);
                dbComponent.Save<DBCenterAccountInfo>(scene.Zone(), resulets[0]).Coroutine();
            }

            await ETTask.CompletedTask;
        }
    }
}
