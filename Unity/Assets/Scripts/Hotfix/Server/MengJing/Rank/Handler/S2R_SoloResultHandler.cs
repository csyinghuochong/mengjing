namespace ET.Server
{

    /// <summary>
    /// 竞技场只记录第一名
    /// </summary>
    [MessageHandler(SceneType.Rank)]
    public class S2R_SoloResultHandler : MessageHandler<Scene, S2R_SoloResultRequest, R2S_SoloResultResponse>
    {
        protected override async ETTask Run(Scene scene, S2R_SoloResultRequest request, R2S_SoloResultResponse response )
        {
            DBRankInfo dBRankInfo = scene.GetComponent<RankSceneComponent>().DBRankInfo;
            dBRankInfo.rankSoloInfo.Clear();
            dBRankInfo.rankSoloInfo.Add(request.RankingInfo);
            await ETTask.CompletedTask;
        }
    }
}
