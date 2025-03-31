namespace ET.Server
{
    
    [MessageHandler(SceneType.Activity)]
    public class C2A_ActivityInfoHandler : MessageHandler<Scene,C2A_ActivityInfoRequest,  A2C_ActivityInfoResponse>
    {
        protected override async ETTask Run(Scene scene, C2A_ActivityInfoRequest request, A2C_ActivityInfoResponse response)
        {
            ActivitySceneComponent activitySceneComponent = scene.GetComponent<ActivitySceneComponent>();
            //activitySceneComponent.DBDayActivityInfo

            await ETTask.CompletedTask;
        }
    }
}
