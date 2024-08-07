using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class M2U_DonationRequestHandler : MessageHandler<Scene, M2U_DonationRequest, U2M_DonationResponse>
    {
        protected override async ETTask Run(Scene scene, M2U_DonationRequest request, U2M_DonationResponse response)
        {
         
            UnionSceneComponent rankSceneComponent = scene.GetComponent<UnionSceneComponent>();
            DBUnionManager dBRankInfo = rankSceneComponent.DBUnionManager;
            dBRankInfo.TotalDonation += (long)(0.5f * request.RankingInfo.Combat);

            int oldrank = -1;
            int newrank = -1;
            ListComponent<long> userlist = new ListComponent<long>();   
            for (int i = dBRankInfo.rankingDonation.Count - 1; i >= 0; i--)
            {
                RankingInfo rankingInfoTemp = dBRankInfo.rankingDonation[i];
                if (rankingInfoTemp.UserId == 0)
                {
                    dBRankInfo.rankingDonation.RemoveAt(i);
                    continue;
                }

                if (rankingInfoTemp.UserId == request.RankingInfo.UserId)
                {
                    rankingInfoTemp.Combat += request.RankingInfo.Combat;
                    oldrank = i;
                }
            }
            if (oldrank == -1)
            {
                dBRankInfo.rankingDonation.Add(request.RankingInfo);
            }
            dBRankInfo.rankingDonation.Sort(delegate (RankingInfo a, RankingInfo b)
            {
                return (int)b.Combat - (int)a.Combat;
            });
            newrank = rankSceneComponent.GetDonationRank(request.RankingInfo.UserId);

            //有变化则通知
            if (oldrank != newrank)
            {
                int number = Math.Min(dBRankInfo.rankingDonation.Count, 20);
                for (int i = 0; i < number;i++)
                {
                    //if (userlist.Count < 10 && !userlist.Contains(dBRankInfo.rankingDonation[i].UserId))
                    //{

                    //}
                    userlist.Add(dBRankInfo.rankingDonation[i].UserId);
                }
                
                for (int i = 0; i < userlist.Count; i++)
                {
                    R2M_RankUpdateMessage r2M_RankUpdateMessage = R2M_RankUpdateMessage.Create();
                    r2M_RankUpdateMessage.RankType = 3;
                    r2M_RankUpdateMessage.RankId = rankSceneComponent.GetDonationRank(userlist[i]);
                    scene.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(userlist[i], r2M_RankUpdateMessage);
                }
            }

            response.RankId = newrank;
            await ETTask.CompletedTask;
        }
    }
}
