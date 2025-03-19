using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class C2U_UnionListHandler : MessageHandler<Scene, C2U_UnionListRequest, U2C_UnionListResponse>
    {
        protected override async ETTask Run(Scene scene, C2U_UnionListRequest request, U2C_UnionListResponse response)
        {
            Log.Warning($"C2U_UnionListRequest:{request.ActorId}");
            List<UnionListItem> unionList = new List<UnionListItem>();
            DBManagerComponent dbManagerComponent = scene.GetComponent<DBManagerComponent>();
            DBComponent dbComponent = dbManagerComponent.GetZoneDB(scene.Zone());
            List<DBUnionInfo> result = await  dbComponent.Query<DBUnionInfo>(scene.Zone(), _account => _account.UnionInfo!=null);
            for (int i = result.Count -1; i >=0 ; i--)
            {
                DBUnionInfo dBUnionInfo = result[i];
                if (dBUnionInfo == null || dBUnionInfo.UnionInfo.LeaderId == 0)
                {
                    continue;
                }

                UnionListItem unionListItem = UnionListItem.Create();
                unionListItem.UnionName = dBUnionInfo.UnionInfo.UnionName;
                unionListItem.PlayerNumber = dBUnionInfo.UnionInfo.UnionPlayerList.Count;
                unionListItem.UnionId = dBUnionInfo.UnionInfo.UnionId;
                unionListItem.UnionLevel = Math.Max(dBUnionInfo.UnionInfo.Level, 1);
                unionListItem.UnionLeader = dBUnionInfo.UnionInfo.LeaderName;
                unionListItem.UnionPurpose = dBUnionInfo.UnionInfo.UnionPurpose;
                unionListItem.ApplyList = dBUnionInfo.UnionInfo.ApplyList;  
                unionList.Add(unionListItem);
            }
            response.UnionList = unionList;
        }
    }
}
