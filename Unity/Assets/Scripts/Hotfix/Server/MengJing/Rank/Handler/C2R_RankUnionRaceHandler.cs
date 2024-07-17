namespace ET.Server
{
    [MessageHandler( SceneType.Rank)]
    public class C2R_RankUnionRaceHandler : MessageHandler<Scene, C2R_RankUnionRaceRequest, R2C_RankUnionRaceResponse>
    {
        protected override async ETTask Run(Scene scene, C2R_RankUnionRaceRequest request, R2C_RankUnionRaceResponse response)
        {
            response.RankList .AddRange(scene.GetComponent<RankSceneComponent>().DBRankInfo.rankUnionRace); 
            await ETTask.CompletedTask;
        }
    }
}
