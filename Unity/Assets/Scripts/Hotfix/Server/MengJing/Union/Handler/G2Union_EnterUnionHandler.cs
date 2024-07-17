namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class G2Union_EnterUnionHandler : MessageHandler<Scene, G2Union_EnterUnion, Union2G_EnterUnion>
    {
        protected override async ETTask Run(Scene scene, G2Union_EnterUnion request, Union2G_EnterUnion response)
        {
            UnionSceneComponent rankSceneComponent = scene.GetComponent<UnionSceneComponent>();
            response.DonationRankId = rankSceneComponent.GetDonationRank(request.UnitId);
            response.WinUnionId = rankSceneComponent.DBUnionManager.WinUnionId;

            await ETTask.CompletedTask;
        }
    }
}
