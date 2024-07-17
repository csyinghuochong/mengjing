namespace ET.Server
{
    [MessageHandler(SceneType.Rank)]
    public class C2R_RankRunRaceHandler : MessageHandler<Scene, C2R_RankRunRaceRequest, R2C_RankRunRaceResponse>
    {
        protected override async ETTask Run(Scene scene, C2R_RankRunRaceRequest request, R2C_RankRunRaceResponse response)
        {
            RankSceneComponent rankComponent = scene.GetComponent<RankSceneComponent>();
            response.RankList .AddRange(rankComponent.DBRankInfo.rankRunRace); 
            
            await ETTask.CompletedTask;
        }
    }
}
