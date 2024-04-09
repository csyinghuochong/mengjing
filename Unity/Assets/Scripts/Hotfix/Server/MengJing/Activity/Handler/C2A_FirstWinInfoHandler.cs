using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Activity)]
    [FriendOf(typeof(ActivityServerComponent))]
    [FriendOf(typeof(DBDayActivityInfo))]
    public class C2A_FirstWinInfoHandler : MessageHandler<Scene, C2A_FirstWinInfoRequest, A2C_FirstWinInfoResponse>
    {
        protected override async ETTask Run(Scene scene, C2A_FirstWinInfoRequest request, A2C_FirstWinInfoResponse response)
        {
            response.FirstWinInfos = scene.GetComponent<ActivityServerComponent>().DBDayActivityInfo.FirstWinInfos;
            await ETTask.CompletedTask;
        }
    }
}
