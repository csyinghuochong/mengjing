using System;
using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Rank)]
    public class M2R_RankShowLieHandler : MessageHandler<Scene, M2R_RankShowLieRequest, R2M_RankShowLieResponse>
    {
        protected override async ETTask Run(Scene scene, M2R_RankShowLieRequest request, R2M_RankShowLieResponse response)
        {
            RankSceneComponent rankSceneComponent = scene.GetComponent<RankSceneComponent>();
            DBRankInfo dBRankInfo = rankSceneComponent.DBRankInfo;
            List<RankShouLieInfo> rankShowLie = rankSceneComponent.DBRankInfo.rankShowLie;

            bool have = false;
            for (int i = 0; i < rankShowLie.Count; i++)
            {
                if (rankShowLie[i].UnitID == request.RankingInfo.UnitID)
                {
                    rankShowLie[i].KillNumber = request.RankingInfo.KillNumber;
                    have = true;
                    break;
                }
            }

            if (!have)
            {
                rankShowLie.Add(request.RankingInfo);
            }

            rankShowLie.Sort(delegate (RankShouLieInfo a, RankShouLieInfo b)
            {
                return (int)b.KillNumber - (int)a.KillNumber;
            });

            int maxnumber = Math.Min(rankShowLie.Count, 10 );
            dBRankInfo.rankShowLie = rankShowLie.GetRange( 0, maxnumber );

            await ETTask.CompletedTask;
        }
    }
}
