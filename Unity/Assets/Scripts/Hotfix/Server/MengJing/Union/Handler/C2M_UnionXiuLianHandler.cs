﻿using System;
using System.Collections.Generic;

namespace ET
{
    [ActorMessageHandler]
    public class C2M_UnionXiuLianHandler : AMActorLocationRpcHandler<Unit, C2M_UnionXiuLianRequest, M2C_UnionXiuLianResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_UnionXiuLianRequest request, M2C_UnionXiuLianResponse response, Action reply)
        {
            int numerType = UnionHelper.GetXiuLianId(request.Position, request.Type);
            if (numerType == 0)
            {
                reply();
                return;
            }

            long unionid = unit.GetComponent<NumericComponent>().GetAsLong(NumericType.UnionId_0);
            if (unionid == 0)
            {
                return;
            }

            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            int xiulianid = numericComponent.GetAsInt(numerType);

            int position = request.Position;
            if (request.Type == 1)
            {
                position += 4;
            }

            if (xiulianid >= UnionQiangHuaConfigCategory.Instance.GetMaxId(position))
            {
                response.Error = ErrorCode.ERR_UnionXiuLianMax;
                reply();
                return;
            }

            UnionQiangHuaConfig unionQiangHuaConfig = UnionQiangHuaConfigCategory.Instance.Get(xiulianid);
            if (unit.GetComponent<UserInfoComponent>().UserInfo.UnionZiJin < unionQiangHuaConfig.CostGold)
            {
                response.Error = ErrorCode.ERR_HouBiNotEnough;
                reply();
                return;
            }
            
            if (!unit.GetComponent<BagComponent>().OnCostItemData(unionQiangHuaConfig.CostItem))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                reply();
                return;
            }


            long selfgold = unit.GetComponent<UserInfoComponent>().UserInfo.Gold;
            U2M_UnionOperationResponse responseUnionEnter = (U2M_UnionOperationResponse)await ActorMessageSenderComponent.Instance.Call(
                       DBHelper.GetUnionServerId(unit.DomainZone()),
                       new M2U_UnionOperationRequest() { OperateType = 3, UnitId = unit.Id, UnionId = unionid, Par = selfgold.ToString() });
            int unionLevel = int.Parse(responseUnionEnter.Par);
            UnionConfig unionConfig = UnionConfigCategory.Instance.Get(unionLevel);

            //Console.WriteLine($"unionConfig:  {unionLevel}  {unionConfig.XiuLianLevel} {unionQiangHuaConfig.QiangHuaLv}");
            if (unionQiangHuaConfig.QiangHuaLv >= unionConfig.XiuLianLevel)
            {
                reply();
                return; 
            }

            unit.GetComponent<NumericComponent>().ApplyValue( numerType, xiulianid+1);
            unit.GetComponent<UserInfoComponent>().UpdateRoleMoneySub( UserDataType.UnionContri,(unionQiangHuaConfig.CostGold * -1).ToString(), true, ItemGetWay.UnionXiuLian);

            //刷新角色属性
            Function_Fight.GetInstance().UnitUpdateProperty_Base(unit,true,true);
            PetComponent petComponent = unit.GetComponent<PetComponent>();  
            for (int i = petComponent.RolePetInfos.Count - 1; i >= 0; i--)
            {
                petComponent.UpdatePetAttribute(petComponent.RolePetInfos[i], false);
            }

            reply();
            await ETTask.CompletedTask;
        }
    }
}
