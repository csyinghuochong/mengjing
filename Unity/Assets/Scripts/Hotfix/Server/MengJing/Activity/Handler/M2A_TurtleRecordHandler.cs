using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Activity)]
    [FriendOf(typeof(ActivitySceneComponent))]
    public class M2A_TurtleRecordHandler : MessageHandler<Scene, M2A_TurtleRecordRequest, A2M_TurtleRecordResponse>
    {
        protected override async ETTask Run(Scene scene, M2A_TurtleRecordRequest request, A2M_TurtleRecordResponse response)
        {
            ActivitySceneComponent activitySceneComponent= scene.GetComponent<ActivitySceneComponent>();
            DBDayActivityInfo dBDayActivityInfo = activitySceneComponent.DBDayActivityInfo;
            if (dBDayActivityInfo.TurtleWinTimes.Count < 3)
            {
                dBDayActivityInfo.TurtleWinTimes = new List<int> { 0, 0, 0 };
            }

            for (int i = 0; i < ConfigData.TurtleList.Count; i++)
            {
                List<KeyValuePair<long, long>> playerids = null;
                activitySceneComponent.TurtleSupportList.TryGetValue(ConfigData.TurtleList[i], out playerids);
                if (playerids != null)
                {
                    for (int p = 0; p < playerids.Count; p++)
                    {
                        if (playerids[p].Key == request.AccountId)
                        {
                            response.SupportId = ConfigData.TurtleList[i];
                        }
                    }
                    response.SupportTimes.Add(playerids.Count);
                }
                else
                {
                    response.SupportTimes.Add(0);
                }
            }

            response.WinTimes = dBDayActivityInfo.TurtleWinTimes;
            await ETTask.CompletedTask;
        }
    }
}
