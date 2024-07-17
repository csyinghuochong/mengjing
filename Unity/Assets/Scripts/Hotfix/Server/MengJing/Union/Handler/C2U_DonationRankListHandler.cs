using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class C2U_DonationRankListHandler : MessageHandler<Scene, C2U_DonationRankListRequest, U2C_DonationRankListResponse>
    {
        protected override async ETTask Run(Scene scene, C2U_DonationRankListRequest request, U2C_DonationRankListResponse response)
        {
            UnionSceneComponent rankComponent = scene.GetComponent<UnionSceneComponent>();

            List<RankingInfo> all = rankComponent.DBUnionManager.rankingDonation;
            List<RankingInfo> list = all.GetRange(0, Math.Min( 10, all.Count ));

            response.RankList .AddRange(list); 
            
            await ETTask.CompletedTask;
        }
    }
}
