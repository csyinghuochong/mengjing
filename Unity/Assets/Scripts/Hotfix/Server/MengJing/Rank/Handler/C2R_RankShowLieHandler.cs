namespace ET.Server
{

    [MessageHandler(SceneType.Rank)]
    public class C2R_RankShowLieHandler : MessageHandler<Scene, C2R_RankShowLieRequest, R2C_RankShowLieResponse>
    {
        protected override async ETTask Run(Scene scene, C2R_RankShowLieRequest request, R2C_RankShowLieResponse response)
        {
            response.RankList .AddRange(scene.GetComponent<RankSceneComponent>().DBRankInfo.rankShowLie); 
            await ETTask.CompletedTask;
        }
    }
}
