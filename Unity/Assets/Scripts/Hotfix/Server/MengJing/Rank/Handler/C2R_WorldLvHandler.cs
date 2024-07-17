namespace ET.Server
{

    [MessageHandler(SceneType.Rank)]
    public class C2R_WorldLvHandler : MessageHandler<Scene, C2R_WorldLvRequest, R2C_WorldLvResponse>
    {
        protected override async ETTask Run(Scene scene, C2R_WorldLvRequest request, R2C_WorldLvResponse response)
        {
            RankSceneComponent rankComponent = scene.GetComponent<RankSceneComponent>();
            response.ServerInfo = rankComponent.DBServerInfo.ServerInfo;
            await ETTask.CompletedTask;
        }
    }
}
