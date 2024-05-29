﻿using System;
using System.Collections.Generic;

namespace ET
{
    [ActorMessageHandler]
    public class C2M_WelfareDrawRewardHandler : AMActorLocationRpcHandler<Unit, C2M_WelfareDrawRewardRequest, M2C_WelfareDrawRewardResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_WelfareDrawRewardRequest request, M2C_WelfareDrawRewardResponse response, Action reply)
        {
            if (unit.GetComponent<NumericComponent>().GetAsInt(NumericType.DrawReward) == 1)
            {
                Log.Error($"C2M_WelfareDrawRewardRequest 1");
                response.Error = ErrorCode.ERR_ModifyData;
                reply();
                return;
            }
            
            int index = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.DrawIndex);
            if (index == 0 || index > ConfigHelper.WelfareDrawList.Count)
            {
                reply();
                return;
            }


            string reward = ConfigHelper.WelfareDrawList[index - 1].Value;
            if (index == 7)
            { 
                UserInfoComponent userInfoComponent = unit.GetComponent<UserInfoComponent>();
                int weaponId = ComHelp.GetWelfareWeapon( userInfoComponent.UserInfo.Occ, userInfoComponent.UserInfo.OccTwo );
                reward = $"{weaponId};1";
            }

            unit.GetComponent<BagComponent>().OnAddItemData(  reward, $"{ItemGetWay.Welfare}_{TimeHelper.ServerNow()}");
            unit.GetComponent<NumericComponent>().ApplyValue(NumericType.DrawReward, 1);

            reply();
            await ETTask.CompletedTask;
        }
    }
}
