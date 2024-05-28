using System;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_ActivityInfoHandler : MessageLocationHandler<Unit, C2M_ActivityInfoRequest, M2C_ActivityInfoResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_ActivityInfoRequest request, M2C_ActivityInfoResponse response)
        {
            ActivityComponentS activityComponent = unit.GetComponent<ActivityComponentS>();
            if (activityComponent.TotalSignNumber == 0)
            {
                for (int i = activityComponent.ActivityReceiveIds.Count - 1; i >= 0; i--)
                {
                    ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(activityComponent.ActivityReceiveIds[i]);
                    if (activityConfig.ActivityType == 23)
                    {
                        activityComponent.ActivityReceiveIds.RemoveAt(i);
                    }
                }
            }
            response.ReceiveIds = activityComponent.ActivityReceiveIds;
            response.LastSignTime = activityComponent.LastSignTime;
            response.TotalSignNumber = activityComponent.TotalSignNumber;
            response.QuTokenRecvive = activityComponent.QuTokenRecvive;
            response.LastLoginTime = activityComponent.LastLoginTime;
            response.DayTeHui = activityComponent.DayTeHui;

            ActivityV1Info activityV1Info = activityComponent.ActivityV1Info;
            activityV1Info.ChouKaDropId = unit.Scene().GetComponent<ServerInfoComponent>().ServerInfo.ChouKaDropId;
            activityV1Info.GuessIds.Clear();

            ActorId activitySceneid = UnitCacheHelper.GetActivityServerId(  unit.Zone() );
            A2M_ActivitySelfInfo r_GameStatusResponse = (A2M_ActivitySelfInfo)await unit.Root().GetComponent<MessageSender>().Call
                   (activitySceneid, new M2A_ActivitySelfInfo()
                   {
                        UnitId = unit.Id,   
                   });
            activityV1Info.GuessIds = r_GameStatusResponse.GuessIds;
            activityV1Info.LastGuessReward = r_GameStatusResponse.LastGuessReward;
            activityV1Info.BaoShiDu = r_GameStatusResponse.BaoShiDu;
            activityV1Info.OpenGuessIds = r_GameStatusResponse.OpenGuessIds;
            response.ActivityV1Info = activityV1Info;

            await ETTask.CompletedTask;
        }
    }
}
