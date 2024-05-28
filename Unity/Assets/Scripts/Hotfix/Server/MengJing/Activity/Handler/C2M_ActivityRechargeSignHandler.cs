﻿using System;
using System.Collections.Generic;


namespace ET
{

    [ActorMessageHandler]
    public class C2M_ActivityRechargeSignHandler : AMActorLocationRpcHandler<Unit, C2M_ActivityRechargeSignRequest, M2C_ActivityRechargeSignResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ActivityRechargeSignRequest request, M2C_ActivityRechargeSignResponse response, Action reply)
        {
            if (!ActivityConfigCategory.Instance.Contain(request.ActivityId))
            {
                Log.Warning($"C2M_ActivityRechargeError {unit.Id} {request.ActivityId}");
                reply();
                return;
            }

            ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(request.ActivityId);
            int itemNumber = ItemHelper.GetNeedCell(activityConfig.Par_2);
            BagComponent bagComponent = unit.GetComponent<BagComponent>();
            if (bagComponent.GetBagLeftCell() < itemNumber)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                reply();
                return;
            }

            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            if (numericComponent.GetAsInt(NumericType.RechargeSign) != 1)
            {
                response.Error = ErrorCode.ERR_TaskCanNotGet;
                reply();
                return;
            }

            LogHelper.LogDebug($"充值签到成功1：{unit.Id} { bagComponent.GetItemNumber(10010043)}");
            numericComponent.ApplyValue(NumericType.RechargeSign, 2);
            unit.GetComponent<BagComponent>().OnAddItemData(activityConfig.Par_2, $"{ItemGetWay.Activity}_{TimeHelper.ServerNow()}");
            LogHelper.LogDebug($"充值签到成功2：{unit.Id} { bagComponent.GetItemNumber(10010043)}");
    
            reply();
            await ETTask.CompletedTask;
        }
    }
}
