namespace ET.Server
{

    [MessageHandler(SceneType.Rank)]
    public class C2R_RankPetListHandler : MessageHandler<Scene, C2R_RankPetListRequest, R2C_RankPetListResponse>
    {
        protected override async ETTask Run(Scene scene, C2R_RankPetListRequest request, R2C_RankPetListResponse response)
        {
            RankSceneComponent rankComponent = scene.GetComponent<RankSceneComponent>();
            response.RankNumber = rankComponent.GetPetRank(request.UserId);
            response.RankPetList.AddRange(rankComponent.GetRankPetList((int)response.RankNumber));

            await ETTask.CompletedTask;
        }
    }

}
