namespace ET.Server
{
    [MessageHandler(SceneType.Rank)]
    public class C2R_CampRankListHandler : MessageHandler<Scene, C2R_CampRankListRequest, R2C_CampRankListResponse>
    {
        protected override async ETTask Run(Scene scene, C2R_CampRankListRequest request, R2C_CampRankListResponse response)
        {
            RankSceneComponent rankComponent = scene.GetComponent<RankSceneComponent>();
            response.RankList_1 .AddRange(rankComponent.DBRankInfo.rankingCamp1); 
            response.RankList_2 .AddRange(rankComponent.DBRankInfo.rankingCamp2); 
            await ETTask.CompletedTask;
        }
    }
}
