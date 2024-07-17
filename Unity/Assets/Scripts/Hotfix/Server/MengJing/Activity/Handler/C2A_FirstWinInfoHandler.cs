using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Activity)]
    [FriendOf(typeof(ActivitySceneComponent))]
    [FriendOf(typeof(DBDayActivityInfo))]
    public class C2A_FirstWinInfoHandler : MessageHandler<Scene, C2A_FirstWinInfoRequest, A2C_FirstWinInfoResponse>
    {
        protected override async ETTask Run(Scene scene, C2A_FirstWinInfoRequest request, A2C_FirstWinInfoResponse response)
        {
            List<FirstWinInfo> FirstWinInfos  = scene.GetComponent<ActivitySceneComponent>().DBDayActivityInfo.FirstWinInfos;
            response.FirstWinInfos .AddRange(FirstWinInfos);
            await ETTask.CompletedTask;
        }
    }
}
