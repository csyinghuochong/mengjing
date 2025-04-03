using System.Collections.Generic;

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
                int openServerDay = ServerHelper.GetServeOpenDay(scene.Zone());
                activitySceneComponent.DBDayActivityInfo.MysteryItemInfos = MysteryShopHelper.InitMysteryItemInfos(openServerDay);
            }
            
            List<MysteryItemInfo> MysteryItemInfos   = activitySceneComponent.DBDayActivityInfo.MysteryItemInfos;
            response.MysteryItemInfos .AddRange(MysteryItemInfos);
            await ETTask.CompletedTask;
        }
    }
}
