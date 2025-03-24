using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Rank)]
    public class C2R_RankListHandler : MessageHandler<Scene, C2R_RankListRequest, R2C_RankListResponse>
    {
        protected override async ETTask Run(Scene scene, C2R_RankListRequest request, R2C_RankListResponse response)
        {
            RankSceneComponent rankComponent = scene.GetComponent<RankSceneComponent>();

            List<RankingInfo> all = rankComponent.DBRankInfo.rankingCombats;
            List<RankingInfo> list = all.GetRange(0, all.Count > CommonHelp.RankNumber ? CommonHelp.RankNumber : all.Count);

            response.RankList .AddRange(list); 

            await ETTask.CompletedTask;
        }
    }
}
