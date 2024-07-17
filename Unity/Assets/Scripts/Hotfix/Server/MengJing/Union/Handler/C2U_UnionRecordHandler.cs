using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class C2U_UnionRecordHandler : MessageHandler<Scene, C2U_UnionRecordRequest, U2C_UnionRecordResponse>
    {
        protected override async ETTask Run(Scene scene, C2U_UnionRecordRequest request, U2C_UnionRecordResponse response)
        {
            DBUnionInfo dBUnionInfo = await scene.GetComponent<UnionSceneComponent>().GetDBUnionInfo( request.UnionId );
            if (dBUnionInfo == null)
            {
                return;
            }

            for (int i = dBUnionInfo.UnionInfo.DonationRecords.Count - 1; i >=0; i--)
            {
                DonationRecord donationRecord = dBUnionInfo.UnionInfo.DonationRecords[i];
                UserInfoComponentS userInfoComponent = await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(scene.Root(), donationRecord.UnitId);
                if (userInfoComponent == null)
                {
                    dBUnionInfo.UnionInfo.UnionPlayerList.RemoveAt(i);
                    continue;
                }
                donationRecord.Name = userInfoComponent.UserInfo.Name;
                donationRecord.Occ = userInfoComponent.UserInfo.Occ;    
            }
            response.DonationRecords .AddRange(dBUnionInfo.UnionInfo.DonationRecords); 
            await ETTask.CompletedTask;
        }
    }
}
