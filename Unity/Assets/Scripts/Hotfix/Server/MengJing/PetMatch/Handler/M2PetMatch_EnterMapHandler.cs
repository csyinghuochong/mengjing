namespace ET.Server
{
    [MessageHandler(SceneType.PetMatch)]
    public class M2PetMatch_EnterMapHandler : MessageHandler<Scene, M2PetMatch_EnterMapRequest, PetMatch2M_EnterMapResponse>
    {
        protected override async ETTask Run(Scene scene, M2PetMatch_EnterMapRequest request, PetMatch2M_EnterMapResponse response)
        {
            Scene soloscene =  scene.GetComponent<PetMatchSceneComponent>().GetChild<Scene>(request.FubenId);
            if (soloscene == null)
            {
                response.Error = ErrorCode.ERR_AlreadyFinish;
                return;
            }
            if (soloscene.GetComponent<PetMeleeDungeonComponent>().IsGameOver())
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
