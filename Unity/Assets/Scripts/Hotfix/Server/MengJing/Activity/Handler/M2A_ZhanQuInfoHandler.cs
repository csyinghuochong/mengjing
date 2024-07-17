namespace ET.Server
{

    [MessageHandler(SceneType.Activity)]
    [FriendOf(typeof(ActivitySceneComponent))]
    public class M2A_ZhanQuInfoHandler : MessageHandler<Scene, M2A_ZhanQuInfoRequest, A2M_ZhanQuInfoResponse>
    {
        protected override async ETTask Run(Scene scene, M2A_ZhanQuInfoRequest request, A2M_ZhanQuInfoResponse response)
        {
            DBDayActivityInfo dBDayActivityInfo = scene.GetComponent<ActivitySceneComponent>().DBDayActivityInfo;

            response.ReceiveNum .AddRange(dBDayActivityInfo.ZhanQuReveives); 

            await ETTask.CompletedTask;
        }

    }
}
