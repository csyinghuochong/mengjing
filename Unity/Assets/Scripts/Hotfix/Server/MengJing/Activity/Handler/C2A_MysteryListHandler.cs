using System;

namespace ET.Server
{

    [MessageHandler(SceneType.Activity)]
    [FriendOf(typeof(ActivitySceneComponent))]
    [FriendOf(typeof(DBDayActivityInfo))]
    public class C2A_MysteryListHandler : MessageHandler<Scene, C2A_MysteryListRequest, A2C_MysteryListResponse>
    {
        protected override async ETTask Run(Scene scene, C2A_MysteryListRequest request, A2C_MysteryListResponse response)
        {
            ActivitySceneComponent activitySceneComponent = scene.GetComponent<ActivitySceneComponent>();
            if (activitySceneComponent.DBDayActivityInfo.MysteryItemInfos.Count == 0)
            {
                Log.Debug($"神秘商店为空: {scene.Zone()}");
                int openServerDay = ServerHelper.GetServeOpenrDay(scene.Zone());
                activitySceneComponent.DBDayActivityInfo.MysteryItemInfos = MysteryShopHelper.InitMysteryItemInfos(openServerDay);
            }
            response.MysteryItemInfos = activitySceneComponent.DBDayActivityInfo.MysteryItemInfos;
            await ETTask.CompletedTask;
        }
    }
}
