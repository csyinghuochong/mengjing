namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_UnionKeJiQuickHandler : MessageLocationHandler<Unit, C2M_UnionKeJiQuickRequest, M2C_UnionKeJiQuickResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_UnionKeJiQuickRequest request, M2C_UnionKeJiQuickResponse response)
        {
            DBUnionInfo dBUnionInfo = await UnitCacheHelper.GetComponent<DBUnionInfo>(unit.Root(), request.UnionId);
            if (dBUnionInfo == null)
            {
                response.Error = ErrorCode.ERR_Union_Not_Exist;
                return;
            }
            if (dBUnionInfo.UnionInfo.KeJiActiteTime == 0)
            {
                response.Error = ErrorCode.ERR_Union_NotKeJi;
                return;
            }

            int keijiId = dBUnionInfo.UnionInfo.UnionKeJiList[dBUnionInfo.UnionInfo.KeJiActitePos];
            UnionKeJiConfig unionKeJiConfig = UnionKeJiConfigCategory.Instance.Get(keijiId);
            if (unionKeJiConfig.NextID == 0)
            {
                response.Error = ErrorCode.ERR_Union_NotKeJi;
                return;
            }

            int cost = UnionHelper.CalcuNeedeForAccele(dBUnionInfo.UnionInfo.KeJiActiteTime, unionKeJiConfig.NeedTime);
            
            if (unit.GetComponent<UserInfoComponentS>().UserInfo.Diamond <=cost)
            {
                response.Error = ErrorCode.ERR_DiamondNotEnoughError;

                return;
            }

            ////需要向游戏服发送协议扣除钻石
            // M2U_UnionKeJiQuickRequest r2M_RechargeRequest = M2U_UnionKeJiQuickRequest.Create();
            // r2M_RechargeRequest.Cost = cost;
            // U2M_UnionKeJiQuickResponse m2G_RechargeResponse = (U2M_UnionKeJiQuickResponse)await unit.Root().GetComponent<messagesender>().Call(unionactorid, r2M_RechargeRequest);
            // if (m2G_RechargeResponse.Error != ErrorCode.ERR_Success)
            // {
            //     response.Error = m2G_RechargeResponse.Error;
            //     return;
            // }
            unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneySub(UserDataType.Diamond, $"-{cost}", true, ItemGetWay.UnionXiuLian);
            
            dBUnionInfo.UnionInfo.UnionKeJiList[dBUnionInfo.UnionInfo.KeJiActitePos] = unionKeJiConfig.NextID;
            dBUnionInfo.UnionInfo.KeJiActitePos = -1;
            dBUnionInfo.UnionInfo.KeJiActiteTime = 0;
            response.UnionInfo = dBUnionInfo.UnionInfo;
            UnitCacheHelper.SaveComponent(unit.Root(),request.UnionId,  dBUnionInfo).Coroutine();
        }
    }
}
