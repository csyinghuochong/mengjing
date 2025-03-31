namespace ET.Server
{
    
    [MessageHandler(SceneType.Activity)]
    public class C2A_CommonSeasonBossInfoHandler : MessageHandler<Scene,C2A_CommonSeasonBossInfoRequest,  A2C_CommonSeasonBossInfoResponse>
    {
        protected override async ETTask Run(Scene scene, C2A_CommonSeasonBossInfoRequest request, A2C_CommonSeasonBossInfoResponse response)
        {
            ActivitySceneComponent activitySceneComponent = scene.GetComponent<ActivitySceneComponent>();
            DBDayActivityInfo dbDayActivityInfo = activitySceneComponent.DBDayActivityInfo;

            response.CommonSeasonBossExp = dbDayActivityInfo.CommonSeasonBossExp;
            response.CommonSeasonBossLevel = dbDayActivityInfo.CommonSeasonBossLevel;

            await ETTask.CompletedTask;
        }
    }
}
