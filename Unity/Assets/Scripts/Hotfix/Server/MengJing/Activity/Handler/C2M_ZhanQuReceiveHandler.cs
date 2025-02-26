namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_ZhanQuReceiveHandler : MessageLocationHandler<Unit, C2M_ZhanQuReceiveRequest, M2C_ZhanQuReceiveResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_ZhanQuReceiveRequest request, M2C_ZhanQuReceiveResponse response)
        {
            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Received, unit.Id))
            {
                ActivityComponentS activityComponent = unit.GetComponent<ActivityComponentS>();
                if (activityComponent.ZhanQuReceiveIds.Contains(request.ActivityId))
                {
                    response.Error = ErrorCode.ERR_AlreadyReceived;
                    return;
                }
                if (!ActivityConfigCategory.Instance.Contain(request.ActivityId))
                {
                    Log.Error($"C2M_ZhanQuReceiveRequest 1");
                    response.Error = ErrorCode.ERR_ModifyData;
                    return;
                }

                ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(request.ActivityId);
                UserInfo userInfo = unit.GetComponent<UserInfoComponentS>().UserInfo;

                if (request.ActivityType != activityConfig.ActivityType)
                {
                    return;
                }
                if (request.ActivityType == (int)ActivityEnum.Type_21 && userInfo.Lv <int.Parse(activityConfig.Par_1))
                {
                    return;
                }
                if (request.ActivityType == (int)ActivityEnum.Type_22 && userInfo.Combat < int.Parse(activityConfig.Par_1))
                {
                    return;
                }

                ServerLogHelper.LogDebug($"C2M_ZhanQuReceive:  {unit.Id} {request.ActivityId} {TimeHelper.ServerNow().ToString()}");
                switch (request.ActivityType)
                {
                    case 21:    //战区等级
                    case 22:    //战区战力
                        string[] itemlist = activityConfig.Par_3.Split('@');
                        if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < itemlist.Length)
                        {
                            response.Error = ErrorCode.ERR_BagIsFull;
                            return;
                        }

                      
                        ActorId paimaiServerId =   UnitCacheHelper.GetActivityServerId(unit.Zone());
                        M2A_ZhanQuReceiveRequest M2A_ZhanQuReceiveRequest = M2A_ZhanQuReceiveRequest.Create();
                        M2A_ZhanQuReceiveRequest.ActivityId = request.ActivityId;
                        M2A_ZhanQuReceiveRequest.ActivityType = request.ActivityType;
                        M2A_ZhanQuReceiveRequest.UnitId = unit.Id;
                        A2M_ZhanQuReceiveResponse r_GameStatusResponse = (A2M_ZhanQuReceiveResponse)await unit.Root().GetComponent<MessageSender>().Call
                            (paimaiServerId, M2A_ZhanQuReceiveRequest);
                        if (r_GameStatusResponse.Error != ErrorCode.ERR_Success)
                        {
                            response.Error = ErrorCode.ERR_AlreadyReceived;

                            return;
                        }

                        activityComponent.ZhanQuReceiveIds.Add(request.ActivityId);
                        unit.GetComponent<BagComponentS>().OnAddItemData(activityConfig.Par_3, $"{ItemGetWay.Activity_ZhanQu}_{TimeHelper.ServerNow()}");
                        break;
                    default:
                        break;
                }
                await ETTask.CompletedTask;
            }
        }
    }
}
