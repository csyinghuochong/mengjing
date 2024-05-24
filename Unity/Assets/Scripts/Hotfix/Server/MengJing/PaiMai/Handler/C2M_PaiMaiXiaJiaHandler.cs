﻿using System;
using System.Collections.Generic;

namespace ET
{

    [ActorMessageHandler]
    public class C2M_PaiMaiXiaJiaHandler : AMActorLocationRpcHandler<Unit, C2M_PaiMaiXiaJiaRequest, M2C_PaiMaiXiaJiaResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PaiMaiXiaJiaRequest request, M2C_PaiMaiXiaJiaResponse response, Action reply)
        {
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.XiaJia, unit.Id))
            {
                if (unit.GetComponent<BagComponent>().GetBagLeftCell() < 1)
                {
                    reply();
                    return;
                }

                long chargeServerId = StartSceneConfigCategory.Instance.GetBySceneName(unit.DomainZone(), Enum.GetName(SceneType.PaiMai)).InstanceId;
                P2M_PaiMaiXiaJiaResponse r_GameStatusResponse = (P2M_PaiMaiXiaJiaResponse)await ActorMessageSenderComponent.Instance.Call
                    (chargeServerId, new M2P_PaiMaiXiaJiaRequest()
                    {
                        ItemType = request.ItemType,    
                        PaiMaiItemInfoId = request.PaiMaiItemInfoId
                    });

                if (r_GameStatusResponse.Error == ErrorCode.ERR_Success && r_GameStatusResponse.PaiMaiItemInfo != null)
                {
                    unit.GetComponent<BagComponent>().OnAddItemData(r_GameStatusResponse.PaiMaiItemInfo.BagInfo, $"{ItemGetWay.XiaJia}_{TimeHelper.ServerNow()}");
                }
                else
                {
                    LogHelper.LogWarning($"C2M_PaiMaiXiaJiaHandler==null  {unit.Id} {request.PaiMaiItemInfoId}");
                }

                reply();
                await ETTask.CompletedTask;
            }
        }
    }
}
