﻿using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Rank)]
    public class M2R_RankRunRaceHandler : MessageHandler<Scene, M2R_RankRunRaceRequest, R2M_RankRunRaceResponse>
    {
        protected override async ETTask Run(Scene scene, M2R_RankRunRaceRequest request, R2M_RankRunRaceResponse response)
        {
            RankSceneComponent rankSceneComponent = scene.GetComponent<RankSceneComponent>();
            DBRankInfo dBRankInfo = rankSceneComponent.DBRankInfo;
            List<RankingInfo> rankRunRace = rankSceneComponent.DBRankInfo.rankRunRace;

            bool have = false;
            for (int i = 0; i < rankRunRace.Count; i++)
            {
                if (rankRunRace[i].UserId == request.RankingInfo.UserId)
                {
                    response.RankId = i + 1;
                    have = true;    
                }
            }

            if (!have)
            {
                rankRunRace.Add(request.RankingInfo);
                response.RankId = rankRunRace.Count;
            }
            int maxnumber = Math.Min(rankRunRace.Count, 10);
            dBRankInfo.rankRunRace = rankRunRace.GetRange(0, maxnumber);

            response.RankList .AddRange(rankRunRace); 
            await ETTask.CompletedTask;
        }
    }
}
