using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class C2U_UnionKeJiQuickHandler : MessageHandler<Scene, C2U_UnionKeJiQuickRequest, U2C_UnionKeJiQuickResponse>
    {
        protected override async ETTask Run(Scene scene, C2U_UnionKeJiQuickRequest request, U2C_UnionKeJiQuickResponse response)
        {
            DBUnionInfo dBUnionInfo = await scene.GetComponent<UnionSceneComponent>().GetDBUnionInfo(request.UnionId);
            if (dBUnionInfo == null)
            {
                response.Error = ErrorCode.ERR_Union_Not_Exist;
                return;
            }

            if (dBUnionInfo.UnionInfo.KeJiActiteTime == 0)
            {
                response.Error = ErrorCode.ERR_Union_NotActive;
                return;
            }

            int keijiId = dBUnionInfo.UnionInfo.UnionKeJiList[dBUnionInfo.UnionInfo.KeJiActitePos];
            UnionKeJiConfig unionKeJiConfig = UnionKeJiConfigCategory.Instance.Get(keijiId);
            if (unionKeJiConfig.NextID == 0)
            {
                response.Error = ErrorCode.ERR_Union_NotActive;
                return;
            }

            int cost = UnionHelper.CalcuNeedeForAccele(dBUnionInfo.UnionInfo.KeJiActiteTime, unionKeJiConfig.NeedTime);
            
            ////需要向游戏服发送协议扣除钻石
            U2M_UnionKeJiQuickRequest r2M_RechargeRequest = U2M_UnionKeJiQuickRequest.Create();
            r2M_RechargeRequest.Cost = cost;
            M2U_UnionKeJiQuickResponse m2G_RechargeResponse = (M2U_UnionKeJiQuickResponse)await scene.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Call(request.ActorId, r2M_RechargeRequest);
            if (m2G_RechargeResponse.Error != ErrorCode.ERR_Success)
            {
                response.Error = m2G_RechargeResponse.Error;
                return;
            }

            dBUnionInfo.UnionInfo.UnionKeJiList[dBUnionInfo.UnionInfo.KeJiActitePos] = unionKeJiConfig.NextID;
            dBUnionInfo.UnionInfo.KeJiActitePos = -1;
            dBUnionInfo.UnionInfo.KeJiActiteTime = 0;
            response.UnionInfo = dBUnionInfo.UnionInfo;
            UnitCacheHelper.SaveComponentCache(scene.Root(), dBUnionInfo).Coroutine();
        }
    }
}
