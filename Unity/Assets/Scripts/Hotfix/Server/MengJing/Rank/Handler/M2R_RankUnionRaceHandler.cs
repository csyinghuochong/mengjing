using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Rank)]
    public class M2R_RankUnionRaceHandler : MessageHandler<Scene, M2R_RankUnionRaceRequest, R2M_RankUnionRaceResponse>
    {
        protected override async ETTask Run(Scene scene, M2R_RankUnionRaceRequest request, R2M_RankUnionRaceResponse response)
        {
            RankSceneComponent rankSceneComponent = scene.GetComponent<RankSceneComponent>();
            List<RankShouLieInfo> rankUnionRace = rankSceneComponent.DBRankInfo.rankUnionRace;

            bool have = false;
            for (int i = 0; i < rankUnionRace.Count; i++)
            {
                if (rankUnionRace[i].UnitID == request.RankingInfo.UnitID)
                {
                    rankUnionRace[i].KillNumber += request.RankingInfo.KillNumber;
                    have = true;
                    break;
                }
            }
            if (!have)
            {
                rankUnionRace.Add(request.RankingInfo);
            }
            rankUnionRace.Sort(delegate (RankShouLieInfo a, RankShouLieInfo b)
            {
                return (int)b.KillNumber - (int)a.KillNumber;
            });

            int maxnumber = Math.Min(rankUnionRace.Count, 10);
            rankUnionRace = rankUnionRace.GetRange(0, maxnumber);

            await ETTask.CompletedTask;
        }
    }
}
