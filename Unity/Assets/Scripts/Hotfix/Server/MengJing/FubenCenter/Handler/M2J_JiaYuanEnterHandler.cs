namespace ET.Server
{
    [MessageHandler(SceneType.FubenCenter)]
    public class M2J_JiaYuanEnterHandler : MessageHandler<Scene, M2F_JiaYuanEnterRequest, F2M_JiaYuanEnterResponse>
    {
        protected override async ETTask Run(Scene scene, M2F_JiaYuanEnterRequest request, F2M_JiaYuanEnterResponse response)
        {
            response.FubenActorId = await scene.GetComponent<FubenCenterComponent>().GetJiaYuanFubenId(request.MasterId, request.UnitId);
            response.Error = ErrorCode.ERR_Success;
        }
    }
}
