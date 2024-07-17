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
           
            ActivityV1Info activityV1Info = activityComponent.ActivityV1Info;
            activityV1Info.ChouKaDropId = unit.Scene().GetComponent<ServerInfoComponent>().ServerInfo.ChouKaDropId;
            activityV1Info.GuessIds.Clear();

            ActorId activitySceneid = UnitCacheHelper.GetActivityServerId(  unit.Zone() );

            M2A_ActivitySelfInfo M2A_ActivitySelfInfo = M2A_ActivitySelfInfo.Create();
            M2A_ActivitySelfInfo.UnitId = unit.Id;
            A2M_ActivitySelfInfo r_GameStatusResponse = (A2M_ActivitySelfInfo)await unit.Root().GetComponent<MessageSender>().Call
                   (activitySceneid, M2A_ActivitySelfInfo);
            activityV1Info.GuessIds = r_GameStatusResponse.GuessIds;
            activityV1Info.LastGuessReward = r_GameStatusResponse.LastGuessReward;
            activityV1Info.BaoShiDu = r_GameStatusResponse.BaoShiDu;
            activityV1Info.OpenGuessIds = r_GameStatusResponse.OpenGuessIds;
            
            response.ReceiveIds .AddRange(activityComponent.ActivityReceiveIds); 
            response.LastSignTime = activityComponent.LastSignTime;
            response.TotalSignNumber = activityComponent.TotalSignNumber;
            response.QuTokenRecvive .AddRange(activityComponent.QuTokenRecvive); 
            response.LastLoginTime = activityComponent.LastLoginTime;
            response.DayTeHui .AddRange(activityComponent.DayTeHui); 

            response.ActivityV1Info = activityV1Info;

            await ETTask.CompletedTask;
        }
    }
}
