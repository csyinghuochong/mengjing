namespace ET.Server
{

    [MessageHandler(SceneType.PetMatch)]
    public class C2PetMatch_RankListHandler : MessageHandler<Scene, C2PetMatch_RankListRequest, PetMatch2C_RankListResponse>
    {
        protected override async ETTask Run(Scene scene, C2PetMatch_RankListRequest request, PetMatch2C_RankListResponse response)
        {
            PetMatchSceneComponent soloSceneComponent = scene.GetComponent<PetMatchSceneComponent>();

            response.PetMatchPlayerInfoList = soloSceneComponent.GetSoloResult();

            await ETTask.CompletedTask;
        }
    }
}
