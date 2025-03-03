﻿namespace ET.Server
{

    [MessageHandler(SceneType.Rank)]
    public class G2Rank_EnterRankHandler : MessageHandler<Scene, G2Rank_EnterRank, Rank2G_EnterRank>
    {
        protected override async ETTask Run(Scene scene, G2Rank_EnterRank request, Rank2G_EnterRank response)
        {
            RankSceneComponent rankSceneComponent = scene.GetComponent<RankSceneComponent>();
            response.RankId = rankSceneComponent.GetCombatRank(request.UnitId);
            response.OccRankId = rankSceneComponent.GetOccCombatRank(request.UnitId, request.Occ);
            response.PetRankId = rankSceneComponent.GetPetRank(request.UnitId);
            response.TrialRankId = rankSceneComponent.GetTrialRank(request.UnitId); 

            if (rankSceneComponent.DBRankInfo.rankSoloInfo.Count > 0
             && rankSceneComponent.DBRankInfo.rankSoloInfo[0].UserId == request.UnitId)
            {
                response.SoloRankId = 1;
            }
            else
            {
                response.SoloRankId = 0;
            }

            await ETTask.CompletedTask;
        }
    }
}
