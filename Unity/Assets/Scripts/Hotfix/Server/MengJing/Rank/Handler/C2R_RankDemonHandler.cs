namespace ET.Server
{
    [MessageHandler(SceneType.Rank)]
    public class C2R_RankDemonHandler : MessageHandler<Scene, C2R_RankDemonRequest, R2C_RankDemonResponse>
    {
        protected override async ETTask Run(Scene scene, C2R_RankDemonRequest request, R2C_RankDemonResponse response)
        {
            RankSceneComponent rankComponent = scene.GetComponent<RankSceneComponent>();
            response.RankList .AddRange( rankComponent.DBRankInfo.rankingDemon);

            await ETTask.CompletedTask;
        }
    }
}
