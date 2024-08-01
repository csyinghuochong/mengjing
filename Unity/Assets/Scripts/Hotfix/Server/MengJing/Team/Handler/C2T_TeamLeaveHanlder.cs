namespace ET.Server
{

    [MessageHandler(SceneType.Team)]
    public class C2T_TeamLeaveHanlder : MessageHandler<Scene, C2T_TeamLeaveRequest, T2C_TeamLeaveResponse>
    {
        protected override async ETTask Run(Scene scene, C2T_TeamLeaveRequest request, T2C_TeamLeaveResponse response)
        {
            scene.GetComponent<TeamSceneComponent>().OnRecvUnitLeave(request.UserId);
            await ETTask.CompletedTask;
        }
    }
}
