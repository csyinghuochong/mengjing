using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class C2U_UnionKickOutHandler : MessageHandler<Scene, C2U_UnionKickOutRequest, U2C_UnionKickOutResponse>
    {
        protected override async ETTask Run(Scene scene, C2U_UnionKickOutRequest request, U2C_UnionKickOutResponse response)
        {
            DBUnionInfo dBUnionInfo =await scene.GetComponent<UnionSceneComponent>().GetDBUnionInfo(request.UnionId);
            if (dBUnionInfo == null)
            {
                return;
            }
            
            //1212275342967491 欧阳 18319670288
            //1212275342967491 寒桑 tcg01   被踢的玩家
            
            //通知玩家
            U2M_UnionKickOutRequest r2M_RechargeRequest = U2M_UnionKickOutRequest.Create();
            r2M_RechargeRequest.UserId = request.UserId;

            MessageLocationSenderOneType messageLocationSender = scene.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit);
            //1212275342967491 寒桑 tcg01   被踢的玩家

            M2U_UnionKickOutResponse m2G_RechargeResponse = (M2U_UnionKickOutResponse)await messageLocationSender.Call(request.UserId, r2M_RechargeRequest);

            if (m2G_RechargeResponse.Error != ErrorCode.ERR_Success)
            {
                NumericComponentS numericComponent = await UnitCacheHelper.GetComponentCache<NumericComponentS>(scene.Root(), request.UserId);
                numericComponent.ApplyValue(NumericType.UnionId_0, 0, false);
                await UnitCacheHelper.SaveComponentCache(scene.Root(), numericComponent);
                
                UserInfoComponentS userInfoComponent = await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(scene.Root(), request.UserId);
                UserInfo unionInfoCache = userInfoComponent.ChildrenDB[0] as UserInfo;
                unionInfoCache.UnionName = string.Empty;
                await UnitCacheHelper.SaveComponentCache(scene.Root(), userInfoComponent);
            }
            else
            {
                for (int i = dBUnionInfo.UnionInfo.UnionPlayerList.Count -1; i >= 0; i--)
                {
                    if (dBUnionInfo.UnionInfo.UnionPlayerList[i].UserID == request.UserId)
                    {
                        dBUnionInfo.UnionInfo.UnionPlayerList.RemoveAt(i);
                    }
                }
            }
            
            UnitCacheHelper.SaveComponent(scene.Root(),dBUnionInfo.Id,  dBUnionInfo).Coroutine();
        }
    }
}
