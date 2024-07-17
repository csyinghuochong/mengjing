namespace ET.Server
{
    [MessageHandler(SceneType.Solo)]
    public class M2S_SoloEnterHandler : MessageHandler<Scene, M2S_SoloEnterRequest, S2M_SoloEnterResponse>
    {
        protected override async ETTask Run(Scene scene, M2S_SoloEnterRequest request, S2M_SoloEnterResponse response)
        {
            Scene soloscene =  scene.GetComponent<SoloSceneComponent>().GetChild<Scene>(request.FubenId);
            if (soloscene == null)
            {
                response.Error = ErrorCode.ERR_AlreadyFinish;
                return;
            }
            if (soloscene.GetComponent<SoloDungeonComponent>().SendReward)
            {
                response.Error = ErrorCode.ERR_AlreadyFinish;
                return;
            }

            response.FubenInstanceId = soloscene.InstanceId;
            response.FubenActorId = soloscene.GetActorId();
            await ETTask.CompletedTask;
        }
    }
}
