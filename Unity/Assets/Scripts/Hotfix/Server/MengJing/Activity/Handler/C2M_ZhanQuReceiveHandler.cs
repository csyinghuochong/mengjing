﻿using System;

namespace ET
{

    [ActorMessageHandler]
    public class C2M_ZhanQuReceiveHandler : AMActorLocationRpcHandler<Unit, C2M_ZhanQuReceiveRequest, M2C_ZhanQuReceiveResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_ZhanQuReceiveRequest request, M2C_ZhanQuReceiveResponse response, Action reply)
        {
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.Received, unit.Id))
            {
                ActivityComponent activityComponent = unit.GetComponent<ActivityComponent>();
                if (activityComponent.ZhanQuReceiveIds.Contains(request.ActivityId))
                {
                    response.Error = ErrorCode.ERR_AlreadyReceived;
                    reply();
                    return;
                }
                if (!ActivityConfigCategory.Instance.Contain(request.ActivityId))
                {
                    Log.Error($"C2M_ZhanQuReceiveRequest 1");
                    response.Error = ErrorCode.ERR_ModifyData;
                    reply();
                    return;
                }

                ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(request.ActivityId);
                UserInfo userInfo = unit.GetComponent<UserInfoComponent>().UserInfo;

                if (request.ActivityType != activityConfig.ActivityType)
                {
                    reply();
                    return;
                }
                if (request.ActivityType == 21 && userInfo.Lv <int.Parse(activityConfig.Par_1))
                {
                    reply();
                    return;
                }
                if (request.ActivityType == 22 && userInfo.Combat < int.Parse(activityConfig.Par_1))
                {
                    reply();
                    return;
                }

                LogHelper.LogDebug($"C2M_ZhanQuReceive:  {unit.Id} {request.ActivityId} {TimeHelper.ServerNow().ToString()}");
                switch (request.ActivityType)
                {
                    case 21:    //战区等级
                    case 22:    //战区战力
                        string[] itemlist = activityConfig.Par_3.Split('@');
                        if (unit.GetComponent<BagComponent>().GetBagLeftCell() < itemlist.Length)
                        {
                            response.Error = ErrorCode.ERR_BagIsFull;
                            reply();
                            return;
                        }   

                        long paimaiServerId = StartSceneConfigCategory.Instance.GetBySceneName(unit.DomainZone(), Enum.GetName(SceneType.Activity)).InstanceId;
                        A2M_ZhanQuReceiveResponse r_GameStatusResponse = (A2M_ZhanQuReceiveResponse)await ActorMessageSenderComponent.Instance.Call
                            (paimaiServerId, new M2A_ZhanQuReceiveRequest()
                            {
                                ActivityId = request.ActivityId,
                                ActivityType = request.ActivityType,
                                UnitId = unit.Id,   
                            });
                        if (r_GameStatusResponse.Error != ErrorCode.ERR_Success)
                        {
                            response.Error = ErrorCode.ERR_AlreadyReceived;
                            reply();
                            return;
                        }

                        activityComponent.ZhanQuReceiveIds.Add(request.ActivityId);
                        unit.GetComponent<BagComponent>().OnAddItemData(activityConfig.Par_3, $"{ItemGetWay.Activity_ZhanQu}_{TimeHelper.ServerNow()}");
                        break;
                    default:
                        break;
                }
                reply();
                await ETTask.CompletedTask;
            }
        }
    }
}
