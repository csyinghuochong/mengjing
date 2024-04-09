using System;

namespace ET.Server
{

    [MessageHandler(SceneType.Activity)]
    [FriendOf(typeof(ActivityServerComponent))]
    public class M2A_ZhanQuInfoHandler : MessageHandler<Scene, M2A_ZhanQuInfoRequest, A2M_ZhanQuInfoResponse>
    {
        protected override async ETTask Run(Scene scene, M2A_ZhanQuInfoRequest request, A2M_ZhanQuInfoResponse response)
        {
            DBDayActivityInfo dBDayActivityInfo = scene.GetComponent<ActivityServerComponent>().DBDayActivityInfo;

            response.ReceiveNum= dBDayActivityInfo.ZhanQuReveives;

            await ETTask.CompletedTask;
        }

    }
}
