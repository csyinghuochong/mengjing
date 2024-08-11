using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class C2U_UnionRaceInfoHandler : MessageHandler<Scene, C2U_UnionRaceInfoRequest, U2C_UnionRaceInfoResponse>
    {
        protected override async ETTask Run(Scene scene, C2U_UnionRaceInfoRequest request, U2C_UnionRaceInfoResponse response)
        {
            Log.Warning($"C2U_UnionRaceInfoRequest:{request.ActorId}");
            
            UnionSceneComponent unionSceneComponent = scene.GetComponent<UnionSceneComponent>();
            
            response.TotalDonation = unionSceneComponent.DBUnionManager.GetBaseJiangJin + (int)(unionSceneComponent.DBUnionManager.TotalDonation);

            DBManagerComponent dbManagerComponent = scene.GetComponent<DBManagerComponent>();
            DBComponent dbComponent = dbManagerComponent.GetZoneDB(scene.Zone());
            
            for (int i = 0; i < unionSceneComponent.DBUnionManager.SignupUnions.Count; i++)
            {
                List<DBUnionInfo> result = await dbComponent.Query<DBUnionInfo>(scene.Zone(), _account => _account.UnionInfo.UnionId == unionSceneComponent.DBUnionManager.SignupUnions[i]);
                if (result.Count == 0)
                {
                    continue;
                }
                DBUnionInfo dBUnionInfo = result[0];
                UnionListItem unionListItem = UnionListItem.Create();
                unionListItem.UnionName = dBUnionInfo.UnionInfo.UnionName;
                unionListItem.PlayerNumber = dBUnionInfo.UnionInfo.UnionPlayerList.Count;
                unionListItem.UnionId = dBUnionInfo.UnionInfo.UnionId;
                response.UnionInfoList.Add(unionListItem);
            }
            
            await ETTask.CompletedTask;
        }
    }
}
