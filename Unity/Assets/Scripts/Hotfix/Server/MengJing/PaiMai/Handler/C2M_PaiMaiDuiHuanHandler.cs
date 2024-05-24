﻿using System;

namespace ET
{

    [ActorMessageHandler]
    public class C2M_PaiMaiDuiHuanHandler : AMActorLocationRpcHandler<Unit, C2M_PaiMaiDuiHuanRequest, M2C_PaiMaiDuiHuanResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_PaiMaiDuiHuanRequest request, M2C_PaiMaiDuiHuanResponse response, Action reply)
        {
            long dbCacheId = DBHelper.GetRankServerId(unit.DomainZone());
            R2M_DBServerInfoResponse d2GGetUnit = (R2M_DBServerInfoResponse)await ActorMessageSenderComponent.Instance.Call(dbCacheId, new M2R_DBServerInfoRequest() { });
            long diamond = request.DiamondsNumber;
            if (request.DiamondsNumber <= 0)
            {
                reply();
                return;
            }

            if (unit.GetComponent<NumericComponent>().GetAsInt(NumericType.RechargeNumber) <= 0)
            {
                reply();
                return;
            }

            //服务器限制,单次最多兑换100000钻石
            if (request.DiamondsNumber > 100000)
            {
                reply();
                return;
            }
       
            //判断钻石是否足够
            if (unit.GetComponent<UserInfoComponent>().UserInfo.Diamond >= diamond)
            {
                unit.GetComponent<UserInfoComponent>().UpdateRoleMoneySub(UserDataType.Diamond, (diamond * -1).ToString(), true, ItemGetWay.DuiHuan);
                unit.GetComponent<UserInfoComponent>().UpdateRoleMoneyAdd(UserDataType.Gold, (diamond * d2GGetUnit.ServerInfo.ExChangeGold).ToString(), true, ItemGetWay.DuiHuan);
                unit.GetComponent<UserInfoComponent>().UpdateRoleMoneyAdd(UserDataType.WeiJingGold,( (int)(diamond / 100) ).ToString(), true, ItemGetWay.DuiHuan);
                unit.GetComponent<TaskComponent>().TriggerTaskEvent(TaskTargetType.DuiHuanGold_15, 0, (int)(diamond / 100));
                unit.GetComponent<TaskComponent>().TriggerTaskCountryEvent(TaskTargetType.DuiHuanGold_15, 0, (int)(diamond / 100));
            }
            else 
            {
                response.Error = ErrorCode.ERR_DiamondNotEnoughError;
            }

            reply();
            await ETTask.CompletedTask;
        }
    }
}
